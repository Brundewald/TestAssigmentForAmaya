using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace TestProject
{
    internal sealed class PlayScreenHandler
    {
        private const int Zero = 0;
        private readonly SetSceneHander _setSceneHander;
        private readonly GameObject _tabletHolder;
        private readonly Button _resetButton;
        private bool _anim;

        public PlayScreenHandler(UIInitializeHandler uiInitializeHandler, PlayStateHandler playStateHandler)
        {
            _resetButton = uiInitializeHandler.GameScreenView.ResetButton;
            _tabletHolder = uiInitializeHandler.GameScreenView.TabletHolder;
            _setSceneHander = playStateHandler.SetSceneHander;
        }

        internal void SetScreen()
        {
            var sequence = DOTween.Sequence();
            sequence.AppendCallback(() =>
            {
                _resetButton.gameObject.SetActive(false);
                _tabletHolder.SetActive(true);
            });
            sequence.AppendCallback(() => _setSceneHander.SetTablets(Zero));
        }
    }
}