using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TestProject
{
    internal sealed class GameScreenView: MonoBehaviour
    {
        [SerializeField] private Button _resetButton;
        [SerializeField] private TextMeshProUGUI _taskTextField;
        [SerializeField] private GameObject _tabletHolder;
        [SerializeField] private Transform[] _tabletPositions;
        [SerializeField] private CanvasGroup _gameScreenCanvasGroup;
        [SerializeField] private CanvasGroup _tabletHolderCanvasGroup;
        [SerializeField] private CanvasGroup _textFieldCanvasGroup;
        
        internal Button ResetButton => _resetButton;
        internal TextMeshProUGUI TaskTextField => _taskTextField;
        internal GameObject TabletHolder => _tabletHolder;
        internal Transform[] TabletPositons => _tabletPositions;
        internal CanvasGroup GameScreenCanvasGroup => _gameScreenCanvasGroup;
        internal CanvasGroup TabletHolderCanvasGroup => _tabletHolderCanvasGroup;
        internal CanvasGroup TextFieldCanvasGroup => _textFieldCanvasGroup;
    }
}