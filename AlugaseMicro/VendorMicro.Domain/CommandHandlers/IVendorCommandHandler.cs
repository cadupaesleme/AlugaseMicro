using System;
using System.Collections.Generic;
using System.Text;
using VendorMicro.Domain.Commands;

namespace VendorMicro.Domain.CommandHandlers
{
    public interface IVendorCommandHandler
    {
        void Handle(VendorCommand command);
    }
}
