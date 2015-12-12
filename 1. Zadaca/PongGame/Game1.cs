using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using zad4;

namespace PongGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferHeight = 700,
                PreferredBackBufferWidth = 1200
            };
            Content.RootDirectory = "Content";
        }

        public Paddle PaddleBottom { get; private set; }

        public Paddle PaddleTop { get; private set; }

        public Ball Ball { get; private set; }

        public Background Background { get; private set; }

        public SoundEffect HitSound { get; private set; }

        public Song Music { get; private set; }

        private IGenericList<Sprite> SpritesForDrawList = new GenericList<Sprite>();


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

            var screenBounds = GraphicsDevice.Viewport.Bounds;

            Texture2D paddleTexture = Content.Load<Texture2D>("paddle");

            PaddleBottom = new Paddle(paddleTexture);
            PaddleTop = new Paddle(paddleTexture);

            PaddleBottom.Position = new Vector2(0, 680);
            PaddleTop.Position = new Vector2(0, 20);

            Texture2D ballTexture = Content.Load<Texture2D>("ball");

            Ball = new Ball(ballTexture);
            Ball.Position = screenBounds.Center.ToVector2();

            Texture2D backgroundTexture = Content.Load<Texture2D>("background");

            Background = new Background(backgroundTexture, screenBounds.Width, screenBounds.Height);

            HitSound = Content.Load<SoundEffect>("hit");

            SoundEffect.MasterVolume = 0.1f;

            //Music = Content.Load<Song>("music");

            MediaPlayer.IsRepeating = true;

            //MediaPlayer.Play(Music);

            SpritesForDrawList.Add(Background);
            SpritesForDrawList.Add(PaddleBottom);
            SpritesForDrawList.Add(PaddleTop);
            SpritesForDrawList.Add(Ball);


        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()

        {
            // TODO: Unload any non ContentManager content here
        }
        public class CollisionDetector
        {
            public static bool Overlaps(Sprite s1, Sprite s2)
            {
                if ((s1.Position.X >= s2.Position.X - s1.Texture.Width/2) && 
                    (s1.Position.X <= s2.Position.X + s2.Texture.Width/2 - s1.Texture.Width / 2) &&
                    (s1.Position.Y + s1.Texture.Height >= s2.Position.Y) && 
                    (s1.Position.Y + s1.Texture.Height <= s2.Position.Y + s2.Texture.Height)){
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            // Handle input
            var touchState = Keyboard.GetState();
            if (touchState.IsKeyDown(Keys.Left))
            {
                PaddleBottom.Position.X -= (float)(PaddleBottom.Speed * gameTime.ElapsedGameTime.TotalMilliseconds);
            }
            if (touchState.IsKeyDown(Keys.Right))
            {
                PaddleBottom.Position.X += (float)(PaddleBottom.Speed * gameTime.ElapsedGameTime.TotalMilliseconds);
            }
            if (touchState.IsKeyDown(Keys.A))
            {
                PaddleTop.Position.X -= (float)(PaddleTop.Speed * gameTime.ElapsedGameTime.TotalMilliseconds);
            }
            if (touchState.IsKeyDown(Keys.D))
            {
                PaddleTop.Position.X += (float)(PaddleTop.Speed * gameTime.ElapsedGameTime.TotalMilliseconds);
            }

            var bounds = GraphicsDevice.Viewport.Bounds;

            // Restrict calculated position inside screen bounds
            PaddleBottom.Position.X = MathHelper.Clamp(PaddleBottom.Position.X, bounds.Left, bounds.Right - PaddleBottom.Size.Width);

            PaddleTop.Position.X = MathHelper.Clamp(PaddleTop.Position.X, bounds.Left, bounds.Right - PaddleBottom.Size.Width);

            // Move ball
            Ball.Position += Ball.Direction * (float)(gameTime.ElapsedGameTime.TotalMilliseconds * Ball.Speed);

            //Ball - walls
            if(Ball.Position.X < bounds.Left || Ball.Position.X > bounds.Right - Ball.Size.Width){
                Ball.Direction.X = -Ball.Direction.X;
                Ball.Speed = Ball.Speed * Ball.BumpSpeedIncreasefactor;
                HitSound.Play();
            }

            //Paddle - ball collision
            if(CollisionDetector.Overlaps(Ball, PaddleTop) && Ball.Direction.Y < 0 || (CollisionDetector.Overlaps(Ball, PaddleBottom) && Ball.Direction.Y > 0))
            {
                Ball.Direction.Y = -Ball.Direction.Y;
                Ball.Speed *= Ball.BumpSpeedIncreasefactor;
            }

            //Reset ball
            if(Ball.Position.Y > bounds.Bottom || Ball.Position.Y < bounds.Top)
            {
                Ball.Position = bounds.Center.ToVector2();
                Ball.Speed = Ball.InitialSpeed;
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            for (int i = 0; i < SpritesForDrawList.Count; i++)
            {
                SpritesForDrawList.GetElement(i).Draw(spriteBatch);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
