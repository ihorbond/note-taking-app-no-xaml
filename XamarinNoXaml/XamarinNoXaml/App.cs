﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamarinNoXaml
{
    public class App: Application
    {
        public App()
        {
            MainPage = new NavigationPage(new MainPage())
            {
                BarBackgroundColor = Color.CadetBlue,
                BarTextColor = Color.White
            };
        }
    }
}
