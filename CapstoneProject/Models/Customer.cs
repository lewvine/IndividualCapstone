using GoogleMapsApi;
using GoogleMapsApi.Entities.Geocoding.Request;
using GoogleMapsApi.Entities.Geocoding.Response;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneProject.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetAddress { get; set; }
        public string CityAddress { get; set; }
        public string StateAddress { get; set; }
        public string ZipAddress { get; set; }
        public double? LatAddress { get; set; }
        public double? LongAddress { get; set; }
        public string EMailAddress{ get; set; }
        public string PhoneNumber { get; set; }

        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }

        public void SetGeocode(string StreetAddress, string CityAddress, string StateAddress, string ZipAddress)
        {
            string address = StreetAddress + ", " + CityAddress + ", " + StateAddress + " " + ZipAddress;
            GeocodingRequest geocodeRequest = new GeocodingRequest()
            {
                Address = address,
                ApiKey = Utilities.APIs.MapsKey,
                SigningKey = "Lew Vine"
            };
            var geoCodingEngine = GoogleMaps.Geocode;
            GeocodingResponse geocode = geoCodingEngine.Query(geocodeRequest);
            this.LatAddress = geocode.Results.First().Geometry.Location.Latitude;
            this.LongAddress = geocode.Results.First().Geometry.Location.Longitude;
        }

        public string GetGeocode()
        {
            string address = "(" + this.LatAddress.ToString() + "," + this.LongAddress.ToString() + ")";
            return address;
        }

    }
}
