using UnityEngine;

namespace TestProject
{
    public sealed class UIInitializeHandler
    {
        private readonly GameObject _gameScreenPrefab;
        private GameScreenView _gameScreenView;

        public GameScreenView GameScreenView => _gameScreenView;
        public UIInitializeHandler(GameData gameData)
        {
            _gameScreenPrefab = gameData.UIData.GameScreenPrefab;
            GetUI();
        }

        private GameObject GetUI()
        {
            var gameScreen = Object.Instantiate(_gameScreenPrefab);
            _gameScreenView = gameScreen.GetComponent<GameScreenView>();
            return gameScreen;
        }
    }
}