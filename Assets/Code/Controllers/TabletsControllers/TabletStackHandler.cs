using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace TestProject
{
    internal sealed class TabletStackHandler
    {
        private DataInterpretationHandler _dataInterpretationHandler;
        private TabletBuilder _tabletBuilder;
        private TabletDataStruct[] _tabletDataStructs;
        private Stack<GameObject> _tabletsStack;
        private List<TabletView> _tabletsView;

        internal event Action OnStackReload;

        internal Stack<GameObject> TabletsStack => _tabletsStack;
        internal List<TabletView> TabletsView => _tabletsView;

        internal TabletStackHandler(GameData gameData, UIInitializeHandler uiInitializeHandler)
        {
            _dataInterpretationHandler = new DataInterpretationHandler(gameData);
            _tabletBuilder = new TabletBuilder(gameData, uiInitializeHandler);
            _tabletsView = new List<TabletView>();
        }

        internal void ReloadStack(int levelStackCount, List<GameObject> activeTablets)
        {
            DestroyTabletsOnScene(activeTablets);
            ReloadTabletStructArray();
            _tabletsView.Clear();
            _tabletsStack = CreateTabletStack(levelStackCount);
            OnStackReload?.Invoke();
        }

        private void ReloadTabletStructArray()
        {
            _tabletDataStructs = _dataInterpretationHandler.TabletsDataStructs;
        }

        private Stack<GameObject> CreateTabletStack(int levelStackCount)
        {
            var stack = new Stack<GameObject>();
            var chosenTablets = new List<TabletDataStruct>();
            SetRandomStack(chosenTablets, stack, levelStackCount);
            return stack;
        }

        private void SetRandomStack(List<TabletDataStruct> chosenTablets, Stack<GameObject> stack, int levelStackCount)
        {
            var usedTablets = new List<TabletDataStruct>();
            for (var i = 0; i <= _tabletDataStructs.Length; i++)
            {
                var tabletToAdd = RandomTablet();
                chosenTablets.Add(tabletToAdd);
                foreach (var tablet in chosenTablets)
                {
                    var stackIsNotFull = stack.Count != levelStackCount;
                    
                    if (usedTablets.Count == 0)
                    {
                        PushToStack(stack, tablet, usedTablets);
                    }
                    else if (stackIsNotFull)
                    {
                        if (usedTablets.Contains(tablet))
                        {
                            usedTablets.Add(tablet);
                        }
                        else
                        {
                            PushToStack(stack, tablet, usedTablets);
                        }
                    }
                }
            }
        }

        private void PushToStack(Stack<GameObject> stack, TabletDataStruct tablet, List<TabletDataStruct> usedTablets)
        {
            var newTabletObject = _tabletBuilder.BuildTablet(tablet, stack.Count);
            var tabletView = _tabletBuilder.TabletView;
            _tabletsView.Add(tabletView);
            stack.Push(newTabletObject);
            usedTablets.Add(tablet);
        }
        
        private void DestroyTabletsOnScene(List<GameObject> activeTablets)
        {
            foreach (var tablet in activeTablets)
            {
                Object.Destroy(tablet);
            }
        }

        private TabletDataStruct RandomTablet()
        {
            var count = _tabletDataStructs.Length;
            var randomIndex = Random.Range(0, count);
            var randomTablet = _tabletDataStructs[randomIndex];
            return randomTablet;
        }
    }
}