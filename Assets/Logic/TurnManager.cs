namespace Logic
{

public class TurnManager
{
    private Ship ship;

    public TurnManager(Ship ship)
    {
        this.ship = ship;
    }

    public void TriggerNextTurn()
    {
        ship.Sail();
    }

    public void TurnShip(TurnType turnType)
    {
        ship.Rotate(turnType: turnType);
    }
}

}