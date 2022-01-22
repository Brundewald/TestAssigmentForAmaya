using System;
using System.Collections.Generic;
using UnityEngine.EventSystems;

namespace TestProject
{
    internal sealed class TabletsTouchHandler: IInitialization, ICleanup
    {
        private readonly TabletStackHandler _tabletStackHandler;
        private readonly List<TabletView> _tabletView;
        private string _touchedTablet;

        internal event Action<PointerEventData> OnTabletPressed; 
        
        internal TabletsTouchHandler(TabletStackHandler tabletStackHandler)
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

            foreach (var view in _tabletView)
            {
                view.OnTabletPressed += TabletPressed;
            }
        }

        private void RemoveSubscription()
        {
            _tabletStackHandler.OnStackReload -= ReloadSubscriptions;

            foreach (var view in _tabletView)
            {
                view.OnTabletPressed -= TabletPressed;
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