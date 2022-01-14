using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TestProject
{
    public class TabletsTouchHandler: IInitialization, ICleanup
    {
        private TabletStackHandler _tabletStackHandler;
        private readonly List<TabletView> _tabletView;
        private string _touchedTablet;

        public event Action<PointerEventData> OnTabletPressed; 
        
        public TabletsTouchHandler(TabletStackHandler tabletStackHandler)
        {
            _tabletStackHandler = tabletStackHandler;
            _tabletView = tabletStackHandler.TabletsView;
        }

        public void Initialize()
        {
            AddSubscriptions();
        }

        public void Cleanup()
        {
            RemoveSubscription();
        }

        private void AddSubscriptions()
        {
            _tabletStackHandler.OnStackReload += ReloadSubscriptions;
            
            for (int i = 0; i < _tabletView.Count; i++)
            {
                _tabletView[i].OnTabletPressed += TabletPressed;
            }
        }

        private void RemoveSubscription()
        {
            _tabletStackHandler.OnStackReload -= ReloadSubscriptions;
            
            for (int i = 0; i < _tabletView.Count; i++)
            {
                _tabletView[i].OnTabletPressed -= TabletPressed;
            }
        }

        private void ReloadSubscriptions()
        {
            RemoveSubscription();
            AddSubscriptions();
        }

        private void TabletPressed(PointerEventData eventData)
        {
            OnTabletPressed?.Invoke(eventData);
        }
    }
}