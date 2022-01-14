using UnityEngine;

namespace TestProject
{
    public sealed class EnterPointView : MonoBehaviour
    {
        [SerializeField] private GameData _gameData;
        private ControllersProxy _controllers;

        private void Awake()
        {
            _controllers = new ControllersProxy();
            new InitializationHandler(_controllers, _gameData);
        }
        private void Start()
        {
            _controllers.Initialize();
        }

        private void Update()
        {
            _controllers.Execute(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            _controllers.Execute(Time.fixedDeltaTime);
        }

        private void OnDestroy()
        {
            _controllers.Cleanup();
        }
    }   
}
