using DG.Tweening;
using TMPro;

namespace Core.Answer
{
    public sealed class TaskViewerAnimation
    {
        public void StartFadeIn(TMP_Text text)
        {
            text.DOFade(0, 0);
            text.DOFade(1, 0.5f);
        }
    }
}