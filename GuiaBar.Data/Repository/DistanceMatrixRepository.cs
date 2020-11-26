using System;
using System.Net.Http;
using System.Text.Json;
using System.Web;
using GuiaBar.Domain.Entities;
using GuiaBar.Domain.Interface;

namespace GuiaBar.Data.Repository
{
    public class DistanceMatrixRepository : IDistanceMatrixRepository
    {
        private readonly HttpClient client;

        public DistanceMatrixRepository()
        {
            this.client = new HttpClient();
        }

        public Root GetRoute(string userAddress, string pubAddress)
        {
            string key = Environment.GetEnvironmentVariable("API_AUTOTAG_KEY");
            string origins = HttpUtility.UrlEncode($"{userAddress}");
            string destination = HttpUtility.UrlEncode($"{pubAddress}");
            string url = $"https://maps.googleapis.com/maps/api/distancematrix/json?units=metric&origins={origins}&destinations={destination}&key={key}";

            string distanceMatrixResponse = client.GetStringAsync(url).Result;

            Root elements = JsonSerializer.Deserialize<Root>(distanceMatrixResponse);

            return elements;
        
        }


        
    }
}