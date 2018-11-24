using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WhereToEat.Model;
using Newtonsoft.Json;

namespace WhereToEat.Logic
{
    public class VenueLogic
    {
        public async static Task<List<Venue>> GetVenues( double lattitude, double longitude)
        {
            List<Venue> venues = new List<Venue>();

            var url = VenueRoot.GenerateURL(lattitude, longitude);

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();

                var venueRoot = JsonConvert.DeserializeObject<VenueRoot>(json);

                venues = venueRoot.response.venues as List<Venue>;
            }
            return venues;
        }
    }
}
