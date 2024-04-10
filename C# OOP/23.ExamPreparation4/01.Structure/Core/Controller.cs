using NauticalCatchChallenge.Core.Contracts;
using NauticalCatchChallenge.Models;
using NauticalCatchChallenge.Repositories;
using NauticalCatchChallenge.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NauticalCatchChallenge.Core
{
    public class Controller : IController
    {
        private FishRepository fish;
        private DiverRepository divers;
        public Controller()
        {
            fish = new FishRepository();
            divers = new DiverRepository();
        }
        public string DiveIntoCompetition(string diverType, string diverName)
        {
            if (diverType == "FreeDiver")
            {
                var diver = divers.GetModel(diverName);
                if (diver != null)
                {
                    return String.Format(OutputMessages.DiverNameDuplication, diverName, "DiverRepository");
                }

                divers.AddModel(new FreeDiver(diverName));
                return String.Format(OutputMessages.DiverRegistered, diverName, "DiverRepository");
            }
            else if (diverType == "ScubaDiver")
            {
                var diver = divers.GetModel(diverName);
                if (diver != null)
                {
                    return String.Format(OutputMessages.DiverNameDuplication, diverName, "DiverRepository");
                }

                divers.AddModel(new ScubaDiver(diverName));
                return String.Format(OutputMessages.DiverRegistered, diverName, "DiverRepository");
            }
            else
            {
                return String.Format(OutputMessages.DiverTypeNotPresented, diverType);
            }
        }
        public string SwimIntoCompetition(string fishType, string fishName, double points)
        {
            if (fishType == "ReefFish")
            {
                var givenFish = fish.GetModel(fishName);
                if (givenFish != null)
                {
                    return String.Format(OutputMessages.FishNameDuplication, fishName, "FishRepository");
                }
                fish.AddModel(new ReefFish(fishName, points));
                return String.Format(OutputMessages.FishCreated, fishName);
            }
            else if (fishType == "PredatoryFish")
            {
                var givenFish = fish.GetModel(fishName);
                if (givenFish != null)
                {
                    return String.Format(OutputMessages.FishNameDuplication, fishName, "FishRepository");
                }
                fish.AddModel(new PredatoryFish(fishName, points));
                return String.Format(OutputMessages.FishCreated, fishName);
            }
            else if (fishType == "DeepSeaFish")
            {
                var givenFish = fish.GetModel(fishName);
                if (givenFish != null)
                {
                    return String.Format(OutputMessages.FishNameDuplication, fishName, "FishRepository");
                }
                fish.AddModel(new DeepSeaFish(fishName, points));
                return String.Format(OutputMessages.FishCreated, fishName);
            }
            else
            {
                return String.Format(OutputMessages.FishTypeNotPresented, fishType);
            }
        }

        public string ChaseFish(string diverName, string fishName, bool isLucky)
        {
            var diver = divers.GetModel(diverName);
            if (diver == null)
            {
                return String.Format(OutputMessages.DiverNotFound, "DiverRepository", diverName);
            }

            var foundFish = fish.GetModel(fishName);
            if (foundFish == null)
            {
                return String.Format(OutputMessages.FishNotAllowed, fishName);
            }

            if (diver.HasHealthIssues)
            {
                return String.Format(OutputMessages.DiverHealthCheck, diverName);
            }

            if (diver.OxygenLevel < foundFish.TimeToCatch)
            {
                diver.Miss(foundFish.TimeToCatch);
                return String.Format(OutputMessages.DiverMisses, diverName, fishName);
            }

            if (diver.OxygenLevel == foundFish.TimeToCatch)
            {
                if (isLucky)
                {
                    diver.Hit(foundFish);
                    return String.Format(OutputMessages.DiverHitsFish, diverName, foundFish.Points, fishName);
                }
                else
                {
                    diver.Miss(foundFish.TimeToCatch);
                    return String.Format(OutputMessages.DiverMisses, diverName, fishName);
                }
            }

            diver.Hit(foundFish);
            return String.Format(OutputMessages.DiverHitsFish, diverName, foundFish.Points, fishName);

        }

        public string HealthRecovery()
        {
            var recovery = divers.Models
                .Where(d => d.HasHealthIssues == true);

            int count = 0;
            foreach (var brokenDiver in recovery)
            {
                count++;
                brokenDiver.UpdateHealthStatus();
                brokenDiver.RenewOxy();
            }
            return String.Format(OutputMessages.DiversRecovered, count);
        }

        public string DiverCatchReport(string diverName)
        {
            var diver = divers.GetModel(diverName);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Diver [ Name: {diver.Name}, Oxygen left: {diver.OxygenLevel}, Fish caught: {diver.Catch.Count}, Points earned: {diver.CompetitionPoints} ]");
            sb.AppendLine($"Catch Report:");
            foreach (var fishka in diver.Catch)
            {
                sb.AppendLine(fish.GetModel(fishka).ToString());
            }

            return sb.ToString().Trim();
        }

        public string CompetitionStatistics()
        {
            var orderedDivers = divers.Models
                .Where(d => d.HasHealthIssues == false)
                .OrderByDescending(d => d.CompetitionPoints)
                .ThenByDescending(d => d.Catch.Count)
                .ThenBy(D => D.Name);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"**Nautical-Catch-Challenge**");
            foreach (var diver in orderedDivers)
            {
                sb.AppendLine(diver.ToString());
            }

            return sb.ToString().Trim();
        }




    }
}
