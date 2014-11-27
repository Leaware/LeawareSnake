using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Graphics;
using Android.Content;


namespace Snake.Android
{
    public class TypefaceProvider
    {
        #region Fields
        private static Typeface typeface;
        #endregion

        #region Constructors

        #endregion

        #region Events

        #endregion

        #region Properties

        #endregion

        #region Methods [public]
        public static Typeface GetTypeface(Context context, string fontPath)
        {
            if (TypefaceProvider.typeface == null)
            {
                TypefaceProvider.typeface = Typeface.CreateFromAsset(context.Assets, fontPath);
            }

            return typeface;
        }
        #endregion

        #region Methods [protected]
        #endregion

        #region Methods [private]

        #endregion
    }
}