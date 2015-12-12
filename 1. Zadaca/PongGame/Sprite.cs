using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PongGame
{
    public abstract class Sprite
    {
        public Rectangle Size;
        public Vector2 Position;

        public Texture2D Texture { get; set; }

        protected Sprite (Texture2D spriteTexture, int width, int height)
        {
            Texture = spriteTexture;
            Size = new Rectangle(0, 0, width, height);
            Position = new Vector2(0, 0);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Size, Color.White);
        }


    }
}
