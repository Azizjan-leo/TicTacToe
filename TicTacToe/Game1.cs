using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TicTacToe.Enginge;

namespace TicTacToe
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch; // то, что рисует

        bool mRealesed = true; // кнопка мыши (не зажата)

        Field Field;
        Texture2D DefaultSprite, XSprite, OSprite, VerticalXSprite, VerticalOSprite, HorizontalXSprite, HorizontalOSprite, LeftXSprite, RightXSprite, LeftOSprite, RightOSprite, FinBackgroundSprite; // Спрайты
        DrawHelper DrawHelper;

        bool fin = false; // флаг окончания игры

        public Game1(int n)
        {
            Field = new Field(n);
            graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = n * 21,  // set this value to the desired width of your window
                PreferredBackBufferHeight = n * 21   // set this value to the desired height of your window
            };
            Window.Title = $"Баллы: игрок X - {Field.PointsX} | игрока O - {Field.PointsO}. Ход: Х"; 
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
            HorizontalXSprite = Content.Load<Texture2D>("horizontalX");
            HorizontalOSprite = Content.Load<Texture2D>("horizontalO");
            VerticalXSprite = Content.Load<Texture2D>("verticalX");
            VerticalOSprite = Content.Load<Texture2D>("verticalO");
            LeftXSprite = Content.Load<Texture2D>("leftX");
            RightXSprite = Content.Load<Texture2D>("rightX");
            LeftOSprite = Content.Load<Texture2D>("leftO"); 
            RightOSprite = Content.Load<Texture2D>("rightO");
            XSprite = Content.Load<Texture2D>("x");
            OSprite = Content.Load<Texture2D>("o");
            FinBackgroundSprite = Content.Load<Texture2D>("FinBackgroundSprite");
            DrawHelper = new DrawHelper(spriteBatch, DefaultSprite, XSprite, OSprite, VerticalXSprite, VerticalOSprite, HorizontalXSprite, HorizontalOSprite, LeftXSprite, RightXSprite, LeftOSprite, RightOSprite);
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
                if(Field.Click(mState.X, mState.Y)) // если игрок поставил свой знак
                {
                    if(Field.IsFull()) // Если все ячейки игрового поля заняты
                    {
                        fin = true; // Выставляем флаг окончания игры
                    }
                    else // если свободные ячейки имеются, обновляем табло (Title окна)
                    {
                        string order = (Field.Order) ? "X" : "O";
                        Window.Title = $"Баллы: игрок X - {Field.PointsX} | игрока O - {Field.PointsO}. Ход: {order}";
                    }
                    
                }
                
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
            if(!fin) // если игра ещё не закончена рисуем игровое поле 
                Field.DrawField(DrawHelper);
            else // иначе показываем красивую картинку и объявляем победителя
            {
                string result;
                if (Field.PointsX - Field.PointsO < 0)
                {
                    result = "Победил игрок 0";
                }
                else if (Field.PointsX - Field.PointsO > 0)
                {
                    result = "Победил игрок X";
                }
                else
                {
                    result = "Ничья";
                }
                Window.Title = $"{result} | Игрок X - {Field.PointsX} | Игрок О - {Field.PointsO}";
                spriteBatch.Draw(FinBackgroundSprite, new Vector2(0,0), Color.White);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}