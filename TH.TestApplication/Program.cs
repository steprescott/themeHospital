using System;
using System.Collections.Generic;
using System.Linq;
using TH.Container;
using TH.Interfaces;

namespace TH.TestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = ThemeHospitalContainer.GetInstance<IPatientBusinessLogic>();

            Console.WriteLine(container.GetAllUsers().Any());
            Console.ReadKey();
        }
    }
}
