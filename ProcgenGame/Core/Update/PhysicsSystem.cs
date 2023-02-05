using ProcgenGame.Core.Components;
using ProcgenGame.Core.Scene;

namespace ProcgenGame.Core.Update;

sealed class PhysicsSystem : IUpdateSystem
{
    readonly float Responsiveness = 10f;

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
        float deltaSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;

        ProcessPlayerAcceleration();
        ProcessVelocityAndPosition(deltaSeconds);
    }

    void ProcessPlayerAcceleration()
    {
        foreach (InputComponent input in _inputComponents.Values)
        {
            PhysicsComponent physics = _physicsComponents[input.EntityId];

            Vector2 dir = Vector2.Zero;

            PlayerInputs inputFlags = input.InputFlags;
            if ((inputFlags & PlayerInputs.Up) != 0) dir.Y += -1f;
            if ((inputFlags & PlayerInputs.Down) != 0) dir.Y += 1f;
            if ((inputFlags & PlayerInputs.Left) != 0) dir.X += -1f;
            if ((inputFlags & PlayerInputs.Right) != 0) dir.X += 1f;

            if (dir != Vector2.Zero)
            {
                dir.Normalize();
            }

            physics.Acceleration = dir * physics.Speed;
        }
    }

    void ProcessVelocityAndPosition(float deltaSeconds)
    {
        foreach (PhysicsComponent physics in _physicsComponents.Values)
        {
            TransformComponent transform = _transformComponents[physics.EntityId];

            // Velocity
            physics.Velocity -= (physics.Velocity * Responsiveness) * deltaSeconds;
            physics.Velocity += (physics.Acceleration * Responsiveness) * deltaSeconds;

            // Position
            transform.Position += (physics.Velocity) * deltaSeconds;
        }
    }
}
