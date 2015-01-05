using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Unity;
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

            _unityContainer.RegisterType<IUnitOfWork, UnitOfWorkEntityFrameworkImplementation>(new ContainerControlledLifetimeManager());

            _unityContainer.RegisterType<ILoginServiceBusinessLogic, LoginServiceBusinessLogic>(new ContainerControlledLifetimeManager());

            _unityContainer.RegisterType<IVisitBusinessLogic, VisitBusinessLogic>(new ContainerControlledLifetimeManager());

            _unityContainer.RegisterType<IPatientBusinessLogic, PatientBusinessLogic>(new ContainerControlledLifetimeManager());
            _unityContainer.RegisterType<IStaffMemberBusinessLogic, StaffMemberBusinessLogic>(new ContainerControlledLifetimeManager());
            _unityContainer.RegisterType<IConsultantBusinessLogic, ConsultantBusinessLogic>(new ContainerControlledLifetimeManager());
            _unityContainer.RegisterType<IDoctorBusinessLogic, DoctorBusinessLogic>(new ContainerControlledLifetimeManager());
            _unityContainer.RegisterType<ITeamBusinessLogic, TeamBusinessLogic>(new ContainerControlledLifetimeManager());

            _unityContainer.RegisterType<IWardBusinessLogic, WardBusinessLogic>(new ContainerControlledLifetimeManager());
            _unityContainer.RegisterType<IBedBusinessLogic, BedBusinessLogic>(new ContainerControlledLifetimeManager());

            _unityContainer.RegisterType<IOperationBusinessLogic, OperationBusinessLogic>(new ContainerControlledLifetimeManager());
            _unityContainer.RegisterType<IProcedureBusinessLogic, ProcedureBusinessLogic>(new ContainerControlledLifetimeManager());
            _unityContainer.RegisterType<IMedicineBusinessLogic, MedicineBusinessLogic>(new ContainerControlledLifetimeManager());
            _unityContainer.RegisterType<ICourseOfMedicineBusinessLogic, CourseOfMedicineBusinessLogic>(new ContainerControlledLifetimeManager());
            _unityContainer.RegisterType<ITreatmentBusinessLogic, TreatmentBusinessLogic>(new ContainerControlledLifetimeManager());

            _unityContainer.RegisterType<INotesBusinessLogic, NotesBusinessLogic>(new ContainerControlledLifetimeManager());
        }
    }
}
