using System.Collections.Generic;

namespace TestProject
{
    internal sealed class ControllersProxy: IInitialization, IExecute, IFixedExecute, ICleanup
    {
        private readonly List<IInitialization> _initializationControllers;
        private readonly List<IExecute> _executeControllers;
        private readonly List<IFixedExecute> _fixedExecuteControllers;
        private readonly List<ICleanup> _cleanupControllers;

        internal ControllersProxy()
        {
            _initializationControllers = new List<IInitialization>();
            _executeControllers = new List<IExecute>();
            _fixedExecuteControllers = new List<IFixedExecute>();
            _cleanupControllers = new List<ICleanup>();
        }

        internal void Add(IController controller)
        {
            if (controller is IInitialization initializationController)
            {
                _initializationControllers.Add(initializationController);
            }

            if (controller is IExecute executeController)
            {
                _executeControllers.Add(executeController);
            }

            if (controller is IFixedExecute fixedExecuteController)
            {
                _fixedExecuteControllers.Add(fixedExecuteController);
            }

            if (controller is ICleanup cleanupController)
            {
                _cleanupControllers.Add(cleanupController);
            }
        }

        public void Initialize()
        {
            foreach (var initializationController in _initializationControllers)
            {
                initializationController.Initialize();
            }
        }

        public void Execute(float deltaTime)
        {
            foreach (var executeController in _executeControllers)
            {
                executeController.Execute(deltaTime);
            }
        }

        public void FixedExecute(float fixedDeltaTime)
        {
            foreach (var fixedExecuteController in _fixedExecuteControllers)
            {
                fixedExecuteController.FixedExecute(fixedDeltaTime);
            }
        }

        public void Cleanup()
        {
            foreach (var cleanupController in _cleanupControllers)
            {
                cleanupController.Cleanup();
            }
        }
    }   
}
