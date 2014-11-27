using System;
using Cirrious.MvvmCross.Binding.Bindings.Target;
using System.Collections.Generic;
using Cirrious.MvvmCross.Binding;

namespace Snake.IOS
{
    public class GameViewBinding : MvxConvertingTargetBinding
    {
        protected GamePanel GameViewTarget
        {
            get
            {
                return (GamePanel)Target;
            }
        }

        public GameViewBinding(GamePanel game)
            :base(game)
        {
        }

        #region Methods
        public override Type TargetType
        {
            get
            {
                return typeof(List<Snake.Core.RectangleF>);
            }
        }

        public override Cirrious.MvvmCross.Binding.MvxBindingMode DefaultMode
        {
            get
            {
                return MvxBindingMode.OneWay;
            }
        }

        protected override void SetValueImpl(object target, object value)
        {
            (target as GamePanel).Draw(value as List<Snake.Core.RectangleF>);
        }
            
        #endregion
    }
}

