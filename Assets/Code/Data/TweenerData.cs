using UnityEngine;

namespace TestProject
{
    [CreateAssetMenu(menuName = "Data/TweenerData", fileName = "TweenerData")]
    public class TweenerData: ScriptableObject
    {
        [SerializeField] private float _fadeTweenDuration;
        [SerializeField] private float _fadeToMin;
        [SerializeField] private float _fadeToMax;
        [SerializeField] private float _shakeDuration;
        [SerializeField] private float _shakeStrength;
        [SerializeField] private Vector3 _wrongAnswerShakeDirection;
        [SerializeField] private Vector3 _rightAnswerShakeDirection;

        public float FadeDuration => _fadeTweenDuration;
        public float FadeToMin => _fadeToMin;
        public float FadeToMax => _fadeToMax;

        public float ShakeDuration => _shakeDuration;
        public float ShakeStrength => _shakeStrength;
        public Vector3 WrongAnswerShakeDirection => _wrongAnswerShakeDirection;
        public Vector3 RightAnswerShakeDirection => _rightAnswerShakeDirection;

    }
}