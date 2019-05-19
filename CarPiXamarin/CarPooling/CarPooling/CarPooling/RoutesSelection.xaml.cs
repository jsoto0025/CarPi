using CarPooling.Controls;
using CarPooling.DTOs.DTOs;
using CarPooling.Session;
using CarPooling.ViewModels;
using Repositories.Route;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace CarPooling
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RoutesSelection : ContentPage
    {
        private readonly IRouteRepository _routeRepository;
        private readonly ISessionData _sessionData;

        public RoutesSelection(IRouteRepository routeRepository, ISessionData sessionData)
        {
            _routeRepository = routeRepository;
            _sessionData = sessionData;

            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var availableRoutes = _routeRepository.GetAllRoutes();
            var userSubscriptions = _routeRepository.GetUserSubscription(_sessionData.User.UserId)
                .Result
                .ToLookup(x => x.RouteId);

            var routes = new ObservableCollection<RouteViewModel>();

            RouteViewModel routeViewModel;
            SubscriptionDTO subscription;
            foreach (var item in availableRoutes.Result)
            {
                subscription = userSubscriptions[item.RouteId].FirstOrDefault();

                routeViewModel = new RouteViewModel()
                {
                    Name = item.Name,
                    RouteId = item.RouteId,
                    IsSuscribed = subscription != null,
                    SubscriptionId = subscription?.SubscriptionId,
                    RouteCoordinates = new ObservableCollection<Position>()
                };

                // Se mapean las coordenadas
                item.Position.ForEach(x => routeViewModel
                    .RouteCoordinates
                    .Add(new Position(x.Latitude, x.Longitude))
                );

                routes.Add(routeViewModel);
            }

            routeLists.ItemsSource = routes;
        }
    }
}