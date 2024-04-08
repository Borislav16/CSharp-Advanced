using Handball.Core.Contracts;
using Handball.Models;
using Handball.Models.Contracts;
using Handball.Repositories;
using Handball.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Core
{
    public class Controller : IController
    {
        private PlayerRepository players;
        private TeamRepository teams;
        public Controller()
        {
            players = new PlayerRepository();
            teams = new TeamRepository();
        }
        public string NewTeam(string name)
        {
            var team = teams.ExistsModel(name);
            if (team)
            {
                return String.Format(OutputMessages.TeamAlreadyExists, name, "TeamRepository");
            }
            teams.AddModel(new Team(name));
            return String.Format(OutputMessages.TeamSuccessfullyAdded, name, "TeamRepository");
        }

        public string NewPlayer(string typeName, string name)
        {
            if (players.ExistsModel(name))
            {
                var player = players.GetModel(name);
                return String.Format(OutputMessages.PlayerIsAlreadyAdded, name, "PlayerRepository", player.GetType().Name);
            }
            if (typeName == "Goalkeeper")
            {
                players.AddModel(new Goalkeeper(name));
                return String.Format(OutputMessages.PlayerAddedSuccessfully, name);
            }
            else if (typeName == "CenterBack")
            {
                players.AddModel(new CenterBack(name));
                return String.Format(OutputMessages.PlayerAddedSuccessfully, name);
            }
            else if (typeName == "ForwardWing")
            {
                players.AddModel(new ForwardWing(name));
                return String.Format(OutputMessages.PlayerAddedSuccessfully, name);
            }
            else
            {
                return String.Format(OutputMessages.InvalidTypeOfPosition, typeName);
            }
            

        }

        public string NewContract(string playerName, string teamName)
        {
            var player = players.GetModel(playerName);
            var team = teams.GetModel(teamName);
            if(player == null)
            {
                return String.Format(OutputMessages.PlayerNotExisting, playerName, "PlayerRepository");
            }
            if(team == null)
            {
                return String.Format(OutputMessages.TeamNotExisting, teamName, "TeamRepository");
            }
            if (player.Team != null)
            {
                return String.Format(OutputMessages.PlayerAlreadySignedContract, playerName, player.Team);
            }
            team.SignContract(player);
            player.JoinTeam(teamName);
            return String.Format(OutputMessages.SignContract, playerName, teamName);

        }
        public string NewGame(string firstTeamName, string secondTeamName)
        {
            var firstTeam = teams.GetModel(firstTeamName);
            var secondTeam = teams.GetModel(secondTeamName);
            if(firstTeam.OverallRating != secondTeam.OverallRating)
            {
                if(firstTeam.OverallRating > secondTeam.OverallRating)
                {
                    firstTeam.Win();
                    secondTeam.Lose();
                    return String.Format(OutputMessages.GameHasWinner, firstTeam.Name, secondTeam.Name);
                }
                else
                {
                    firstTeam.Lose();
                    secondTeam.Win();
                    return String.Format(OutputMessages.GameHasWinner, secondTeam.Name, firstTeam.Name);
                }
            }
            firstTeam.Draw();
            secondTeam.Draw();
            return String.Format(OutputMessages.GameIsDraw, firstTeam.Name, secondTeam.Name);
        }

        public string PlayerStatistics(string teamName)
        {
            var team = teams.GetModel(teamName);
            var playersFromSelectedTeam = team.Players
                .OrderByDescending(p => p.Rating)
                .ThenBy(p => p.Name);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"***{teamName}***");
            foreach (var player in playersFromSelectedTeam)
            {
                sb.AppendLine(player.ToString());
            }
            return sb.ToString().Trim();
        }

        public string LeagueStandings()
        {
            var allTeams = teams.Models
                .OrderByDescending(t => t.PointsEarned)
                .ThenByDescending(t => t.OverallRating)
                .ThenBy(t => t.Name);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"***League Standings***");
            foreach(var team in allTeams) 
            {
                sb.AppendLine(team.ToString());
            }
            return sb.ToString().Trim();
        }



    }
}
