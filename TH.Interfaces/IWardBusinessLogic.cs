using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.Domain.Other;

namespace TH.Interfaces
{
    public interface IWardBusinessLogic
    {
        List<Domain.Other.Ward> GetAllWards();
        bool CreateOrUpdateWard(Ward ward);
    }
}
