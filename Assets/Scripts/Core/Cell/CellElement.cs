using Core.Answer;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Core.Cell
{
    public sealed class CellElement : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private Image _icon;
        [SerializeField] private Image _background;
        [SerializeField] private Button _actionButton;
        [Header("Data")]
        [SerializeField] private CellSO _cellData;
        
        private readonly CellElementAnimation _animation = new CellElementAnimation();

        [Inject] private ResponsesHandler _responsesHandler;
        [Inject] private CellElementParticles _particles;

        private void OnEnable()
        {
            _actionButton.onClick.AddListener(OnActionButtonClick);
            _responsesHandler.OnCorrectAnswerSelected += HandleCorrectAnswer;
            _responsesHandler.OnIncorrectAnswerSelected += HandleIncorrectAnswer;
        }

        public void Initialize(CellSO cellData)
        {
            _cellData = cellData;
            _icon.sprite = cellData.GetCellIcon();
        }

        private void OnActionButtonClick()
        {
            if (_cellData == null) return;
            
            _responsesHandler.HandleCellSelection(_cellData);
        }

        private void HandleCorrectAnswer(CellSO cell)
        {
            if (cell != _cellData) return;
            
            _animation.StartBounce(_icon);
            _particles.PlayParticles(transform.position);
        }

        private void HandleIncorrectAnswer(CellSO cell)
        {
            if (cell != _cellData) return;
            
            _animation.StartShake(_icon);
        }

        private void OnDisable()
        {
            _actionButton.onClick.RemoveListener(OnActionButtonClick);
            _responsesHandler.OnCorrectAnswerSelected -= HandleCorrectAnswer;
            _responsesHandler.OnIncorrectAnswerSelected -= HandleIncorrectAnswer;
        }

        private void OnDestroy()
        {
            _icon?.transform.DOKill();
        }
    }
}