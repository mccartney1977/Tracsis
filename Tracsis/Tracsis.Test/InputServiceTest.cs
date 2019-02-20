using NUnit.Framework;
using Tracsis.Service;

namespace Tracsis.Test
{
    public class InputServiceTest
    {
        public IInputService _InputService { get; set; }
        public bool _ExpectedHasData { get; set; }

        [SetUp]
        public void Setup()
        {
            _InputService = new InputService();
            _ExpectedHasData = false;
        }

        [Test]
        public void HasCodes_Empty_False_Test()
        {
            // Arrange
            // Act
            var actualHasData = _InputService.HasCodes;
            // Assert
            Assert.AreEqual(_ExpectedHasData, actualHasData);
        }
    }
}