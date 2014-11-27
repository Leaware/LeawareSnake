using System;
using System.Collections.Generic;
using Cirrious.MvvmCross.Binding.Bindings.Target;
using Snake.Android.Widgets;

namespace Snake.Android
{
    public class GameViewBinding : MvxConvertingTargetBinding
    {
        public GameViewBinding(GameView game)
            : base(game)
        {
        }

        protected GameView GameViewTarget
        {
            get
            {
                return (GameView)Target;
            }
        }

        protected override void SetValueImpl(object target, object value)
        {
            (target as GameView).Draw(value as List<Snake.Core.RectangleF>);
        }

        public override Type TargetType
        {
            get
            {
                return typeof(List<Snake.Core.RectangleF>);
            }
        }
    }
}