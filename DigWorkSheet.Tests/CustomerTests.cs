using AutoMapper;
using DigWorkSheet.Model.Requests;
using DigWorkSheet.WebApi.Database;
using DigWorkSheet.WebApi.Services;
using System.Collections.Generic;
using Xunit;

namespace DigWorkSheet.Tests
{
    public class CustomerTests : IClassFixture<DigWorkSheetContext>, IClassFixture<Mapper>
    {
        private readonly DigWorkSheetContext _context;
        private readonly IMapper _mapper;

        public CustomerTests(DigWorkSheetContext context, IMapper mapper)
        {
            _context = context; 
            _mapper = mapper;   
        }

        [Fact]
        public void ShouldGetAllCustomers()
        {
            //Arrange

            List<Model.Customer> expected = new List<Model.Customer>();
            var search = new CustomerSearchRequest
            {
                Search = "E"
            };

            //Act

            var customerService = new CustomerService(_context, _mapper);
            var actual = customerService.Get(search);

            //Assert

            Assert.Equal(expected, actual.Result);
        }
    }
}
