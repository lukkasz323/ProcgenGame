namespace ProcgenGame;

public class Level
{
    private int[,] _terrain = new int[,]
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

    public int TileSize { get; } = 64;
    public (int x, int y) Origin { get; } = (64, 0);
    public int Width { get => _terrain.GetLength(1) * TileSize; }
    public int Height { get => _terrain.GetLength(0) * TileSize; }
    public (int x, int y) Center { get => (Origin.x + (Width / 2), Origin.y + (Height / 2)); }

    public Tile[,] Tiles { get; private set; }
       

    public Level()
    {
        (int x, int y) length = (_terrain.GetLength(1), _terrain.GetLength(0));

        Tiles = new Tile[length.y, length.x]; 

        for (int y = 0; y < length.y; y++)
        {
            for (int x = 0; x < length.x; x++)
            {
                Tiles[y, x] = new Tile(
                    _terrain[y, x],
                    new Rectangle(
                        Origin.x + (x * TileSize),
                        Origin.y + (y * TileSize),
                        TileSize, 
                        TileSize));
            }
        }
    }
}
