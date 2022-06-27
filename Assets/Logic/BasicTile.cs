namespace Logic
{

public class BasicTile: Tile
{
    public TileType Type => type;

    private TileType type;
    private Tile strategy;
    private BasicTile northTile;
    private BasicTile eastTile;
    private BasicTile southTile;
    private BasicTile westTile;


    public BasicTile(TileType type)
    {
        this.type = type;
        if(type == TileType.Whirlpool)
            strategy = new WhirlpoolTile();
        else
            strategy = new EmptyTile();

        // this.northTile = northTile;
        // this.eastTile = eastTile;
        // this.southTile = southTile;
        // this.westTile = westTile;
    }

    public void ChangeType(TileType type)
    {
        this.type = type;
    }

    public void Enter(Ship ship)
    {
        strategy.Enter(ship: ship);
    }

    public void Leave()
    {
    }
}

}