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
    public Button moveButton;

    [SerializeField]
    public Button nextTurnButton;

    [SerializeField]
    public Button turnLeftButton;

    [SerializeField]
    public Button turnRightButton;

    [SerializeField]
    public Button sailButton;

    private Energy energy;
    private Movement movement;

    [Inject]

    public void Inject(Energy energy, Movement movement)
    {
        this.energy = energy;
        this.movement = movement;
    }

    private void Start()
    {
        nextTurnButton.onClick.AddListener(TriggerNextTurn);
        moveButton.onClick.AddListener(IncreaseMovement);
        turnLeftButton.onClick.AddListener(TurnLeft);
        turnRightButton.onClick.AddListener(TurnRight);
        sailButton.onClick.AddListener(Sail);
    }

    private void TriggerNextTurn()
    {
        energy.ResetCurrent();
        movement.ResetCurrent();
    }

    private void IncreaseMovement()
    {
        if(energy.TryUse(energy: 1))
        {
            movement.IncreaseCurrentMovement(increaseAmount: 3);
        }
    }

    private void TurnLeft()
    {
        if(movement.TryUse(movement: 1))
        {
            mapManager.Ship.Rotate(turnType: TurnType.HalfLeft);
        }
    }

    private void TurnRight()
    {
        if(movement.TryUse(movement: 1))
        {
            mapManager.Ship.Rotate(turnType: TurnType.HalfRight);
        }
    }

    private void Sail()
    {
        if(movement.TryUse(movement: 1))
        {
            mapManager.Ship.Sail();
        }
    }
}
