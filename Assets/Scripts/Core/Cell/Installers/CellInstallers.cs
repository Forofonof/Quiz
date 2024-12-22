using Core.Cell.Factory;
using UnityEngine;
using Zenject;

namespace Core.Cell.Installers
{
    public sealed class CellInstallers : MonoInstaller
    {
        [Header("Cell References")]
        [SerializeField] private GameObject _cellPrefab;
        [SerializeField] private Transform _spawnParent;
        
        public override void InstallBindings()
        {
            Container.Bind<CellSpawner>().AsSingle();
            Container.Bind<Transform>().WithId("SpawnParent").FromInstance(_spawnParent).AsSingle();
            Container.Bind<ICellFactory>().To<CellItemFactory>().AsTransient().WithArguments(_cellPrefab);
        }
    }
}