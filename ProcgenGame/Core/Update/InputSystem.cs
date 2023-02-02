using ProcgenGame.Core.Components;
using ProcgenGame.Core.Scene;

namespace ProcgenGame.Core.Update;

/// <summary> Reponsible for processing player inputs for other update systems to act upon. </summary>
sealed class InputSystem : IUpdateSystem
{
    readonly Game1 _game;
    readonly GameScene _scene;
    readonly ComponentRegistry _componentRegistry;
    readonly Dictionary<InputAction, bool> _actionLocks = new();
    readonly Dictionary<int, InputComponent> _inputComponents;

    public InputSystem(Game1 game)
    {
        _game = game;
        _scene = game.Scene;
        _componentRegistry = game.Scene.ComponentRegistry;
        _inputComponents = _componentRegistry.GetComponentsOfType<InputComponent>();

        foreach (InputAction action in Enum.GetValues<InputAction>())
        {
            _actionLocks[action] = false;
        }
    }

    public void Process(GameTime gameTime)
    {
        KeyboardState keyboard = Keyboard.GetState();

        UpdateInputFlags(keyboard);
        HandleActions(keyboard);
    }

    void UpdateInputFlags(KeyboardState keyboard)
    {
        foreach (InputComponent input in _inputComponents.Values)
        {
            PlayerInputs stateFlags = 0;

            if (keyboard.IsKeyDown(Keys.W)) stateFlags |= PlayerInputs.Up;
            if (keyboard.IsKeyDown(Keys.S)) stateFlags |= PlayerInputs.Down;
            if (keyboard.IsKeyDown(Keys.A)) stateFlags |= PlayerInputs.Left;
            if (keyboard.IsKeyDown(Keys.D)) stateFlags |= PlayerInputs.Right;

            input.InputFlags = stateFlags;
        }
    }

    void HandleActions(KeyboardState keyboard)
    {
        InputAction action;

        // Exit game
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
    }
}
