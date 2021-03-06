﻿using DigWorkSheet.Model.Requests;
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
        public async Task<ObjectResult> Get([FromQuery] CustomerSearchRequest request)
        {
            var customers = await _customer.Get(request);

            return Ok(customers);
        }

        [HttpPost]
        public Model.Customer Insert(Model.Customer customer)
        {
            return _customer.Insert(customer);
        }

        [HttpGet("{id}")]
        public Model.Customer GetById(int id)
        {
            return _customer.GetById(id);
        }

        [HttpPut("{id}")]
        public Model.Customer Update(int id, Model.Customer customer)
        {
            return _customer.Update(id, customer);
        }

        [HttpDelete("{id}")]
        public List<Model.Customer> Delete(int id)
        {
            return _customer.Delete(id);
        }

        [HttpGet("GetByName/{name})")]
        public List<Model.Customer> GetByName( string name)
        {
            return _customer.GetByName(name);
        }
        
    }
}
