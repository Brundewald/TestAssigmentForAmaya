using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace TestProject
{
    public sealed class SetSceneHander
    {
        private const float InsertDelayForAppear = 0;
        
        private TabletStackHandler _tabletStackHandler;
        private TaskDisplayHandler _taskDisplayHandler;
        private GameStateHandler _gameStateHandler;
        private TweenAnimationHandler _tweenAnimationHandler;
        private TaskData _taskData;
        private Stack<GameObject> _tablets;
        private List<GameObject> _activeTablets;
        private int _currentPosition;
        private string _requiredTablet;
        private List<string> _previousTablets;
        private GameObject _tabletHolder;
        
        public string RequiredTablet => _requiredTablet;

        public SetSceneHander(TabletStackHandler tabletStackHandler,
            TaskDisplayHandler taskDisplayHandler, TweenAnimationHandler tweenAnimationHandler,
            GameStateHandler gameStateHandler, GameData gameData)
        {
            _tabletStackHandler = tabletStackHandler;
            _taskDisplayHandler = taskDisplayHandler;
            _gameStateHandler = gameStateHandler;
            _tweenAnimationHandler = tweenAnimationHandler;
            _taskData = gameData.TaskData;
            _activeTablets = new List<GameObject>();
            _previousTablets = new List<string>();
        }
        
        internal void SetTablets(int currentState)
        {
            if (currentState == 0)
            {
                SetupScene(_taskData.EasyLevelStackCount);
            }
            else if (currentState == 1)
            {
                SetupScene(_taskData.MediumLevelStackCount);
            }
            else if (currentState == 2)
            {
                SetupScene(_taskData.HardLevelStackCount);
            }
            else
            {
                ResetScene();
            }
        }

        internal void MoveNext()
        {
            _currentPosition++;
            SetTablets(_currentPosition);
        }

        private void SetupScene(int levelStackCount)
        {
            _tabletStackHandler.ReloadStack(levelStackCount, _activeTablets);
            _tablets = _tabletStackHandler.TabletsStack;
            ReloadScene(levelStackCount);
        }

        private void ReloadScene(int levelStackCount)
        {
            
            if(levelStackCount != _taskData.EasyLevelStackCount)
            {
                PlaceTablets(levelStackCount);
                SetCriteria();
            }
            else
            {
                var sequence = DOTween.Sequence();
                sequence.AppendCallback((() =>
                {
                    PlaceTablets(levelStackCount);
                    SetCriteria();
                }));
                sequence.Append(_tweenAnimationHandler.DoTextFieldFadeIn());
                sequence.Append(_tweenAnimationHandler.DoTabletHolderFadeIn());
                sequence.Insert(InsertDelayForAppear, _tweenAnimationHandler.DoAppearShake());
            }
        }


        private void PlaceTablets(int availableTablets)
        {
            _activeTablets.Clear();
            for (var i = 1; i <= availableTablets; i++)
            {
                var tablet= _tablets.Pop();
                tablet.SetActive(true);
                _activeTablets.Add(tablet);
            }
        }

        private void SetCriteria()
        {
            var randomNumber = Random.Range(0, _activeTablets.Count);
            var tabletName = _activeTablets[randomNumber].name;
            if (_requiredTablet == null)
            {
                SetRequaredTablet(tabletName);
            }
            else if (!_previousTablets.Contains(tabletName))
            {
                SetRequaredTablet(tabletName);
            }
            else
            {
                SetCriteria();
            }
        }

        private void SetRequaredTablet(string tabletName)
        {
            _requiredTablet = tabletName;
            _previousTablets.Add(_requiredTablet);
            _taskDisplayHandler.ShowTask(_requiredTablet);
        }

        private void ResetScene()
        {
            _currentPosition = 0;
            _gameStateHandler.SwitchState(GameState.Win);
        }
    }
}