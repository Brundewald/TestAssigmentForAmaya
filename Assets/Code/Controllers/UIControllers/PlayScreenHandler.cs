using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace TestProject
{
    internal sealed class PlayScreenHandler
    {
        private readonly TweenAnimationHandler _tweenAnimationHandler;
        private SetSceneHander _setSceneHander;
        private GameObject _tabletHolder;
        private Button _resetButton;
        private bool _anim;

        public PlayScreenHandler(UIInitializeHandler uiInitializeHandler,
            TweenAnimationHandler tweenAnimationHandler, PlayStateHandler playStateHandler)
        {
            _resetButton = uiInitializeHandler.GameScreenView.ResetButton;
            _tabletHolder = uiInitializeHandler.GameScreenView.TabletHolder;
            _tweenAnimationHandler = tweenAnimationHandler;
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
            sequence.AppendCallback(() => _setSceneHander.SetTablets(0));
        }
    }
}