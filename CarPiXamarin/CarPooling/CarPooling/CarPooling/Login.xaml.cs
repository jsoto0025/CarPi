using Autofac;
using CarPooling.Session;
using Repositories.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarPooling
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        private readonly IUsersRepository _usersRepository;
        private readonly ISessionData _sessionData;

        public Login(IUsersRepository usersRepository, ISessionData sessionData)
        {
            InitializeComponent();

            _usersRepository = usersRepository;
            _sessionData = sessionData;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var user = txtUser.Text;
            var password = txtPassword.Text;

            var result = _usersRepository.AreUserAndPasswordValid(user, password);

            if (result != null)
            {
                try
                {
                    _sessionData.User = result;

                    // Redirect to the ohter page
                    var nextPage = App.DependencyContainer.Resolve<RoutesSelection>();
                    Application.Current.MainPage = new NavigationPage(nextPage);
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}