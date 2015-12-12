using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PongGame
{
    public class Paddle : Sprite
    {
        private const float InitialSpeed = 0.9f;
        private const int PaddleHeight = 20;
        private const int PaddleWidth = 200;
        public float Speed { get; set; }

        public Paddle(Texture2D spriteTexture) : base(spriteTexture, PaddleWidth, PaddleHeight)
        {
            Speed = InitialSpeed;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Size, Color.Black);
        }
    }
}
