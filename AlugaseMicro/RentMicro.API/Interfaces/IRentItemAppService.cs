using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RentMicro.API.Models;

namespace RentMicro.API.Interfaces
{
    public interface IRentItemAppService
    {
        IEnumerable<RentItemViewModel> ReadAll();
        RentItemViewModel Read(Guid id);
        void Update(RentItemViewModel RentItemViewModel);
        void Delete(Guid id);
        void Create(RentItemViewModel RentItemViewModel);
    }
}
