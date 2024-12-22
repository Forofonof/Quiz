using System;
using System.Collections.Generic;
using Core.Cell;
using Random = UnityEngine.Random;

namespace Core.Answer
{
    public sealed class ResponsesHandler
    {
        public event Action<CellSO> OnCorrectAnswerSelected;
        public event Action<CellSO> OnIncorrectAnswerSelected;
        public event Action<string> OnNewTaskGenerated;

        public void HandleCellSelection(CellSO selectedCell)
        {
            if (selectedCell.IsCorrect)
            {
                OnCorrectAnswerSelected?.Invoke(selectedCell);
            }
            else
            {
                OnIncorrectAnswerSelected?.Invoke(selectedCell);
            }
        }

        public void AssignCorrectCell(List<CellSO> cells, HashSet<CellSO> usedCells)
        {
            List<CellSO> availableCells = cells.FindAll(cell => !usedCells.Contains(cell));
            var correctCell = availableCells[Random.Range(0, availableCells.Count)];
            
            correctCell.SetCorrect(true);
            usedCells.Add(correctCell);

            OnNewTaskGenerated?.Invoke(correctCell.GetCellName());
        }
    }
}