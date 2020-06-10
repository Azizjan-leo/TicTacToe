using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TicTacToe.Source.Enginge;

namespace TicTacToe
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        bool mRealesed = true; // кнопка мыши (не зажата)

        Field Field;
        Texture2D DefaultSprite, XSprite, OSprite, VerticalSprite, HorizontalSprite; // Спрайты
        DrawHelper DrawHelper;

        public Game1(int n)
        {
            Field = new Field(n);
            graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = n * 21,  // set this value to the desired width of your window
                PreferredBackBufferHeight = n * 21   // set this value to the desired height of your window
            };
            graphics.ApplyChanges();
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            DefaultSprite = Content.Load<Texture2D>("default");
            HorizontalSprite = Content.Load<Texture2D>("default");
            VerticalSprite = Content.Load<Texture2D>("default");
            XSprite = Content.Load<Texture2D>("x");
            OSprite = Content.Load<Texture2D>("default");
            DrawHelper = new DrawHelper(spriteBatch, DefaultSprite, XSprite, OSprite, VerticalSprite, HorizontalSprite);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            var mState = Mouse.GetState();

            // пользователь нажал левую кнопку мыши
            if (mState.LeftButton == ButtonState.Pressed && mRealesed == true)
            {
                Field.Click(mState.X, mState.Y);

                mRealesed = false;
            }

            // пользователь отпустил левую кнопку мыши
            if (mState.LeftButton == ButtonState.Released)
            {
                mRealesed = true;
            }
            base.Update(gameTime);
        }

       
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            Field.DrawField(DrawHelper);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
