using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TestProject
{
    internal class TabletView: MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Image _tabletBackhround;
        [SerializeField] private Image _tabletImage;

        internal event Action<PointerEventData> OnTabletPressed;
        internal Image TabletBackground => _tabletBackhround;
        internal Image TabletImage => _tabletImage;
        
        public void OnPointerClick(PointerEventData eventData)
        {
            OnTabletPressed?.Invoke(eventData);
        }
    }
}