namespace ProcgenGame;

public class DrawManager
{
    private Game1 _game;
    private SpriteBatch _batch;

    public DrawManager(Game1 game)
    {
        _game = game;
        _batch = game.SpriteBatch;
    }

    public void Draw(GameTime gameTime)
    {
        _batch.Begin();

        DrawLevel();
        DrawPlayer();

        _batch.DrawString(_game.Fonts[FontName.Default], $"{_game.Player.Rectangle}", new Vector2(4, 0), Color.Black);

        _batch.End();
    }

    private void DrawLevel()
    {
        foreach (Tile tile in _game.Level.Tiles)
        {
            Texture2D texture = _game.Textures[(TextureName)Enum.ToObject(typeof(TextureName), tile.Type)];

            _batch.Draw(texture, tile.Rectangle, Color.White);
        }
    }

    private void DrawPlayer()
    {
        _batch.Draw(_game.Textures[TextureName.White], _game.Player.Rectangle, Color.Red);
    }
}