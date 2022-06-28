using UnityEngine;
using TMPro;
using Zenject;
using Logic;

public class EnergyHolder : MonoBehaviour
{
    [SerializeField]
    public TMP_Text currentEnergyView;

    [SerializeField]
    public TMP_Text maxEnergyView;

    private Energy energy;

    [Inject]
    public void Inject(Energy energy)
    {
        this.energy = energy;
    }

    private void Start()
    {
        energy.RegisterOnCurrentEnergyChangeCallback(ChangeCurrentEnergyView);
        energy.RegisterOnMaxEnergyChangeCallback(ChangeMaxEnergyView);

        ChangeCurrentEnergyView(newEnergy: energy.CurrentEnergy);
        ChangeMaxEnergyView(newEnergy: energy.MaxEnergy);
    }

    private void ChangeCurrentEnergyView(int newEnergy)
    {
        currentEnergyView.text = newEnergy.ToString();
    }

    private void ChangeMaxEnergyView(int newEnergy)
    {
        maxEnergyView.text = newEnergy.ToString();
    }
}
