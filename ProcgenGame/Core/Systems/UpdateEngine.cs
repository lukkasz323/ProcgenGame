namespace ProcgenGame.Core.Systems;

/// <summary> Updates the game state, to be used in a loop. </summary>
sealed class UpdateEngine
{
    DrawSystem _draw;
    InputSystem _input;
    PhysicsSystem _physics;

    public UpdateEngine(Game1 game)
    {
        _input = new InputSystem(game);
        _physics = new PhysicsSystem(game);
        _draw = new DrawSystem(game);
    }

    /// <summary> Process all update systems except Draw. Should be called before Draw(). </summary>
    public void Update(GameTime gameTime)
    {
        _input.Process(gameTime);
        _physics.Process(gameTime);
    }

    /// <summary> Process only drawing to the screen. Should be called after Update(). </summary>
    public void Draw(GameTime gameTime)
    {
        _draw.Process(gameTime);
    }
}