#region "Using"
using System;
#endregion

namespace Snake.Core
{
	public class Shape : IEquatable<Shape>
	{
		#region Constructors
		public Shape()
		{
		}

		public Shape(PointF anchorPoint, Color color)
		{
            this.Color = color;
            this.AnchorPoint = anchorPoint;
		}
		#endregion

        #region IShape implementation
        public PointF AnchorPoint { get; set; }

        public Color Color { get; set; }
        #endregion

		#region IEquatable implementation
		public bool Equals(Shape other)
		{
            if (!this.AnchorPoint.Equals(other.AnchorPoint))
            {
                return false;
            }

            if (!this.Color.Equals(other.Color))
            {
                return false;
            }

            return true;
		}
		#endregion

		#region IDisposable
		public virtual void Dispose()
		{
		}
		#endregion
	}
}