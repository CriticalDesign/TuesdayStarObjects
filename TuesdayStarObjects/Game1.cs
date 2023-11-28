using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace TuesdayStarObjects
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private List<Star> myStar;
        private Texture2D _starTexture;
        private int _numStars, _numStarsOnScreen;
        private SpriteFont _gameFont;

        private bool _notSpacePressed;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _numStars = 50;
            _numStarsOnScreen = 0;
            _notSpacePressed = true;
            myStar = new List<Star>();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _starTexture = Content.Load<Texture2D>("Star_Sprite");

            for (int i = 0; i < _numStars; i++)
            {
                myStar.Add(new Star(_starTexture));
            }

            _gameFont = Content.Load<SpriteFont>("GameFont");
            
            
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.Space) && _notSpacePressed)
            {
                _notSpacePressed = false;
                _numStars++;
            }

            if (!Keyboard.GetState().IsKeyDown(Keys.Space) && !_notSpacePressed)
                _notSpacePressed = true;


            for (int i = 0; i < myStar.Count; i++)
            {
                myStar[i].Update();
            }

            _numStarsOnScreen = 0;
            for(int i = 0; i < myStar.Count; i++)
            {
                if (myStar[i].GetY() > 0 && myStar[i].GetY() < 480)
                    _numStarsOnScreen++;

                if (myStar[i].GetY() > 600)
                    myStar.RemoveAt(i);
            }

            while(myStar.Count < _numStars)
            {
                myStar.Add(new Star(_starTexture));
            }


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            for (int i = 0; i < myStar.Count; i++)
            {
                myStar[i].Draw(_spriteBatch);
            }


            _spriteBatch.Begin();
            _spriteBatch.DrawString(_gameFont, "Number of stars total: " + _numStars, new Vector2(10,10), Color.White);
            _spriteBatch.DrawString(_gameFont, "Number of stars on screen: " + _numStarsOnScreen, new Vector2(450, 10), Color.White);

            _spriteBatch.DrawString(_gameFont, "Press \"space\" to add another star.", new Vector2(240, 450), Color.White);


            _spriteBatch.End();



            base.Draw(gameTime);
        }
    }
}