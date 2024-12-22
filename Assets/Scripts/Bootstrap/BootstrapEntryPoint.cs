using Tools.SceneLoader;
using UI.Loading;
using Zenject;

namespace Bootstrap
{
    public sealed class BootstrapEntryPoint : IInitializable
    {
        private readonly LoadingScreen _loadingScreen;
        private readonly NextSceneHandler _nextSceneHandler;

        public BootstrapEntryPoint(LoadingScreen loadingScreen, NextSceneHandler nextSceneHandler)
        {
            _loadingScreen = loadingScreen;
            _nextSceneHandler = nextSceneHandler;
        }
        
        public void Initialize()
        {
            InitScene();
        }
        
        private void InitScene()
        {
            _loadingScreen.Init(_nextSceneHandler.GetScene());
        }
    }
}