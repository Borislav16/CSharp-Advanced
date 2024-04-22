using InfluencerManagerApp.Core.Contracts;
using InfluencerManagerApp.Models;
using InfluencerManagerApp.Repositories;
using InfluencerManagerApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Core
{
    public class Controller : IController
    {
        private InfluencerRepository influencers;
        private CampaignRepository campaigns;
        public Controller()
        {
            influencers = new InfluencerRepository();
            campaigns = new CampaignRepository();
        }

        public string ApplicationReport()
        {
            StringBuilder sb = new StringBuilder();
            var orderedInfluencers = influencers.Models
                .OrderByDescending(i => i.Income)
                .ThenByDescending(i => i.Followers);
            foreach (var influencer in orderedInfluencers)
            {
                sb.AppendLine(influencer.ToString());
                if(influencer.Participations.Count > 0)
                {
                    sb.AppendLine("Active Campaigns:");
                    foreach (var campaignName in influencer.Participations.OrderBy(p => p))
                    {
                        sb.AppendLine($"--{campaigns.FindByName(campaignName).ToString()}");
                    }
                }
            }
            return sb.ToString().Trim();
        }

        public string AttractInfluencer(string brand, string username)
        {
            var influencer = influencers.FindByName(username);
            if (influencer == null)
            {
                return String.Format(OutputMessages.InfluencerNotFound, "InfluencerRepository", username);
            }

            var campaign = campaigns.FindByName(brand);
            if (campaign == null)
            {
                return String.Format(OutputMessages.CampaignNotFound, brand);
            }
            if (influencer.Participations.Contains(brand))
            {
                return String.Format(OutputMessages.InfluencerAlreadyEngaged, username, brand);
            }
            if (campaign.GetType().Name == "ProductCampaign")
            {
                if (influencer.GetType().Name == "FashionInfluencer")
                {
                    if (campaign.Budget < influencer.CalculateCampaignPrice())
                    {
                        return String.Format(OutputMessages.UnsufficientBudget, brand, username);
                    }
                    campaign.Engage(influencer);
                    influencer.EnrollCampaign(campaign.Brand);
                    return String.Format(OutputMessages.InfluencerAttractedSuccessfully, username, brand);
                }
                else if (influencer.GetType().Name == "BusinessInfluencer")
                {
                    if (campaign.Budget < influencer.CalculateCampaignPrice())
                    {
                        return String.Format(OutputMessages.UnsufficientBudget, brand, username);
                    }
                    campaign.Engage(influencer);
                    influencer.EnrollCampaign(campaign.Brand);
                    return String.Format(OutputMessages.InfluencerAttractedSuccessfully, username, brand);
                }
                else
                {
                    return String.Format(OutputMessages.InfluencerNotEligibleForCampaign, username, brand);
                }
            }
            else
            {
                if (influencer.GetType().Name == "BloggerInfluencer")
                {
                    if (campaign.Budget < influencer.CalculateCampaignPrice())
                    {
                        return String.Format(OutputMessages.UnsufficientBudget, brand, username);
                    }
                    campaign.Engage(influencer);
                    influencer.EnrollCampaign(campaign.Brand);
                    return String.Format(OutputMessages.InfluencerAttractedSuccessfully, username, brand);
                }
                else if (influencer.GetType().Name == "BusinessInfluencer")
                {
                    if (campaign.Budget < influencer.CalculateCampaignPrice())
                    {
                        return String.Format(OutputMessages.UnsufficientBudget, brand, username);
                    }
                    campaign.Engage(influencer);
                    influencer.EnrollCampaign(campaign.Brand);
                    return String.Format(OutputMessages.InfluencerAttractedSuccessfully, username, brand);
                }
                else
                {
                    return String.Format(OutputMessages.InfluencerNotEligibleForCampaign, username, brand);
                }
            }
        }

        public string BeginCampaign(string typeName, string brand)
        {
            if (typeName == "ProductCampaign")
            {
                var campaign = campaigns.FindByName(brand);
                if (campaign != null)
                {
                    return String.Format(OutputMessages.CampaignDuplicated, brand);
                }
                campaigns.AddModel(new ProductCampaign(brand));
                return String.Format(OutputMessages.CampaignStartedSuccessfully, brand, typeName);
            }
            else if (typeName == "ServiceCampaign")
            {
                var campaign = campaigns.FindByName(brand);
                if (campaign != null)
                {
                    return String.Format(OutputMessages.CampaignDuplicated, brand);
                }
                campaigns.AddModel(new ServiceCampaign(brand));
                return String.Format(OutputMessages.CampaignStartedSuccessfully, brand, typeName);
            }
            else
            {
                return String.Format(OutputMessages.CampaignTypeIsNotValid, typeName);
            }
        }

        public string CloseCampaign(string brand)
        {
            var campaign = campaigns.FindByName(brand);
            if (campaign == null)
            {
                return String.Format(OutputMessages.InvalidCampaignToClose);
            }
            if (campaign.Budget <= 10000)
            {
                return String.Format(OutputMessages.CampaignCannotBeClosed, brand);
            }
            else
            {
                foreach (var influencer in campaign.Contributors)
                {
                    var contributor = influencers.FindByName(influencer);
                    if (contributor != null)
                    {
                        contributor.EarnFee(2000);
                        contributor.EndParticipation(brand);
                    }
                }
                campaigns.RemoveModel(campaign);
                return String.Format(OutputMessages.CampaignClosedSuccessfully, brand);
            }
        }

        public string ConcludeAppContract(string username)
        {
            var influencer = influencers.FindByName(username);
            if (influencer == null)
            {
                return String.Format(OutputMessages.InfluencerNotSigned, username);
            }
            if (influencer.Participations.Count > 0)
            {
                return String.Format(OutputMessages.InfluencerHasActiveParticipations, username);
            }
            influencers.RemoveModel(influencer);
            return String.Format(OutputMessages.ContractConcludedSuccessfully, username);
        }

        public string FundCampaign(string brand, double amount)
        {
            var campaign = campaigns.FindByName(brand);
            if (campaign == null)
            {
                return String.Format(OutputMessages.InvalidCampaignToFund);
            }
            if (amount < 0)
            {
                return String.Format(OutputMessages.NotPositiveFundingAmount);
            }
            campaign.Gain(amount);
            return String.Format(OutputMessages.CampaignFundedSuccessfully, brand, amount);
        }

        public string RegisterInfluencer(string typeName, string username, int followers)
        {
            if (typeName == "BusinessInfluencer")
            {
                var influencer = influencers.FindByName(username);
                if (influencer != null)
                {
                    return String.Format(OutputMessages.UsernameIsRegistered, username, "InfluencerRepository");
                }
                influencers.AddModel(new BusinessInfluencer(username, followers));
                return String.Format(OutputMessages.InfluencerRegisteredSuccessfully, username);
            }
            else if (typeName == "FashionInfluencer")
            {
                var influencer = influencers.FindByName(username);
                if (influencer != null)
                {
                    return String.Format(OutputMessages.UsernameIsRegistered, username, "InfluencerRepository");
                }
                influencers.AddModel(new FashionInfluencer(username, followers));
                return String.Format(OutputMessages.InfluencerRegisteredSuccessfully, username);
            }
            else if (typeName == "BloggerInfluencer")
            {
                var influencer = influencers.FindByName(username);
                if (influencer != null)
                {
                    return String.Format(OutputMessages.UsernameIsRegistered, username, "InfluencerRepository");
                }
                influencers.AddModel(new BloggerInfluencer(username, followers));
                return String.Format(OutputMessages.InfluencerRegisteredSuccessfully, username);
            }
            else
            {
                return String.Format(OutputMessages.InfluencerInvalidType, typeName);
            }
        }
    }
}
