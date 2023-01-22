namespace ProcgenGame.Core;

public enum InputAction
{
    None,
    ToggleFullscreen,
}

public enum Direction
{
    North = 0,
    South = 1,
    West = 2,
    East = 3,
}

public enum FontName
{
    Default,
}

public enum TextureName
{
    Debug1 = -9,
    Border = -1,
    White = 0,
    Dirt = 1,
}

[Flags]
public enum FlagsInput
{
    None    = 0,
    Up      = 1 << 0,
    Down    = 1 << 1,
    Left    = 1 << 2,
    Right   = 1 << 3,
}