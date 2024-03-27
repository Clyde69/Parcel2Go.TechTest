using FluentAssertions;
using Parcel2Go.TechTest.Interfaces;
using Parcel2Go.TechTest.Repositories;
using Parcel2Go.TechTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcel2Go.TechTest.ServicesTests
{
    [TestClass()]
    public class ExampleTests
    {
        [TestMethod()]
        public async Task Example1()
        {
            //  Arrange
            var repo = new HardCodedInventoryRepository();
            var calcService = new CostCalculationService();
            var objectUnderTest = new CheckoutService(repo, calcService);

            objectUnderTest.NewTransaction();
            objectUnderTest.Scan(TestTest.Entities.Enums.InventoryType.ServiceB, 2);

            //  Act
            var total = await objectUnderTest.GetTotalPriceAsync();

            //  Assert
            total.Should().Be(20m);
        }

        [TestMethod()]
        public async Task Example2()
        {
            //  Arrange
            var repo = new HardCodedInventoryRepository();
            var calcService = new CostCalculationService();
            var objectUnderTest = new CheckoutService(repo, calcService);

            objectUnderTest.NewTransaction();
            objectUnderTest.Scan(TestTest.Entities.Enums.InventoryType.ServiceF, 1);
            objectUnderTest.Scan(TestTest.Entities.Enums.InventoryType.ServiceC, 1);

            //  Act
            var total = await objectUnderTest.GetTotalPriceAsync();

            //  Assert
            total.Should().Be(23m);
        }

        [TestMethod()]
        public async Task Example3()
        {
            //  Arrange
            var repo = new HardCodedInventoryRepository();
            var calcService = new CostCalculationService();
            var objectUnderTest = new CheckoutService(repo, calcService);

            objectUnderTest.NewTransaction();
            objectUnderTest.Scan(TestTest.Entities.Enums.InventoryType.ServiceF, 2);
            objectUnderTest.Scan(TestTest.Entities.Enums.InventoryType.ServiceB, 1);

            //  Act
            var total = await objectUnderTest.GetTotalPriceAsync();

            //  Assert
            total.Should().Be(27m);
        }
    }
}
