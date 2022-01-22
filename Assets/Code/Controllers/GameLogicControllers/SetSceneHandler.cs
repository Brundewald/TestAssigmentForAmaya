namespace TestProject
{
    internal sealed class SetSceneHandler: IInitialization, ICleanup
    {
        private readonly SceneManagementHandler _sceneManagementHandler;
        private readonly GameStateHandler _gameStateHandler;
        private readonly TweenAnimationHandler _tweenAnimationHandler;
        private readonly CriteriaCheckEventHandler _criteriaCheckEventHandler;
        private readonly TaskData _taskData;
        private int _currentPosition;

        internal SetSceneHandler(CriteriaCheckEventHandler criteriaCheckEventHandler, SceneManagementHandler sceneManagementHandler,
            GameStateHandler gameStateHandler, GameData gameData)
        {
            _criteriaCheckEventHandler = criteriaCheckEventHandler;
            _sceneManagementHandler = sceneManagementHandler;
            _gameStateHandler = gameStateHandler;
            _taskData = gameData.TaskData;
        }

        public void Initialize()
        {
            _criteriaCheckEventHandler.OnRightAnswer += MoveNext;
        }

        public void Cleanup()
        {
            _criteriaCheckEventHandler.OnRightAnswer -= MoveNext;
        }

        internal void SetScreen(int currentState)
        {
            if (currentState == LevelCount.EasyLevel)
            {
                _sceneManagementHandler.SetupScene(_taskData.EasyLevelStackCount);
            }
            else if (currentState == LevelCount.MediumLevel)
            {
                _sceneManagementHandler.SetupScene(_taskData.MediumLevelStackCount);
            }
            else if (currentState == LevelCount.HardLevel)
            {
                _sceneManagementHandler.SetupScene(_taskData.HardLevelStackCount);
            }
            else
            {
                ResetScene();
            }
        }

        private void MoveNext()
        {
            _currentPosition++;
            SetScreen(_currentPosition);
        }

        private void ResetScene()
        {
            _currentPosition = LevelCount.EasyLevel;
            _gameStateHandler.SwitchState(GameState.Win);
        }
    }
}