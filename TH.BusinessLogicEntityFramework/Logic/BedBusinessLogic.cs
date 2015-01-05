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
    public class BedBusinessLogic : IBedBusinessLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public BedBusinessLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Domain.Wards.Bed> GetAllBeds()
        {
            var beds = _unitOfWork.GetAll<Bed>().ToList();

            return beds.Select(b => ReflectiveMapperService.ConvertItem<Bed, Domain.Wards.Bed>(b)).ToList();
        }

        public bool CreateOrUpdateBed(Domain.Wards.Bed bed)
        {
            var efBed = _unitOfWork.GetById<Bed>(bed.BedId);
            var efWard = _unitOfWork.GetById<Ward>(bed.WardId);

            if (efWard != null)
            {
                try
                {
                    if (efBed == null)
                    {
                        efBed = new Bed
                        {
                            BedId = bed.BedId != Guid.Empty ? bed.BedId : Guid.NewGuid()
                        };

                        efBed.Number = bed.Number;
                        efBed.Ward = efWard;
                        _unitOfWork.Insert(efBed);
                    }
                    else
                    {
                        efBed.Number = bed.Number;
                        efBed.Ward = ReflectiveMapperService.ConvertItem<Domain.Wards.Ward, Ward>(GetWardForBed(bed));
                        _unitOfWork.Update(efBed);
                    }

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

        public bool AssignBedToWard(Domain.Wards.Bed bed, Domain.Wards.Ward ward)
        {
            ward.Beds.Add(bed);

            try
            {
                var efWard = ReflectiveMapperService.ConvertItem<Domain.Wards.Ward, Ward>(ward);
                _unitOfWork.Update(efWard);
                _unitOfWork.SaveChanges();
                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }

        public Domain.Wards.Ward GetWardForBed(Domain.Wards.Bed bed)
        {
            return ReflectiveMapperService.ConvertItem<Ward, Domain.Wards.Ward>(_unitOfWork.GetById<Ward>(bed.WardId));
        }

        public bool AssignPatientToBed(Guid bedid, Guid patientid)
        {
            var bed = _unitOfWork.GetById<Bed>(bedid);
            var patient = _unitOfWork.GetById<Patient>(patientid);
            
            if (bed != null && patient != null)
            {
                bed.Ward.WardWaitingList.Patients.Remove(patient);
                var currentVisit = patient.CurrentVisit;
                currentVisit.BedId = bedid;

                try
                {
                    _unitOfWork.Update(bed);
                    _unitOfWork.Update(currentVisit);
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
