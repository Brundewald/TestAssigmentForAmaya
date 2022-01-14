using UnityEngine;

namespace TestProject
{
    [CreateAssetMenu(menuName = "Data/UIData", fileName = "UIData")]
    public sealed class UIData: ScriptableObject
    {
        private const string _taskText = "Find: ";
        private const string _finalText = "Hooray! You did it!\n\r Now press 'Restart'";
        
        [SerializeField] private GameObject _gameScreenPrefab;
        public GameObject GameScreenPrefab => _gameScreenPrefab;
        public string TaskText => _taskText;
        public string FinalText => _finalText;
    }
}