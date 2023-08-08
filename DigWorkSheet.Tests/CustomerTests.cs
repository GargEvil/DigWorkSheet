using AutoMapper;
using DigWorkSheet.Model.Requests;
using DigWorkSheet.Tests.Helpers;
using DigWorkSheet.WebApi.Database;
using DigWorkSheet.WebApi.Services;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace DigWorkSheet.Tests
{
    public class CustomerTests
    {
        private readonly Mock<DigWorkSheetContext> _contextMock = new Mock<DigWorkSheetContext>();
        private readonly Mock<IMapper> _mapperMock = new Mock<IMapper>();

        [Fact]
        public void ShouldGetAllCustomers()
        {
            //Arrange
            List<Model.Customer> expected = new List<Model.Customer>();
            var search = new CustomerSearchRequest
            {
                Search = ""
            };

            //Act
            var customerService = new CustomerService(_contextMock.Object, _mapperMock.Object);
            var actual = customerService.Get(search);


            //Assert
            Assert.Equal(expected.Count, actual.Result.Count);
        }
    }
}
