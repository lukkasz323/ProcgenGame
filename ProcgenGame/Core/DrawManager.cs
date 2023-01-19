using Microsoft.Xna.Framework.Input;

namespace ProcgenGame.Core;

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

        DrawRoom();
        DrawPlayer();

        _batch.DrawString(_game.Fonts[FontName.Default], $"{_game.Scene.Player.Position}", new Vector2(4, 0), Color.Black);
        _batch.DrawString(_game.Fonts[FontName.Default], $"{Keyboard.GetState().IsKeyDown(Keys.W)}", new Vector2(4, 16), Color.Black);

        _batch.End();
    }

    private void DrawRoom()
    {
        foreach (Tile tile in _game.Scene.Room.Tiles)
        {
            Texture2D texture = _game.Textures[(TextureName)Enum.ToObject(typeof(TextureName), tile.Type)];

            _batch.Draw(texture, tile.Rectangle, Color.White);
        }
    }

    private void DrawPlayer()
    {
        Vector2 position = _game.Scene.Player.Position;
        int size = _game.Scene.Player.Size;

        _batch.Draw(_game.Textures[TextureName.White], new Rectangle((int)position.X, (int)position.Y, size, size), Color.Red);
    }
}