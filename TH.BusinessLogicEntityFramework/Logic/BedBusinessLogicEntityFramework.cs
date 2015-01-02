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
    public class BedBusinessLogicEntityFramework : IBedBusinessLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public BedBusinessLogicEntityFramework(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Domain.Other.Bed> GetAllBeds()
        {
            var beds = _unitOfWork.GetAll<Bed>().ToList();

            return beds.Select(b => ReflectiveMapperService.ConvertItem<Bed, Domain.Other.Bed>(b)).ToList();
        }

        public bool CreateOrUpdateBed(Domain.Other.Bed bed)
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
                        efBed.Ward = ReflectiveMapperService.ConvertItem<Domain.Other.Ward, Ward>(GetWardForBed(bed));
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

        public bool AssignBedToWard(Domain.Other.Bed bed, Domain.Other.Ward ward)
        {
            ward.Beds.Add(bed);

            try
            {
                var efWard = ReflectiveMapperService.ConvertItem<Domain.Other.Ward, Ward>(ward);
                _unitOfWork.Update(efWard);
                _unitOfWork.SaveChanges();
                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }

        public Domain.Other.Ward GetWardForBed(Domain.Other.Bed bed)
        {
            return ReflectiveMapperService.ConvertItem<Ward, Domain.Other.Ward>(_unitOfWork.GetById<Ward>(bed.WardId));
        }

        public bool AssignPatientToBed(Guid bedid, Guid patientid)
        {
            var bed = _unitOfWork.GetById<Bed>(bedid);
            var patient = _unitOfWork.GetById<Patient>(patientid);
            
            if (bed != null && patient != null)
            {
                var currentVisit = patient.CurrentVisit;
                currentVisit.BedId = bedid;

                try
                {
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
