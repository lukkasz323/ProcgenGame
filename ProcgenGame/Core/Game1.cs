using ProcgenGame.Core.Scene;
using ProcgenGame.Core.Update;

namespace ProcgenGame.Core;

/// <summary> Game starts here and then updates itself till the end. <br/>
/// Overriden methods in this class are called externally by the Game base-class from the MonoGame(Xna) framework.</summary>
sealed class Game1 : Game
{
    UpdateEngine _updateEngine;

    public GraphicsDeviceManager Graphics { get; }
    public SpriteBatch SpriteBatch { get; set; }
    public GameScene Scene { get; set; }
    public AssetStorage Assets { get; set; }

#pragma warning disable CS8618
    public Game1()
#pragma warning restore CS8618
    {
        Assets = new AssetStorage();
        Scene = new GameScene(this);

        Graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";

        IsMouseVisible = true;
    }

    /// <summary> Ran after the constructor. </summary>
    protected override void Initialize()
    {
        SpriteBatch = new SpriteBatch(GraphicsDevice);
        _updateEngine = new UpdateEngine(this);

        Graphics.PreferredBackBufferWidth = 832;
        Graphics.PreferredBackBufferHeight = 704;
        Graphics.HardwareModeSwitch = false;
        Graphics.ApplyChanges();

        base.Initialize();
    }

    /// <summary> Ran after Initalize(). </summary>
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
        _updateEngine.Update(gameTime);

        base.Update(gameTime);
    }

    /// <summary> Ran first after Update().
    /// Runs in a loop alongside (after) Update() till near the end of the game's lifecycle. </summary>
    protected override void Draw(GameTime gameTime)
    {
        _updateEngine.Draw(gameTime);

        base.Draw(gameTime);
    }
}