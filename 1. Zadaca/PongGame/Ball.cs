using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PongGame
{
    public class Ball : Sprite
    {
        public const float InitialSpeed = 0.4f;
        public const float BumpSpeedIncreasefactor = 1.01f;
        public const int BallSize = 50;

        public float Speed { get; set; }

        public Vector2 Direction;

        public Ball(Texture2D spriteTexture) : base(spriteTexture, BallSize, BallSize)
        {
            Speed = InitialSpeed;
            Direction = new Vector2(1, 1);
        }




    }
}
