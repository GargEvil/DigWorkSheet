using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigWorkSheet.WebApi.Services
{
    public interface IOfferService
    {
        List<Model.Offer> Get();
      
        Model.Offer Insert(Model.Offer offer);
       
        Model.Offer Update(int id, Model.Offer offer);
        
        List<Model.Offer> Delete(int id);
        
    }
}
