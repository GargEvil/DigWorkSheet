using AutoMapper;
using DigWorkSheet.Model;
using DigWorkSheet.Model.Requests;
using DigWorkSheet.WebApi.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigWorkSheet.WebApi.Services
{
    public class InternetService : IInternetService
    {
        private readonly DigWorkSheetContext _internet;
        private readonly IMapper _mapper;

        public InternetService(DigWorkSheetContext internet, IMapper mapper)
        {
            _internet = internet;
            _mapper = mapper;
        }

        public List<Model.Internet> Delete(int id)
        {
            var InternetEntity = _internet.Internets.Find(id);

            _internet.Internets.Remove(InternetEntity);

            _internet.SaveChanges();

            var list = _internet.Internets.ToList();

            return _mapper.Map<List<Model.Internet>>(list);


        }

        public List<Model.Internet> Get(InternetSearchRequest request)
        {
            var query = _internet.Internets.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request?.Name))
            {
                query = query.Where(x => x.Name.Contains(request.Name));
            }



            var list = query.ToList();

            return _mapper.Map<List<Model.Internet>>(list);
        }

        public Model.Internet Insert(Model.Internet internet)
        {
            var InternetEntity = _mapper.Map<Database.Internet>(internet);

            _internet.Internets.Add(InternetEntity);
            _internet.SaveChanges();

            return _mapper.Map<Model.Internet>(InternetEntity);
        }

        public Model.Internet Update(int id, Model.Internet internet)
        {
            var internetEntity = _internet.Internets.Find(id);

            _internet.Internets.Attach(internetEntity);
            _internet.Internets.Update(internetEntity);

            _mapper.Map(internet, internetEntity);

            _internet.SaveChanges();

            return _mapper.Map<Model.Internet>(internetEntity);
        }
    }
}
