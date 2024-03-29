﻿using System;
using System.Collections.Generic;
using WhereToEat.Helper;

namespace WhereToEat.Model
{
    public class VenueRoot
    {
        public Response response { get; set; }

        public static string GenerateURL(double longitude, double latitude)
        {
            return String.Format(Constants.address, longitude, latitude, Constants.cID, Constants.cSECRET, DateTime.Now.ToString("yyyyMMdd"));
        }
    }
}

    public class Location
    {
        public double lat { get; set; }
        public double lng { get; set; }
        public int distance { get; set; }
        public string postalCode { get; set; }
        public string cc { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public IList<string> formattedAddress { get; set; }
        public string address { get; set; }
    }

    public class Category
    {
        public string id { get; set; }
        public string name { get; set; }
        public string pluralName { get; set; }
        public string shortName { get; set; }
        public bool primary { get; set; }
    }

public class Photos
{
    public int count { get; set; }
    public IList<object> groups { get; set; }
}

public class Venue
    {
        public string id { get; set; }
        public string name { get; set; }
        public Location location { get; set; }
        public IList<Category> categories { get; set; }
    public Photos photos { get; set; }
    public static implicit operator List<object>(Venue v)
    {
        throw new NotImplementedException();
    }
}

    public class Response
    {
        public IList<Venue> venues { get; set; }
    }


