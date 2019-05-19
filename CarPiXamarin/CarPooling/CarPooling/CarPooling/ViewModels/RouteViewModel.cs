using Autofac;
using CarPooling.DTOs.DTOs;
using CarPooling.Session;
using Repositories.Route;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace CarPooling.ViewModels
{
    public class RouteViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Position> _RouteCoordinates;
        public ObservableCollection<Position> RouteCoordinates
        {
            get
            {
                if (_RouteCoordinates == null)
                {
                    _RouteCoordinates = new ObservableCollection<Position>();
                }

                return _RouteCoordinates;
            }
            set
            {
                _RouteCoordinates = value;
            }
        }

        public bool _IsSuscribed;

        public bool IsSuscribed
        {
            get
            {
                return _IsSuscribed;
            }
            set
            {
                _IsSuscribed = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsSuscribed)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsNotSuscribed)));
            }
        }
        public bool IsNotSuscribed
        {
            get
            {
                return !IsSuscribed;
            }
        }

        private int? _SubscriptionId;
        public int? SubscriptionId
        {
            get { return _SubscriptionId; }
            set
            {
                _SubscriptionId = value;

                if (value > 0)
                {
                    IsSuscribed = true;
                }
                else
                {
                    IsSuscribed = false;
                }
            }
        }

        public int RouteId { get; set; }
        public string Name { get; set; }

        public Command SubscribeCommand { get; set; }
        public Command UnsubscribeCommand { get; set; }

        public RouteViewModel()
        {
            SubscribeCommand = new Command(SubscribeToRoute);
            UnsubscribeCommand = new Command(UnsubscribeFromRoute);
        }

        private async void UnsubscribeFromRoute()
        {
            var repository = App.DependencyContainer.Resolve<IRouteRepository>();

            var sessionData = App.DependencyContainer.Resolve<ISessionData>();

            await repository.Unsubscribe(SubscriptionId.Value);

            SubscriptionId = null;

            IsSuscribed = false;
        }

        private async void SubscribeToRoute()
        {
            var repository = App.DependencyContainer.Resolve<IRouteRepository>();
            var sessionData = App.DependencyContainer.Resolve<ISessionData>();

            var subscriptionDTO = new SubscriptionDTO()
            {
                UserId = sessionData.User.UserId,
                RouteId = RouteId
            };

            var subscription = await repository.Subscribe(subscriptionDTO);

            SubscriptionId = subscription.SubscriptionId;

            IsSuscribed = true;
        }
    }
}
