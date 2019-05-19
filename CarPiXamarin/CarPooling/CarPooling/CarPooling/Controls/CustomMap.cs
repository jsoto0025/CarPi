using CarPooling.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using System.Linq;

namespace CarPooling.Controls
{
    public class CustomMap : Map
    {
        public ObservableCollection<Position> RouteCoordinates { get; set; }

        public static readonly BindableProperty RouteCoordinatesProperty = BindableProperty.Create(
                nameof(RouteCoordinates),
                typeof(ObservableCollection<Position>),
                declaringType: typeof(CustomMap),
                defaultValue: null,
                defaultBindingMode: BindingMode.TwoWay,
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    var map = (CustomMap)bindable;
                    map.RouteCoordinates = (ObservableCollection<Position>)newValue;
                    map.MoveToRegion(MapSpan.FromCenterAndRadius(map.RouteCoordinates.First(), Distance.FromKilometers(1)));
                }
            );

        public CustomMap()
        {
            RouteCoordinates = new ObservableCollection<Position>();
        }
    }
}
