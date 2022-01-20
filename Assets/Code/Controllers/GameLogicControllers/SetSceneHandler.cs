namespace TestProject
{
    public sealed class SetSceneHandler: IInitialization, ICleanup
    {
        private const int EasyLevel = 0;
        private const int MediumLevel = 1;
        private const int HardLevel = 2;

        private readonly SceneManagementHandler _sceneManagementHandler;
        private readonly GameStateHandler _gameStateHandler;
        private readonly TweenAnimationHandler _tweenAnimationHandler;
        private readonly CriteriaCheckEventHandler _criteriaCheckEventHandler;
        private readonly TaskData _taskData;
        private int _currentPosition;

        public SetSceneHandler(CriteriaCheckEventHandler criteriaCheckEventHandler, SceneManagementHandler sceneManagementHandler,
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

        public void SetScreen(int currentState)
        {
            if (currentState == EasyLevel)
            {
                _sceneManagementHandler.SetupScene(_taskData.EasyLevelStackCount);
            }
            else if (currentState == MediumLevel)
            {
                _sceneManagementHandler.SetupScene(_taskData.MediumLevelStackCount);
            }
            else if (currentState == HardLevel)
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
            _currentPosition = EasyLevel;
            _gameStateHandler.SwitchState(GameState.Win);
        }
    }
}