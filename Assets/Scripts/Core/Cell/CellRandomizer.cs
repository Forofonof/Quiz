using System.Collections.Generic;
using Core.Answer;
using UnityEngine;
using Zenject;

namespace Core.Cell
{
    public sealed class CellRandomizer
    {
        [Inject] private ResponsesHandler _responsesHandler;
        [Inject] private TaskViewer _taskViewer;
        [Inject] private List<CellSO> _cells;

        public List<CellSO> GetRandomizedCells(int count, HashSet<CellSO> usedCells)
        {
            ResetCells(_cells);
            List<CellSO> availableCells = GetAvailableCells(usedCells);
            List<CellSO> shuffledCells = ShuffleCells(availableCells);

            return shuffledCells.GetRange(0, Mathf.Min(count, shuffledCells.Count));
        }

        private List<CellSO> GetAvailableCells(HashSet<CellSO> usedCells)
        {
            return _cells.FindAll(cell => !usedCells.Contains(cell));
        }

        private List<CellSO> ShuffleCells(List<CellSO> cells)
        {
            for (int i = cells.Count - 1; i > 0; i--)
            {
                int randomIndex = Random.Range(0, i + 1); 
                (cells[i], cells[randomIndex]) = (cells[randomIndex], cells[i]);
            }

            return cells;
        }

        private void ResetCells(List<CellSO> cells)
        {
            foreach (var cell in cells)
            {
                cell.SetCorrect(false);
            }
        }
    }
}