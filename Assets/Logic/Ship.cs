using System;
using System.Collections.Generic;

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

    public void Rotate()
    {
        if(direction == Direction.North)
            direction = Direction.South;
        else if(direction == Direction.South)
            direction = Direction.North;
        else if(direction == Direction.West)
            direction = Direction.East;
        else
            direction = Direction.West;

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


