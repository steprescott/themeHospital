using System;
using System.Collections.Generic;
using System.Linq;
using TH.Container;
using TH.Domain.Other;
using TH.Domain.Treatments;
using TH.Domain.User;
using TH.Domain.Wards;
using TH.Interfaces;

namespace TH.TestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Starting... :D");

            //Add me some patients
            AddPatient("482D8F08-92BB-11E4-91AE-DD2F340000B1", "Ste", "Prescott", "DA6DAAEA-92D6-11E4-A840-8032340000B1");
            AddPatient("86A9EE66-92BB-11E4-91AE-DD2F340000B1", "Bryan", "Cranston", "EE2579AA-92D6-11E4-AF3A-8032340000B1");
            AddPatient("8C722B7E-92BB-11E4-914F-DD2F340000B1", "Aaron", "Paul", "F1594A98-92D6-11E4-B124-8032340000B1");
            AddPatient("95C7F5A0-92BB-11E4-9237-DD2F340000B1", "Josh", "Smith", "F5C3DF4E-92D6-11E4-AC6B-8032340000B1");

            //Add me some consultants
            AddConsultantUser("1E02D510-92BD-11E4-B57E-8C7495DB5880", "Jonny", "Booker", "Consultant1", "Password", "37F21840-92D7-11E4-8B9A-8032340000B1");
            AddConsultantUser("29AF7012-92BD-11E4-9CD3-8C7495DB5880", "Joe", "Fletcher", "Consultant2", "Password", "3BD217A8-92D7-11E4-B691-8032340000B1");

            //Add me some doctors
            AddDoctorUser("38288E94-92BD-11E4-918E-8C7495DB5880", "Tom", "Windowson", "Doctor1", "Password", "3E79D4D2-92D7-11E4-81CD-8032340000B1");
            AddDoctorUser("3B7C67C8-92BD-11E4-B9DC-8C7495DB5880", "Noah", "Knudsen", "Doctor2", "Password", "4147D89E-92D7-11E4-B124-8032340000B1");
            AddDoctorUser("3FC28B14-92BD-11E4-B7F0-8C7495DB5880", "Joel", "Thiruchelvan", "Doctor3", "Password", "4537E1E2-92D7-11E4-B691-8032340000B1");

            //Add me some receptionists
            AddReceptionistUser("4782DA52-92BD-11E4-82F2-8C7495DB5880", "Dowdy", "Receptionist", "Receptionist1", "Password", "48597FAC-92D7-11E4-AC6B-8032340000B1");

            //Add me some operations
            AddOperation("d63f6ef7-594b-43e4-8523-105edefb93cd", "Vasectomy", "Vasectomy works by stopping sperm from getting into a man’s semen. This means that when a man ejaculates, the semen has no sperm and a woman’s egg cannot be fertilised.");
            AddOperation("fb321465-ee68-4674-b121-63a6af500c23", "Lumbar puncture", "A lumbar puncture is a medical procedure where a needle is inserted into the lower part of the spine to look for evidence of conditions affecting the brain, spinal cord or other parts of the nervous system.");
            AddOperation("7f368361-5bf8-4b38-9adc-65fbe0f6a2be", "Heart transplant", "A heart transplant is an operation to replace a damaged or failing heart with a healthy human heart from a donor who has recently died.");

            //Add me some medicine
            AddMedicine("60357f04-4a2b-4b10-b7a4-11244f94d591", "Morphine", "Morphine is used to treat moderate to severe pain. Short-acting formulations are taken as needed for pain.");
            AddMedicine("325ff7d3-e84b-489b-b81e-d0f191d6ebd8", "Paracetamol", "Paracetamol is a painkilling (analgesic) medicine available over-the-counter without a prescription.");
            AddMedicine("06dc300f-136a-45f8-8d28-b3769ebf570f", "Codeine", "Codeine is an opioid pain medication. An opioid is sometimes called a narcotic. Codeine is used to treat mild to moderately severe pain.");

            //Add me some wards
            var ward1 = AddWard("AE17AB22-8F9C-11E4-9E1E-7C2C95DB5880", 1);
            var ward2 = AddWard("B5DB3AEA-8F9C-11E4-98FD-7C2C95DB5880", 2);

            //Add me some beds
            AddBed("72311cc9-7e4c-4b73-a403-471601993bf4", 1, ward1);
            AddBed("b7b03889-bae2-4470-8144-4fcb920b6ad4", 2, ward1);
            AddBed("4c3f8b04-47eb-4c3e-a895-4efd6f2eb225", 3, ward1);
            AddBed("f6b2c23f-214c-439a-b8e9-ccd88944f4c7", 1, ward2);
            AddBed("03f5d5bc-f4bf-43ec-9cb8-8756d0ab1d5d", 2, ward2);

            //Add some peeps to ward waiting list
            AddPatientToWardWaitingList(new Guid("AE17AB22-8F9C-11E4-9E1E-7C2C95DB5880"), new Guid("86A9EE66-92BB-11E4-91AE-DD2F340000B1"));
            AddPatientToWardWaitingList(new Guid("AE17AB22-8F9C-11E4-9E1E-7C2C95DB5880"), new Guid("8C722B7E-92BB-11E4-914F-DD2F340000B1"));

            Console.WriteLine("--- Done :D");
            Console.ReadKey();
        }

        private static void AddPatient(string patientId, string firstName, string surname, string addressId)
        {
            var patientBusinessLogic = ThemeHospitalContainer.GetInstance<IPatientBusinessLogic>();

            patientBusinessLogic.InsertOrUpdatePatient(new Patient
            {
                UserId = new Guid(patientId),
                FirstName = firstName,
                OtherNames = string.Empty,
                LastName = surname,
                DateOfBirth = Convert.ToDateTime("27/05/1991"),
                ContactNumber = "01234567890",
                Gender = "Male",
                Addresses = new List<Address>
                {
                    new Address{
                        AddressId = new Guid(addressId),
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

        private static void AddConsultantUser(string consultantId, string FirstName, string surname, string username, string password, string addressId)
        {
            var staffMemberBusinessLogic = ThemeHospitalContainer.GetInstance<IStaffMemberBusinessLogic>();

            staffMemberBusinessLogic.CreateOrUpdateConsultant(new Consultant
            {
                UserId = new Guid(consultantId),
                FirstName = FirstName,
                OtherNames = string.Empty,
                LastName = surname,
                DateOfBirth = Convert.ToDateTime("01/01/1991"),
                ContactNumber = "01234567890",
                Gender = "Male",
                Addresses = new List<Address>
                {
                    new Address{
                        AddressId = new Guid(addressId),
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

        private static void AddDoctorUser(string doctorId, string FirstName, string surname, string username, string password, string addressId)
        {
            var staffMemberBusinessLogic = ThemeHospitalContainer.GetInstance<IStaffMemberBusinessLogic>();

            staffMemberBusinessLogic.CreateOrUpdateDoctor(new Doctor
            {
                UserId = new Guid(doctorId),
                FirstName = FirstName,
                OtherNames = string.Empty,
                LastName = surname,
                DateOfBirth = Convert.ToDateTime("01/01/1991"),
                ContactNumber = "01234567890",
                Gender = "Male",
                Addresses = new List<Address>
                {
                    new Address{
                        AddressId = new Guid(addressId),
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

        private static void AddReceptionistUser(string receptionistId, string FirstName, string surname, string username, string password, string addressId)
        {
            var staffMemberBusinessLogic = ThemeHospitalContainer.GetInstance<IStaffMemberBusinessLogic>();

            staffMemberBusinessLogic.CreateOrUpdateReceptionist(new Receptionist
            {
                UserId = new Guid(receptionistId),
                FirstName = FirstName,
                OtherNames = string.Empty,
                LastName = surname,
                DateOfBirth = Convert.ToDateTime("01/01/1991"),
                ContactNumber = "01234567890",
                Gender = "Male",
                Addresses = new List<Address>
                {
                    new Address{
                        AddressId = new Guid(addressId),
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
                WardId = ward.WardId
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

        private static void AddPatientToWardWaitingList(Guid wardId, Guid patientId)
        {
            var wardWaitingListBusinessLogic = ThemeHospitalContainer.GetInstance<IWardBusinessLogic>();

            wardWaitingListBusinessLogic.AssignPatientToWardWaitingList(wardId, patientId);
        }
    }
}
