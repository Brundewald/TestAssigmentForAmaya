namespace TestProject
{
    internal sealed class InitializationHandler
    {
        internal InitializationHandler(ControllersProxy controllers, GameData gameData)
        {
            var uiInitializeHandler = new UIInitializeHandler(gameData);
            var tweenAnimationHandler = new TweenAnimationHandler(gameData, uiInitializeHandler);
            var gameStateHandler = new GameStateHandler(gameData, uiInitializeHandler, tweenAnimationHandler);
            controllers.Add(gameStateHandler);
        }
    }
}