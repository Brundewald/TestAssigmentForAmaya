using DG.Tweening;
using UnityEngine.UI;

namespace TestProject
{
    public sealed class ReloadScreenHandler
    {
        private readonly TweenAnimationHandler _tweenAnimationHandler;
        private readonly GameStateHandler _gameStateHandler;
        private readonly Button _resetButton;
        
        public ReloadScreenHandler(TweenAnimationHandler tweenAnimationHandler, UIInitializeHandler uiInitializeHandler, GameStateHandler gameStateHandler)
        {
            _tweenAnimationHandler = tweenAnimationHandler;
            _gameStateHandler = gameStateHandler;
            _resetButton = uiInitializeHandler.GameScreenView.ResetButton;
        }

        internal void SetScreen()
        {
            var sequence = DOTween.Sequence();
            sequence.Append(_tweenAnimationHandler.DoGameScreenFadeOut());
            sequence.Insert(0, _tweenAnimationHandler.DoTextFieldFadeOut());
            sequence.AppendCallback((() =>
            {
                _resetButton.gameObject.SetActive(false);
            }));
            sequence.Append(_tweenAnimationHandler.DoGameScreenFadeIn());
            sequence.AppendCallback((() =>
            {
                _gameStateHandler.SwitchState(GameState.Play);
            }));
        }
    }
}