using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigWorkSheet.WebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigWorkSheet.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private readonly IOfferService _offer;

        public OfferController( IOfferService offer)
        {
            _offer = offer;
        }

        [HttpGet]
        public List<Model.Offer> Get()
        {
            return _offer.Get();
        }

        [HttpPost]
        public Model.Offer Insert(Model.Offer offer)
        {
            return _offer.Insert(offer);
        }

        [HttpPut("{id}")]

        public Model.Offer Update(int id, Model.Offer offer)
        {
            return _offer.Update(id, offer);
        }

        [HttpDelete("{id}")]
        public List<Model.Offer> Delete (int id)
        {
            return _offer.Delete(id);
        }
    }
}
