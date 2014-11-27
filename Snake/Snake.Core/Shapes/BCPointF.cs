using System;

namespace Snake.Core
{
    public class PointF : IEquatable<PointF>
    {
        #region Constructor
        public PointF(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }

        public PointF()
        {

        }
        #endregion

        #region Properties
        public float X { get; set; }

        public float Y { get; set; }
        #endregion

		#region IEquatable implementation
		public bool Equals(PointF other)
		{
            if (this.X != other.X)
            {
                return false;
            }

            if (this.Y != other.Y)
            {
                return false;
            }

            return true;
		}
		#endregion
    }
}