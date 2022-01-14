using UnityEngine;

namespace TestProject
{
    public sealed class ParticalIntializer
    {
        private readonly GameObject _particleSystemPrefab;
        private ParticleSystem _particleSystem;
        private GameObject _particleSystemGameObject;
        private GameObject _gameScreen;
        
        public ParticalIntializer(GameData gameData, UIInitializeHandler uiInitializeHandler)
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