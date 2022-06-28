using System;

namespace Logic
{
using OnMoveCallback = Action<Direction>;
using OnRotateCallback = Action<Direction>;

public class Ship
{
    private Direction direction;
    private int speed;
    private OnMoveCallback onMove;
    private OnRotateCallback onRotate;
    private DirectionRotator rotator = new DirectionRotator();

    public Ship(Direction direction)
    {
        this.direction = direction;
        this.speed = 1;
    }

    public void Sail()
    {
        for(int tick = 0; tick < speed; ++tick)
        {
            OnMoveCallback onMove = this.onMove;
            if(onMove != null)
                onMove(direction);
        }
    }

    public void Rotate(TurnType turnType)
    {
        direction = rotator.Rotate(direction: direction, turnType: turnType);

        OnRotateCallback onRotate = this.onRotate;
        if(onRotate != null)
            onRotate(direction);
    }

    public void RegisterOnMoveCallback(OnMoveCallback callback)
    {
        onMove += callback;
    }

    public void RegisterOnRotateCallback(OnRotateCallback callback)
    {
        onRotate += callback;
    }
}  
 
}


