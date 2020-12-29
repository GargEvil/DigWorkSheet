using DigWorkSheet.WebApi.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigWorkSheet.WebApi.Services
{
    public class ContractService : IContractService
    {
        private readonly DigWorkSheetContext _context;

        public ContractService(DigWorkSheetContext context)
        {
            _context = context;
        }
        //Use AutoMapper OOBAVEZNOOOOO
        public List<Model.Contract> Get()
        {
            var list = _context.Contracts.ToList();

            List<Model.Contract> result = new List<Model.Contract>();

            foreach (var item in list)
            {
                result.Add(new Model.Contract()
                {
                    Id=item.Id,
                    Content = item.Content,
                    NumberOfContract = item.NumberOfContract,
                });
            }
            return result;
        }
    }

}