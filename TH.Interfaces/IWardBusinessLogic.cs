using System;
using System.Collections.Generic;
using System.Linq;
using TH.Domain.Wards;

namespace TH.Interfaces
{
    public interface IWardBusinessLogic
    {
        List<Ward> GetAllWards();
        bool CreateOrUpdateWard(Ward ward);
    }
}
