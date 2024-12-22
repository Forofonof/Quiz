using UnityEngine;
using Zenject;

namespace Core.Cell
{
    public sealed class CellElementParticles
    {
        [Inject(Id = "Particle")]
        private ParticleSystem _particle;

        public void PlayParticles(Vector3 position)
        {
            _particle.transform.position = position;
            _particle.Play();
        }

        public void StopParticles()
        {
            _particle.Clear();
            _particle.Stop();
        }
    }
}