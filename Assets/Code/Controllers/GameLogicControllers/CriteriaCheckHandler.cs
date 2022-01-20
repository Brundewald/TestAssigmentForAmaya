using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TestProject
{
    public sealed class CriteriaCheckHandler: IInitialization, ICleanup
    {
        private readonly SetSceneHander _setSceneHander;
        private readonly TabletsTouchHandler _tabletsTouchHandler;

        public event Action<Transform> OnCriteriaMatch;
        public event Action<Transform> OnCriteriaDismatch;
        
        public CriteriaCheckHandler(SetSceneHander setSceneHander, TabletsTouchHandler tabletsTouchHandler)
        {
            _setSceneHander = setSceneHander;
            _tabletsTouchHandler = tabletsTouchHandler;
        }


        public void Initialize()
        {
            _tabletsTouchHandler.OnTabletPressed += CheckTablet;
        }

        public void Cleanup()
        {
            _tabletsTouchHandler.OnTabletPressed -= CheckTablet;
        }

        private void CheckTablet(PointerEventData eventData)
        {
            var tabletObject = eventData.pointerCurrentRaycast.gameObject;
            var tabletName = tabletObject.name;
            var tabletToFind = _setSceneHander.RequiredTablet;
            
            if (tabletToFind == tabletName)
            {
                OnCriteriaMatch?.Invoke(tabletObject.transform);
            }
            else
            {
                OnCriteriaDismatch?.Invoke(tabletObject.transform);
            }
        }
    }
}