
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigWorkSheet.WebApi.Services
{
    public interface IContractService
    {
        List<Model.Contracts> Get();
    }
}
