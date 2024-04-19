using HighwayToPeak.Core.Contracts;
using HighwayToPeak.Models;
using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories;
using HighwayToPeak.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayToPeak.Core
{
    public class Controller : IController
    {
        private ClimberRepository climbers;
        private PeakRepository peaks;
        private BaseCamp baseCamp;

        public Controller()
        {
            climbers = new ClimberRepository();
            peaks = new PeakRepository();
            baseCamp = new BaseCamp();
        }
        public string AddPeak(string name, int elevation, string difficultyLevel)
        {
            var peak = peaks.Get(name);
            if (peak != null)
            {
                return String.Format(OutputMessages.PeakAlreadyAdded, name);
            }

            if (difficultyLevel == "Extreme")
            {
                peaks.Add(new Peak(name, elevation, difficultyLevel));
                return String.Format(OutputMessages.PeakIsAllowed, name, "PeakRepository");
            }
            else if (difficultyLevel == "Hard")
            {
                peaks.Add(new Peak(name, elevation, difficultyLevel));
                return String.Format(OutputMessages.PeakIsAllowed, name, "PeakRepository");
            }
            else if (difficultyLevel == "Moderate")
            {
                peaks.Add(new Peak(name, elevation, difficultyLevel));
                return String.Format(OutputMessages.PeakIsAllowed, name, "PeakRepository");
            }
            else
            {
                return String.Format(OutputMessages.PeakDiffucultyLevelInvalid, difficultyLevel);
            }
        }

        public string NewClimberAtCamp(string name, bool isOxygenUsed)
        {
            var climber = climbers.Get(name);
            if (climber != null)
            {
                return String.Format(OutputMessages.ClimberCannotBeDuplicated, name, "ClimberRepository");
            }

            if (isOxygenUsed)
            {
                climbers.Add(new OxygenClimber(name));
                baseCamp.ArriveAtCamp(name);
                return String.Format(OutputMessages.ClimberArrivedAtBaseCamp, name);
            }
            else
            {
                climbers.Add(new NaturalClimber(name));
                baseCamp.ArriveAtCamp(name);
                return String.Format(OutputMessages.ClimberArrivedAtBaseCamp, name);
            }
        }

        public string AttackPeak(string climberName, string peakName)
        {
            var climber = climbers.Get(climberName);
            if (climber == null)
            {
                return String.Format(OutputMessages.ClimberNotArrivedYet, climberName);
            }

            var peak = peaks.Get(peakName);
            if (peak == null)
            {
                return String.Format(OutputMessages.PeakIsNotAllowed, peakName);
            }

            if (peak.DifficultyLevel == "Extreme" && climber.GetType().Name == "NaturalClimber" )
            {
                return String.Format(OutputMessages.NotCorrespondingDifficultyLevel, climberName, peakName);
            }

            var camp = baseCamp.Residents.FirstOrDefault(b => b == climberName);
            if (camp == null)
            {
                return String.Format(OutputMessages.ClimberNotFoundForInstructions, climberName, peakName);
            }

            baseCamp.LeaveCamp(climberName);
            climber.Climb(peak);
            if (climber.Stamina == 0)
            {
                return String.Format(OutputMessages.NotSuccessfullAttack, climberName);
            }
            else
            {
                baseCamp.ArriveAtCamp(climberName);
                return String.Format(OutputMessages.SuccessfulAttack, climberName, peakName);
            }
        }

        public string CampRecovery(string climberName, int daysToRecover)
        {
            var camp = baseCamp.Residents.FirstOrDefault(b => b == climberName);
            if (camp == null)
            {
                return String.Format(OutputMessages.ClimberIsNotAtBaseCamp, climberName);
            }
            var climber = climbers.Get(climberName);
            if (climber.GetType().Name == "OxygenClimber")
            {
                if (climber.Stamina == 10)
                {
                    return String.Format(OutputMessages.NoNeedOfRecovery, climberName);
                }
                else
                {
                    climber.Rest(daysToRecover);
                    return String.Format(OutputMessages.ClimberRecovered, climberName, daysToRecover);

                }
            }
            else
            {
                if (climber.Stamina > 6)
                {
                    return String.Format(OutputMessages.NoNeedOfRecovery, climberName);
                }
                else
                {
                    climber.Rest(daysToRecover);
                    return String.Format(OutputMessages.ClimberRecovered, climberName, daysToRecover);

                }
            }

        }

        public string BaseCampReport()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("BaseCamp residents:");
            if (baseCamp.Residents.Count == 0)
            {
                sb.AppendLine("BaseCamp is currently empty.");
            }
            else
            {
                foreach (var climberName in baseCamp.Residents.OrderBy(x => x))
                {
                    var climber = climbers.Get(climberName);
                    sb.AppendLine($"Name: {climberName}, Stamina: {climber.Stamina}, Count of Conquered Peaks: {climber.ConqueredPeaks.Count}");
                }
            }

            return sb.ToString().Trim();
        }


        public string OverallStatistics()
        {
            var orderedClimbers = climbers.All
                .OrderByDescending(c => c.ConqueredPeaks.Count)
                .ThenBy(c => c.Name);
                
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***Highway-To-Peak***");
            foreach (var climber in orderedClimbers)
            {
                sb.AppendLine(climber.ToString());
                var orderedPeaks = new List<IPeak>();
                foreach (var peak in climber.ConqueredPeaks)
                {
                    orderedPeaks.Add(peaks.Get(peak));
                }
                foreach (var item in orderedPeaks.OrderByDescending(op => op.Elevation))
                {
                    sb.AppendLine(item.ToString());
                }
            }
            return sb.ToString().Trim();
        }
    }
}
