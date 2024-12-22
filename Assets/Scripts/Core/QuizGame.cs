using System;
using System.Collections.Generic;
using Core.Answer;
using Core.Cell;
using Core.ScriptableObjects;
using Zenject;

namespace Core
{
    public sealed class QuizGame
    {
        private readonly HashSet<CellSO> _usedCells = new HashSet<CellSO>();
        
        private int _currentRound;

        [Inject] private CellSpawner _cellSpawner;
        [Inject] private ResponsesHandler _responsesHandler;
        [Inject] private QuizRoundSettingSO _quizRoundSetting;

        public event Action OnEndGameSession;

        public void Initialize()
        {
            _responsesHandler.OnCorrectAnswerSelected += HandleCorrectAnswer;
            StartGame();
        }

        public void ResetGame()
        {
            _currentRound = 0;
            StartGame();
        }

        private void StartGame()
        {
            _currentRound = 1;
            _cellSpawner.CreateCells(_quizRoundSetting.StartNumberCells, _usedCells);
        }

        private void StartNewRound()
        {
            _currentRound++;

            if (_currentRound > _quizRoundSetting.TotalRounds)
            {
                EndGame();
                return;
            }

            int numberOfCells = _quizRoundSetting.StartNumberCells + (_quizRoundSetting.NumberCellsNewRound * (_currentRound - 1));
            _cellSpawner.RestartCells(numberOfCells, _usedCells);
        }

        private void HandleCorrectAnswer(CellSO correctCell)
        {
            StartNewRound();
        }

        private void EndGame()
        {
            OnEndGameSession?.Invoke();
        }
    }
}