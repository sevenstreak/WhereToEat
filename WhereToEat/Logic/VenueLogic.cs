using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WhereToEat.Model;
using Newtonsoft.Json;
using Xamarin.Forms;
using System.Linq;
using System.Diagnostics.Contracts;

namespace WhereToEat.Logic
{
    public class VenueLogic
    {
        public async static Task<List<Venue>> GetVenues(double lattitude, double longitude)
        {
            Contract.Ensures(Contract.Result<Venue>() != null);
            List<Venue> venues = new List<Venue>();
            try
            {


                var url = VenueRoot.GenerateURL(lattitude, longitude);

                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(url);
                    var json = await response.Content.ReadAsStringAsync();

                    var venueRoot = JsonConvert.DeserializeObject<VenueRoot>(json);

                    venues = venueRoot.response.venues as List<Venue>;

                }
                var rdms = new Random();
                var rdmVenues = venues[rdms.Next(0,30)];
                return venues;
               
            }
            catch (Exception ex)
            {
                // DisplayAlert("Error", "Wifi connection may have security settings that blocks app", "ok");
                Console.WriteLine(ex);
            }
            var rdm = new Random();
            var rdmVenue = venues[rdm.Next(0, 30)];
            return venues;
        }


    }
}
