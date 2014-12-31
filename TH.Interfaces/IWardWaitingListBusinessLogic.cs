using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TH.Interfaces
{
    public interface IWardWaitingListBusinessLogic
    {
        bool CreateWardWaitingList(Domain.Wards.WardWaitingList wardWaitingList);
    }
}
