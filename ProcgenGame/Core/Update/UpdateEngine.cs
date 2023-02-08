namespace ProcgenGame.Core.Update;

/// <summary> Updates the game state, to be used the a main game loop. </summary>
sealed class UpdateEngine
{
    readonly Game1 _game;
    readonly IUpdateSystem _draw;
    readonly IUpdateSystem _input;
    readonly IUpdateSystem _physics;

    public UpdateEngine(Game1 game)
    {
        _game = game;
        _input = new InputSystem(game);
        _physics = new PhysicsSystem(game.Scene);
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