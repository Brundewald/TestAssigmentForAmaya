namespace TestProject
{
    public sealed class GameStateHandler: IInitialization, ICleanup
    {
        private readonly PlayStateHandler _playStateHandler;
        private readonly PlayScreenHandler _playScreenHandler;
        private readonly ResetScreenHandler _resetScreenHandler;
        private readonly ReloadScreenHandler _reloadScreenHandler;

        public GameStateHandler(GameData gameData, UIInitializeHandler uiInitializeHandler,
            TweenAnimationHandler tweenAnimationHandler)
        {
            _playStateHandler = new PlayStateHandler(uiInitializeHandler, tweenAnimationHandler, this, gameData);
            _playScreenHandler = new PlayScreenHandler(uiInitializeHandler, tweenAnimationHandler, _playStateHandler);
            _resetScreenHandler = new ResetScreenHandler(gameData, uiInitializeHandler);
            _reloadScreenHandler = new ReloadScreenHandler(tweenAnimationHandler, uiInitializeHandler, this);
        }

        public void Initialize()
        {
            _playStateHandler.Initialize();
        }

        public void Cleanup()
        {
            _playStateHandler.Cleanup();
        }

        public void SwitchState(GameState state)
        {
            switch (state)
            {
                case GameState.Play:
                    _playScreenHandler.SetScreen();
                    break;
                case GameState.Win:
                    _resetScreenHandler.SetScreen();
                    break;
                case GameState.Restart:
                    _reloadScreenHandler.SetScreen();
                    break;
            }
        }
    }
}