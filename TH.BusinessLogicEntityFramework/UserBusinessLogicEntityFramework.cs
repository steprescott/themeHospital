using System;
using System.Collections.Generic;
using System.Linq;
using TH.Interfaces;
using TH.UnitOfWorkEntityFramework;

namespace TH.BusinessLogicEntityFramework
{
    public class UserBusinessLogicEntityFramework : IUserBusinessLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserBusinessLogicEntityFramework(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Domain.User> GetAllUsers()
        {
            return _unitOfWork.GetAll<User>().Select(u => new Domain.User
            {
                Id = u.UserId
            });
        }
    }
}
