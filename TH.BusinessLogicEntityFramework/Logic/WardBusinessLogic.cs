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
    public class WardBusinessLogic : IWardBusinessLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public WardBusinessLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Domain.Wards.Ward> GetAllWards()
        {
            var wards = _unitOfWork.GetAll<Ward>().ToList();

            return wards.Select(w => ReflectiveMapperService.ConvertItem<Ward, Domain.Wards.Ward>(w)).OrderBy(ward => ward.Number).ToList();
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
                                 Beds = ReflectiveMapperService.ConvertItem<List<Domain.Wards.Bed>, List<Bed>>(ward.Beds),
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
                    efWard.Beds = ReflectiveMapperService.ConvertItem<List<Domain.Wards.Bed>, List<Bed>>(ward.Beds);

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
            var ward = _unitOfWork.GetById<Ward>(id);

            return ReflectiveMapperService.ConvertItem<Ward, Domain.Wards.Ward>(ward, 6);
        }

        public List<Domain.Wards.Bed> AvailableBedsForWardWithId(Guid id)
        {
            var ward = _unitOfWork.GetById<Ward>(id);

            return ReflectiveMapperService.ConvertItem<List<Bed>, List<Domain.Wards.Bed>>(ward.AvailableBeds);
        }

        public bool AssignPatientToWardWaitingList(Guid wardId, Guid patientId)
        {
            var ward = _unitOfWork.GetById<Ward>(wardId);
            var patient = _unitOfWork.GetById<Patient>(patientId);

            if (ward != null && patient != null)
            {
                try
                {
                    ward.WardWaitingList.Patients.Add(patient);
                    _unitOfWork.Update(ward);
                    _unitOfWork.SaveChanges();
                    return true;
                }
                catch (Exception exception)
                {
                    return false;
                }
            }
            return false;
        }
    }
}
