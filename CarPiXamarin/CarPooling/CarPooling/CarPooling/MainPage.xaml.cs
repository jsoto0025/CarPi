using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Xamarin.Forms;

namespace CarPooling
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var nextPage = App.DependencyContainer.Resolve<Login>();

            Application.Current.MainPage = new NavigationPage(nextPage);
        }
    }
}
