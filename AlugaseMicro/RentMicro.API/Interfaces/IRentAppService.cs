using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RentMicro.API.Models;

namespace RentMicro.API.Interfaces
{
    public interface IRentAppService
    {
        IEnumerable<RentViewModel> ReadAll();
        RentViewModel Read(Guid id);
        void Update(RentViewModel RentViewModel);
        void Delete(Guid id);
        void Create(RentViewModel RentViewModel);
    }
}
