using ProcgenGame.Core.Components;
using ProcgenGame.Core.Scene;
using System.Security.Cryptography.X509Certificates;

namespace ProcgenGame.Core.Update;

class DrawSystem : IUpdateSystem
{
    readonly Game1 _game;
    readonly GameScene _scene;
    readonly SpriteBatch _spriteBatch;
    readonly Dictionary<FontName, SpriteFont> _fonts;
    readonly Dictionary<TextureName, Texture2D> _textures;
    readonly ComponentRegistry _componentRegistry;
    readonly Dictionary<int, DrawComponent> _drawComponents;
    readonly Dictionary<int, TransformComponent> _transformComponents;

    public DrawSystem(Game1 game)
    {
        _game = game;
        _scene = game.Scene;
        _spriteBatch = game.SpriteBatch;
        _fonts = game.Assets.Fonts;
        _textures = game.Assets.Textures;
        _componentRegistry = _scene.ComponentRegistry;
        _drawComponents = _componentRegistry.GetComponentsOfType<DrawComponent>();
        _transformComponents = _componentRegistry.GetComponentsOfType<TransformComponent>();
    }

    public void Process(GameTime gameTime)
    {
        _game.GraphicsDevice.Clear(Color.White * 0.05f);

        _spriteBatch.Begin();

        DrawRoom();
        DrawEntities();
        DrawDebugInfo(gameTime);

        _spriteBatch.End();
    }

    void DrawDebugInfo(GameTime gameTime)
    {
        SpriteFont defaultFont = _fonts[FontName.Default];
        Color defaultColor = Color.White;

        var playerTransform = _scene.Player.GetComponent<TransformComponent>();
        var playerPhysics = _scene.Player.GetComponent<PhysicsComponent>();
        var fps = (int)(1 / gameTime.ElapsedGameTime.TotalSeconds);
        var px = playerTransform.Position.X;
        var py = playerTransform.Position.Y;
        var vx = playerPhysics.Velocity.X;
        var vy = playerPhysics.Velocity.Y;
        var ax = playerPhysics.Acceleration.X;
        var ay = playerPhysics.Acceleration.Y;

        _spriteBatch.DrawString(defaultFont, $"{fps}", new Vector2(4, 0), defaultColor);

        _spriteBatch.DrawString(defaultFont, $"Ax {ax}", new Vector2(4, 540), defaultColor);
        _spriteBatch.DrawString(defaultFont, $"Ay {ay}", new Vector2(4, 560), defaultColor);
        _spriteBatch.DrawString(defaultFont, $"Vx {vx}", new Vector2(4, 600), defaultColor);
        _spriteBatch.DrawString(defaultFont, $"Vy {vy}", new Vector2(4, 620), defaultColor);
        _spriteBatch.DrawString(defaultFont, $"Px {px}", new Vector2(4, 660), defaultColor);
        _spriteBatch.DrawString(defaultFont, $"Py {py}", new Vector2(4, 680), defaultColor);
    }

    void DrawRoom()
    {
        foreach (Tile tile in _scene.Room.Tiles)
        {
            Texture2D texture = _textures[(TextureName)Enum.ToObject(typeof(TextureName), tile.Type)];

            _spriteBatch.Draw(texture, tile.Rectangle, Color.White);
        }
    }

    void DrawEntities()
    {
        foreach (DrawComponent draw in _drawComponents.Values)
        {
            TransformComponent transform = _transformComponents[draw.EntityId];

            _spriteBatch.Draw(
                texture: _textures[draw.TextureName],
                destinationRectangle: new Rectangle(
                    x: (int)transform.Position.X,
                    y: (int)transform.Position.Y,
                    width: transform.Size,
                    height: transform.Size),
                color: draw.Color);
        }
    }
}