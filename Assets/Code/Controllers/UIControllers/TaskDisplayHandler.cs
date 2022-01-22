using TMPro;

namespace TestProject
{
    internal sealed class TaskDisplayHandler
    {
        private readonly string _text;
        private readonly TextMeshProUGUI _textField;

        internal TaskDisplayHandler(UIInitializeHandler uiInitializeHandler, GameData gameData)
        {
            _textField = uiInitializeHandler.GameScreenView.TaskTextField;
            _text = gameData.UIData.TaskText;
        }

        internal void ShowTask(string tabletName)
        {
            _textField.text = _text + tabletName;
        }
    }
}