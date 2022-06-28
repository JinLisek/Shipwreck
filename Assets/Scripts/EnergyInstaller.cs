using Zenject;
using Logic;

public class EnergyInstaller : MonoInstaller
{
    private int maxEnergy = 3;

    public override void InstallBindings()
    {
        Container.Bind<Energy>().FromInstance(new Energy(maxEnergy: maxEnergy));
    }
}