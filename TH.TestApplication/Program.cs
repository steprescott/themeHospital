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
            Console.WriteLine("--- Starting... :D");

            //Add me some patients
            AddPatient("Ste", "Prescott");

            //Add me some consultants
            AddConsultantUser("Jonny", "Booker", "Consultant1", "Password");
            AddConsultantUser("Joe", "Fletcher", "Consultant2", "Password");

            //Add me some doctors
            AddDoctorUser("Tom", "Windowson", "Doctor1", "Password");
            AddDoctorUser("Noah", "Knudsen", "Doctor2", "Password");
            AddDoctorUser("Joel", "Thiruchelvan", "Doctor3", "Password");

            //Add me some receptionists
            AddReceptionistUser("Dowdy", "Receptionist", "Receptionist1", "Password");

            Console.WriteLine("--- Done :D");
            Console.ReadKey();
        }

        private static void AddPatient(string firstname, string surname)
        {
            var patientBusinessLogic = ThemeHospitalContainer.GetInstance<IPatientBusinessLogic>();

            patientBusinessLogic.InsertOrUpdatePatient(new Patient
            {
                Firstname = firstname,
                OtherNames = string.Empty,
                LastName = surname,
                DateOfBirth = Convert.ToDateTime("27/05/1991"),
                ContactNumber = "01234567890",
                Gender = "Male",
                Addresses = new List<Address>
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
        }

        private static void AddConsultantUser(string firstname, string surname, string username, string password)
        {
            var staffMemberBusinessLogic = ThemeHospitalContainer.GetInstance<IStaffMemberBusinessLogic>();

            staffMemberBusinessLogic.InsertOrUpdateConsultant(new Consultant
            {
                Firstname = firstname,
                OtherNames = string.Empty,
                LastName = surname,
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
                    }
                },

                LastLoggedIn = DateTime.Now,
                Username = username,
                Password = password,
                Skills = new List<Skill>
                {
                    new Skill { Name = "God" }
                }
            });
        }

        private static void AddDoctorUser(string firstname, string surname, string username, string password)
        {
            var staffMemberBusinessLogic = ThemeHospitalContainer.GetInstance<IStaffMemberBusinessLogic>();

            staffMemberBusinessLogic.InsertOrUpdateDoctor(new Doctor
            {
                Firstname = firstname,
                OtherNames = string.Empty,
                LastName = surname,
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
                    }
                },

                LastLoggedIn = DateTime.Now,
                Username = username,
                Password = password
            });
        }
        
        private static void AddReceptionistUser(string firstname, string surname, string username, string password)
        {
            var staffMemberBusinessLogic = ThemeHospitalContainer.GetInstance<IStaffMemberBusinessLogic>();

            staffMemberBusinessLogic.InsertOrUpdateReceptionist(new Receptionist
            {
                Firstname = firstname,
                OtherNames = string.Empty,
                LastName = surname,
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
                    }
                },

                LastLoggedIn = DateTime.Now,
                Username = username,
                Password = password
            });
        }
    }
}
