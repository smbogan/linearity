using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linearity
{
    public class Block
    {
        public float X { get; private set; }

        public float Y { get; private set; }

        public float Width { get; private set; }

        public float Height { get; private set; }

        public float Right
        {
            get
            {
                return X + Width;
            }
        }

        public float Bottom
        {
            get
            {
                return Y + Height;
            }
        }


        public Block(float x, float y, float width, float height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public bool Intersect(Block other)
        {
            return !(other.X > Right
                || other.Right < X
                || other.Y > Bottom
                || other.Bottom < Y);
        }

        public List<Block> Subtract(Block other)
        {
            List<Block> result = new List<Block>();

            if (!Intersect(other))
            {
                result.Add(new Block(X, Y, Width, Height));

                return result;
            }

            if(other.Y - Y > 0)
            {
                float h = other.Y - Y;
                float x = X;
                float y = Y;
                float w = Width;

                result.Add(new Block(x, y, w, h));
            }

            if(Right - other.Right > 0)
            {
                float x = other.Right;
                float y = other.Y;
                float w = Right - other.Right;
                float h = other.Height;

                result.Add(new Block(x, y, w, h));
            }

            if(Bottom - other.Bottom > 0)
            {
                float x = X;
                float y = other.Bottom;
                float w = Width;
                float h = Bottom - other.Bottom;

                result.Add(new Block(x, y, w, h));
            }

            if(other.X - X > 0)
            {
                float x = X;
                float y = other.Y;
                float w = other.X - X;
                float h = other.Height;

                result.Add(new Block(x, y, w, h));
            }

            return result;
        }
    }
}
