using System;

namespace Snake.Core
{
    public class SizeF : IEquatable<SizeF>
    {
        #region Constructor
        public SizeF(float width, float height)
        {
            this.Height = height;
            this.Width = width;
        }
        #endregion

        #region Properties
        public float Width { get; set; }

        public float Height { get; set; }
        #endregion

		#region IEquatable implementation
		public bool Equals(SizeF other)
		{
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
