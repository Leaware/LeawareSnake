using System;

namespace Snake.Core
{
	public class Color : IEquatable<Color>
	{
        #region Members
		public const int AlphaOpaque = 255;
		#endregion

		#region Constructors
		public Color()
		{
		}

		public Color(int red, int green, int blue) : this(red, green, blue, Color.AlphaOpaque)
		{
		}

		public Color(int red, int green, int blue, int alpha)
		{
            this.Green = green;
            this.Blue = blue;
            this.Red = red;
            this.Alpha = alpha;
		}
		#endregion

        #region Properties
        public int Red { get; set; }

        public int Green { get; set; }

        public int Blue { get; set; }

        public int Alpha { get; set; }
        #endregion

		#region IEquatable implementation
		public bool Equals(Color other)
		{
            if (this.Red != other.Red)
            {
                return false;
            }

            if (this.Green != other.Green)
            {
                return false;
            }

            if (this.Blue != other.Blue)
            {
                return false;
            }

            if (this.Alpha != other.Alpha)
            {
                return false;
            }

            return true;
		}
		#endregion
	}
}