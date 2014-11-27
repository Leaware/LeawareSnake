﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cirrious.CrossCore.IoC;

namespace Snake.Core
{
    public class App : Cirrious.MvvmCross.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterAppStart<StartViewModel>();
        }
    }
}
