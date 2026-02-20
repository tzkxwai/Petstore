using Allure.NUnit;
using RestSharp;
using NUnit.Framework;
using PetstoreTests.Services;


namespace PetstoreTests
{
    [AllureNUnit]
    public class BaseTest
    {
        protected RestClient client;
        protected PetService petService;

        [SetUp]
        public void Setup()
        {
            client = new RestClient("https://petstore.swagger.io/v2");
            petService = new PetService(client);
        }

        [TearDown]
        public void Teardown()
        {
            client?.Dispose();
        }
    }
}