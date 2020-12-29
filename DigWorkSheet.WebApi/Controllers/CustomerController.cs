using DigWorkSheet.WebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigWorkSheet.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customer;

        public CustomerController(ICustomerService customer)
        {
            _customer = customer;
        }

        [HttpGet]

        public ActionResult<List<Model.Customer>> Get()
        {
            return _customer.Get();
        }

    }
}
