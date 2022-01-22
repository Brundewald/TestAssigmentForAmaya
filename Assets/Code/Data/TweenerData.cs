using UnityEngine;

namespace TestProject
{
    [CreateAssetMenu(menuName = "Data/TweenerData", fileName = "TweenerData")]
    internal class TweenerData: ScriptableObject
    {
        [SerializeField] private float _fadeTweenDuration;
        [SerializeField] private float _fadeToMin;
        [SerializeField] private float _fadeToMax;
        [SerializeField] private float _shakeDuration;
        [SerializeField] private float _shakeStrength;
        [SerializeField] private Vector3 _wrongAnswerShakeDirection;
        [SerializeField] private Vector3 _rightAnswerShakeDirection;

        internal float FadeDuration => _fadeTweenDuration;
        internal float FadeToMin => _fadeToMin;
        internal float FadeToMax => _fadeToMax;

        internal float ShakeDuration => _shakeDuration;
        internal float ShakeStrength => _shakeStrength;
        internal Vector3 WrongAnswerShakeDirection => _wrongAnswerShakeDirection;
        internal Vector3 RightAnswerShakeDirection => _rightAnswerShakeDirection;

    }
}