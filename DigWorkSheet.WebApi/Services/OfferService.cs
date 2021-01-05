using AutoMapper;
using DigWorkSheet.Model;
using DigWorkSheet.WebApi.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigWorkSheet.WebApi.Services
{
    public class OfferService : IOfferService
    {
        private readonly DigWorkSheetContext _context;
        private readonly IMapper _mapper;

        public OfferService(DigWorkSheetContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

      

        public List<Model.Offer> Get()
        {
            var list = _context.Offers.ToList();

            return _mapper.Map<List<Model.Offer>>(list);
        }

        public Model.Offer Insert(Model.Offer offer)
        {
            var offerEntity = _mapper.Map<Database.Offer>(offer);

            _context.Offers.Add(offerEntity);
            _context.SaveChanges();

            return _mapper.Map<Model.Offer>(offerEntity);
        }

        public Model.Offer Update(int id, Model.Offer offer)
        {
            var entity = _context.Offers.Find(id);

            _context.Offers.Attach(entity);
            _context.Offers.Update(entity);

            _mapper.Map(offer, entity);

            _context.SaveChanges();

            return _mapper.Map<Model.Offer>(entity);
        }

        public List<Model.Offer> Delete(int id)
        {
            var entity = _context.Offers.Find(id);

            _context.Remove(entity);
            _context.SaveChanges();

            var list = _context.Offers.ToList();

            return _mapper.Map<List<Model.Offer>>(list);
        }
    }
}
