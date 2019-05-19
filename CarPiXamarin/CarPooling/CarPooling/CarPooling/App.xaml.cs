using System;
using Autofac;
using CommonServiceLocator;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace CarPooling
{
    public partial class App : Application
    {
        public static IContainer DependencyContainer { get; internal set; }

        public App()
        {
            InitializeComponent();

            Bootstrap.Initialize();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
