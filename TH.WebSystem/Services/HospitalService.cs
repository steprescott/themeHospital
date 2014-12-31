using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TH.Container;
using TH.Interfaces;

namespace TH.WebSystem.Services
{
    public class HospitalService
    {
        public IPatientBusinessLogic PatientBusinessLogic
        {
            get { return ThemeHospitalContainer.GetInstance<IPatientBusinessLogic>(); }
        }

        public IConsultantBusinessLogic ConsultantBusinessLogic
        {
            get { return ThemeHospitalContainer.GetInstance<IConsultantBusinessLogic>(); }
        }

        public IDoctorBusinessLogic DoctorBusinessLogic
        {
            get { return ThemeHospitalContainer.GetInstance<IDoctorBusinessLogic>(); }
        }

        public IStaffMemberBusinessLogic StaffMemberBusinessLogic
        {
            get { return ThemeHospitalContainer.GetInstance<IStaffMemberBusinessLogic>(); }
        }

        public ITeamBusinessLogic TeamBusinessLogic
        {
            get { return ThemeHospitalContainer.GetInstance<ITeamBusinessLogic>(); }
        }

        public ITreatmentBusinessLogic TreatmentBusinessLogic
        {
            get { return ThemeHospitalContainer.GetInstance<ITreatmentBusinessLogic>(); }
        }

        public IOperationBusinessLogic OperationBusinessLogic
        {
            get { return ThemeHospitalContainer.GetInstance<IOperationBusinessLogic>(); }
        }

        public IProcedureBusinessLogic ProcedureBusinessLogic
        {
            get { return ThemeHospitalContainer.GetInstance<IProcedureBusinessLogic>(); }
        }

        public INotesBusinessLogic NotesBusinessLogic
        {
            get { return ThemeHospitalContainer.GetInstance<INotesBusinessLogic>(); }
        }

        public IWardBusinessLogic WardBusinessLogic
        {
            get { return ThemeHospitalContainer.GetInstance<IWardBusinessLogic>(); }
        }

        public IVisitBusinessLogic VisitBusinessLogic
        {
            get { return ThemeHospitalContainer.GetInstance<IVisitBusinessLogic>(); }
        }
    }
}