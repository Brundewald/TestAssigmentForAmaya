using DG.Tweening;
using UnityEngine;

namespace TestProject
{
    internal sealed class ShakeHandler
    {
        private TweenerData _tweenerData;
        
        internal ShakeHandler(GameData gameData)
        {
            _tweenerData = gameData.TweenerData;
        }

        internal Tween AppearBounce(Transform transform)
        {
            return transform.DOShakeScale(_tweenerData.ShakeDuration, _tweenerData.ShakeStrength).SetEase(Ease.InBounce);
        }
        internal Tween WrongAnswerBounce(Transform transform)
        {
            return transform.DOShakePosition(_tweenerData.ShakeDuration, _tweenerData.WrongAnswerShakeDirection).SetEase(Ease.InBounce);
        }

        internal Tween RightAnswerBounce(Transform transform)
        {
            return transform.DOShakePosition(_tweenerData.ShakeDuration, _tweenerData.RightAnswerShakeDirection).SetEase(Ease.InBounce);
        }
    }
}