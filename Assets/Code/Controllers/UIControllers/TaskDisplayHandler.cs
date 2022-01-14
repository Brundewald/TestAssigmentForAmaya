using TMPro;

namespace TestProject
{
    public sealed class TaskDisplayHandler
    {
        private readonly string _text;
        private TextMeshProUGUI _textField;

        public TaskDisplayHandler(UIInitializeHandler uiInitializeHandler, GameData gameData)
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