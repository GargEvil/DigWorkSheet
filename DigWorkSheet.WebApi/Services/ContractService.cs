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

        public List<Model.Contracts> Get()
        {
            var list = _context.Contracts.ToList();

            List<Model.Contracts> result = new List<Model.Contracts>();

            foreach (var item in list)
            {
                result.Add(new Model.Contracts()
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