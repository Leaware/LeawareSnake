using System;

namespace Snake.Core
{
    public class RectangleF : IEquatable<RectangleF>
    {
        #region Constructor
        public RectangleF(float x, float y, float width, float height)
        {
            this.Position = new PointF(x, y);
            this.Width = width;
            this.Height = height;
        }

        public RectangleF(RectangleF rect)
        {
            this.Position = new PointF(rect.Position.X, rect.Position.Y);
            this.Width = rect.Width;
            this.Height = rect.Height;
        }

        public RectangleF()
        {

        }
        #endregion

        #region Properties
        public float X 
        { 
            get 
            { 
                return this.Position.X; 
            } 
            set
            { 
                this.Position.X = value; 
            }
        }

        public float Y 
        { 
            get 
            { 
                return this.Position.Y; 
            } 
            set
            { 
                this.Position.Y = value; 
            }
        }

        public PointF Position {get;set; }

        public float Height { get; set; }

        public float Width { get; set; }
        #endregion

		#region IEquatable implementation
		public bool Equals(RectangleF other)
		{
            if (this.X != other.X)
            {
                return false;
            }

            if (this.Y != other.Y)
            {
                return false;
            }

            if (this.Width != other.Width)
            {
                return false;
            }

            if (this.Height != other.Height)
            {
                return false;
            }

            return true;
		}
		#endregion
    }
}
