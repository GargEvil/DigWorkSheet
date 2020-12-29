using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using DigWorkSheet.WebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace DigWorkSheet.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private readonly IContractService _contract;

        public ContractController(IContractService contract)
        {
            _contract = contract;
        }

        [HttpGet]

        public ActionResult<List<Model.Contract>> Get()
        {
            return _contract.Get();
        }

    }
}
