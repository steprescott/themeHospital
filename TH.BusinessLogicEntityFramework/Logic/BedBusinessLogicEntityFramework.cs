using System;
using System.Collections.Generic;
using System.Linq;
using TH.Interfaces;
using TH.UnitOfWorkEntityFramework;

namespace TH.BusinessLogicEntityFramework.Logic
{
    public class BedBusinessLogicEntityFramework : IBedBusinessLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public BedBusinessLogicEntityFramework(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
                            BedId = bed.BedId != Guid.Empty ? bed.BedId : Guid.NewGuid(),
                            Number = bed.Number,
                            Ward = efWard
                        };

                        _unitOfWork.Insert(efBed);
                    }
                    else
                    {
                        efBed.Number = bed.Number;
                        efBed.Ward = _unitOfWork.GetById<Ward>(bed.WardId);

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
            try
            {
                var efWard = _unitOfWork.GetById<Ward>(ward.WardId);
                var efBed = _unitOfWork.GetById<Bed>(bed.BedId);

                if (efWard != null && efBed != null)
                {
                    efWard.Beds.Add(efBed);

                    _unitOfWork.Update(efWard);
                    _unitOfWork.SaveChanges();

                    return true;
                }
            }
            catch (Exception exception)
            {
                return false;
            }

            return false;
        }

        public static Bed ConvertToEntityFramework(Domain.Other.Bed bed)
        {
            return new Bed
            {
                BedId = bed.BedId,
                WardId = bed.WardId,
                Number = bed.Number
            };
        }

        public static Domain.Other.Bed ConvertToDomain(Bed bed)
        {
            return new Domain.Other.Bed
            {
                BedId = bed.BedId,
                WardId = bed.WardId,
                Number = bed.Number,
            };
        }
    }
}
