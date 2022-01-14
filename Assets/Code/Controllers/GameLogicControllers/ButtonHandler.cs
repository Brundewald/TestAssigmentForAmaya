using UnityEngine;
using UnityEngine.UI;

namespace TestProject
{
    public sealed class ButtonHandler: IInitialization, ICleanup
    {
        private readonly GameStateHandler _gameStateHandler;
        private readonly Button _resetButton;

        public ButtonHandler(UIInitializeHandler uiInitializeHandler, GameStateHandler gameStateHandler)
        {
            _gameStateHandler = gameStateHandler;
            _resetButton = uiInitializeHandler.GameScreenView.ResetButton;
        }

        public void Initialize()
        {
            AddSubscriptions();
        }

        public void Cleanup()
        {
            RemoveSubscriptions();
        }

        private void RemoveSubscriptions()
        {
            _resetButton.onClick.RemoveAllListeners();
        }

        private void AddSubscriptions()
        {
            _resetButton.onClick.AddListener(ResetLevel);
        }

        private void ResetLevel()
        {
            SetGame();
        }

        private void SetGame()
        {
            _gameStateHandler.SwitchState(GameState.Restart);
        }
    }
}