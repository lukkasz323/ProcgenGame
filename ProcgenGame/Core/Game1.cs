using ProcgenGame.Core.Scene;
using ProcgenGame.Core.Systems;

namespace ProcgenGame.Core;

/// <summary> Game starts here and then updates itself till the end.
/// Methods in this class are called externally by the framework.</summary>
sealed class Game1 : Game
{
    public GraphicsDeviceManager Graphics { get; }
    public SpriteBatch SpriteBatch { get; set; }
    public UpdateEngine UpdateEngine { get; set; }
    public GameScene Scene { get; set; }
    public AssetStorage Assets { get; set; }

    public Game1()
    {
        Graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        
        IsMouseVisible = true;

        // FPS Limiter
        IsFixedTimeStep = false;
    }

    /// <summary> Ran after the constructor. </summary>
    protected override void Initialize()
    {
        SpriteBatch = new SpriteBatch(GraphicsDevice);
        Assets = new AssetStorage();
        Scene = new GameScene(this);
        UpdateEngine = new UpdateEngine(this);

        Graphics.PreferredBackBufferWidth = 832;
        Graphics.PreferredBackBufferHeight = 704;
        Graphics.HardwareModeSwitch = false;
        Graphics.ApplyChanges();

        base.Initialize();
    }

    /// <summary> Ran after Initalize().</summary>
    protected override void LoadContent()
    {
        // Game assets should be only loaded here
        foreach (TextureName textureName in Enum.GetValues<TextureName>())
        {
            Assets.Textures.Add(textureName, Content.Load<Texture2D>($"Textures/{textureName}"));
        }
        foreach (FontName fontName in Enum.GetValues<FontName>())
        {
            Assets.Fonts.Add(fontName, Content.Load<SpriteFont>($"Fonts/{fontName}"));
        }
    }

    /// <summary> Ran first after LoadContent().
    /// Runs in a loop alongside (before) Draw() till near the end of the game's lifecycle. </summary>
    protected override void Update(GameTime gameTime)
    {
        UpdateEngine.Update(gameTime);

        base.Update(gameTime); // Must be last!
    }

    /// <summary> Ran first after Update().
    /// Runs in a loop alongside (after) Update() till near the end of the game's lifecycle. </summary>
    protected override void Draw(GameTime gameTime)
    {
        UpdateEngine.Draw(gameTime);

        base.Draw(gameTime); // Must be last!
    }
}