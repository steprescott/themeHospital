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

            //Add me some beds
            var ward1 = AddWard("AE17AB22-8F9C-11E4-9E1E-7C2C95DB5880", 1);
            var ward2 = AddWard("B5DB3AEA-8F9C-11E4-98FD-7C2C95DB5880", 2);

            var bed1 = AddBed("72311cc9-7e4c-4b73-a403-471601993bf4", 1, ward1);
            var bed2 = AddBed("b7b03889-bae2-4470-8144-4fcb920b6ad4", 2, ward1);
            var bed3 = AddBed("4c3f8b04-47eb-4c3e-a895-4efd6f2eb225", 3, ward1);
            var bed4 = AddBed("f6b2c23f-214c-439a-b8e9-ccd88944f4c7", 1, ward2);
            var bed5 = AddBed("03f5d5bc-f4bf-43ec-9cb8-8756d0ab1d5d", 2, ward2);

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

        private static Bed AddBed(string bedId, int bedNumber, Ward ward)
        {
            var bedBusinessLogic = ThemeHospitalContainer.GetInstance<IBedBusinessLogic>();
            var bed = new Bed
            {
                BedId = Guid.Parse(bedId),
                Number = bedNumber,
                Ward = ward
            };

            bedBusinessLogic.CreateOrUpdateBed(bed);

            return bed;
        }

        private static Ward AddWard(string wardId, int wardNumber)
        {
            var wardBusinessLogic = ThemeHospitalContainer.GetInstance<IWardBusinessLogic>();
            var ward = new Ward
            {
                WardId = Guid.Parse(wardId),
                Number = wardNumber
            };

            wardBusinessLogic.CreateOrUpdateWard(ward);

            return ward;
        }
    }
}
