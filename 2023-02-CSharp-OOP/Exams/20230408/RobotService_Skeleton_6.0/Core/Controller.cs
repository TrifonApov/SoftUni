using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RobotService.Core.Contracts;
using RobotService.Models;
using RobotService.Models.Contracts;
using RobotService.Repositories;
using RobotService.Utilities.Messages;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private SupplementRepository supplementRepository;
        private RobotRepository robotRepository;

        public Controller()
        {
            supplementRepository = new SupplementRepository();
            robotRepository = new RobotRepository();
        }

        public string CreateRobot(string model, string typeName)
        {
            IRobot robot;
            switch (typeName)
            {
                case nameof(DomesticAssistant):
                    robot = new DomesticAssistant(model);
                    break;
                case nameof(IndustrialAssistant):
                    robot = new IndustrialAssistant(model);
                    break;
                default:
                    return string.Format(OutputMessages.RobotCannotBeCreated, typeName);
            }

            robotRepository.AddNew(robot);
            return string.Format(OutputMessages.RobotCreatedSuccessfully, typeName, model);
        }

        public string CreateSupplement(string typeName)
        {
            ISupplement supplement;
            switch (typeName)
            {
                case nameof(SpecializedArm):
                    supplement = new SpecializedArm();
                    break;
                case nameof(LaserRadar):
                    supplement = new LaserRadar();
                    break;
                default:
                    return string.Format(OutputMessages.SupplementCannotBeCreated, typeName);
            }

            supplementRepository.AddNew(supplement);
            return string.Format(OutputMessages.SupplementCreatedSuccessfully, typeName);
        }

        public string UpgradeRobot(string model, string supplementTypeName)
        {
            ISupplement supplement = supplementRepository.Models().First(s => s.GetType().Name == supplementTypeName);
            int interfaceValue = supplement.InterfaceStandard;

            var robotsByModels = robotRepository
                .Models().Where(r => r.Model == model);
            var robotsBySupported = robotsByModels.Where(r => !r.InterfaceStandards.Contains(interfaceValue));

            if (!robotsBySupported.Any())
                return string.Format(OutputMessages.AllModelsUpgraded, model);

            robotsBySupported.First().InstallSupplement(supplement);
            supplementRepository.RemoveByName(supplementTypeName);

            return string.Format(OutputMessages.UpgradeSuccessful, model, supplementTypeName);

        }

        public string PerformService(string serviceName, int intefaceStandard, int totalPowerNeeded)
        {
            var robots = robotRepository.Models().
                Where(r => r.InterfaceStandards.Contains(intefaceStandard));

            if (!robots.Any())
                return string.Format(OutputMessages.UnableToPerform, intefaceStandard);

            var orderedRobots = robots.OrderByDescending(r => r.BatteryLevel);

            int sum = orderedRobots.Sum(r => r.BatteryLevel);

            if (sum < totalPowerNeeded)
                return string.Format(OutputMessages.MorePowerNeeded, serviceName, totalPowerNeeded - sum);

            int counter = 0;

            foreach (IRobot robot in orderedRobots)
            {
                if (robot.BatteryLevel >= totalPowerNeeded)
                {
                    robot.ExecuteService(totalPowerNeeded);
                    counter++;
                    break;
                }
                else 
                {
                    totalPowerNeeded -= robot.BatteryLevel;
                    robot.ExecuteService(robot.BatteryLevel);
                    counter++;

                }

                if (totalPowerNeeded <= 0)
                {
                    break;
                }
            }
            
            return string.Format(OutputMessages.PerformedSuccessfully, serviceName, counter);

        }

        public string RobotRecovery(string model, int minutes)
        {
            var robotsToRecovery = 
                robotRepository.Models()
                    .Where(r => r.Model == model && r.BatteryLevel < r.BatteryCapacity / 2);

            int robotsFed = 0;
            foreach (IRobot robot in robotsToRecovery)
            {
                robot.Eating(minutes);
                robotsFed++;
            }
            return string.Format(OutputMessages.RobotsFed, robotsFed);
        }


        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            var robots = robotRepository.Models()
                .OrderByDescending(r=>r.BatteryLevel)
                .ThenBy(r=>r.BatteryCapacity);
            foreach (IRobot robot in robots)
            {
                sb.AppendLine(robot.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}