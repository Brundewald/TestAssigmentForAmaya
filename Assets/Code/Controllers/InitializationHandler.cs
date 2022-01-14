namespace TestProject
{
    public sealed class InitializationHandler
    {
        public InitializationHandler(ControllersProxy controllers, GameData gameData)
        {
            var uiInitializeHandler = new UIInitializeHandler(gameData);
            var tweenAnimationHandler = new TweenAnimationHandler(gameData, uiInitializeHandler);
            var gameStateHandler = new GameStateHandler(gameData, uiInitializeHandler, tweenAnimationHandler);
            controllers.Add(gameStateHandler);
        }
    }
}