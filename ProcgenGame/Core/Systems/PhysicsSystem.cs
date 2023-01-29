﻿using ProcgenGame.Core.Components;
using ProcgenGame.Core.Scene;

namespace ProcgenGame.Core.Systems;

public class PhysicsSystem : IUpdateSystem
{
    private readonly Game1 _game;
    private readonly GameScene _scene;
    private readonly ComponentRegister _componentRegister;
    private readonly List<PhysicsComponent> _physicsComponents;
    private readonly List<TransformComponent> _transformComponents;

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
        foreach ((PhysicsComponent physics, TransformComponent transform) in _physicsComponents.Zip(_transformComponents))
        {
            transform.Position += physics.Velocity;
            physics.Velocity -= physics.Velocity * 0.2f;
        }
    }
}
