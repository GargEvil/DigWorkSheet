using DigWorkSheet.MobileUI.Services;
using DigWorkSheet.MobileUI.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DigWorkSheet.MobileUI
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
