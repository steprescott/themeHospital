using System;
using System.Collections.Generic;
using System.Linq;
using TH.Container;
using TH.Domain;
using TH.Domain.Other;
using TH.Domain.Treatments;
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

            //Add me some operations
            AddOperation("d63f6ef7-594b-43e4-8523-105edefb93cd", "Vasectomy", "Vasectomy works by stopping sperm from getting into a man’s semen. This means that when a man ejaculates, the semen has no sperm and a woman’s egg cannot be fertilised.");
            AddOperation("fb321465-ee68-4674-b121-63a6af500c23", "Lumbar puncture", "A lumbar puncture is a medical procedure where a needle is inserted into the lower part of the spine to look for evidence of conditions affecting the brain, spinal cord or other parts of the nervous system.");
            AddOperation("7f368361-5bf8-4b38-9adc-65fbe0f6a2be", "Heart transplant", "A heart transplant is an operation to replace a damaged or failing heart with a healthy human heart from a donor who has recently died.");

            //Add me some medicine
            AddMedicine("60357f04-4a2b-4b10-b7a4-11244f94d591", "Morphine", "Morphine is used to treat moderate to severe pain. Short-acting formulations are taken as needed for pain.");
            AddMedicine("325ff7d3-e84b-489b-b81e-d0f191d6ebd8", "Paracetamol", "Paracetamol is a painkilling (analgesic) medicine available over-the-counter without a prescription.");
            AddMedicine("06dc300f-136a-45f8-8d28-b3769ebf570f", "Codeine", "Codeine is an opioid pain medication. An opioid is sometimes called a narcotic. Codeine is used to treat mild to moderately severe pain.");

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

            staffMemberBusinessLogic.CreateOrUpdateConsultant(new Consultant
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

            staffMemberBusinessLogic.CreateOrUpdateDoctor(new Doctor
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

            staffMemberBusinessLogic.CreateOrUpdateReceptionist(new Receptionist
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

        private static void AddOperation(string operationId, string name, string decription)
        {
            var operationBusinessLogic = ThemeHospitalContainer.GetInstance<IOperationBusinessLogic>();

            operationBusinessLogic.CreateOrUpdateOperation(new Operation {
                OperationId = Guid.Parse(operationId),
                Name = name,
                Description = decription
            });
        }

        private static void AddMedicine(string medicineId, string name, string decription)
        {
            var medicineBusinessLogic = ThemeHospitalContainer.GetInstance<IMedicineBusinessLogic>();

            medicineBusinessLogic.CreateOrUpdateMedicine(new Medicine
            {
                MedicineId = Guid.Parse(medicineId),
                Name = name,
                Description = decription
            });
        }
    }
}
