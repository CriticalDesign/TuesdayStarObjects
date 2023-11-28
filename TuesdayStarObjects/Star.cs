using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using System;

namespace TuesdayStarObjects
{
    internal class Star
    {

        private Texture2D _starTexture;
        private Vector2 _starPosition;
        private Vector2 _starScale;
        private float _starRotation;
        private Vector2 _starOrigin;
        private Color _starColor;
        private Random _rng;

        private float _starSpeed, _starRotationSpeed;

        public Star(Texture2D starTextureIn)
        {
            _rng = new Random();


            _starSpeed = _rng.Next(50, 151) / 100f;
            _starRotationSpeed = _rng.Next(-100, 101) / 2500f;

            _starTexture = starTextureIn;
            _starPosition = new Vector2(_rng.Next(0, 801), _rng.Next(-400, -100));


            float scaleTemp = _rng.Next(20, 56) / 100f;
            _starScale = new Vector2(scaleTemp, scaleTemp);
            
            _starRotation = _rng.Next(1,101) / 100f;
            _starColor = new Color(128 + _rng.Next(1, 129), 128 + _rng.Next(1, 129), 128 + _rng.Next(1, 129));
            _starOrigin = new Vector2(_starTexture.Width / 2f, _starTexture.Height / 2f);
        }

        public void Update()
        {
            _starPosition.Y += _starSpeed;
            _starRotation += _starRotationSpeed;
        }


        public void Draw(SpriteBatch starSpriteBatch)
        {
            starSpriteBatch.Begin();
            starSpriteBatch.Draw(_starTexture,
                _starPosition,
                null,
                _starColor,
                _starRotation,
                _starOrigin,
                _starScale,
                SpriteEffects.None,
                0
                );
            starSpriteBatch.End();
        }

        public float GetY()
        {
            return _starPosition.Y;
        }

    }
}
