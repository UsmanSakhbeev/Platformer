
namespace Platformer
{
    public sealed class Controllers: IInitialization
    {
        private readonly IExecute[] _executeControllers;
        public int Length => _executeControllers.Length;
        public IExecute this[int index] => _executeControllers[index];

        public Controllers() {
            ServiceLocator.SetService(new WeaponController());
        }
        public void Initialization() {
            foreach (var controller in _executeControllers)
            {
                if (controller is IInitialization initialization)
                {
                    initialization.Initialization();
                }
            }
        }
    }
}