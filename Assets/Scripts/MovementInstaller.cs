using Zenject;
using Logic;

public class MovementInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<Movement>().FromInstance(new Movement());
    }
}