using DG.Tweening;
using UnityEngine;

namespace TestProject
{
    internal sealed class FadeInFadeOutHandler
    {
        private readonly TweenerData _tweenerData;
        
        internal FadeInFadeOutHandler(GameData gameData)
        {
            _tweenerData = gameData.TweenerData;
        }
        
        internal Tween FadeIn(CanvasGroup canvasGroup)
        {
            return canvasGroup.DOFade(_tweenerData.FadeToMax, _tweenerData.FadeDuration);
        }

        internal Tween FadeOut(CanvasGroup canvasGroup)
        {
            return canvasGroup.DOFade(_tweenerData.FadeToMin, _tweenerData.FadeDuration);
        }
    }
}