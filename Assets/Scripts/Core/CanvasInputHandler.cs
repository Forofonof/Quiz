using UnityEngine.UI;
using Zenject;

namespace Core
{
    public class CanvasInputHandler
    {
        [Inject(Id = "_gameplayCanvas")] private GraphicRaycaster _gameplayCanvas;
        [Inject] private QuizGame _quizGame;

        public void Initialize()
        {
            _quizGame.OnEndGameSession += DisableRaycasterGameplay;
        }
        
        public void EnableRaycasterGameplay()
        {
            _gameplayCanvas.enabled = true;
        }

        private void DisableRaycasterGameplay()
        {
            _gameplayCanvas.enabled = false;
        }
    }
}