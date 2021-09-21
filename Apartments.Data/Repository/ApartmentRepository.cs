using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Apartments.Application.Interfaces;

namespace Apartments.Data.Repository
{
    public class ApartmentRepository: IApartmentRepository
    {
        private readonly HttpClient _client;
        public ApartmentRepository(HttpClient client)
        {
            _client = client;
        }

        public async Task<string> GetApartments(string Apartment, int Limit)
        {
            using (var request = new HttpRequestMessage(HttpMethod.Get, _client.BaseAddress))
            {
                request.Content = new StringContent(ReadJSON(Apartment,Limit), Encoding.UTF8, "application/json");
                var response = await _client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                return content;
            }
        }

        public string ReadJSON(string apartment,int limit)
        {
            if (limit == 0 || (limit>25)) limit = 25;

            string jsonString = "{\"_source\":{\"includes\":[\"property.name\",\"property.market\",\"property.state\",\"mgmt.name\",\"mgmt.market\",\"mgmt.state\"]},\"size\":" 
                + limit + ",\"query\": {\"bool\": {\"should\": [{\"match\": {\"mgmt.name\": \"" + apartment + "*\"}},{\"match\": {\"property.name\": \""+ apartment + "*\"}}]}}}";
            
            return jsonString;
        }
    }
}
