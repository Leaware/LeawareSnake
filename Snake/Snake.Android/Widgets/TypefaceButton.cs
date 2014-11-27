using System;

using Android.App;
using Android.Content;
using Android.Widget;
using Android.Util;
using Android.Graphics;
using Android.Content.Res;
using Android.Runtime;

namespace Snake.Android.Widgets
{
    public class TypefaceButton : Button
    {
        #region Fields
        private string fontPath;
        #endregion

        #region Constructors
        public TypefaceButton(Context context)
            : base(context)
        {
            this.Initialize();
        }

        public TypefaceButton(Context context, IAttributeSet attrs) :
            base(context, attrs)
        {
            TypedArray typedArray = Context.ObtainStyledAttributes(attrs, Resource.Styleable.Typeface, 0, 0);
            try
            {
                this.fontPath = typedArray.GetString(Resource.Styleable.Typeface_fontPath);
            }
            finally
            {
                typedArray.Recycle();
            }

            this.Initialize();
        }

        public TypefaceButton(IntPtr ptr, JniHandleOwnership handleOnwerShip)
            : base(ptr, handleOnwerShip)
        {
        }

        public TypefaceButton(Context context, IAttributeSet attrs, int defstyle) :
            base(context, attrs, defstyle)
        {
            this.Initialize();
        }

        #endregion

        #region Events

        #endregion

        #region Properties

        #endregion

        #region Methods [public]
        #endregion

        #region Methods [protected]
        #endregion

        #region Methods [private]
        private void Initialize()
        {
            Typeface typeface = Typeface.CreateFromAsset(Context.Assets, this.fontPath);
            if (this.Typeface != null)
            {
                TypefaceStyle style = Typeface.Style;
                this.SetTypeface(typeface, style);
            }
            else
            {
                this.SetTypeface(typeface, TypefaceStyle.Normal);
            }
        }

        #endregion
    }
}