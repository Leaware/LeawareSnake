using System;

namespace Snake.Core
{
    public class SnakePart
    {
        #region Properties
        public int Position;
        public RectangleF Shape;
        #endregion

        #region Constructor
        public SnakePart(int position, RectangleF shape)
        {
            this.Position = position;
            this.Shape = shape;
        }
        #endregion

        #region Methods
        public void SetPosition(RectangleF rect)
        {
            this.Shape = new RectangleF(rect);
        }

        public void SetPosition(Direction direction)
        {
            switch (direction)
            {
                case Direction.Bottom:
                    this.Shape.Y -= this.Shape.Height + 1;
                    break;
                case Direction.Left:
                    this.Shape.X -= this.Shape.Width + 1;
                    break;
                case Direction.Right:
                    this.Shape.X += this.Shape.Width + 1;
                    break;
                case Direction.Top:
                    this.Shape.Y += this.Shape.Height + 1;
                    break;
            }
        }
        #endregion
    }
}

