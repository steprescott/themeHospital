using System;
using System.Collections.Generic;
using System.Linq;
using TH.Interfaces;
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

        public List<Domain.Other.Ward> GetAllWards()
        {
            var wards = _unitOfWork.GetAll<Ward>().ToList();

            return wards.Select(w => ConvertToDomain(w)).ToList();
        }

        public bool CreateOrUpdateWard(Domain.Other.Ward ward)
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

        public Domain.Other.Ward GetWardWithId(Guid id)
        {
            var ward = _unitOfWork.GetById<Ward>(id);

            return ConvertToDomain(ward);
        }

        public Domain.Other.Ward GetWardForBed(Domain.Other.Bed bed)
        {
            var ward = _unitOfWork.GetById<Ward>(bed.WardId);

            return ConvertToDomain(ward);
        }

        public static Ward ConvertToEntityFramework(Domain.Other.Ward ward)
        {
            return new Ward
            {
                WardId = ward.WardId,
                Number = ward.Number,

            };
        }

        public static Domain.Other.Ward ConvertToDomain(Ward ward)
        {
            return new Domain.Other.Ward
            {
                WardId = ward.WardId,
                Number = ward.Number
            };
        }
    }
}
