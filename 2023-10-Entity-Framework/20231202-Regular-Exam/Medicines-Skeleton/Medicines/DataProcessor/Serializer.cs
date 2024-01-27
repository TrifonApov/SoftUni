namespace Medicines.DataProcessor
{
    using Medicines.Data;
    using Medicines.Data.Models.Enums;
    using Medicines.DataProcessor.ExportDtos;
    using Medicines.Extensions;

    public class Serializer
    {
        public static string ExportPatientsWithTheirMedicines(MedicinesContext context, string date)
        {
            DateTime dateToCompare = DateTime.Parse(date);
            var patientsWithTheirMedicines = context.Patients
                .Where(p => p.PatientsMedicines.Any(pm => pm.Medicine.ProductionDate > dateToCompare))
                .Select(p => new ExportPatientDTO
                {
                    Name = p.FullName,
                    AgeGroup = p.AgeGroup,
                    Gender = p.Gender.ToString().ToLower(),
                    Medicines = p.PatientsMedicines
                        .Where(m=>m.Medicine.ProductionDate > dateToCompare)
                        .OrderByDescending(pm=>pm.Medicine.ExpiryDate)
                        .ThenBy(pm => pm.Medicine.Price)
                        .Select(pm => new ExportMedicineDTO
                        {
                            Name = pm.Medicine.Name,
                            Price = pm.Medicine.Price.ToString("0.00"),
                            Category = pm.Medicine.Category.ToString().ToLower(),
                            Producer = pm.Medicine.Producer,
                            BestBefore = pm.Medicine.ExpiryDate.ToString("yyyy-MM-dd")
                        })
                        .ToArray()
                })
                .OrderByDescending(p => p.Medicines.Length)
                .ThenBy(p => p.Name)
                .ToList();

            return patientsWithTheirMedicines.SerializeToXml("Patients").TrimEnd();
        }

        public static string ExportMedicinesFromDesiredCategoryInNonStopPharmacies(MedicinesContext context, int medicineCategory)
        {
            var medicinesFromDesiredCategory = context.Medicines
                .Where(m => m.Pharmacy.IsNonStop && m.Category == (Category)medicineCategory)
                .OrderBy(m => m.Price)
                .ThenBy(m => m.Name)
                .Select(m => new
                {
                    Name = m.Name,
                    Price = m.Price.ToString("0.00"),
                    Pharmacy = new
                    {
                        Name = m.Pharmacy.Name,
                        PhoneNumber = m.Pharmacy.PhoneNumber
                    }
                })
                .ToList();

            var result = medicinesFromDesiredCategory.SerializeToJson();
            return result.TrimEnd();
        }
    }
}
