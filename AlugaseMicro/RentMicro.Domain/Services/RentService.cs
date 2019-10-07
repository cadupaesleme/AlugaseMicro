using System;
using System.Collections.Generic;
using System.Text;
using RentMicro.Domain.Interfaces;
using RentMicro.Domain.RentAggregate;

namespace RentMicro.Domain.Services
{
    public class RentService : IRentService
    {
        private readonly IRentRepository _RentRepository;

        public RentService(IRentRepository RentRepository)
        {
            _RentRepository = RentRepository;
        }

        public IEnumerable<Rent> ReadAll()
        {
            return _RentRepository.ReadAll();
        }

        public void Create(Rent Rent)
        {
            Rent.Id = new Guid();
            _RentRepository.Create(Rent);
        }

        public void Update(Rent Rent)
        {
            _RentRepository.Update(Rent);
        }

        public Rent Read(Guid id)
        {
            return _RentRepository.Read(id);
        }

        public void Delete(Guid id)
        {
            _RentRepository.Delete(id);
        }

        public void Complete()
        {
            _RentRepository.SaveChanges();
        }
    }

}
