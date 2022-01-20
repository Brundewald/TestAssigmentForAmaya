using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace TestProject
{
    internal sealed class PlayScreenHandler
    {
        private const int Easy = 0;
        private readonly SetSceneHandler _setSceneHandler;
        private readonly GameObject _tabletHolder;
        private readonly Button _resetButton;

        public PlayScreenHandler(UIInitializeHandler uiInitializeHandler, PlayStateHandler playStateHandler)
        {
            _resetButton = uiInitializeHandler.GameScreenView.ResetButton;
            _tabletHolder = uiInitializeHandler.GameScreenView.TabletHolder;
            _setSceneHandler = playStateHandler.SetSceneHandler;
        }

        internal void SetScreen()
        {
            var sequence = DOTween.Sequence();
            sequence.AppendCallback(() =>
            {
                _resetButton.gameObject.SetActive(false);
                _tabletHolder.SetActive(true);
            });
            sequence.AppendCallback(() => _setSceneHandler.SetScreen(Easy));
        }
    }
}