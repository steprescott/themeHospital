using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Unity;
using TH.BusinessLogicEntityFramework;
using TH.Interfaces;
using TH.UnitOfWorkEntityFramework;

namespace TH.Container
{
    public class ThemeHospitalContainer
    {
        private static UnityContainer _unityContainer;

        public static T GetInstance<T>()
        {
            if (_unityContainer == null)
            {
                Register();
            }

            return _unityContainer.Resolve<T>();
        }

        private static void Register()
        {
            _unityContainer = new UnityContainer();
            _unityContainer.RegisterType<IPatientBusinessLogic, PatientBusinessLogicEntityFramework>(new ContainerControlledLifetimeManager());
            _unityContainer.RegisterType<IStaffMemberBusinessLogic, StaffMemberBusinessLogicEntityFramework>(new ContainerControlledLifetimeManager());

            _unityContainer.RegisterType<IUnitOfWork, UnitOfWorkEntityFrameworkImplementation>(new ContainerControlledLifetimeManager());
        }
    }
}
