using Allure.Net.Commons;
using Allure.NUnit.Attributes;
using BaseTest.Models;
using BaseTest.Validators;
using NUnit.Framework;
using FluentValidation.Results;
using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetstoreTests.Tests
{
    public class PetTests : BaseTest
    {
        [Test]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("QA Team")]
        [AllureTag("API", "E2E", "Pet")]
        public void Create_Get_Delete_Pet_E2E()
        {
            var pet = new Pet
            {
                Id = DateTime.Now.Ticks,
                Name = "SuperDog",
                Status = "available",
                Category = new Category
                {
                    Id = 1,
                    Name = "Dogs"
                }
            };

            // 🔹 1. Валидация
            var validator = new PetValidator();
            ValidationResult result = validator.Validate(pet);

            Assert.That(result.IsValid, Is.True, result.ToString());

            // 🔹 2. Create
            var createResponse = petService.CreatePet(pet);
            Assert.That(createResponse.StatusCode,
                Is.EqualTo(System.Net.HttpStatusCode.OK));

            // 🔹 3. Get
            var getResponse = petService.GetPet(pet.Id);

            Assert.That(getResponse.Data.Name, Is.EqualTo(pet.Name));
            Assert.That(getResponse.Data.Status, Is.EqualTo("available"));

            // 🔹 4. Delete
            var deleteResponse = petService.DeletePet(pet.Id);
            Assert.That(deleteResponse.StatusCode,
                Is.EqualTo(System.Net.HttpStatusCode.OK));
        }
    }
}
