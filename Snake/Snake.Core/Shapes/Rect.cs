#region "Using"
using System;
#endregion

namespace Snake.Core
{
	public class Rect : Shape, IEquatable<Rect>
	{
		#region Constructors
		public Rect() : base()
		{
		}

		public Rect(PointF anchorPoint, Color color) : base(anchorPoint, color)
		{
		}

		public Rect(PointF anchorPoint, Color color, float width, float height) : base(anchorPoint, color)
		{
            this.Width = width;
            this.Height = height;
		}
		#endregion

        #region Properties
        public float Width { get; set; }

        public float Height { get; set; }
        #endregion

		#region IEquatable implementation
        public bool Equals(Rect other)
		{
            if (!base.Equals(other))
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