using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TH.Container;
using TH.Interfaces;

namespace TH.WebSystem.Services
{
    public class SecurityService
    {
        public ILoginServiceBusinessLogic LoginServiceBusinessLogic
        {
            get { return ThemeHospitalContainer.GetInstance<ILoginServiceBusinessLogic>(); }
        }
    }
}