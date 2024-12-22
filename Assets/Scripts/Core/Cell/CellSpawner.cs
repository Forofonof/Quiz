using System.Collections.Generic;
using Core.Answer;
using Core.Cell.Factory;
using UnityEngine;
using Zenject;

namespace Core.Cell
{
    public sealed class CellSpawner
    {
        private readonly List<GameObject> _spawnedCells = new List<GameObject>();
        
        [Inject] private ICellFactory _cellFactory;
        [Inject(Id = "SpawnParent")] private Transform _spawnParent;
        [Inject] private CellRandomizer _cellRandomizer;
        [Inject] private ResponsesHandler _responsesHandler;
        [Inject] private List<CellSO> _cells;

        public void CreateCells(int count, HashSet<CellSO> usedCells)
        {
            if (usedCells.Count >= _cells.Count)
            {
                usedCells.Clear();
            }
            
            List<CellSO> randomizedCells = _cellRandomizer.GetRandomizedCells(count, usedCells);
            
            foreach (CellSO cellData in randomizedCells)
            {
                GameObject cell = _cellFactory.CreateCell(cellData, _spawnParent);
                _spawnedCells.Add(cell);
            }
            
            _responsesHandler.AssignCorrectCell(randomizedCells, usedCells);
        }
        
        public void RestartCells(int count, HashSet<CellSO> usedCells)
        {
            DestroyCells();
            CreateCells(count, usedCells);
        }

        public void DestroyCells()
        {
            foreach (GameObject cell in _spawnedCells)
            {
                if (cell == null) continue;
                
                Object.Destroy(cell);
            }
            
            _spawnedCells.Clear();
        }
    }
}