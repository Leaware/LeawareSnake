using System;
using System.Collections.Generic;

namespace Snake.Core
{
    public class FoodShape
    {
        #region Members
        private List<RectangleF> baseShapes;
        private int size;
        #endregion

        #region Constructor
        public FoodShape(int size)
        {
            this.size = size;
            this.GenerateBaseShape();
        }
        #endregion

        #region Properties
        public List<RectangleF> Shapes { get; set; }
        public PointF Position { get; private set; }
        #endregion

        #region Methods
        private void GenerateBaseShape()
        {
            float oneSize = size / 3.0f;

            RectangleF top = new RectangleF(
                oneSize, 0, oneSize, oneSize);
            RectangleF bottom = new RectangleF(
                oneSize, oneSize * 2, oneSize, oneSize);
            RectangleF left = new RectangleF(
                0, oneSize, oneSize, oneSize);
            RectangleF right = new RectangleF(
                oneSize  * 2, oneSize, oneSize, oneSize);

            this.baseShapes = new List<RectangleF>();
            this.baseShapes.Add(top);
            this.baseShapes.Add(bottom);
            this.baseShapes.Add(left);
            this.baseShapes.Add(right);
        }

        public List<RectangleF> GetShapeForPosition(int x, int y)
        {
            x = (x / this.size) * this.size;
            y = (y / this.size) *this.size;

            this.Position = new PointF(x, y);

            this.Shapes = new List<RectangleF>();

            foreach (RectangleF rect in this.baseShapes)
            {
                RectangleF nRect = new RectangleF(rect);
                nRect.X += x;
                nRect.Y += y;

                this.Shapes.Add(nRect);
            }

            return this.Shapes;
        }
        #endregion
    }
}

