using System.Text;
using Boardgames.Data.Models;
using Boardgames.Data.Models.Enums;
using Boardgames.DataProcessor.ImportDto;
using Boardgames.Extensions;

namespace Boardgames.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Text.RegularExpressions;
    using Boardgames.Data;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCreator
            = "Successfully imported creator – {0} {1} with {2} boardgames.";

        private const string SuccessfullyImportedSeller
            = "Successfully imported seller - {0} with {1} boardgames.";

        public static string ImportCreators(BoardgamesContext context, string xmlString)
        {
            StringBuilder result = new StringBuilder();

            var creatorsDTOs = xmlString.DeserializeFromXml<ImportCreatorDTO[]>("Creators");
            var creatorsToAdd = new List<Creator>();

            foreach (var creatorDTO in creatorsDTOs)
            {
                if (!IsValid(creatorDTO))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                Creator creatorToAdd = new Creator
                {
                    FirstName = creatorDTO.FirstName,
                    LastName = creatorDTO.LastName,
                };

                foreach (ImportBoardgameDTO boardgameDTO in creatorDTO.Boardgames)
                {
                    if (IsValid(boardgameDTO))
                    {
                        creatorToAdd.Boardgames.Add(new Boardgame
                        {
                            Name = boardgameDTO.Name,
                            Rating = boardgameDTO.Rating,
                            YearPublished = boardgameDTO.YearPublished,
                            CategoryType = (CategoryType)boardgameDTO.CategoryType,
                            Mechanics = boardgameDTO.Mechanics
                        });

                    }
                    else
                    {
                        result.AppendLine(ErrorMessage);
                    }

                }

                creatorsToAdd.Add(creatorToAdd);
                result.AppendLine(string.Format(SuccessfullyImportedCreator, creatorToAdd.FirstName,
                    creatorToAdd.LastName, creatorToAdd.Boardgames.Count));

            }

            context.AddRange(creatorsToAdd);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportSellers(BoardgamesContext context, string jsonString)
        {
            StringBuilder result = new StringBuilder();

            var importSellersDTOs =
                jsonString.DeserializeFromJson<ImportSellerDTO[]>();

            var sellersToAdd = new List<Seller>();
            var boardgamesIds = context.Boardgames.Select(x => x.Id).ToArray();

            foreach (ImportSellerDTO importSellersDTO in importSellersDTOs)
            {
                var regex = @"^www\.[a-zA-Z0-9-]+\.com";
                var match = Regex.Match(importSellersDTO.Website, regex, RegexOptions.IgnoreCase);

                if (!IsValid(importSellersDTO) || !match.Success || importSellersDTO.Website == null)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var sellerToAdd = new Seller
                {
                    Name = importSellersDTO.Name,
                    Address = importSellersDTO.Address,
                    Country = importSellersDTO.Country,
                    Website = importSellersDTO.Website
                };

                foreach (int boarggameId in importSellersDTO.Boardgames.Distinct())
                {
                    if (boardgamesIds.Contains(boarggameId))
                    {
                        sellerToAdd.BoardgamesSellers.Add(new BoardgameSeller()
                        {
                            BoardgameId = boarggameId
                        });
                    }
                    else
                    {
                        result.AppendLine(ErrorMessage);
                    }
                }

                sellersToAdd.Add(sellerToAdd);
                result.AppendLine(string.Format(SuccessfullyImportedSeller, sellerToAdd.Name,
                    sellerToAdd.BoardgamesSellers.Count));
            }

            context.AddRange(sellersToAdd);
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
