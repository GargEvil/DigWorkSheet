using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigWorkSheet.Model.Requests;
using DigWorkSheet.WebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigWorkSheet.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InternetController : ControllerBase
    {
        private readonly IInternetService _internet;

        public InternetController(IInternetService internet)
        {
            _internet = internet;
        }

        [HttpGet]
        public List<Model.Internet> Get([FromQuery] InternetSearchRequest request)
        {
            return _internet.Get(request);
        }

        [HttpPost]
        public Model.Internet Insert (Model.Internet internet)
        {
            return _internet.Insert(internet);
        }

        [HttpPut("{id}")]
        public Model.Internet Update (int id, Model.Internet internet)
        {
            return _internet.Update(id, internet);
        }

        [HttpDelete("{id}")]
        public List<Model.Internet> Delete (int id)
        {
            return _internet.Delete(id);
        }
    }
}
