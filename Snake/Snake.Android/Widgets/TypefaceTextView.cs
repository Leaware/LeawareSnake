using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Content.Res;
using Android.Widget;
using Android.Util;
using Android.Runtime;

namespace Snake.Android.Widgets
{
    public class TypefaceTextView : TextView
    {
        #region Fields
        private string fontPath;
        #endregion

        #region Constructors
        public TypefaceTextView(Context context)
            : base(context)
        {
            this.Initialize();
        }

        public TypefaceTextView(Context context, IAttributeSet attrs) :
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

        public TypefaceTextView(Context context, IAttributeSet attrs, int defStyle) :
            base(context, attrs, defStyle)
        {
            this.Initialize();
        }

        public TypefaceTextView(IntPtr javaReference, JniHandleOwnership handle)
            : base(javaReference, handle)
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
            Typeface typeface = TypefaceProvider.GetTypeface(this.Context, this.fontPath);
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