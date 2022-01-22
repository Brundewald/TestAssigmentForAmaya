using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TestProject
{
    internal class ResetScreenHandler
    {
        private readonly GameObject _tabletHolder;
        private readonly Button _resetButton;
        private readonly TextMeshProUGUI _textField;
        private readonly string _text;

        internal ResetScreenHandler(GameData gameData, UIInitializeHandler uiInitializeHandler)
        {
            _tabletHolder = uiInitializeHandler.GameScreenView.TabletHolder;
            _resetButton = uiInitializeHandler.GameScreenView.ResetButton;
            _textField = uiInitializeHandler.GameScreenView.TaskTextField;
            _text = gameData.UIData.FinalText;
        }

        internal void SetScreen()
        { 
            _tabletHolder.SetActive(false); 
            _resetButton.gameObject.SetActive(true);
            _textField.text = _text;
        }
    }
}