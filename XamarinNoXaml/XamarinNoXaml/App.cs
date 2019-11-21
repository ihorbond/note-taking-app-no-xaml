using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace XamarinNoXaml
{
    public class App: Application
    {
        public App()
        {
            //DotNetEnv.Env.Load();
            MainPage = new NavigationPage(new MainPage())
            {
                BarBackgroundColor = Color.CadetBlue,
                BarTextColor = Color.White
            };

            var pa = Directory.GetCurrentDirectory();
            var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.CommonApplicationData), ".env");
            //using (var stream = File.OpenRead(path))
            //{
            //    DotNetEnv.Env.Load(stream);
            //}
            var he = "";
        }
    }
}
