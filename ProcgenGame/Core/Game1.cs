using ProcgenGame.Core.Systems;

namespace ProcgenGame.Core;

/// <summary> Game starts here and then updates itself till the end. </summary>
public class Game1 : Game
{
    public GraphicsDeviceManager Graphics { get; }
    public SpriteBatch SpriteBatch { get; private set; }
    public UpdateController UpdateController { get; private set; }
    public Scene Scene { get; private set; }
    public AssetStorage Assets { get; private set; }

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
        Assets = new(Fonts: new(), Textures: new());
        Scene = new Scene(this);
        UpdateController = new UpdateController(this);

        Graphics.PreferredBackBufferWidth = 832;
        Graphics.PreferredBackBufferHeight = 704;
        Graphics.HardwareModeSwitch = false;
        Graphics.ApplyChanges();

        base.Initialize();
    }

    /// <summary> Ran after Initalize(). Should be exclusively responsible for loading game assets.</summary>
    protected override void LoadContent()
    {
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
        UpdateController.Update(gameTime); 

        base.Update(gameTime); // Must be last!
    }

    /// <summary> Ran first after Update().
    /// Runs in a loop alongside (after) Update() till near the end of the game's lifecycle. </summary>
    protected override void Draw(GameTime gameTime)
    {
        UpdateController.Draw(gameTime);

        base.Draw(gameTime); // Must be last!
    }
}