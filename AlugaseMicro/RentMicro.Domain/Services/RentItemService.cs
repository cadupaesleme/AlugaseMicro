using System;
using System.Collections.Generic;
using System.Text;
using RentMicro.Domain.Interfaces;
using RentMicro.Domain.RentAggregate;

namespace RentItemMicro.Domain.Services
{
    public class RentItemService : IRentItemService
    {
        private readonly IRentItemRepository _RentItemRepository;

        public RentItemService(IRentItemRepository RentItemRepository)
        {
            _RentItemRepository = RentItemRepository;
        }

        public IEnumerable<RentItem> ReadAll()
        {
            return _RentItemRepository.ReadAll();
        }

        public void Create(RentItem RentItem)
        {
            RentItem.Id = new Guid();
            _RentItemRepository.Create(RentItem);
        }

        public void Update(RentItem RentItem)
        {
            _RentItemRepository.Update(RentItem);
        }

        public RentItem Read(Guid id)
        {
            return _RentItemRepository.Read(id);
        }

        public void Delete(Guid id)
        {
            _RentItemRepository.Delete(id);
        }

        public void Complete()
        {
            _RentItemRepository.SaveChanges();
        }
    }

}
