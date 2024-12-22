using Core.Cell;
using UnityEngine;
using Zenject;

namespace Core.Installers
{
    public class EffectInstallers : MonoInstaller
    {
        [SerializeField] private ParticleSystem _particle;

        public override void InstallBindings()
        {
            Container.Bind<ParticleSystem>().WithId("Particle").FromInstance(_particle).AsSingle();
            Container.Bind<CellElementParticles>().AsSingle();
        }
    }

}