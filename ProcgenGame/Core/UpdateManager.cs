using Microsoft.Xna.Framework.Input;

namespace ProcgenGame.Core;

public class UpdateManager
{
    private Game1 _game;

    public UpdateManager(Game1 game)
    {
        _game = game;
    }

    public void Update(GameTime gameTime)
    {
        HandleInputs(gameTime);
    }

    private void HandleInputs(GameTime gameTime)
    {
        InputAction action;

        // Keyboard
        KeyboardState keyboard = Keyboard.GetState();

        if (keyboard.IsKeyDown(Keys.Escape))
        {
            _game.Exit();
        }

        // Fullscreen
        action = InputAction.ToggleFullscreen;
        if (!_game.ActionIsLocked[action])
        {
            if (keyboard.IsKeyDown(Keys.LeftAlt) && keyboard.IsKeyDown(Keys.Enter))
            {
                _game.Graphics.ToggleFullScreen();

                _game.ActionIsLocked[action] = true;
            }
        }
        else
        {
            if (keyboard.IsKeyUp(Keys.LeftAlt) || keyboard.IsKeyUp(Keys.Enter))
            {
                _game.ActionIsLocked[action] = false;
            }
        }

        // Player movement
        if (keyboard.IsKeyDown(Keys.W))
        {

        }

        // Gamepad
        //GamePadState gamepad = GamePad.GetState(PlayerIndex.One);
    }
}