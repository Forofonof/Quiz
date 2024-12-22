using Core;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public sealed class GameOverScreen
    {
        [Inject(Id = "_restartButton")] private Button _restartButton;
        [Inject(Id = "_restartScreen")] private Image _restartScreen;
        [Inject] private QuizGame _quizGame;

        public void Initialize()
        {
            _quizGame.OnEndGameSession += ActiveButton;
        }
        
        public void DeactivateButton()
        {
            _restartButton.gameObject.SetActive(false);
        }

        private void ActiveButton()
        {
            _restartButton.gameObject.SetActive(true);
        }
    }
}