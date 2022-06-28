using UnityEngine;

using Logic;

public class MapManager : MonoBehaviour
{
    [SerializeField] private GameObject emptyTilePrefab;
    [SerializeField] private GameObject whirlpoolTilePrefab;
    [SerializeField] private GameObject shipPrefab;
    [SerializeField] private int width;
    [SerializeField] private int height;

    private TurnManager turnManager;
    private GameObject shipObject;
    private BasicTile[,] tiles;
    private Ship ship;
    public Ship Ship => ship;
    private Position shipPosition = new Position(x: 0, y: 0);

    public void OnNextTurn()
    {
        turnManager.TriggerNextTurn();
    }

    public void TurnShip(TurnType turnType)
    {
        turnManager.TurnShip(turnType: turnType);
    }

    private void Start()
    {
        ship = CreateShip();
        SpawnTiles(ship: ship);
        turnManager = new TurnManager(ship: ship);
    }

    private void Update()
    {
    }

    private Ship CreateShip()
    {
        Ship ship = new Ship(direction: Direction.North);
        shipPosition = new Position(x: 3, y: 1);

        shipObject = Instantiate(shipPrefab);
        shipObject.name = "ship";
        shipObject.transform.position = new Vector2(x: shipPosition.x, y: shipPosition.y);
        shipObject.transform.SetParent(this.transform);

        ship.RegisterOnMoveCallback(this.MoveShipInDirection);
        ship.RegisterOnRotateCallback(this.RotateShipInDirection);

        return ship;
    }

    private void SpawnTiles(Ship ship)
    {
        tiles = new BasicTile[height, width];

        for(int y = 0; y < height; ++y)
            for(int x = 0; x < width; ++x)
                tiles[y, x] = new BasicTile(type: TileType.Empty);

        for(int x = 0; x < width; ++x)
        {
            tiles[0, x] = new BasicTile(type: TileType.Whirlpool);
        }

        for (int y = 1; y < height - 1; y++)
        {
            tiles[y, 0] = new BasicTile(type: TileType.Whirlpool);
            int x = 1;
            for (; x < width - 1; x++)
            {
                tiles[y, x] = new BasicTile(type: TileType.Empty);
            }
            tiles[y, x] = new BasicTile(type: TileType.Whirlpool);
        }

        for(int x = 0; x < width; ++x)
        {
            tiles[height - 1, x] = new BasicTile(type: TileType.Whirlpool);
        }

        tiles[shipPosition.x, shipPosition.y].Enter(ship);

        for(int y = 0; y < height; ++y)
        {
            for(int x = 0; x < width; ++x)
            {
                SpawnTile(posX: x, posY: y, tile: tiles[y, x]);
            }
        }
    }

    private void SpawnTile(int posX, int posY, BasicTile tile)
    {
        GameObject tileObject = Instantiate(ChooseTilePrefab(tile));
        tileObject.transform.position = new Vector2(posX, posY);
        tileObject.transform.SetParent(this.transform);
        tileObject.name = "tile_" + posX + "_" + posY;
    }

    private GameObject ChooseTilePrefab(BasicTile tile)
    {
        if(tile.Type == TileType.Whirlpool)
        {
            return whirlpoolTilePrefab;
        }

        return emptyTilePrefab;
    }

    private void MoveShipInDirection(Direction direction)
    {
        Position newShipPosition = shipPosition;
        Vector2 newPosition = new Vector2(x: shipObject.transform.position.x, y: shipObject.transform.position.y);

        if(direction == Direction.North)
            newShipPosition.y += 1;
        else if (direction == Direction.South)
            newShipPosition.y -= 1;

        if(direction == Direction.East)
            newShipPosition.x += 1;
        else if (direction == Direction.West)
            newShipPosition.x -= 1;

        tiles[newShipPosition.y, newShipPosition.x].Enter(ship);

        shipPosition = newShipPosition;
        shipObject.transform.position = new Vector2(x:newShipPosition.x, y: newShipPosition.y);
    }

    private void RotateShipInDirection(Direction direction)
    {
        if(direction == Direction.North)
            shipObject.transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
        else if(direction == Direction.East)
            shipObject.transform.rotation = Quaternion.AngleAxis(270, Vector3.forward);
        else if(direction == Direction.South)
            shipObject.transform.rotation = Quaternion.AngleAxis(180, Vector3.forward);
        else
            shipObject.transform.rotation = Quaternion.AngleAxis(90, Vector3.forward);

    }

}
