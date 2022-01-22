namespace TestProject
{
    internal sealed class PlayStateHandler: IInitialization, ICleanup
    {
        private readonly GameStateHandler _gameStateHandler;
        private readonly TabletsTouchHandler _tabletsTouchHandler;
        private readonly CriteriaCheckEventHandler _criteriaCheckEventHandler;
        private readonly CriteriaCheckHandler _criteriaCheckHandler;
        private readonly ButtonHandler _buttonHandler;
        private readonly ParticleIntializer _particleSystem;
        private readonly SetSceneHandler _setSceneHandler;

        internal SetSceneHandler SetSceneHandler => _setSceneHandler;

        internal PlayStateHandler(UIInitializeHandler uiInitializeHandler, TweenAnimationHandler tweenAnimationHandler,
            GameStateHandler gameStateHandler, GameData gameData)
        {
            var taskDisplayHandler = new TaskDisplayHandler(uiInitializeHandler, gameData);
            var tabletStackHandler = new TabletStackHandler(gameData, uiInitializeHandler);
            var tabletsOnScreenHandler = new TabletsOnScreenHandler(tabletStackHandler);
            var criteriaSettingHandler = new CriteriaSettingHandler(tabletsOnScreenHandler, taskDisplayHandler);
            var sceneManagementHandler = new SceneManagementHandler(tabletStackHandler, tabletsOnScreenHandler,
                criteriaSettingHandler, tweenAnimationHandler, gameData);
            _gameStateHandler = gameStateHandler;
            _tabletsTouchHandler = new TabletsTouchHandler(tabletStackHandler);
            _criteriaCheckHandler = new CriteriaCheckHandler(criteriaSettingHandler, _tabletsTouchHandler);
            _particleSystem = new ParticleIntializer(gameData, uiInitializeHandler);
            _criteriaCheckEventHandler = new CriteriaCheckEventHandler(_criteriaCheckHandler, tweenAnimationHandler, _particleSystem);
            _setSceneHandler = new SetSceneHandler(_criteriaCheckEventHandler, sceneManagementHandler, gameStateHandler, gameData);
            _buttonHandler = new ButtonHandler(uiInitializeHandler, gameStateHandler);
        }

        public void Initialize()
        {
            _gameStateHandler.SwitchState(GameState.Play);
            _tabletsTouchHandler.Initialize();
            _buttonHandler.Initialize();
            _criteriaCheckHandler.Initialize();
            _setSceneHandler.Initialize();
            _particleSystem.Initialize();
            _criteriaCheckEventHandler.Initialize();
        }

        public void Cleanup()
        {
            _tabletsTouchHandler.Cleanup();
            _buttonHandler.Cleanup();
            _criteriaCheckHandler.Cleanup();
            _criteriaCheckEventHandler.Cleanup();
            _setSceneHandler.Cleanup();
        }
    }
}