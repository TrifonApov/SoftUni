namespace Footballers.DataProcessor
{
    using Footballers.Data;
    using Footballers.Data.Models;
    using Footballers.Data.Models.Enums;
    using Footballers.DataProcessor.ImportDto;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using Trucks.Extensions;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        public static string ImportCoaches(FootballersContext context, string xmlString)
        {
            StringBuilder result = new StringBuilder();

            var importCoachersDTOs = xmlString.DeserializeFromXml<ImportCoachDTO[]>("Coaches");
            var coachesToAdd = new List<Coach>();

            foreach (var importCoachDTO in importCoachersDTOs)
            {
                if (!IsValid(importCoachDTO) || 
                    string.IsNullOrEmpty(importCoachDTO.Nationality))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var newCoach = new Coach()
                {
                    Name = importCoachDTO.Name,
                    Nationality = importCoachDTO.Nationality,
                };

                foreach (var importFootballerDTO in importCoachDTO.Footballers)
                {
                    if (!IsValid(importFootballerDTO))
                    {
                        result.AppendLine(ErrorMessage); 
                        continue;
                    }

                    DateTime footballerContractStartDate;
                    bool isFootballerContractStartDateValid = DateTime.TryParseExact(importFootballerDTO.ContractStartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out footballerContractStartDate);
                    
                    DateTime footballerContractEndDate;
                    bool isFootballerContractEndDateValid = DateTime.TryParseExact(importFootballerDTO.ContractEndDate,
                        "dd/MM/yyyy", CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out footballerContractEndDate);
                    if (!isFootballerContractEndDateValid)
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }
                    if (!isFootballerContractStartDateValid || !isFootballerContractEndDateValid || footballerContractStartDate >= footballerContractEndDate)
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }


                    newCoach.Footballers.Add(new Footballer
                    {
                        Name = importFootballerDTO.Name,
                        ContractStartDate = footballerContractStartDate,
                        ContractEndDate = footballerContractEndDate,
                        BestSkillType = (BestSkillType)importFootballerDTO.BestSkillType,
                        PositionType = (PositionType)importFootballerDTO.PositionType,
                    });
                }
                coachesToAdd.Add(newCoach);
                result.AppendLine(string.Format(SuccessfullyImportedCoach, newCoach.Name, newCoach.Footballers.Count));
            }

            context.AddRange(coachesToAdd);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportTeams(FootballersContext context, string jsonString)
        {
            StringBuilder result = new StringBuilder();

            var importTeamDTOs = jsonString.DeserializeFromJson<ImportTeamDTO[]>();

            var teamsToAdd = new List<Team>();
            var footballersIds = context.Footballers.Select(x => x.Id).ToArray();

            foreach (var importTeamDTO in importTeamDTOs)
            {
                if (!IsValid(importTeamDTO)
                    || string.IsNullOrEmpty(importTeamDTO.Nationality)
                    || importTeamDTO.Trophies < 1)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var newTeam = new Team
                {
                    Name = importTeamDTO.Name,
                    Nationality = importTeamDTO.Nationality,
                    Trophies = importTeamDTO.Trophies,
                };

                foreach (var footballerId in importTeamDTO.Footballers.Distinct())
                {
                    if (!footballersIds.Contains(footballerId))
                    {
                        result.AppendLine(ErrorMessage);
                    }
                    else
                    {
                        newTeam.TeamsFootballers.Add(new TeamFootballer
                        {
                            FootballerId = footballerId,
                        });
                    }
                }
                teamsToAdd.Add(newTeam);
                result.AppendLine(string.Format(SuccessfullyImportedTeam,newTeam.Name, newTeam.TeamsFootballers.Count));
            }

            context.AddRange(teamsToAdd);
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
