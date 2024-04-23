using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Models
{
    public abstract class Influencer : IInfluencer
    {
        protected Influencer(string username, int followers, double engagementRate)
        {
            Username = username;
            Followers = followers;
            EngagementRate = engagementRate;
            participations = new List<string>();
        }
        private string username;

        public string Username
        {
            get { return username; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.UsernameIsRequired);
                }
                username = value;
            }
        }

        private int followers;

        public int Followers
        {
            get { return followers; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.FollowersCountNegative);
                }
                followers = value;
            }
        }


        private double engagementRate;

        public double EngagementRate
        {
            get { return engagementRate; }
            protected set { engagementRate = value; }
        }


        private double income;

        public double Income
        {
            get { return income; }
            private set { income = value; }
        }


        private List<string> participations;

        public IReadOnlyCollection<string> Participations
        {
            get { return participations.AsReadOnly(); }

        }

        public virtual int CalculateCampaignPrice()
        {
            return (int)Math.Floor(Followers * EngagementRate);
        }

        public void EarnFee(double amount)
        {
            Income += amount;
        }

        public void EndParticipation(string brand)
        {
            participations.Remove(brand);
        }

        public void EnrollCampaign(string brand)
        {
            participations.Add(brand);
        }

        public override string ToString()
        {
            return $"{Username} - Followers: {Followers}, Total Income: {Income}";
        }
    }
}
