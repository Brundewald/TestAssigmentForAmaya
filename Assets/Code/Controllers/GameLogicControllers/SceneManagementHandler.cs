using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace TestProject
{
    public sealed class SceneManagementHandler
    {
        private const float InsertDelayForAppear = 0;
        
        private readonly TabletStackHandler _tabletStackHandler;
        private readonly TabletsOnScreenHandler _tabletsOnScreenHandler;
        private readonly CriteriaSettingHandler _criteriaSettingHandler;
        private readonly TweenAnimationHandler _tweenAnimationHandler;
        private readonly TaskData _taskData;
        private List<GameObject> _activeTablets;

        public SceneManagementHandler(TabletStackHandler tabletStackHandler,TabletsOnScreenHandler tabletsOnScreenHandler, 
            CriteriaSettingHandler criteriaSettingHandler, TweenAnimationHandler tweenAnimationHandler, GameData gameData)
        {
            _tabletStackHandler = tabletStackHandler;
            _tabletsOnScreenHandler = tabletsOnScreenHandler;
            _criteriaSettingHandler = criteriaSettingHandler;
            _tweenAnimationHandler = tweenAnimationHandler;
            _taskData = gameData.TaskData;
        }
        
        public void SetupScene(int levelStackCount)
        {
            _activeTablets = _tabletsOnScreenHandler.TabletsOnScreen;
            _tabletStackHandler.ReloadStack(levelStackCount, _activeTablets);
            ReloadScene(levelStackCount);
        }

        private void ReloadScene(int levelStackCount)
        {
            
            if(levelStackCount != _taskData.EasyLevelStackCount)
            {
                _tabletsOnScreenHandler.PlaceTablets(levelStackCount);
                _criteriaSettingHandler.SetCriteria();
            }
            else
            {
                var sequence = DOTween.Sequence();
                sequence.AppendCallback((() =>
                {
                    _tabletsOnScreenHandler.PlaceTablets(levelStackCount);
                    _criteriaSettingHandler.SetCriteria();
                }));
                sequence.Append(_tweenAnimationHandler.DoTextFieldFadeIn());
                sequence.Append(_tweenAnimationHandler.DoTabletHolderFadeIn());
                sequence.Insert(InsertDelayForAppear, _tweenAnimationHandler.DoAppearShake());
            }
        }
    }
}