using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Plugin.Geolocator;
using WhereToEat.Logic;
using WhereToEat.Model;
using Plugin.Permissions;
using Android;


namespace WhereToEat
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();


        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        async void searchBtn(object sender, System.EventArgs e)
        {
        
            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync();

            var venues = await VenueLogic.GetVenues(position.Latitude, position.Longitude);

            var rdm = new Random();
            venues = venues.GetRange(rdm.Next(0,29),1);
            venueList.ItemsSource = venues;

            //cellImage.Source = venues.

        }
    }
}
