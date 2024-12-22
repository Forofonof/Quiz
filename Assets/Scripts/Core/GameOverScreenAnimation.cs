using DG.Tweening;
using UnityEngine.UI;

namespace Core
{
    public sealed class GameOverScreenAnimation
    {
        public void StartFadeInOut(Image screen)
        {
            screen.gameObject.SetActive(true);
            screen.DOFade(0, 0);
            screen.DOFade(0.8f, 0.5f).SetLoops(2, LoopType.Yoyo);
        }
    }
}