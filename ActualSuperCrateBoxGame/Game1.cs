using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace ActualSuperCrateBoxGame
{
    public class Game1 : Game
    {     

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SpriteEffects _spriteEffects;

        //Player stuff
        private Texture2D playerTexture;
        private int playerMoveSpeed;
        private Vector2 playerPosition;

        private Player _player;

        //Input stuff
        private KeyboardState  _keyboardState;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            playerPosition = new Vector2(30,30);
            playerMoveSpeed = 7;
            _spriteEffects = SpriteEffects.FlipHorizontally;

            _player = new(new(300, 300));
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            playerTexture = Content.Load<Texture2D>("temporary character");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _keyboardState = Keyboard.GetState();

            if (_keyboardState.IsKeyDown(Keys.Left))
            {
                playerPosition.X -= playerMoveSpeed;
                _spriteEffects = SpriteEffects.FlipHorizontally;
            }

            if (_keyboardState.IsKeyDown(Keys.Right))
            {
                playerPosition.X += playerMoveSpeed;
                _spriteEffects = SpriteEffects.None;
            }

            // TODO: Add your update logic here
            _player.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here 
            _player.Draw();
            _spriteBatch.Begin();
            Rectangle sourceRectangle = new Rectangle(0, 0, playerTexture.Width, playerTexture.Height);
            Vector2 origin = new Vector2(0,0);
            //_spriteBatch.Draw(playerTexture, sourceRectangle, Color.White);
            _spriteBatch.Draw(playerTexture, playerPosition, sourceRectangle, Color.White, 0f, origin, 1f, _spriteEffects, 1);
            _spriteBatch.End(); 

            base.Draw(gameTime);
        }
    }
}