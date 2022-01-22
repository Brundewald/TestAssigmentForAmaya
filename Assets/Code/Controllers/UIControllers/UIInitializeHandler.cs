using UnityEngine;

namespace TestProject
{
    internal sealed class UIInitializeHandler
    {
        private readonly GameObject _gameScreenPrefab;
        private GameScreenView _gameScreenView;

        internal GameScreenView GameScreenView => _gameScreenView;
        internal UIInitializeHandler(GameData gameData)
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