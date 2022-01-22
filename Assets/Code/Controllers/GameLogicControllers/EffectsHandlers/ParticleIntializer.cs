using UnityEngine;

namespace TestProject
{
    internal sealed class ParticleIntializer
    {
        private readonly GameObject _particleSystemPrefab;
        private readonly GameObject _gameScreen;
        private ParticleSystem _particleSystem;
        private GameObject _particleSystemGameObject;

        internal ParticleIntializer(GameData gameData, UIInitializeHandler uiInitializeHandler)
        {
            _particleSystemPrefab = gameData.TaskData.ParticleSystem;
            _gameScreen = uiInitializeHandler.GameScreenView.gameObject;
        }

        internal void Initialize()
        {
            if (_particleSystemGameObject == null)
            {
                var particleSystemGameObject = Object.Instantiate(_particleSystemPrefab);
                var parentTransform = _gameScreen.transform;
                particleSystemGameObject.transform.SetParent(parentTransform);
                _particleSystem = particleSystemGameObject.GetComponent<ParticleSystem>();
                _particleSystemGameObject = particleSystemGameObject;
            }
        }

        internal void PlayParticleEffect(Transform transform)
        {
            _particleSystemGameObject.transform.position = transform.position;
            _particleSystem.Play();
        }
    }
}