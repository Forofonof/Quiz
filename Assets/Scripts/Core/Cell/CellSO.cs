using UnityEngine;

namespace Core.Cell
{
    [CreateAssetMenu(fileName = "Cell", menuName = "Quiz/CellSO")]
    public sealed class CellSO : ScriptableObject
    {
        [SerializeField] private Sprite _cellIcon;
        [SerializeField] private string _cellName;
        [SerializeField] private bool _isCorrect;
        
        public Sprite GetCellIcon() => _cellIcon;
        public string GetCellName() => _cellName;
        public bool IsCorrect => _isCorrect;
        
        public void SetCorrect(bool value)
        {
            _isCorrect = value;
        }
    }
}