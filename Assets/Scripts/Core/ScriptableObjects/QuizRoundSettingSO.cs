using UnityEngine;

namespace Core.ScriptableObjects
{
    [CreateAssetMenu(fileName = "DifficultyQuiz", menuName = "Quiz/QuizRoundSettingSO")]
    public class QuizRoundSettingSO : ScriptableObject
    {
        [Header("Number of cells in the first round")]
        [SerializeField] private int _startNumberCells;
        [Header("Number of new cells each round")]
        [SerializeField] private int _numberCellsNewRound;
        [Header("Total number of rounds per session")]
        [SerializeField] private int _totalRounds;

        public int StartNumberCells => _startNumberCells;
        public int NumberCellsNewRound => _numberCellsNewRound;
        public int TotalRounds => _totalRounds;
    }
}