using System;
using System.Text;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;

namespace ChristmasPastryShop.Models.Booths
{
    public class Booth : IBooth
    {
        private int boothId;
        private int capacity;
        private IRepository<IDelicacy> delicacyMenu;
        private IRepository<ICocktail> cocktailMenu;
        private double currentBill;
        private double turnover;
        private bool isReserved;

        public Booth(int boothId, int capacity)
        {
            BoothId = boothId;
            Capacity = capacity;
            delicacyMenu = new DelicacyRepository();
            cocktailMenu = new CocktailRepository();
            CurrentBill = 0;
            Turnover = 0;
            IsReserved = false;
        }

        public int BoothId
        {
            get => boothId;
            private set => boothId = value;
        }

        public int Capacity
        {
            get => capacity;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.CapacityLessThanOne);
                }
                capacity = value;
            }
        }

        public IRepository<IDelicacy> DelicacyMenu
        {
            get => delicacyMenu;
            private set => delicacyMenu = value;
        }

        public IRepository<ICocktail> CocktailMenu
        {
            get => cocktailMenu;
            private set => cocktailMenu = value;
        }

        public double CurrentBill
        {
            get => currentBill;
            private set => currentBill = value;
        }

        public double Turnover
        {
            get => turnover;
            private set => turnover = value;
        }

        public bool IsReserved
        {
            get => isReserved;
            private set => isReserved = value;
        }

        public void UpdateCurrentBill(double amount)
        {
            currentBill += amount;
        }

        public void Charge()
        {
            Turnover += CurrentBill;
            CurrentBill = 0;
        }

        public void ChangeStatus()
        {
            IsReserved = !IsReserved;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Booth: {boothId}");
            sb.AppendLine($"Capacity: {capacity}");
            sb.AppendLine($"Turnover: {turnover:F2} lv");
            
            sb.AppendLine("-Cocktail menu:");
            foreach (ICocktail cocktail in cocktailMenu.Models)
            {
                sb.AppendLine($"--{cocktail.ToString()}");
            }

            sb.AppendLine("-Delicacy menu:");
            foreach (IDelicacy delicacy in delicacyMenu.Models)
            {
                sb.AppendLine($"--{delicacy.ToString()}");
            }



            return sb.ToString().Trim();
        }
    }
}