using Core.Answer;
using Core.Cell;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Core.Installers
{
    public class CoreInstallers : MonoInstaller
    {
        [Header("Text")]
        [SerializeField] private TMP_Text _labelText;
        [Header("Screen")]
        [SerializeField] private Button _restartButton;
        [SerializeField] private Image _restartScreen;
        [SerializeField] private GraphicRaycaster _gameplayCanvas;
        
        public override void InstallBindings()
        {
            Container.Bind<QuizGame>().AsSingle();
            Container.Bind<TaskViewer>().AsSingle();
            Container.Bind<ResponsesHandler>().AsSingle();
            Container.Bind<CellRandomizer>().AsSingle();
            Container.Bind<RestartGame>().AsSingle();
            Container.Bind<GameOverScreen>().AsSingle();
            Container.Bind<CanvasInputHandler>().AsSingle();

            BindComponents();
        }

        private void BindComponents()
        {
            Container.BindInstance(_labelText).WithId("_labelText").AsSingle();
            Container.BindInstance(_restartButton).WithId("_restartButton").AsSingle();
            Container.BindInstance(_restartScreen).WithId("_restartScreen").AsSingle();
            Container.BindInstance(_gameplayCanvas).WithId("_gameplayCanvas").AsSingle();
        }
    }
}