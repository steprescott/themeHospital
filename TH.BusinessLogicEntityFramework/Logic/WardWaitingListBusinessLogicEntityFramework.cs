using System;
using System.Collections.Generic;
using System.Linq;
using TH.Interfaces;
using TH.UnitOfWorkEntityFramework;

namespace TH.BusinessLogicEntityFramework.Logic
{
    public class WardWaitingListBusinessLogicEntityFramework : IWardWaitingListBusinessLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public WardWaitingListBusinessLogicEntityFramework(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool CreateWardWaitingList(Domain.Wards.WardWaitingList wardWaitingList)
        {
            try
            {
                WardWaitingList efObject = ConvertToEntityFramework(wardWaitingList);
                _unitOfWork.Insert(efObject);
                _unitOfWork.SaveChanges();
                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }
        public static WardWaitingList ConvertToEntityFramework(Domain.Wards.WardWaitingList wardWaitingList)
        {
            return new WardWaitingList {
                WardWaitingListId = wardWaitingList.WardWaitingListId,
                Ward = WardBusinessLogicEntityFramework.ConvertToEntityFramework(wardWaitingList.Ward),
                Patients = wardWaitingList.Patients.Select(o => PatientBusinessLogicEntityFramework.ConvertToEntityFramework(o))
            };
        }

        public static Domain.Wards.WardWaitingList ConvertToDomain(WardWaitingList wardWaitingList)
        {
            return new Domain.Wards.WardWaitingList
            {
                WardWaitingListId = wardWaitingList.WardWaitingListId,
                Ward = WardBusinessLogicEntityFramework.ConvertToDomain(wardWaitingList.Ward),
                Patients = wardWaitingList.Patients.Select(o => PatientBusinessLogicEntityFramework.ConvertToDomain(o))
            }; 
        }
    }
    }
}
