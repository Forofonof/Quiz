using Tools.SceneLoader;

namespace UI.Loading
{
    public sealed class LoadingScreen
    {
        private readonly AsyncLoader _asyncLoader;
        
        public LoadingScreen(AsyncLoader asyncLoader)
        {
            _asyncLoader = asyncLoader;
        }

        public void Init(string sceneName)
        {
            _asyncLoader.LoadSceneAsync(sceneName);
        }
    }
}