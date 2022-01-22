using DG.Tweening;
using UnityEngine;

namespace TestProject
{
    internal sealed class TweenAnimationHandler
    {
        private readonly FadeInFadeOutHandler _fadeInFadeOutHandler;
        private readonly ShakeHandler _shakeHandler;
        private readonly CanvasGroup _gameScreenCanvasGroup;
        private readonly CanvasGroup _tabletHolderCanvasGroup;
        private readonly CanvasGroup _textFieldCanvasGroup;
        private readonly GameObject _tabletHolder;
        
        internal TweenAnimationHandler(GameData gameData, UIInitializeHandler uiInitializeHandler)
        {
            _fadeInFadeOutHandler = new FadeInFadeOutHandler(gameData);
            _shakeHandler = new ShakeHandler(gameData);

            _gameScreenCanvasGroup = uiInitializeHandler.GameScreenView.GameScreenCanvasGroup;
            _tabletHolderCanvasGroup = uiInitializeHandler.GameScreenView.TabletHolderCanvasGroup;
            _textFieldCanvasGroup = uiInitializeHandler.GameScreenView.TextFieldCanvasGroup;
            _tabletHolder = uiInitializeHandler.GameScreenView.TabletHolder;
        }

        internal Tween DoGameScreenFadeIn()
        {
            return _fadeInFadeOutHandler.FadeIn(_gameScreenCanvasGroup);
        }

        internal Tween DoGameScreenFadeOut()
        {
            return _fadeInFadeOutHandler.FadeOut(_gameScreenCanvasGroup);
        }

        internal Tween DoTabletHolderFadeIn()
        {
            return _fadeInFadeOutHandler.FadeIn(_tabletHolderCanvasGroup);
        }
        
        internal Tween DoTextFieldFadeIn()
        {
            return _fadeInFadeOutHandler.FadeIn(_textFieldCanvasGroup);
        }

        internal Tween DoTextFieldFadeOut()
        {
            return _fadeInFadeOutHandler.FadeOut(_textFieldCanvasGroup);
        }

        internal Tween DoAppearShake()
        {
            return _shakeHandler.AppearBounce(_tabletHolder.transform);
        }

        internal Tween DoRightAnswerShake(Transform transform)
        {
            return _shakeHandler.RightAnswerBounce(transform);
        }

        internal Tween DoWrongAnswerShake(Transform transform)
        {
            return _shakeHandler.WrongAnswerBounce(transform);
        }
    }
}