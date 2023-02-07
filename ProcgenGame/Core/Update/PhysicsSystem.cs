using ProcgenGame.Core.Components;
using ProcgenGame.Core.Scene;

namespace ProcgenGame.Core.Update;

sealed class PhysicsSystem : IUpdateSystem
{
    readonly Game1 _game;
    readonly GameScene _scene;
    readonly ComponentRegistry _componentRegister;
    readonly Dictionary<int, PhysicsComponent> _physicsComponents;
    readonly Dictionary<int, TransformComponent> _transformComponents;
    readonly Dictionary<int, InputComponent> _inputComponents;

    public PhysicsSystem(Game1 game)
    {
        _game = game;
        _scene = game.Scene;
        _componentRegister = _scene.ComponentRegistry;
        _physicsComponents = _componentRegister.GetComponentsOfType<PhysicsComponent>();
        _transformComponents = _componentRegister.GetComponentsOfType<TransformComponent>();
        _inputComponents = _componentRegister.GetComponentsOfType<InputComponent>();
    }

    public void Process(GameTime gameTime)
    {
        HandlePlayerVelocity(gameTime);
        ProcessEntities();
    }

    void HandlePlayerVelocity(GameTime gameTime)
    {
        foreach (InputComponent input in _inputComponents.Values)
        {
            PhysicsComponent physics = _physicsComponents[input.EntityId];

            PlayerInputs inputFlags = input.InputFlags;
            float acceleration = (float)gameTime.ElapsedGameTime.TotalSeconds * physics.Speed;

            if ((inputFlags & PlayerInputs.Up) != 0) physics.Velocity += new Vector2(0, -acceleration);
            if ((inputFlags & PlayerInputs.Down) != 0) physics.Velocity += new Vector2(0, acceleration);
            if ((inputFlags & PlayerInputs.Left) != 0) physics.Velocity += new Vector2(-acceleration, 0);
            if ((inputFlags & PlayerInputs.Right) != 0) physics.Velocity += new Vector2(acceleration, 0);
        }
    }

    void ProcessEntities()
    {
        foreach (PhysicsComponent physics in _physicsComponents.Values)
        {
            TransformComponent transform = _transformComponents[physics.EntityId];

            transform.Position += physics.Velocity * 5f;
            physics.Velocity -= physics.Velocity;
        }
    }
}
