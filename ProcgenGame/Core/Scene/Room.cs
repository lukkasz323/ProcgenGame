namespace ProcgenGame.Core.Scene;

sealed class Room
{
    GameScene _scene;

    int[,] _tileTypes = new int[,]
    {
        { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, },
        { -1, 1, 1, 1, 1, 1, 1, 1, 1, 1, -1, },
        { -1, 1, 1, 1, 1, 1, 1, 1, 1, 1, -1, },
        { -1, 1, 1, 1, 1, 1, 1, 1, 1, 1, -1, },
        { -1, 1, 1, 1, 1, 1, 1, 1, 1, 1, -1, },
        { -1, 1, 1, 1, 1, 1, 1, 1, 1, 1, -1, },
        { -1, 1, 1, 1, 1, 1, 1, 1, 1, 1, -1, },
        { -1, 1, 1, 1, 1, 1, 1, 1, 1, 1, -1, },
        { -1, 1, 1, 1, 1, 1, 1, 1, 1, 1, -1, },
        { -1, 1, 1, 1, 1, 1, 1, 1, 1, 1, -1, },
        { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, },
    };

    public Vector2 Position { get; } = new(64, 0);
    public int Width { get => _tileTypes.GetLength(1) * _scene.TileSize; }
    public int Height { get => _tileTypes.GetLength(0) * _scene.TileSize; }
    public Vector2 Center { get => new(Position.X + Width / 2, Position.Y + Height / 2); }
    public Tile[,] Tiles { get; set; }
    public Point FloorPosition { get; set; }
    public int Depth { get; set; }

    public Room(GameScene scene, Point floorPosition, int depth)
    {
        _scene = scene;
        FloorPosition = floorPosition;
        Depth = depth;

        (int x, int y) length = (_tileTypes.GetLength(1), _tileTypes.GetLength(0));

        Tiles = new Tile[length.y, length.x];

        for (int y = 0; y < length.y; y++)
        {
            for (int x = 0; x < length.x; x++)
            {
                Tiles[y, x] = new Tile(
                    _tileTypes[y, x],
                    new Rectangle(
                        (int)Position.X + x * _scene.TileSize,
                        (int)Position.Y + y * _scene.TileSize,
                        _scene.TileSize,
                        _scene.TileSize));
            }
        }
    }
}
