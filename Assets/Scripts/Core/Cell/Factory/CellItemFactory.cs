using UnityEngine;
using Zenject;

namespace Core.Cell.Factory
{
    public sealed class CellItemFactory : ICellFactory
    {
        private readonly DiContainer _container;
        private readonly GameObject _cellPrefab;

        public CellItemFactory(GameObject cellPrefab, DiContainer container)
        {
            _cellPrefab = cellPrefab;
            _container = container;
        }

        public GameObject CreateCell(CellSO cellData, Transform parent)
        {
            CellElement cellElement = _container.InstantiatePrefabForComponent<CellElement>(_cellPrefab, parent);
            
            cellElement.Initialize(cellData);

            return cellElement.gameObject;
        }
    }

}