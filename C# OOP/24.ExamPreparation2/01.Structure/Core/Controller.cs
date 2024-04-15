using RobotService.Core.Contracts;
using RobotService.Models;
using RobotService.Models.Contracts;
using RobotService.Repositories;
using RobotService.Repositories.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private SupplementRepository supplements;
        private RobotRepository robots;
        private List<string> robotsTypes = new List<string>() { "DomesticAssistant", "IndustrialAssistant" };
        private List<string> supplementsTypes = new List<string>() { "SpecializedArm", "LaserRadar" };
        public Controller()
        {
            supplements = new SupplementRepository();
            robots = new RobotRepository();
        }

        public string CreateRobot(string model, string typeName)
        {
            if (!robotsTypes.Contains(typeName))
            {
                return String.Format(OutputMessages.RobotCannotBeCreated, typeName);
            }

            IRobot robot;
            if (typeName == "DomesticAssistant")
            {
                robots.AddNew(new DomesticAssistant(model));
            }
            else if (typeName == "IndustrialAssistant")
            {
                robots.AddNew(new IndustrialAssistant(model));
            }
            return String.Format(OutputMessages.RobotCreatedSuccessfully, typeName, model);
        }

        public string CreateSupplement(string typeName)
        {
            if (!supplementsTypes.Contains(typeName))
            {
                return String.Format(OutputMessages.SupplementCannotBeCreated, typeName);
            }

            ISupplement supplement;
            if (typeName == "SpecializedArm")
            {
                supplements.AddNew(new SpecializedArm());
            }
            else if (typeName == "LaserRadar")
            {
                supplements.AddNew(new LaserRadar());
            }
            return String.Format(OutputMessages.SupplementCreatedSuccessfully, typeName);
        }


        public string UpgradeRobot(string model, string supplementTypeName)
        {
            ISupplement supplement = this.supplements.Models().FirstOrDefault(x => x.GetType().Name == supplementTypeName);

            var selectedModels = this.robots.Models().Where(r => r.Model == model);
            var stillNotUpgraded = selectedModels.Where(r => r.InterfaceStandards.All(s => s != supplement.InterfaceStandard));
            var robotForUpgrade = stillNotUpgraded.FirstOrDefault();

            if (robotForUpgrade == null)
            {
                return string.Format(OutputMessages.AllModelsUpgraded, model);
            }


            robotForUpgrade.InstallSupplement(supplement);
            this.supplements.RemoveByName(supplementTypeName);

            return string.Format(OutputMessages.UpgradeSuccessful, model, supplementTypeName);
        }


        public string PerformService(string serviceName, int intefaceStandard, int totalPowerNeeded)
        {
            var selectedRobots = this.robots
                .Models()
                .Where(r => r.InterfaceStandards.Contains(intefaceStandard))
                .OrderByDescending(y => y.BatteryLevel);

            if (selectedRobots.Count() == 0)
            {
                return string.Format(OutputMessages.UnableToPerform, intefaceStandard);
            }

            int powerSum = selectedRobots.Sum(r => r.BatteryLevel);

            if (powerSum < totalPowerNeeded)
            {
                return string.Format(OutputMessages.MorePowerNeeded, serviceName, totalPowerNeeded - powerSum);
            }

            int usedRobotsCount = 0;

            foreach (var robot in selectedRobots)
            {
                

                if (totalPowerNeeded <= robot.BatteryLevel)
                {
                    robot.ExecuteService(totalPowerNeeded);
                    usedRobotsCount++;
                    break;
                }
                else
                {
                    totalPowerNeeded -= robot.BatteryLevel;
                    robot.ExecuteService(robot.BatteryLevel);
                    usedRobotsCount++;
                }

            }

            return string.Format(OutputMessages.PerformedSuccessfully, serviceName, usedRobotsCount);
        }


        public string RobotRecovery(string model, int minutes)
        {
            var selectedRobots = this.robots
                .Models()
                .Where(r => r.Model == model && r.BatteryLevel*2 < r.BatteryCapacity);
            int count = 0;

            foreach (var robot in selectedRobots)
            {
                robot.Eating(minutes);
                count++;
            }

            return string.Format(OutputMessages.RobotsFed, count);
        }

        public string Report()
        {
            var allRobots = robots
                .Models()
                .OrderByDescending(r => r.BatteryLevel)
                .ThenBy(r => r.BatteryCapacity);

            StringBuilder sb = new StringBuilder();

            foreach (var robot in allRobots)
            {
                sb.AppendLine(robot.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
