using System;

namespace Logic
{
using OnCurrentMovementChange = Action<int>;

public class Movement 
{
    private OnCurrentMovementChange onCurrentMovementChange;
    private int currentMovement;

    public int CurrentMovement => currentMovement;

    public Movement()
    {
        this.currentMovement = 0;
    }

    public void ResetCurrent()
    {
        currentMovement = 0;
        onCurrentMovementChange(currentMovement);
    }

    public bool TryUse(int movement)
    {
        int newMovement = currentMovement - movement;
        if(newMovement < 0)
        {
            return false;
        }

        currentMovement = newMovement;
        onCurrentMovementChange(currentMovement);
        return true;
    }

    public void IncreaseCurrentMovement(int increaseAmount)
    {
        currentMovement += increaseAmount;
        onCurrentMovementChange(currentMovement);
    }

    public void RegisterOnCurrentMovementChangeCallback(OnCurrentMovementChange callback)
    {
        onCurrentMovementChange += callback;
    }
}

}