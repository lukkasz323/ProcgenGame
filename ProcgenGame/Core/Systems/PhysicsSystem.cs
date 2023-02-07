using ProcgenGame.Core.Components;
using ProcgenGame.Core.Scene;

namespace ProcgenGame.Core.Systems;

sealed class PhysicsSystem : IUpdateSystem
{
    readonly Game1 _game;
    readonly GameScene _scene;
    readonly ComponentRegister _componentRegister;
    readonly Dictionary<int, PhysicsComponent> _physicsComponents;
    readonly Dictionary<int, TransformComponent> _transformComponents;

    public PhysicsSystem(Game1 game)
    {
        _game = game;
        _scene = game.Scene;
        _componentRegister = game.Scene.ComponentRegister;
        _physicsComponents = _componentRegister.GetComponentsOfType<PhysicsComponent>();
        _transformComponents = _componentRegister.GetComponentsOfType<TransformComponent>();
    }

    public void Process(GameTime gameTime)
    {
        foreach (PhysicsComponent physics in _physicsComponents.Values)
        {
            TransformComponent transform = _transformComponents[physics.EntityId];

            transform.Position += physics.Velocity;
            physics.Velocity -= physics.Velocity * 0.2f;
        }
    }
}
