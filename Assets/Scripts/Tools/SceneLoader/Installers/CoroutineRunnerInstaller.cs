using UnityEngine;
using Zenject;

namespace Tools.SceneLoader.Installers
{
    public sealed class CoroutineRunnerInstaller : MonoInstaller
    {
        [SerializeField] private CoroutineRunner _coroutineRunner;

        public override void InstallBindings()
        {
            Container.Bind<CoroutineRunner>()
                     .FromInstance(_coroutineRunner)
                     .AsSingle()
                     .NonLazy();
        }
    }
}