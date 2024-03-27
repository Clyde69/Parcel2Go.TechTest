using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parcel2Go.TechTest.Repositories;
using Parcel2Go.TestTest.Entities.Enums;
using Parcel2Go.TestTest.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcel2Go.TechTest.Repositories.Tests
{
    [TestClass()]
    public class HardCodedInventoryRepositoryTests
    {
        [TestMethod()]
        public async Task GetInventoryPricesAsyncTest()
        {
            //  Arrange
            var objectUnderTest = new HardCodedInventoryRepository();
            var expectedResults = new Dictionary<InventoryType, InventoryPrice>();
            expectedResults.Add(InventoryType.ServiceA, new InventoryPrice(InventoryType.ServiceA, new List<Price> { new Price(1, 10), new Price(3, 35) }));
            expectedResults.Add(InventoryType.ServiceB, new InventoryPrice(InventoryType.ServiceB, new List<Price> { new Price(1, 10), new Price(3, 35) }));
            expectedResults.Add(InventoryType.ServiceC, new InventoryPrice(InventoryType.ServiceC, new List<Price> { new Price(1, 15) }));
            expectedResults.Add(InventoryType.ServiceD, new InventoryPrice(InventoryType.ServiceD, new List<Price> { new Price(1, 25) }));
            expectedResults.Add(InventoryType.ServiceF, new InventoryPrice(InventoryType.ServiceF, new List<Price> { new Price(1, 8), new Price(2, 15) }));
            
            //  Act
            var results = await objectUnderTest.GetInventoryPricesAsync();

            //  Assert
            results.Should().BeEquivalentTo(expectedResults);
        }
    }
}