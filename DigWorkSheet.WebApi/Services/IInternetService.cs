using DigWorkSheet.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigWorkSheet.WebApi.Services
{
    public interface IInternetService
    {
        List<Model.Internet> Get(InternetSearchRequest request);

        Model.Internet Insert(Model.Internet internet);

        Model.Internet Update(int id, Model.Internet internet);

        List<Model.Internet> Delete(int id);

    }
}
