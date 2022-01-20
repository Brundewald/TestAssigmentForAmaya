using DG.Tweening;
using UnityEngine;

namespace TestProject
{
    public sealed class TouchEffectsHandler: IInitialization, ICleanup
    {
        private readonly SetSceneHander _setSceneHander;
        private readonly CriteriaCheckHandler _criteriaCheckHandler;
        private readonly TweenAnimationHandler _tweenAnimationHandler;
        private readonly ParticalIntializer _particalSystem;
        
        public TouchEffectsHandler(SetSceneHander setSceneHander, CriteriaCheckHandler criteriaCheckHandler,
            TweenAnimationHandler tweenAnimationHandler, ParticalIntializer particalIntializer)
        {
            _setSceneHander = setSceneHander;
            _criteriaCheckHandler = criteriaCheckHandler;
            _tweenAnimationHandler = tweenAnimationHandler;
            _particalSystem = particalIntializer;
        }

        public void Initialize()
        {
            _criteriaCheckHandler.OnCriteriaMatch += RightAnswerEffects;
            _criteriaCheckHandler.OnCriteriaDismatch += WrongAnswerEffects;
        }

        public void Cleanup()
        {
            _criteriaCheckHandler.OnCriteriaMatch -= RightAnswerEffects;
            _criteriaCheckHandler.OnCriteriaDismatch -= WrongAnswerEffects;
        }

        private void RightAnswerEffects(Transform targetTransform)
        {
            var sequence = DOTween.Sequence();
            sequence.AppendCallback(()=>
            {
                _particalSystem.PlayParticleEffect(targetTransform);
            });
            sequence.Append(_tweenAnimationHandler.DoRightAnswerShake(targetTransform));
            sequence.AppendCallback((() =>
            {
                _setSceneHander.MoveNext();
            }));
        }

        private void WrongAnswerEffects(Transform targetTransform)
        {
            var sequence = DOTween.Sequence();

            sequence.Append(_tweenAnimationHandler.DoWrongAnswerShake(targetTransform));
        }
    }
}