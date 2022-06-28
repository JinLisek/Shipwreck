using UnityEngine;
using UnityEngine.UI;
using Logic;
using System;
using Zenject;

public class ControlsManager : MonoBehaviour
{
    [SerializeField]
    public MapManager mapManager;

    [SerializeField]
    public Button turnRightButton;

    [SerializeField]
    public Button nextTurnButton;

    private Energy energy;

    [Inject]

    public void Inject(Energy energy)
    {
        this.energy = energy;
    }

    private void Start()
    {
        nextTurnButton.onClick.AddListener(TriggerNextTurn);
        turnRightButton.onClick.AddListener(TryRightTurn);
    }

    private void TriggerNextTurn()
    {
        mapManager.Ship.Sail();
        energy.Refill();
    }

    private void TryRightTurn()
    {
        if(energy.TryUse(energy: 1))
        {
            mapManager.Ship.Rotate(turnType: TurnType.HalfRight);
        }
    }
}
