using ProcgenGame.Core.Components;
using ProcgenGame.Core.Scene;

namespace ProcgenGame.Core.Update;

sealed class PhysicsSystem : IUpdateSystem
{
    readonly GameScene _scene;
    readonly ComponentRegistry _componentRegistry;
    readonly Dictionary<int, PhysicsComponent> _physicsComponents;
    readonly Dictionary<int, TransformComponent> _transformComponents;
    readonly Dictionary<int, InputComponent> _inputComponents;

    public PhysicsSystem(GameScene scene)
    {
        _scene = scene;
        _componentRegistry = scene.ComponentRegistry;
        _physicsComponents = _componentRegistry.GetComponentsOfType<PhysicsComponent>();
        _transformComponents = _componentRegistry.GetComponentsOfType<TransformComponent>();
        _inputComponents = _componentRegistry.GetComponentsOfType<InputComponent>();
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

            transform.Position += physics.Velocity;
            physics.Velocity -= physics.Velocity * 0.2f;
        }
    }
}
