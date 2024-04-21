namespace Television.Tests
{
    using System;
    using System.Diagnostics;
    using NUnit.Framework;
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorShouldWork()
        {
            TelevisionDevice televisionDevice = new("brand", 24, 14, 4);
            Assert.AreEqual("brand", televisionDevice.Brand);
            Assert.AreEqual(24, televisionDevice.Price);
            Assert.AreEqual(14, televisionDevice.ScreenWidth);
            Assert.AreEqual(4, televisionDevice.ScreenHeigth);
            Assert.AreEqual(0, televisionDevice.CurrentChannel);
            Assert.AreEqual(13, televisionDevice.Volume);
            Assert.AreEqual(false, televisionDevice.IsMuted);
        }

        [Test]
        public void MethodSwitchOnShouldWorkCorrectluy()
        {
            TelevisionDevice televisionDevice = new("brand", 24, 14, 4);
            string result = televisionDevice.SwitchOn();
            Assert.AreEqual($"Cahnnel 0 - Volume 13 - Sound On", result);
        }

        [Test]
        public void MethodChangeChannelShouldWork()
        {
            TelevisionDevice televisionDevice = new("brand", 24, 14, 4);
            int result = televisionDevice.ChangeChannel(15);
            Assert.AreEqual(15, result);

            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => televisionDevice.ChangeChannel(-1));
            Assert.AreEqual("Invalid key!", exception.Message);

            exception = Assert.Throws<ArgumentException>(()
                => televisionDevice.ChangeChannel(-100));
            Assert.AreEqual("Invalid key!", exception.Message);
        }

        [Test]
        public void MethodVolumeChangeShouldWorkCorrectly()
        {
            TelevisionDevice televisionDevice = new("brand", 24, 14, 4);
            string result = televisionDevice.VolumeChange("left", 50);
            Assert.AreEqual($"Volume: 13", result);

            result = televisionDevice.VolumeChange("UP", 50);
            Assert.AreEqual($"Volume: 63", result);

            result = televisionDevice.VolumeChange("UP", 150);
            Assert.AreEqual($"Volume: 100", result);

            result = televisionDevice.VolumeChange("DOWN", 50);
            Assert.AreEqual($"Volume: 50", result);

            result = televisionDevice.VolumeChange("DOWN", 150);
            Assert.AreEqual($"Volume: 0", result);
        }

        [Test]
        public void MethodMuteDeviceShouldWorkCorrectly()
        {
            TelevisionDevice televisionDevice = new("brand", 24, 14, 4);
            bool result = televisionDevice.MuteDevice();
            Assert.IsTrue(result);
            result = televisionDevice.MuteDevice();
            Assert.IsFalse(result);
        }

        [Test]
        public void MethodToStringShouldWork()
        {
            TelevisionDevice televisionDevice = new("brand", 24, 14, 4);
            string result = televisionDevice.ToString();
            Assert.AreEqual($"TV Device: brand, Screen Resolution: 14x4, Price 24$", result);
        }
    }
}