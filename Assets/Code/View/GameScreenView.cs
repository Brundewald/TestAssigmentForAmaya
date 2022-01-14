using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TestProject
{
    public sealed class GameScreenView: MonoBehaviour
    {
        [SerializeField] private Button _resetButton;
        [SerializeField] private TextMeshProUGUI _taskTextField;
        [SerializeField] private GameObject _tabletHolder;
        [SerializeField] private Transform[] _tabletPositions;
        [SerializeField] private CanvasGroup _gameScreenCanvasGroup;
        [SerializeField] private CanvasGroup _tabletHolderCanvasGroup;
        [SerializeField] private CanvasGroup _textFieldCanvasGroup;
        
        public Button ResetButton => _resetButton;
        public TextMeshProUGUI TaskTextField => _taskTextField;
        public GameObject TabletHolder => _tabletHolder;
        public Transform[] TabletPositons => _tabletPositions;
        public CanvasGroup GameScreenCanvasGroup => _gameScreenCanvasGroup;
        public CanvasGroup TabletHolderCanvasGroup => _tabletHolderCanvasGroup;
        public CanvasGroup TextFieldCanvasGroup => _textFieldCanvasGroup;
    }
}