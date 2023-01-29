using ProcgenGame.Core.Scene;

namespace ProcgenGame.Core.Systems;

/// <summary> Reponsible for processing player inputs for other update systems to act upon. </summary>
sealed class InputSystem : IUpdateSystem
{
    private Game1 _game;
    private GameScene _scene;
    private Dictionary<InputAction, bool> _actionLocks = new();

    public InputSystem(Game1 game)
    {
        _game = game;
        _scene = game.Scene;

        foreach (InputAction action in Enum.GetValues<InputAction>())
        {
            _actionLocks[action] = false;
        }
    }

    public void Process(GameTime gameTime)
    {
        InputAction action;
        float elapsedSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;

        // Keyboard
        KeyboardState keyboard = Keyboard.GetState();

        if (keyboard.IsKeyDown(Keys.Escape))
        {
            _game.Exit();
        }

        // Fullscreen
        action = InputAction.ToggleFullscreen;
        if (!_actionLocks[action])
        {
            if (keyboard.IsKeyDown(Keys.LeftAlt) && keyboard.IsKeyDown(Keys.Enter))
            {
                _game.Graphics.ToggleFullScreen();

                _actionLocks[action] = true;
            }
        }
        else
        {
            if (keyboard.IsKeyUp(Keys.LeftAlt) || keyboard.IsKeyUp(Keys.Enter))
            {
                _actionLocks[action] = false;
            }
        }

        //    // Player
        //    Player player = _scene.Player;

        //    float acceleration = elapsedSeconds * player.Speed;

        //    int stateFlags;

        //    // 1
        //    stateFlags = 0;
        //    stateFlags += keyboard.IsKeyDown(Keys.W) ? (int)StateFlags.Up : 0;
        //    stateFlags += keyboard.IsKeyDown(Keys.S) ? (int)StateFlags.Down : 0;
        //    stateFlags += keyboard.IsKeyDown(Keys.A) ? (int)StateFlags.Left : 0;
        //    stateFlags += keyboard.IsKeyDown(Keys.D) ? (int)StateFlags.Right : 0;

        //    // 2
        //    stateFlags = 0;
        //    if (keyboard.IsKeyDown(Keys.W)) stateFlags += (int)StateFlags.Up;
        //    if (keyboard.IsKeyDown(Keys.S)) stateFlags += (int)StateFlags.Down;
        //    if (keyboard.IsKeyDown(Keys.A)) stateFlags += (int)StateFlags.Left;
        //    if (keyboard.IsKeyDown(Keys.D)) stateFlags += (int)StateFlags.Right;

        //    // 3
        //    stateFlags = 0;
        //    if (keyboard.IsKeyDown(Keys.W)) { stateFlags += (int)StateFlags.Up; }
        //    if (keyboard.IsKeyDown(Keys.S)) { stateFlags += (int)StateFlags.Down; }
        //    if (keyboard.IsKeyDown(Keys.A)) { stateFlags += (int)StateFlags.Left; }
        //    if (keyboard.IsKeyDown(Keys.D)) { stateFlags += (int)StateFlags.Right; }

        //    // 4
        //    stateFlags = 0;
        //    if (keyboard.IsKeyDown(Keys.W))
        //        stateFlags += (int)StateFlags.Up;
        //    if (keyboard.IsKeyDown(Keys.S))
        //        stateFlags += (int)StateFlags.Down;
        //    if (keyboard.IsKeyDown(Keys.A))
        //        stateFlags += (int)StateFlags.Left;
        //    if (keyboard.IsKeyDown(Keys.D))
        //        stateFlags += (int)StateFlags.Right;

        //    // 5
        //    stateFlags = 0;
        //    if (keyboard.IsKeyDown(Keys.W))
        //    {
        //        stateFlags += (int)StateFlags.Up;
        //    }
        //    if (keyboard.IsKeyDown(Keys.S))
        //    {
        //        stateFlags += (int)StateFlags.Down;
        //    }
        //    if (keyboard.IsKeyDown(Keys.A))
        //    {
        //        stateFlags += (int)StateFlags.Left;
        //    }
        //    if (keyboard.IsKeyDown(Keys.D))
        //    {
        //        stateFlags += (int)StateFlags.Right;
        //    }

        //    if (keyboard.IsKeyDown(Keys.W))
        //    {
        //        player.Velocity += new Vector2(0, -acceleration);
        //    }
        //    if (keyboard.IsKeyDown(Keys.S))
        //    {
        //        player.Velocity += new Vector2(0, acceleration);
        //    }
        //    if (keyboard.IsKeyDown(Keys.A))
        //    {
        //        player.Velocity += new Vector2(-acceleration, 0);
        //    }
        //    if (keyboard.IsKeyDown(Keys.D))
        //    {
        //        player.Velocity += new Vector2(acceleration, 0);
        //    }
    }
}
