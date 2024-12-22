using Tools.SceneLoader;
using UI.Loading;
using Zenject;

namespace Bootstrap.Installers
{
    public sealed class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindAsSingle<AsyncLoader>();
            BindAsSingle<NextSceneHandler>();
            BindAsSingle<LoadingScreen>();
            BindInterFaces<BootstrapEntryPoint>();
        }
        
        private void BindAsSingle<T>()
        {
            Container.Bind<T>()
                     .AsSingle();
        }

        private void BindInterFaces<T>()
        {
            Container.BindInterfacesAndSelfTo<T>()
                     .AsSingle();
        }
    }
}