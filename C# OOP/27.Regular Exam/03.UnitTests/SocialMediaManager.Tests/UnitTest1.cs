using System;
using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;

namespace SocialMediaManager.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructoShouldWorkCorrectly()
        {
            InfluencerRepository influencerRepository = new InfluencerRepository();
            Assert.AreEqual(0, influencerRepository.Influencers.Count());
        }

        [Test]
        public void MethodRegisterInfluencerShouldWorkCorrectly()
        {
            Influencer influencer = new("username", 10);
            InfluencerRepository influencerRepository = new InfluencerRepository();
            string result = influencerRepository.RegisterInfluencer(influencer);
            Assert.AreEqual($"Successfully added influencer {influencer.Username} with {influencer.Followers}", result);

            ArgumentNullException argumentException = Assert.Throws<ArgumentNullException>(()
                => influencerRepository.RegisterInfluencer(null));
            Assert.AreEqual("Influencer is null (Parameter 'influencer')", argumentException.Message);


            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => influencerRepository.RegisterInfluencer(new("username", 10)));
            Assert.AreEqual($"Influencer with username username already exists", exception.Message);
        }

        [Test]
        public void MethodRemoveInfluencerShouldWorkCorrectly()
        {
            Influencer influencer = new("username", 10);
            InfluencerRepository influencerRepository = new InfluencerRepository();
            influencerRepository.RegisterInfluencer(influencer);
            bool result = influencerRepository.RemoveInfluencer("username");
            Assert.IsTrue(result);

            result = influencerRepository.RemoveInfluencer("username");
            Assert.IsFalse(result);

            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(()
                => influencerRepository.RemoveInfluencer(string.Empty));
            Assert.AreEqual("Username cannot be null (Parameter 'username')", exception.Message);

            exception = Assert.Throws<ArgumentNullException>(()
                => influencerRepository.RemoveInfluencer("     "));
            Assert.AreEqual("Username cannot be null (Parameter 'username')", exception.Message);
        }

        [Test]
        public void MethodGetInfluencerWithMostFollowersShouldWorkCorrectly()
        {
            Influencer influencer = new("username", 25);
            InfluencerRepository influencerRepository = new InfluencerRepository();
            influencerRepository.RegisterInfluencer(influencer);
            influencerRepository.RegisterInfluencer(new("username2", 16));
            influencerRepository.RegisterInfluencer(new("username3", 13));
            var result = influencerRepository.GetInfluencerWithMostFollowers();
            Assert.AreEqual(influencer, result);
        }

        [Test]
        public void MethodGetInfluencerShouldWorkCorrectly()
        {
            Influencer influencer = new("username", 25);
            Influencer influencer2 = new("username2", 16);
            InfluencerRepository influencerRepository = new InfluencerRepository();
            influencerRepository.RegisterInfluencer(influencer);
            influencerRepository.RegisterInfluencer(influencer2);
            var result = influencerRepository.GetInfluencer("username2");
            Assert.AreEqual(influencer2, result);
            result = influencerRepository.GetInfluencer("username23");
            Assert.IsNull(result);
        }
    }
}