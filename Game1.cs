using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MLEM.Ui;
using MLEM.Ui.Style;
using MLEM.Ui.Elements;
using MLEM.Font;
using MLEM.Misc;

namespace templatetest;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    public UiSystem UiSystem;

    Texture2D background;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        Window.AllowUserResizing = true;
        //graphics.IsFullScreen = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        var style = new UntexturedStyle(this._spriteBatch);
        style.Font = new GenericSpriteFont(this.Content.Load<SpriteFont>("Fonts/DroidSans"), this.Content.Load<SpriteFont>("Fonts/DroidSans-Bold"));
        style.PanelChildPadding = new Padding(style.PanelChildPadding, 10);
        this.UiSystem = new UiSystem(this, style, null);

        var box = new Panel(Anchor.Center, new Vector2(400, 1), Vector2.Zero, setHeightBasedOnChildren: true);
        box.AddChild(new Paragraph(Anchor.AutoLeft, 1, "This is some example text!"));
        box.AddChild(new Button(Anchor.AutoCenter, new Vector2(0.5F, 80), "Okay") {
            OnPressed = element => this.UiSystem.Remove("InfoBox"),
            PositionOffset = new Vector2(0, 1)
        });
        this.UiSystem.Add("InfoBox", box);

        this.background = Content.Load<Texture2D>("Textures/pexels-sherman-trotz-18896623");

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        this.UiSystem.Update(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here

        this._spriteBatch.Begin();
        this._spriteBatch.Draw(this.background, Vector2.Zero, Color.White);
        this._spriteBatch.End();

        this.UiSystem.Draw(gameTime, this._spriteBatch);
        base.Draw(gameTime);
    }
}
