namespace Logic
{

public class DirectionRotator
{
    private CircularLinkedList<Direction> directionsCycle = new CircularLinkedList<Direction>();
    
    public DirectionRotator()
    {
        directionsCycle.AddLast(Direction.North);
        directionsCycle.AddLast(Direction.East);
        directionsCycle.AddLast(Direction.South);
        directionsCycle.AddLast(Direction.West);
    }

    public Direction Rotate(Direction direction, TurnType turnType)
    {
        if(turnType == TurnType.Uturn)
        {
            if(direction == Direction.North)
                return Direction.South;
            if(direction == Direction.South)
                return Direction.North;
            if(direction == Direction.West)
                return Direction.East;

            return Direction.West;
        }

        var directionNode = directionsCycle.Find(direction);

        if(turnType == TurnType.HalfRight)
        {
            directionNode = CircularLinkedListExtensions.Next(directionNode);
        }
        else if(turnType == TurnType.HalfLeft)
        {
            directionNode = CircularLinkedListExtensions.Previous(directionNode);
        }

        return directionNode.Value;
    }
}

}