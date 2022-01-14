namespace TestProject
{
    public sealed class PlayStateHandler: IInitialization, ICleanup
    {
        private readonly GameStateHandler _gameStateHandler;
        private readonly TabletsTouchHandler _tabletsTouchHandler;
        private readonly SetSceneHander _setSceneHander;
        private readonly ButtonHandler _buttonHandler;
        private readonly CriteriaCheckHandler _criteriaCheckHandler;
        private readonly TabletStackHandler _tabletStackHandler;
        private readonly ParticalIntializer _particleSystem;

        public SetSceneHander SetSceneHander => _setSceneHander;

        public PlayStateHandler(UIInitializeHandler uiInitializeHandler, TweenAnimationHandler tweenAnimationHandler,
            GameStateHandler gameStateHandler, GameData gameData)
        {
            var taskDisplayHandler = new TaskDisplayHandler(uiInitializeHandler, gameData);
            _particleSystem = new ParticalIntializer(gameData, uiInitializeHandler);
            _gameStateHandler = gameStateHandler;
            _tabletStackHandler = new TabletStackHandler(gameData, uiInitializeHandler);
            _tabletsTouchHandler = new TabletsTouchHandler(_tabletStackHandler);
            _setSceneHander = new SetSceneHander(_tabletStackHandler, taskDisplayHandler, tweenAnimationHandler, gameStateHandler, gameData);
            _buttonHandler = new ButtonHandler(uiInitializeHandler, gameStateHandler);
            _criteriaCheckHandler = new CriteriaCheckHandler(_setSceneHander, _tabletsTouchHandler, tweenAnimationHandler, _particleSystem);
        }

        public void Initialize()
        {
            _particleSystem.Initialize();
            _gameStateHandler.SwitchState(GameState.Play);
            _tabletStackHandler.Initialize();
            _tabletsTouchHandler.Initialize();
            _buttonHandler.Initialize();
            _criteriaCheckHandler.Initialize();
        }

        public void Cleanup()
        {
            _tabletsTouchHandler.Cleanup();
            _buttonHandler.Cleanup();
            _criteriaCheckHandler.Cleanup();
        }
    }
}