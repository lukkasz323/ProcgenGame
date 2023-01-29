using ProcgenGame.Core.Components;
using ProcgenGame.Core.Entities;

namespace ProcgenGame.Core;

/// <summary> Contains the game world. </summary>
internal sealed class Scene
{
    readonly Game1 _game;

    public ComponentRegister ComponentRegister { get; } = new();
    public EntitySpawner EntitySpawner { get; } = new();
    public EntityManager EntityManager { get; } = new();
    public Player Player { get; }
    public List<Room> Rooms { get; }
    public Room Room { get; }
    public Random Rng { get; } = new();
    public int TileSize { get; } = 64;
    public int Floor { get; private set; } = 1;

    public Scene(Game1 game)
    {
        _game = game;

        Rooms = GenerateRooms();
        Room = new Room(this, Point.Zero, 0); // <--- to be removed

        // New entity creation (Player)
        //EntityManager.AddEntity(new Player());
        //EntityManager.SetPosition(this, new Vector2(0, -3));
    }

    private List<Room> GenerateRooms()
    {
        var rooms = new List<Room>();

        var allDirections = Enum.GetValues<Direction>();

        var room = new Room(this, Point.Zero, 0);
        rooms.Add(room);

        var possibleDirections = new List<Direction>(allDirections);
        foreach (Direction _ in allDirections)
        {
            Direction direction = PullRandomItem(possibleDirections);
            Point otherPosition = room.FloorPosition + Utils.DirectionToPosition[direction];
            var otherRoom = new Room(this, otherPosition, room.Depth + 1);
            rooms.Add(otherRoom);
        }

        return rooms;
    }

    private Direction PullRandomItem(List<Direction> items)
    {
        int index = Rng.Next(items.Count);
        Direction item = items[index];

        items.RemoveAt(index);
        return item;
    }

}