using DG.Tweening;
using UnityEngine.EventSystems;

namespace TestProject
{
    public sealed class CriteriaCheckHandler: IInitialization, ICleanup
    {
        private readonly SetSceneHander _setSceneHander;
        private readonly TabletsTouchHandler _tabletsTouchHandler;
        private readonly TweenAnimationHandler _tweenAnimationHandler;
        private readonly ParticalIntializer _particalSystem;
        private string _tabletToFind;
        private string _chosenTablet;
        
        public CriteriaCheckHandler(SetSceneHander setSceneHander, TabletsTouchHandler tabletsTouchHandler,
            TweenAnimationHandler tweenAnimationHandler, ParticalIntializer particalIntializer)
        {
            _setSceneHander = setSceneHander;
            _tabletsTouchHandler = tabletsTouchHandler;
            _tweenAnimationHandler = tweenAnimationHandler;
            _particalSystem = particalIntializer;
        }


        public void Initialize()
        {
            _tabletsTouchHandler.OnTabletPressed += CheckTablet;
        }

        public void Cleanup()
        {
            _tabletsTouchHandler.OnTabletPressed += CheckTablet;
        }

        private void CheckTablet(PointerEventData eventData)
        {
            var tabletObject = eventData.pointerCurrentRaycast.gameObject;
            var tabletName = tabletObject.name;
            var tabletToFind = _setSceneHander.RequiredTablet;
            var sequence = DOTween.Sequence();
            
            if (tabletToFind == tabletName)
            {
                sequence.AppendCallback(()=>
                {
                    _particalSystem.PlayParticleEffect(tabletObject.transform);
                });
                sequence.Append(_tweenAnimationHandler.DoRightAnswerShake(tabletObject.transform));
                sequence.AppendCallback((() =>
                {
                    _setSceneHander.MoveNext();
                }));
            }
            else
            {
                sequence.Append(_tweenAnimationHandler.DoWrongAnswerShake(tabletObject.transform));
            }
        }
    }
}