using System;
using System.Collections.Generic;
using System.Linq;
using TH.Domain.Other;

namespace TH.Interfaces
{
    public interface IWardBusinessLogic
    {
        List<Domain.Other.Ward> GetAllWards();
        bool CreateOrUpdateWard(Ward ward);
    }
}
