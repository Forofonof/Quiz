using UnityEngine;

namespace Core.Cell.Factory
{
    public interface ICellFactory
    {
        GameObject CreateCell(CellSO cellData, Transform parent);
    }
}