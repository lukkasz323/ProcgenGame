namespace ProcgenGame.Core;

public class Game1 : Game
{
    public GraphicsDeviceManager Graphics { get; }
    public SpriteBatch SpriteBatch { get; private set; }
    public UpdateManager UpdateManager { get; private set; }
    public DrawManager DrawManager { get; private set; }

    public Dictionary<FontName, SpriteFont> Fonts { get; private set; } = new();
    public Dictionary<TextureName, Texture2D> Textures { get; private set; } = new();
    public Dictionary<InputAction, bool> ActionIsLocked { get; private set; } = new();

    public Scene Scene { get; private set; }

    public Game1()
    {
        Graphics = new GraphicsDeviceManager(this);

        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        Graphics.PreferredBackBufferWidth = 832;
        Graphics.PreferredBackBufferHeight = 704;
        Graphics.HardwareModeSwitch = false;
        Graphics.ApplyChanges();

        foreach (InputAction action in Enum.GetValues(typeof(InputAction)))
        {
            ActionIsLocked[action] = false;
        }

        SpriteBatch = new(GraphicsDevice);

        UpdateManager = new UpdateManager(this);
        DrawManager = new DrawManager(this);

        Scene = new Scene();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        foreach (TextureName textureName in Enum.GetValues(typeof(TextureName)))
        {
            Textures.Add(textureName, Content.Load<Texture2D>($"Textures/{textureName}"));
        }
        foreach (FontName fontName in Enum.GetValues(typeof(FontName)))
        {
            Fonts.Add(fontName, Content.Load<SpriteFont>($"Fonts/{fontName}"));
        }
    }

    protected override void Update(GameTime gameTime)
    {
        UpdateManager.Update(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        DrawManager.Draw(gameTime);

        base.Draw(gameTime);
    }
}