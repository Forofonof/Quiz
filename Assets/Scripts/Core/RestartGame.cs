using System;
using Core.Cell;
using UnityEngine.UI;
using Zenject;

namespace Core
{
    public sealed class RestartGame
    {
        [Inject(Id = "_restartButton")] private Button _restartButton;
        [Inject(Id = "_restartScreen")] private Image _restartScreen;
        [Inject] private CanvasInputHandler _canvasInputHandler;
        [Inject] private CellElementParticles _cellElementParticles;
        [Inject] private CellSpawner _cellSpawner;
        [Inject] private QuizGame _quizGame;

        private readonly GameOverScreenAnimation _animation = new GameOverScreenAnimation();

        public event Action OnRestartGame;

        public void Initialize()
        {
            _restartButton.onClick.AddListener(Restart);
        }

        private void Restart()
        {
            _cellElementParticles.StopParticles();
            _animation.StartFadeInOut(_restartScreen);
            _canvasInputHandler.EnableRaycasterGameplay();
            _cellSpawner.DestroyCells();
            _quizGame.ResetGame();
            OnRestartGame?.Invoke();
        }
    }
}