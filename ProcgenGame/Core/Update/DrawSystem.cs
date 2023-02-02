using ProcgenGame.Core.Components;
using ProcgenGame.Core.Scene;

namespace ProcgenGame.Core.Update;

class DrawSystem : IUpdateSystem
{
    readonly Game1 _game;
    readonly GameScene _scene;
    readonly SpriteBatch _batch;
    readonly Dictionary<FontName, SpriteFont> _fonts;
    readonly Dictionary<TextureName, Texture2D> _textures;
    readonly ComponentRegistry _componentRegister;
    readonly Dictionary<int, DrawComponent> _drawComponents;
    readonly Dictionary<int, TransformComponent> _transformComponents;

    public DrawSystem(Game1 game)
    {
        _game = game;
        _scene = game.Scene;
        _batch = game.SpriteBatch;
        _fonts = game.Assets.Fonts;
        _textures = game.Assets.Textures;
        _componentRegister = game.Scene.ComponentRegistry;
        _drawComponents = _componentRegister.GetComponentsOfType<DrawComponent>();
        _transformComponents = _componentRegister.GetComponentsOfType<TransformComponent>();
    }

    public void Process(GameTime gameTime)
    {
        _game.GraphicsDevice.Clear(Color.White * 0.05f);

        _batch.Begin();

        DrawRoom();
        DrawEntities();
        DrawDebugInfo(gameTime);

        _batch.End();
    }

    void DrawDebugInfo(GameTime gameTime)
    {
        Color fontColor = Color.White;
        var fps = (int)(1 / gameTime.ElapsedGameTime.TotalSeconds);
        var playerTransform = _scene.Player.GetComponent<TransformComponent>();
        var playerPhysics = _scene.Player.GetComponent<PhysicsComponent>();

        _batch.DrawString(_fonts[FontName.Default], $"{fps}", new Vector2(4, 0), fontColor);
        Debug.A = playerPhysics.Speed;
        Debug.B = playerPhysics.Velocity;
        Debug.C = playerTransform.Position;
        _batch.DrawString(_fonts[FontName.Default], $"A: {Debug.A}", new Vector2(4, 640), fontColor);
        _batch.DrawString(_fonts[FontName.Default], $"B: {Debug.B}", new Vector2(4, 660), fontColor);
        _batch.DrawString(_fonts[FontName.Default], $"C: {Debug.C}", new Vector2(4, 680), fontColor);
    }

    void DrawRoom()
    {
        foreach (Tile tile in _scene.Room.Tiles)
        {
            Texture2D texture = _textures[(TextureName)Enum.ToObject(typeof(TextureName), tile.Type)];

            _batch.Draw(texture, tile.Rectangle, Color.White);
        }
    }

    void DrawEntities()
    {
        foreach (DrawComponent draw in _drawComponents.Values)
        {
            TransformComponent transform = _transformComponents[draw.EntityId];

            _batch.Draw(
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