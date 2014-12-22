using System;
using System.Collections.Generic;
using System.Linq;
using TH.Container;
using TH.Domain;
using TH.Domain.Other;
using TH.Domain.User;
using TH.Interfaces;

namespace TH.TestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var patientBusinessLogic = ThemeHospitalContainer.GetInstance<IPatientBusinessLogic>();
            var staffMemberBusinessLogic = ThemeHospitalContainer.GetInstance<IStaffMemberBusinessLogic>();

            patientBusinessLogic.InsertOrUpdatePatient(new Patient 
            {
                UserId = new Guid("11a9a41f-67eb-4c18-9db2-58f57a396caa"),
                Firstname = "Ste",
                OtherNames = "Christopher",
                LastName = "Prescott",
                DateOfBirth = Convert.ToDateTime("27/05/1991"),
                ContactNumber = "01234567890",
                Gender = "Male",
                Addresses = new List<Address>()
                {
                    new Address{
                        AddressLine1 = "1 Lion Works",
                        AddressLine2 = "92 Arundel Street",
                        AddressLine3 = "",
                        City = "Sheffield",
                        PostCode = "S1 4RE",
                        IsCurrentAddress = true
                    }
                },

                EmergencyContactName = "Jonny",
                EmergencyContactNumber = "01141234567"
            });


            staffMemberBusinessLogic.InsertOrUpdateConsultant(new Consultant
            {
                UserId = new Guid("22a9a41f-67eb-4c18-9db2-58f57a396cbb"),
                Firstname = "Staff",
                OtherNames = "Member",
                LastName = "1",
                DateOfBirth = Convert.ToDateTime("01/01/1991"),
                ContactNumber = "01234567890",
                Gender = "Male",
                Addresses = new List<Address>
                {
                    new Address{
                        AddressLine1 = "Address line 1",
                        AddressLine2 = "Address line 2",
                        AddressLine3 = "Address line 3",
                        City = "City",
                        PostCode = "Post code",
                        IsCurrentAddress = true
                    },
                    new Address{
                        AddressLine1 = "Old address line 1",
                        AddressLine2 = "Old address line 2",
                        AddressLine3 = "Old address line 3",
                        City = "Old city",
                        PostCode = "Old post code",
                        IsCurrentAddress = false
                    }
                },

                LastLoggedIn = DateTime.Now,
                Username = "staffMember1",
                Password = "password",
                Skills = new List<Skill>
                {
                    new Skill { Name = "C# Master" }
                }
            });

            //Console.WriteLine(patientBusinessLogic.GetAllPatients().Any());
            //Console.WriteLine(patientBusinessLogic.GetPatientWithId(new Guid("11a9a41f-67eb-4c18-9db2-58f57a396caa")).Firstname);
            //Console.WriteLine(staffMemberBusinessLogic.LoginStaffMember("staffMember1", "password").Firstname);
            Console.ReadKey();
        }
    }
}
