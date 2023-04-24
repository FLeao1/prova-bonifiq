using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProvaPub.Models;
using ProvaPub;
using ProvaPub.Repository;
using ProvaPub.Services;
using Xunit;
using Moq;

namespace Tests
{
    public class CustomerServiceTests
    {
        [Fact]
        public async Task CanPurchase_ReturnsTrue_WhenCustomerCanPurchase()
        {
            // Arrange
            int customerId = 1;
            decimal purchaseValue = 100;
            var dbContextMock = new Mock<TestDbContext>();
            var customerService = new CustomerService(dbContextMock.Object);
            dbContextMock.Setup(db => db.Customers.FindAsync(customerId))
                .ReturnsAsync(new Customer { Id = customerId, Balance = 200 });

            // Act
            var result = await customerService.CanPurchase(customerId, purchaseValue);

            // Assert
            Xunit.Assert.True(result);
        }

        [Fact]
        public async Task CanPurchase_ReturnsFalse_WhenCustomerCannotPurchase()
        {
            // Arrange
            int customerId = 1;
            decimal purchaseValue = 1000;
            var dbContextMock = new Mock<TestDbContext>();
            var customerService = new CustomerService(dbContextMock.Object);
            dbContextMock.Setup(db => db.Customers.FindAsync(customerId))
                .ReturnsAsync(new Customer { Id = customerId, Balance = 200 });

            // Act
            var result = await customerService.CanPurchase(customerId, purchaseValue);

            // Assert
            Xunit.Assert.False(result);
        }
    }
}