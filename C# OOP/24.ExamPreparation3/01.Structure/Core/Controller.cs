using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ChristmasPastryShop.Core
{
    public class Controller : IController
    {
        private BoothRepository booths;

        public Controller()
        {
            booths = new BoothRepository();
        }
        public string AddBooth(int capacity)
        {
            int boothId = booths.Models.Count + 1;
            booths.AddModel(new Booth(boothId, capacity));
            return String.Format(OutputMessages.NewBoothAdded, boothId, capacity);
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            if (size != "Small" && size != "Large" && size != "Middle")
            {
                return String.Format(OutputMessages.InvalidCocktailSize, size);
            }

            var cocktail = booths.Models
                .FirstOrDefault(b => b.CocktailMenu.Models.Any(d => d.Name == cocktailName && d.Size == size));
            if (cocktail != null)
            {
                return String.Format(OutputMessages.CocktailAlreadyAdded, size, cocktailName);
            }

            if (cocktailTypeName == "MulledWine")
            {
                var booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);
                booth.CocktailMenu.AddModel(new MulledWine(cocktailName, size));
                return String.Format(OutputMessages.NewCocktailAdded, size, cocktailName, cocktailTypeName);
            }
            else if (cocktailTypeName == "Hibernation")
            {
                var booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);
                booth.CocktailMenu.AddModel(new Hibernation(cocktailName, size));
                return String.Format(OutputMessages.NewCocktailAdded, size, cocktailName, cocktailTypeName);
            }
            else
            {
                return String.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);

            }
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            var delicacy = booths.Models
                .FirstOrDefault(b => b.DelicacyMenu.Models.Any(d => d.Name == delicacyName));
            if (delicacy != null)
            {
                return String.Format(OutputMessages.DelicacyAlreadyAdded, delicacyName);
            }
            if (delicacyTypeName == "Gingerbread")
            {
                var booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);
                booth.DelicacyMenu.AddModel(new Gingerbread(delicacyName));
                return String.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);
            }
            else if (delicacyTypeName == "Stolen")
            {
                var booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);
                booth.DelicacyMenu.AddModel(new Stolen(delicacyName));
                return String.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);
            }
            else
            {
                return String.Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);
            }
        }

        public string BoothReport(int boothId)
        {
            var booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);
            return booth.ToString();
        }

        public string LeaveBooth(int boothId)
        {
            var booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);
            double currentBill = booth.CurrentBill;
            booth.Charge();
            booth.ChangeStatus();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Bill {currentBill:f2} lv");
            sb.AppendLine($"Booth {boothId} is now available!");
            return sb.ToString().Trim();
            
        }

        public string ReserveBooth(int countOfPeople)
        {
            var booth = booths.Models
                .Where(b => b.IsReserved == false && b.Capacity >= countOfPeople)
                .OrderBy(b => b.Capacity)
                .ThenByDescending(b => b.BoothId)
                .FirstOrDefault();

            if (booth == null)
            {
                return String.Format(OutputMessages.NoAvailableBooth, countOfPeople);
            }

            booth.ChangeStatus();
            return String.Format(OutputMessages.BoothReservedSuccessfully, booth.BoothId, countOfPeople);
        }

        public string TryOrder(int boothId, string order)
        {
            string[] splittedOrder = order.Split('/');
            var booth = booths.Models
               .FirstOrDefault(b => b.BoothId == boothId);
            if (splittedOrder[0] == "MulledWine" || splittedOrder[0] == "Hibernation")
            {
                var item = booth.CocktailMenu.Models.FirstOrDefault(c => c.Name == splittedOrder[1]);
                if (item == null)
                {
                    return String.Format(OutputMessages.NotRecognizedItemName, splittedOrder[0], splittedOrder[1]);
                }
                item = booth.CocktailMenu.Models.FirstOrDefault(c => c.Name == splittedOrder[1] && c.Size == splittedOrder[3]);
                if (item == null)
                {
                    return String.Format(OutputMessages.NotRecognizedItemName, splittedOrder[3], splittedOrder[1]);
                }
                booth.UpdateCurrentBill(item.Price * int.Parse(splittedOrder[2]));
                return String.Format(OutputMessages.SuccessfullyOrdered, boothId, splittedOrder[2], splittedOrder[1]);
            }
            else if (splittedOrder[0] == "Gingerbread" || splittedOrder[0] == "Stolen")
            {
                var item = booth.DelicacyMenu.Models.FirstOrDefault(c => c.Name == splittedOrder[1]);
                if (item == null)
                {
                    return String.Format(OutputMessages.NotRecognizedItemName, splittedOrder[0], splittedOrder[1]);
                }
                booth.UpdateCurrentBill(item.Price * int.Parse(splittedOrder[2]));
                return String.Format(OutputMessages.SuccessfullyOrdered, boothId, splittedOrder[2], splittedOrder[1]);
            }
            else
            {
                return String.Format(OutputMessages.NotRecognizedType, splittedOrder[0]);
            }

        }
    }
}
