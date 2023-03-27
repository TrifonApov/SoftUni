using System;
using System.Linq;
using System.Text;
using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Utilities.Messages;

namespace ChristmasPastryShop.Core
{
    public class Controller : IController
    {
        private BoothRepository boothRepository;

        public Controller()
        {
            this.boothRepository = new BoothRepository();
        }

        public string AddBooth(int capacity)
        {
            IBooth booth = new Booth(boothRepository.Models.Count + 1, capacity);
            boothRepository.AddModel(booth);

            return string.Format(OutputMessages.NewBoothAdded, booth.BoothId, booth.Capacity);
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            IBooth booth = boothRepository.Models.FirstOrDefault(b => b.BoothId == boothId);
            if (booth == null)
                return string.Format(OutputMessages.BoothNotFound, boothId);

            if (booth.DelicacyMenu.Models.Any(m => m.Name == delicacyName))
                return string.Format(OutputMessages.DelicacyAlreadyAdded, delicacyName);

            IDelicacy delicacy;
            switch (delicacyTypeName)
            {
                case "Stolen":
                    delicacy = new Stolen(delicacyName);
                    break;
                case "Gingerbread":
                    delicacy = new Gingerbread(delicacyName);
                    break;
                default:
                    return string.Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);
            }

            booth.DelicacyMenu.AddModel(delicacy);
            return string.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            IBooth booth = boothRepository.Models.FirstOrDefault(b => b.BoothId == boothId);
            if (booth == null)
                return string.Format(OutputMessages.BoothNotFound, boothId);

            if (size != "Small" && size != "Middle" && size != "Large")
                return string.Format(OutputMessages.InvalidCocktailSize, size);

            if (booth.CocktailMenu.Models.Any(c => c.Name == cocktailName && c.Size == size))
                return string.Format(OutputMessages.CocktailAlreadyAdded, size, cocktailName);

            ICocktail cocktail;
            switch (cocktailTypeName)
            {
                case "Hibernation":
                    cocktail = new Hibernation(cocktailName, size);
                    break;
                case "MulledWine":
                    cocktail = new MulledWine(cocktailName, size);
                    break;
                default:
                    return string.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);
            }

            booth.CocktailMenu.AddModel(cocktail);
            return string.Format(OutputMessages.NewCocktailAdded, size, cocktailName, cocktailTypeName);
        }

        public string ReserveBooth(int countOfPeople)
        {
            IBooth availableBooth = boothRepository
                .Models
                .Where(b => b.IsReserved == false && b.Capacity >= countOfPeople)
                .OrderBy(b => b.Capacity).
                ThenByDescending(b => b.BoothId).FirstOrDefault();

            if (availableBooth == null)
                return string.Format(OutputMessages.NoAvailableBooth, countOfPeople);

            availableBooth.ChangeStatus();
            return string.Format(OutputMessages.BoothReservedSuccessfully, availableBooth.BoothId, countOfPeople);
        }

        public string TryOrder(int boothId, string order)
        {
            IBooth booth = boothRepository.Models.FirstOrDefault(b => b.BoothId == boothId);
            if (booth == null)
                return string.Format(OutputMessages.BoothNotFound, boothId);

            string[] orderTokens = order.Split("/", StringSplitOptions.RemoveEmptyEntries);
            string itemTypeName = orderTokens[0];
            string itemName = orderTokens[1];
            int count = int.Parse(orderTokens[2]);

            string cocktailSize = string.Empty;
            if (orderTokens.Length > 3)
                cocktailSize = orderTokens[3];

            if (itemTypeName != "Gingerbread" &&
                itemTypeName != "Stolen" &&
                itemTypeName != "Hibernation" &&
                itemTypeName != "MulledWine")
                return string.Format(OutputMessages.NotRecognizedType, itemTypeName);

            ICocktail cocktail = booth.CocktailMenu.Models.FirstOrDefault(c => c.Name == itemName && c.Size == cocktailSize);
            IDelicacy delicacy = booth.DelicacyMenu.Models.FirstOrDefault(d => d.Name == itemName);

            //if (cocktail == null && delicacy == null)
                //return string.Format(OutputMessages.NotRecognizedItemName, cocktailSize, itemName);

            if (itemTypeName == "MulledWine" || itemTypeName == "Hibernation")
            {
                if (cocktail == null)
                    return string.Format(OutputMessages.CocktailStillNotAdded, cocktailSize, itemName);

                booth.UpdateCurrentBill(cocktail.Price * count);
            }
            else
            {
                if (delicacy == null)
                    return string.Format(OutputMessages.DelicacyStillNotAdded, itemTypeName, itemName);

                booth.UpdateCurrentBill(delicacy.Price * count);
            }

            return string.Format(OutputMessages.SuccessfullyOrdered, booth.BoothId, count, itemName);

        }

        public string LeaveBooth(int boothId)
        {
            IBooth booth = boothRepository.Models.FirstOrDefault(b => b.BoothId == boothId);
            if (booth == null)
                return string.Format(OutputMessages.BoothNotFound, boothId);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format(OutputMessages.GetBill, booth.CurrentBill));
            booth.Charge();

            sb.AppendLine(string.Format(OutputMessages.BoothIsAvailable, booth.BoothId));
            booth.ChangeStatus();

            return sb.ToString().Trim();
        }

        public string BoothReport(int boothId)
        {
            IBooth booth = boothRepository.Models.FirstOrDefault(b => b.BoothId == boothId);
            if (booth == null)
                return string.Format(OutputMessages.BoothNotFound, boothId);

            return booth.ToString();
        }
    }
}