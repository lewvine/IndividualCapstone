﻿using GoogleMapsApi;
using GoogleMapsApi.Entities.Geocoding.Request;
using GoogleMapsApi.Entities.Geocoding.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace CapstoneProject.Models
{
    public class Project
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsSold { get; set; }
        public int SquareFootage { get; set; }
        public bool IsProjectAreaCleared {get;set;}
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public double Cost { get; set; }
        public string StreetAddress { get; set; }
        public string CityAddress { get; set; }
        public string StateAddress { get; set; }
        public string ZipAddress { get; set; }
        public double? LatAddress { get; set; }
        public double? LongAddress { get; set; }
        public ICollection<Appointment> Appointments { get; set; }

        [ForeignKey("Customer")]
        public int CustID { get; set; }
        public Customer Customer { get; set; }

        [ForeignKey("Salesperson")]
        public int SalesID { get; set; }
        public Salesperson Salesperson { get; set; }

        [ForeignKey("Grass")]
        public int GrassID { get; set; }
        public Grass Grass { get; set; }

        public void SetGeocode(string address)
        {
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

        public void SendText(string body)
        {
            string accountSid = Utilities.APIs.TwilioAccountSID;
            string authToken = Utilities.APIs.TwilioAuthToken;

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: body,
                from: new Twilio.Types.PhoneNumber(Utilities.APIs.TwilioPhoneNumber),
                to: new Twilio.Types.PhoneNumber("[1][828][4579615]")
                );

        }
    }
}
