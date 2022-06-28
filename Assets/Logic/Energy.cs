using System;

namespace Logic
{
using OnCurrentEnergyChange = Action<int>;
using OnMaxEnergyChange = Action<int>;

public class Energy 
{
    private OnCurrentEnergyChange onCurrentEnergyChange;
    private OnMaxEnergyChange onMaxEnergyChange;

    private int maxEnergy;
    private int currentEnergy;


    public int MaxEnergy => maxEnergy;
    public int CurrentEnergy => currentEnergy;

    public Energy(int maxEnergy)
    {
        this.maxEnergy = maxEnergy;
        this.currentEnergy = maxEnergy;
    }

    public void Refill()
    {
        currentEnergy = maxEnergy;
        onCurrentEnergyChange(currentEnergy);
    }

    public bool TryUse(int energy)
    {
        int newEnergy = currentEnergy - energy;
        if(newEnergy < 0)
        {
            return false;
        }

        currentEnergy = newEnergy;
        onCurrentEnergyChange(currentEnergy);
        return true;
    }

    public void RegisterOnCurrentEnergyChangeCallback(OnCurrentEnergyChange callback)
    {
        onCurrentEnergyChange += callback;
    }

    public void RegisterOnMaxEnergyChangeCallback(OnMaxEnergyChange callback)
    {
        onMaxEnergyChange += callback;
    }

}

}