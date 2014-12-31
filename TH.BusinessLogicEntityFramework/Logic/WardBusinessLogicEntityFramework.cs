using System;
using System.Collections.Generic;
using System.Linq;
using TH.Domain.Other;
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

        public List<Domain.Other.Ward> GetAllWards()
        {
            var wards = _unitOfWork.GetAll<Ward>().ToList();

            return wards.Select(w => ReflectiveMapperService.ConvertItem<Ward, Domain.Other.Ward>(w)).ToList();
        }

        public bool CreateOrUpdateWard(Domain.Other.Ward ward)
        {
            var efWard = _unitOfWork.GetById<Ward>(ward.WardId);
            try
            {
                if (efWard == null)
                {
                    efWard = new Ward
                    {
                        WardId = ward.WardId != Guid.Empty ? ward.WardId : Guid.NewGuid()
                    };

                    efWard.Number = ward.Number;
                    efWard.Beds = ReflectiveMapperService.ConvertItem<List<Domain.Other.Bed>, List<Bed>>(ward.Beds);
                    efWard.WardWaitingList = new WardWaitingList
                    {
                        WardWaitingListId = Guid.NewGuid()
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

        public Domain.Other.Ward GetWardWithId(Guid id)
        {
            return ReflectiveMapperService.ConvertItem<Ward, Domain.Other.Ward>(_unitOfWork.GetById<Ward>(id));
        }
    }
}
