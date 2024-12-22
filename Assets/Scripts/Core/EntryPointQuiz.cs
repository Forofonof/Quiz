using Core.Answer;
using UI;
using UnityEngine;
using Zenject;

namespace Core
{
    public sealed class EntryPointQuiz : MonoBehaviour
    {
        [Inject] private QuizGame _quizGame;
        [Inject] private TaskViewer _taskViewer;
        [Inject] private RestartGame _restartGame;
        [Inject] private GameOverScreen _gameOverScreen;
        [Inject] private CanvasInputHandler _canvasInputHandler;
        
        private void Start()
        {
            _restartGame.OnRestartGame += RestartGame;
            _taskViewer.Initialize();
            _quizGame.Initialize();
            _restartGame.Initialize();
            _gameOverScreen.Initialize();
            _canvasInputHandler.Initialize();
        }

        private void RestartGame()
        {
            _gameOverScreen.DeactivateButton();
        }
    }
}