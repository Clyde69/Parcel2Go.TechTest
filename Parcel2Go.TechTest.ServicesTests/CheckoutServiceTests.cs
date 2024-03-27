using AutoFixture;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Parcel2Go.TechTest.Interfaces;
using Parcel2Go.TechTest.Services;
using Parcel2Go.TestTest.Entities.Enums;
using Parcel2Go.TestTest.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcel2Go.TechTest.Services.Tests
{
    [TestClass()]
    public class CheckoutServiceTests
    {
        [TestMethod()]
        public void NewTransactionTest()
        {
            //  Arrange
            var inventoryRepo = Substitute.For<IInventoryRepository>();
            var costCalcService = Substitute.For<ICostCalculationService>();
            var objectUnderTest = new CheckoutService(inventoryRepo, costCalcService);

            var originalTransRef = objectUnderTest.Transaction.Reference;

            //  Act
            objectUnderTest.NewTransaction();

            //  Assert
            objectUnderTest.Transaction.Reference.Should().NotBe(originalTransRef);
        }

        [TestMethod()]
        public void ScanTest()
        {
            //  Arrange
            var inventoryRepo = Substitute.For<IInventoryRepository>();
            var costCalcService = Substitute.For<ICostCalculationService>();
            var objectUnderTest = new CheckoutService(inventoryRepo, costCalcService);

            //  Act
            objectUnderTest.Scan(InventoryType.ServiceA, 2);

            //  Assert
            objectUnderTest.Transaction.TransactionItems.Count().Should().Be(1);
            objectUnderTest.Transaction.TransactionItems.FirstOrDefault().InventoryItem.Should().Be(InventoryType.ServiceA);
            objectUnderTest.Transaction.TransactionItems.Sum(s => s.Quantity).Should().Be(2);
        }

        [TestMethod()]
        public async Task GetTotalPriceAsyncTest()
        {
            //  Arrange
            var inventoryRepo = Substitute.For<IInventoryRepository>();
            var costCalcService = Substitute.For<ICostCalculationService>();
            var objectUnderTest = new CheckoutService(inventoryRepo, costCalcService);

            var invPrices = new List<InventoryPrice>() {
                    new InventoryPrice(InventoryType.ServiceA, new List<Price>{ new Price(1, 10), new Price(3, 35) }),
                    new InventoryPrice(InventoryType.ServiceB, new List<Price>{ new Price(1, 10), new Price(3, 35) }),
                    new InventoryPrice(InventoryType.ServiceC, new List<Price>{ new Price(1, 15) }),
                    new InventoryPrice(InventoryType.ServiceD, new List<Price>{ new Price(1, 25) }),
                    new InventoryPrice(InventoryType.ServiceF, new List<Price>{ new Price(1, 8), new Price(2, 15) })
                }.ToDictionary(s => s.Type, s => s);

            inventoryRepo.GetInventoryPricesAsync()
                .Returns(invPrices);
            costCalcService.ItemTotalCost(Arg.Any<TransactionItem>(), Arg.Any<IEnumerable<Price>>())
                .Returns(10);

            objectUnderTest.Transaction.TransactionItems = new List<TransactionItem>() { 
                new TransactionItem(InventoryType.ServiceA, 2),
                new TransactionItem(InventoryType.ServiceB, 2),
                new TransactionItem(InventoryType.ServiceA, 1),
                new TransactionItem(InventoryType.ServiceC, 5)
            };  

            //  Act
            var totalPrice = await objectUnderTest.GetTotalPriceAsync();

            //  Assert
            totalPrice.Should().Be(30m);
            inventoryRepo.ReceivedCalls().Count().Should().Be(1);
            costCalcService.ReceivedCalls().Count().Should().Be(3);
        }
    }
}