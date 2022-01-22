using System;
using DG.Tweening;
using UnityEngine;

namespace TestProject
{
    internal sealed class CriteriaCheckEventHandler: IInitialization, ICleanup
    {
        private readonly CriteriaCheckHandler _criteriaCheckHandler;
        private readonly TweenAnimationHandler _tweenAnimationHandler;
        private readonly ParticleIntializer _particleSystem;

        internal event Action OnRightAnswer;
        
        internal CriteriaCheckEventHandler(CriteriaCheckHandler criteriaCheckHandler,
            TweenAnimationHandler tweenAnimationHandler, ParticleIntializer particleIntializer)
        {
            _criteriaCheckHandler = criteriaCheckHandler;
            _tweenAnimationHandler = tweenAnimationHandler;
            _particleSystem = particleIntializer;
        }

        public void Initialize()
        {
            _criteriaCheckHandler.OnCriteriaMatch += RightAnswerEffects;
            _criteriaCheckHandler.OnCriteriaMismatch += WrongAnswerEffects;
        }

        public void Cleanup()
        {
            _criteriaCheckHandler.OnCriteriaMatch -= RightAnswerEffects;
            _criteriaCheckHandler.OnCriteriaMismatch -= WrongAnswerEffects;
        }

        private void RightAnswerEffects(Transform targetTransform)
        {
            var sequence = DOTween.Sequence();
            sequence.AppendCallback(()=>
            {
                _particleSystem.PlayParticleEffect(targetTransform);
            });
            sequence.Append(_tweenAnimationHandler.DoRightAnswerShake(targetTransform));
            sequence.AppendCallback(() =>
            {
                OnRightAnswer?.Invoke();
            });
        }

        private void WrongAnswerEffects(Transform targetTransform)
        {
            var sequence = DOTween.Sequence();
            sequence.Append(_tweenAnimationHandler.DoWrongAnswerShake(targetTransform));
        }
    }
}