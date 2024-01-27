namespace Medicines.DataProcessor
{
    using Medicines.Data;
    using Medicines.Data.Models;
    using Medicines.Data.Models.Enums;
    using Medicines.DataProcessor.ImportDtos;
    using Medicines.Extensions;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid Data!";
        private const string SuccessfullyImportedPharmacy = "Successfully imported pharmacy - {0} with {1} medicines.";
        private const string SuccessfullyImportedPatient = "Successfully imported patient - {0} with {1} medicines.";

        public static string ImportPatients(MedicinesContext context, string jsonString)
        {
            StringBuilder result = new StringBuilder();

            var importPatientsDTOs = jsonString.DeserializeFromJson<ImportPatientDTO[]>();

            var patientsToAdd = new List<Patient>();
            var medicinesIds = context.Medicines.Select(m => m.Id);

            foreach (var importPatientDTO in importPatientsDTOs) 
            {
                if (!IsValid(importPatientDTO))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var newPatient = new Patient 
                { 
                    FullName = importPatientDTO.FullName,
                    AgeGroup = (AgeGroup) importPatientDTO.AgeGroup,
                    Gender = (Gender) importPatientDTO.Gender
                };

                foreach (int medicineId in importPatientDTO.Medicines)
                {
                    if (newPatient.PatientsMedicines.Any(pm=>pm.MedicineId == medicineId))
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }
                    newPatient.PatientsMedicines.Add(new PatientMedicine
                    {
                        MedicineId = medicineId,
                    });
                }

                patientsToAdd.Add(newPatient);
                result.AppendLine(string.Format(SuccessfullyImportedPatient,newPatient.FullName, newPatient.PatientsMedicines.Count));

            }

            context.AddRange(patientsToAdd);
            context.SaveChanges();

            return result.ToString().TrimEnd();   
        }

        public static string ImportPharmacies(MedicinesContext context, string xmlString)
        {
            StringBuilder result = new StringBuilder();

            var importPharmaciesDTOs = xmlString.DeserializeFromXml<ImportPharmacyDTO[]>("Pharmacies");
            var pharmaciesToAdd = new List<Pharmacy>();

            foreach (var importPharmacyDTO in importPharmaciesDTOs)
            {
                bool isValidBoolean = importPharmacyDTO.IsNonStop == "true" || importPharmacyDTO.IsNonStop == "false";

                var regex = @"\(\d\d\d\) \d\d\d-\d\d\d\d";
                var match = Regex.Match(importPharmacyDTO.PhoneNumber, regex);

                if (!IsValid(importPharmacyDTO) || !isValidBoolean || string.IsNullOrEmpty(importPharmacyDTO.Name) || !match.Success)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var newPharmacy = new Pharmacy
                {
                    Name = importPharmacyDTO.Name,
                    PhoneNumber = importPharmacyDTO.PhoneNumber,
                    IsNonStop = bool.Parse(importPharmacyDTO.IsNonStop),
                };

                foreach (var medicineDTO in importPharmacyDTO.ImportMedicineDTOs)
                {

                    if (!IsValid(medicineDTO) || 
                        string.IsNullOrEmpty(medicineDTO.ProductionDate) || 
                        string.IsNullOrEmpty(medicineDTO.ExpiryDate) ||
                        string.IsNullOrEmpty(medicineDTO.Name) ||
                        string.IsNullOrEmpty(medicineDTO.Producer))
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }
                    DateTime ProductionDate = DateTime.Parse(medicineDTO.ProductionDate);
                    DateTime ExpiryDate = DateTime.Parse(medicineDTO.ExpiryDate);

                    if (ProductionDate >= ExpiryDate || newPharmacy.Medicines.Any(m => m.Name == medicineDTO.Name && m.Producer == medicineDTO.Producer)) 
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }

                    newPharmacy.Medicines.Add(new Medicine
                    {
                        Name = medicineDTO.Name,
                        Price = medicineDTO.Price,
                        Producer = medicineDTO.Producer,
                        ProductionDate = ProductionDate,
                        ExpiryDate = ExpiryDate,
                        Category = (Category)medicineDTO.Category
                    });

                }

                pharmaciesToAdd.Add(newPharmacy);
                result.AppendLine(string.Format(SuccessfullyImportedPharmacy, newPharmacy.Name, newPharmacy.Medicines.Count));
            }

            context.AddRange(pharmaciesToAdd);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
