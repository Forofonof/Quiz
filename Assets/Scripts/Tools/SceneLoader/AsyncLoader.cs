using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Tools.SceneLoader
{
    public sealed class AsyncLoader
    {
        private readonly CoroutineRunner _coroutineRunner;

        public AsyncLoader(CoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        public void LoadSceneAsync(string sceneName)
        {
            _coroutineRunner.RunCoroutine(LoadSceneCoroutine(sceneName));
        }

        private IEnumerator LoadSceneCoroutine(string sceneName)
        {
            var loadOperation = SceneManager.LoadSceneAsync(sceneName);
            loadOperation.allowSceneActivation = false;

            yield return HandleRealLoading(loadOperation);

            loadOperation.allowSceneActivation = true;
        }

        private IEnumerator HandleRealLoading(AsyncOperation loadOperation)
        {
            while (!loadOperation.isDone)
            {
                if (loadOperation.progress >= 0.9f)
                {
                    break;
                }

                yield return null;
            }
        }
    }
}