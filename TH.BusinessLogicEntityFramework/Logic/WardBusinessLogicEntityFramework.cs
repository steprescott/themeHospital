using System;
using System.Collections.Generic;
using System.Linq;
using TH.Interfaces;
using TH.UnitOfWorkEntityFramework;
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

            return wards.Select(w => ConvertToDomain(w, true)).ToList();
        }

        public bool CreateOrUpdateWard(Domain.Wards.Ward ward)
        {
            try
            {
                var efWard = _unitOfWork.GetById<Ward>(ward.WardId);

                if (efWard == null)
                {
                    efWard = new Ward
                    {
                        WardId = ward.WardId != Guid.Empty ? ward.WardId : Guid.NewGuid()
                    };

                    efWard.Number = ward.Number;
                    efWard.WardWaitingList = new WardWaitingList
                    {
                        WardWaitingListId = Guid.NewGuid()
                    };

                    _unitOfWork.Insert(efWard);
                }
                else
                {
                    efWard.Number = ward.Number;
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

            return ConvertToDomain(ward, true);
        }

        public Domain.Wards.Ward GetWardForBed(Domain.Other.Bed bed)
        {
            var ward = _unitOfWork.GetById<Ward>(bed.Ward.WardId);

            return ConvertToDomain(ward, true);
        }

        public static Ward ConvertToEntityFramework(Domain.Wards.Ward ward, bool solvedNested = false)
        {
            var obj = new Ward
            {
                WardId = ward.WardId,
                Number = ward.Number,
            };

            if (solvedNested)
            {
                obj.Beds = ward.Beds.Select(b => BedBusinessLogicEntityFramework.ConvertToEntityFramework(b)).ToList();
            }

            return obj;
        }

        public static Domain.Wards.Ward ConvertToDomain(Ward ward, bool solvedNested = false)
        {
            var obj = new Domain.Wards.Ward
            {
                WardId = ward.WardId,
                Number = ward.Number,
            };

            if (solvedNested)
            {
                obj.Beds = ward.Beds.Select(b => BedBusinessLogicEntityFramework.ConvertToDomain(b)).ToList();
            }

            return obj;
        }
    }
}
