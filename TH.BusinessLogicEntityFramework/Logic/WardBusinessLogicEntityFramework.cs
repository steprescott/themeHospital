using System;
using System.Collections.Generic;
using System.Linq;
using TH.Interfaces;
using TH.ReflectiveMapper;
using TH.UnitOfWorkEntityFramework;
using Bed = TH.UnitOfWorkEntityFramework.Bed;
using Ward = TH.UnitOfWorkEntityFramework.Ward;

namespace TH.BusinessLogicEntityFramework.Logic
{
    public class WardBusinessLogicEntityFramework : IWardBusinessLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public WardBusinessLogicEntityFramework(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Domain.Wards.Ward> GetAllWards()
        {
            var wards = _unitOfWork.GetAll<Ward>().ToList();

            return wards.Select(w => ReflectiveMapperService.ConvertItem<Ward, Domain.Wards.Ward>(w)).ToList();
        }

        public bool CreateOrUpdateWard(Domain.Wards.Ward ward)
        {
            var efWard = _unitOfWork.GetById<Ward>(ward.WardId);
            try
            {
                if (efWard == null)
                {
                    efWard = new Ward
                             {
                                 WardId = ward.WardId != Guid.Empty ? ward.WardId : Guid.NewGuid(),
                                 Number = ward.Number,
                                 Beds = ReflectiveMapperService.ConvertItem<List<Domain.Other.Bed>, List<Bed>>(ward.Beds),
                                 WardWaitingList = new WardWaitingList
                                                   {
                                                       WardWaitingListId = Guid.NewGuid()
                                                   }
                             };

                    _unitOfWork.Insert(efWard);
                }
                else
                {
                    efWard.Number = ward.Number;
                    efWard.Beds = ReflectiveMapperService.ConvertItem<List<Domain.Other.Bed>, List<Bed>>(ward.Beds);

                    _unitOfWork.Update(efWard);
                }

                _unitOfWork.SaveChanges();
                return true;

            }
            catch (Exception exception)
            {
                return false;
            }
        }

        public Domain.Wards.Ward GetWardWithId(Guid id)
        {
            return ReflectiveMapperService.ConvertItem<Ward, Domain.Wards.Ward>(_unitOfWork.GetById<Ward>(id));
        }

        public List<Domain.Other.Bed> AvailableBedsForWardWithId(Guid id)
        {
            var ward = _unitOfWork.GetById<Ward>(id);

            return ReflectiveMapperService.ConvertItem<List<Bed>, List<Domain.Other.Bed>>(ward.AvailableBeds);
        }

        public bool AssignPatientToWardWaitingList(Domain.Wards.WardWaitlingList wardWaitlingList, Domain.User.Patient patient)
        {
            wardWaitlingList.Patients.Add(patient);

            try
            {
                var efWardWaitingList = ReflectiveMapperService.ConvertItem<Domain.Wards.WardWaitlingList, WardWaitingList>(wardWaitlingList);
                _unitOfWork.Update(efWardWaitingList);
                _unitOfWork.SaveChanges();
                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }
    }
}
