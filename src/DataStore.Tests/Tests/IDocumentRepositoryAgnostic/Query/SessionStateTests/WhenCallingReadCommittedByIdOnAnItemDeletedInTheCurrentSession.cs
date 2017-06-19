using System;
using DataStore.Tests.Models;
using DataStore.Tests.TestHarness;
using Newtonsoft.Json;
using Xunit;

namespace DataStore.Tests.Tests.IDocumentRepositoryAgnostic.Query.SessionStateTests
{
    public class WhenCallingReadCommittedByIdOnAnItemDeletedInTheCurrentSession
    {
        public WhenCallingReadCommittedByIdOnAnItemDeletedInTheCurrentSession()
        {
            // Given
            var testHarness = TestHarnessFunctions.GetTestHarness(
                nameof(WhenCallingReadCommittedByIdOnAnItemDeletedInTheCurrentSession));

            carId = Guid.NewGuid();
            var existingCar = new Car
            {
                id = carId,
                Active = false,
                Make = "Volvo"
            };
            testHarness.AddToDatabase(existingCar);

            testHarness.DataStore.DeleteHardById<Car>(carId).Wait();

            // When
            var document = testHarness.DataStore.Advanced.ReadCommittedById<Car>(carId).Result;
            try
            {
                carFromDatabase = document; //this approach is for Azure
            }
            catch (Exception)
            {
                carFromDatabase = JsonConvert.DeserializeObject<Car>(JsonConvert.SerializeObject(document));
            }
        }

        private readonly Car carFromDatabase;
        private readonly Guid carId;

        [Fact]
        public void ItShouldReturnTheItem()
        {
            Assert.Equal("Volvo", carFromDatabase.Make);
            Assert.Equal(carId, carFromDatabase.id);
        }
    }
}