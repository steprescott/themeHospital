using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Unity;
using TH.BusinessLogicEntityFramework;
using TH.BusinessLogicEntityFramework.Logic;
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

            _unityContainer.RegisterType<ILoginServiceBusinessLogic, LoginServiceBusinessLogicEntityFramework>(new ContainerControlledLifetimeManager());

            _unityContainer.RegisterType<IPatientBusinessLogic, PatientBusinessLogicEntityFramework>(new ContainerControlledLifetimeManager());
            _unityContainer.RegisterType<IStaffMemberBusinessLogic, StaffMemberBusinessLogicEntityFramework>(new ContainerControlledLifetimeManager());
            _unityContainer.RegisterType<IConsultantBusinessLogic, ConsultantBusinessLogicEntityFramework>(new ContainerControlledLifetimeManager());
            _unityContainer.RegisterType<IDoctorBusinessLogic, DoctorBusinessLogicEntityFramework>(new ContainerControlledLifetimeManager());
            _unityContainer.RegisterType<ITeamBusinessLogic, TeamBusinessLogicEntityFramework>(new ContainerControlledLifetimeManager());
            _unityContainer.RegisterType<ITreatmentBusinessLogic, TreatmentBusinessLogicEntityFramework>(new ContainerControlledLifetimeManager());
            _unityContainer.RegisterType<IUnitOfWork, UnitOfWorkEntityFrameworkImplementation>(new ContainerControlledLifetimeManager());
        }
    }
}
