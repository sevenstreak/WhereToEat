using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Plugin.Geolocator;
using WhereToEat.Logic;



namespace WhereToEat
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {

            base.OnAppearing();

            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync();

            var venues = WhereToEat.Logic.VenueLogic.GetVenues(position.Latitude, position.Longitude);
            

        }

        async void searchBtn(object sender, System.EventArgs e)
        {

            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync();

            var venues = VenueLogic.GetVenues(position.Longitude, position.Latitude);


        }
    }
}
