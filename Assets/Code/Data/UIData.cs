using UnityEngine;

namespace TestProject
{
    [CreateAssetMenu(menuName = "Data/UIData", fileName = "UIData")]
    internal sealed class UIData: ScriptableObject
    {
        private const string _taskText = "Find: ";
        private const string _finalText = "Hooray! You did it!\n\r Now press 'Restart'";
        
        [SerializeField] private GameObject _gameScreenPrefab;
        internal GameObject GameScreenPrefab => _gameScreenPrefab;
        internal string TaskText => _taskText;
        internal string FinalText => _finalText;
    }
}