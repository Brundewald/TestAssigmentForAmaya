using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TestProject
{
    public class TabletView: MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Image _tabletBackhround;
        [SerializeField] private Image _tabletImage;

        public event Action<PointerEventData> OnTabletPressed;
        public Image TabletBackground => _tabletBackhround;
        public Image TabletImage => _tabletImage;
        
        public void OnPointerClick(PointerEventData eventData)
        {
            OnTabletPressed?.Invoke(eventData);
        }
    }
}