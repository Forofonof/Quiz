using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Cell
{
    public sealed class CellElementAnimation
    {
        public void StartShake(Image icon)
        {
            icon.transform.DOKill();
            icon.transform.DOShakePosition(0.5f, new Vector3(10f, 0, 0));
        }

        public void StartBounce(Image icon)
        {
            icon.transform.DOKill();
            
            icon.transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 0.5f)
                          .SetEase(Ease.OutBounce)
                          .OnComplete(() => icon.transform.DOScale(Vector3.one, 0.5f));
        }
    }
}