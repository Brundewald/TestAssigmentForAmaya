using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TestProject
{
    public sealed class CriteriaCheckHandler: IInitialization, ICleanup
    {
        private readonly CriteriaSettingHandler _criteriaSettingHandler;
        private readonly TabletsTouchHandler _tabletsTouchHandler;

        public event Action<Transform> OnCriteriaMatch;
        public event Action<Transform> OnCriteriaMismatch;
        
        public CriteriaCheckHandler(CriteriaSettingHandler criteriaSettingHandler, TabletsTouchHandler tabletsTouchHandler)
        {
            _criteriaSettingHandler = criteriaSettingHandler;
            _tabletsTouchHandler = tabletsTouchHandler;
        }

        public void Initialize()
        {
            _tabletsTouchHandler.OnTabletPressed += CheckTabletForMatch;
        }

        public void Cleanup()
        {
            _tabletsTouchHandler.OnTabletPressed -= CheckTabletForMatch;
        }

        private void CheckTabletForMatch(PointerEventData eventData)
        {
            var tabletObject = eventData.pointerCurrentRaycast.gameObject;
            var tabletName = tabletObject.name;
            var tabletToFind = _criteriaSettingHandler.RequiredTablet;
            
            if (tabletToFind == tabletName)
            {
                OnCriteriaMatch?.Invoke(tabletObject.transform);
            }
            else
            {
                OnCriteriaMismatch?.Invoke(tabletObject.transform);
            }
        }
    }
}