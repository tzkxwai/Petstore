using BaseTest.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetstoreTests.Services
{
    public class PetService
    {
        private readonly RestClient _client;

        public PetService(RestClient client)
        {
            _client = client;
        }

        public RestResponse CreatePet(Pet pet)
        {
            var request = new RestRequest("pet", Method.Post);
            request.AddJsonBody(pet);
            return _client.Execute(request);
        }

        public RestResponse<Pet> GetPet(long id)
        {
            var request = new RestRequest($"pet/{id}", Method.Get);
            return _client.Execute<Pet>(request);
        }

        public RestResponse DeletePet(long id)
        {
            var request = new RestRequest($"pet/{id}", Method.Delete);
            return _client.Execute(request);
        }
    }
}
