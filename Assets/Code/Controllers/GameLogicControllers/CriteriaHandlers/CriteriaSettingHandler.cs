using System.Collections.Generic;
using UnityEngine;

namespace TestProject
{
    public sealed class CriteriaSettingHandler
    {
        private readonly TabletsOnScreenHandler _tabletsOnScreenHandler;
        private readonly TaskDisplayHandler _taskDisplayHandler;
        private readonly List<string> _previousTablets;
        private List<GameObject> _tabletsOnScreen;
        private string _requiredTablet;

        public string RequiredTablet => _requiredTablet;

        public CriteriaSettingHandler(TabletsOnScreenHandler tabletsOnScreenHandler, TaskDisplayHandler taskDisplayHandler)
        {
            _tabletsOnScreenHandler = tabletsOnScreenHandler;
            _taskDisplayHandler = taskDisplayHandler;
            _tabletsOnScreen = new List<GameObject>();
            _previousTablets = new List<string>();
        }

        public void SetCriteria()
        {
            _tabletsOnScreen = _tabletsOnScreenHandler.TabletsOnScreen;
            var randomNumber = Random.Range(0, _tabletsOnScreen.Count);
            var tabletName = _tabletsOnScreen[randomNumber].name;
            
            if (_requiredTablet == null)
            {
                SetRequiredTablet(tabletName);
            }
            else if (!_previousTablets.Contains(tabletName))
            {
                SetRequiredTablet(tabletName);
            }
            else
            {
                SetCriteria();
            }
        }

        private void SetRequiredTablet(string tabletName)
        {
            _requiredTablet = tabletName;
            _previousTablets.Add(_requiredTablet);
            _taskDisplayHandler.ShowTask(_requiredTablet);
        }
    }
}