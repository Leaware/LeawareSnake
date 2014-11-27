using System;
using System.Collections.Generic;
using System.Linq;

namespace Snake.Core
{
    public class Snake
    {
        #region Members
        public List<SnakePart> SnakeParts { get; private set; }
        #endregion

        #region Contstructor
        public Snake(PointF initializePosition, int pixelSize)
        {
            this.Initialize(initializePosition, pixelSize);
        }
        #endregion

        #region Methods
        private void Initialize(PointF initializePosition, int pixelSize)
        {
            SnakePart head = new SnakePart(0, 
                new RectangleF(
                    ((int)initializePosition.X / pixelSize) * pixelSize, 
                    ((int)initializePosition.Y / pixelSize) * pixelSize, pixelSize - 1, pixelSize - 1));

            SnakePart tail = new SnakePart(1, 
                new RectangleF(
                    ((int)initializePosition.X / pixelSize) * pixelSize - pixelSize, 
                    ((int)initializePosition.Y / pixelSize) * pixelSize, pixelSize - 1, pixelSize - 1));

            this.SnakeParts = new List<SnakePart>();
            this.SnakeParts.Add(head);
            this.SnakeParts.Add(tail);
        }  

        public void Move(Direction direction)
        {
            for (int i = this.SnakeParts.Count - 1; i > 0; i--)
            {
                this.SnakeParts[i].SetPosition(this.SnakeParts[i - 1].Shape);
            }

            this.SnakeParts[0].SetPosition(direction);
        }

        public void MoveWithAdd(Direction direction)
        {
            SnakePart part = new SnakePart(this.SnakeParts.Count, 
                new RectangleF(this.SnakeParts[this.SnakeParts.Count - 1].Shape));

            for (int i = this.SnakeParts.Count - 1; i > 0; i--)
            {
                this.SnakeParts[i].SetPosition(this.SnakeParts[i - 1].Shape);
            }

            this.SnakeParts[0].SetPosition(direction);
            this.SnakeParts.Add(part);
        }

        public bool IsInBound(SizeF bound)
        {
            if (this.SnakeParts[0].Shape.X < 0 || this.SnakeParts[0].Shape.X  + this.SnakeParts[0].Shape.Width >= bound.Width)
            {
                return false;
            }

            if (this.SnakeParts[0].Shape.Y < 0 || this.SnakeParts[0].Shape.Y + this.SnakeParts[0].Shape.Height >= bound.Height)
            {
                return false;
            }

            SnakePart head = this.SnakeParts[0];

            if (this.SnakeParts.Where(x => x.Shape.X == head.Shape.X && x.Shape.Y == head.Shape.Y).Count() > 1)
            {
                return false;
            }

            return true;
        }
        #endregion
    }
}

