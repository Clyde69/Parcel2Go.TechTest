using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parcel2Go.TechTest.Services;
using Parcel2Go.TestTest.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcel2Go.TechTest.Services.Tests
{
    [TestClass()]
    public class CostCalculationServiceTests
    {
        [TestMethod()]
        public void ItemTotalCostTest_AllPricesAvailable_ReturnsExpected()
        {
            //  Arrange
            var objectUnderTest = new CostCalculationService();

            var transactionItem = new TransactionItem(TestTest.Entities.Enums.InventoryType.None, 10);
            var prices = new List<Price>()
            {
                new Price(1, 2), new Price(3, 5)
            };
            var expectedCost = 17m;

            //  Act
            var result = objectUnderTest.ItemTotalCost(transactionItem, prices);

            //  Assert
            result.Should().Be(expectedCost);
        }

        [TestMethod()]
        public void ItemTotalCostTest_MissingPrice_ThrowsException()
        {
            //  Arrange
            var objectUnderTest = new CostCalculationService();

            var transactionItem = new TransactionItem(TestTest.Entities.Enums.InventoryType.None, 10);
            var prices = new List<Price>()
            {
                new Price(3, 5)
            };
            var expectedException = "Missing pricing for 1 unit(s).";
            var caughtExceptionMessage = string.Empty;

            //  Act
            try
            {
                objectUnderTest.ItemTotalCost(transactionItem, prices);
            }
            catch(Exception ex)
            {
                caughtExceptionMessage = ex.Message;
            }

            //  Assert
            caughtExceptionMessage.Should().Be(expectedException);
        }
    }
}