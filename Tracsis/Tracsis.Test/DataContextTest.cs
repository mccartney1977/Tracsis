using NUnit.Framework;
using TracsisData;

namespace Tracsis.Test
{
    public class DataContextTest
    {
        private IDataContext _LookupData { get; set; }
        private bool _ExpectedHasData { get; set; }

        [SetUp]
        public void Setup()
        {
            _LookupData = null;
            _ExpectedHasData = false;
        }

        [Test]
        public void LookupData_Null_NoHasData_Test()
        {
            // Arrange
            // Act
            var _LookupData = new LookupContext();
            var actualHasData = _LookupData.HasData;

            // Assert
            Assert.AreEqual(_ExpectedHasData, actualHasData);
        }
    }
}