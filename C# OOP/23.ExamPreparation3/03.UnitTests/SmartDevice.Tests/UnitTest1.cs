namespace SmartDevice.Tests
{
    using NUnit.Framework;
    using System;
    using System.Text;

    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorShouldWorkCorrectly()
        {
            Device device = new Device(10);
            Assert.AreEqual(10,device.MemoryCapacity);
            Assert.AreEqual(10, device.AvailableMemory);
            Assert.AreEqual(0, device.Photos);
            Assert.IsNotNull(device.Applications);
        }

        [Test]
        public void MethodTakePhotosFalse()
        {
            Device device = new Device(10);
            bool result = device.TakePhoto(15);
            Assert.IsFalse(result);
        }

        [Test]
        public void MethodTakePhotosTrue()
        {
            Device device = new Device(10);
            bool result = device.TakePhoto(5);
            Assert.IsTrue(result);
            Assert.AreEqual(5, device.AvailableMemory);
            Assert.AreEqual(1, device.Photos);

            bool result2 = device.TakePhoto(5);
            Assert.IsTrue(result2);
            Assert.AreEqual(0, device.AvailableMemory);
            Assert.AreEqual(2, device.Photos);
        }

        [Test]
        public void MethodInstallAppThrowException()
        {
            Device device = new Device(10);
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => device.InstallApp("name", 15));
            Assert.AreEqual("Not enough available memory to install the app.", exception.Message);
        }

        [Test]
        public void MethpdInstallAppShouldWorkCorrectly()
        {
            Device device = new Device(10);
            string result = device.InstallApp("name", 5);
            Assert.AreEqual(5, device.AvailableMemory);
            Assert.AreEqual(1, device.Applications.Count);
            Assert.AreEqual($"name is installed successfully. Run application?", result);

            string result2 = device.InstallApp("name", 5);
            Assert.AreEqual(0, device.AvailableMemory);
            Assert.AreEqual(2, device.Applications.Count);
            Assert.AreEqual($"name is installed successfully. Run application?", result);
        }

        [Test]
        public void MethodFormatDevice()
        {
            Device device = new Device(10);
            bool result = device.TakePhoto(5);
            Assert.IsTrue(result);
            Assert.AreEqual(5, device.AvailableMemory);
            Assert.AreEqual(1, device.Photos);

            bool result2 = device.TakePhoto(5);
            Assert.IsTrue(result2);
            Assert.AreEqual(0, device.AvailableMemory);
            Assert.AreEqual(2, device.Photos);

            device.FormatDevice();
            Assert.AreEqual(10, device.AvailableMemory);
            Assert.AreEqual(0, device.Photos);
            Assert.AreEqual(0, device.Applications.Count);
        }

        [Test]
        public void MethodGetDeviceStatus()
        {
            Device device = new Device(10);
            bool result = device.TakePhoto(5);
            string result2 = device.InstallApp("name", 5);
            

            StringBuilder stringBuilderExpected = new StringBuilder();

            stringBuilderExpected.AppendLine($"Memory Capacity: 10 MB, Available Memory: 0 MB");
            stringBuilderExpected.AppendLine($"Photos Count: 1");
            stringBuilderExpected.AppendLine($"Applications Installed: {string.Join(", ", device.Applications)}");
            string result3 = device.GetDeviceStatus();
            Assert.AreEqual(stringBuilderExpected.ToString().Trim(), result3);
        }
    }
}