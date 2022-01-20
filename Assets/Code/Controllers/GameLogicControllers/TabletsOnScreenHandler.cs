using System.Collections.Generic;
using UnityEngine;

namespace TestProject
{
    public sealed class TabletsOnScreenHandler
    {
        private readonly TabletStackHandler _tabletStackHandler;
        private readonly List<GameObject> _tabletsOnScreen;
        private Stack<GameObject> _tablets;
        
        public List<GameObject> TabletsOnScreen => _tabletsOnScreen;

        public TabletsOnScreenHandler(TabletStackHandler tabletStackHandler)
        {
            _tabletStackHandler = tabletStackHandler;
            _tabletsOnScreen = new List<GameObject>();
        }

        public void PlaceTablets(int availableTablets)
        {
            _tablets = _tabletStackHandler.TabletsStack;
            _tabletsOnScreen.Clear();
            for (var i = 1; i <= availableTablets; i++)
            {
                var tablet= _tablets.Pop();
                tablet.SetActive(true);
                _tabletsOnScreen.Add(tablet);
            }
        }
    }
}