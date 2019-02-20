using NUnit.Framework;
using TracsisData.Entity;

namespace Tests
{
    public class LookupEntityTest
    {
        private string _DataRow { get; set; }
        private bool _ExpectedIsValid { get; set; }

        [SetUp]
        public void Setup()
        {
            _DataRow = null;
            _ExpectedIsValid = false;
        }

        [Test]
        public void LookupEntity_NullInput_InValid_Test()
        {
            // Arrange
            // Act
            var lookupEntity = new LookupEntity(_DataRow);
            var actualIsValid = lookupEntity.IsValid;
            // Assert
            Assert.AreEqual(_ExpectedIsValid, actualIsValid);
        }

        [Test]
        public void LookupEntity_EmptyInput_InValid_Test()
        {
            // Arrange
            _DataRow = string.Empty;
            // Act
            var lookupEntity = new LookupEntity(_DataRow);
            var actualIsValid = lookupEntity.IsValid;
            // Assert
            Assert.AreEqual(_ExpectedIsValid, actualIsValid);
        }

        [Test]
        public void LookupEntity_NoTabSeparator_InValid_Test()
        {
            // Arrange
            _DataRow = "GLASGlasgow";
            // Act
            var lookupEntity = new LookupEntity(_DataRow);
            var actualIsValid = lookupEntity.IsValid;
            // Assert
            Assert.AreEqual(_ExpectedIsValid, actualIsValid);
        }

        [Test]
        public void LookupEntity_EmptyIndex_InValid_Test()
        {
            // Arrange
            _DataRow = "\tGlasgow";
            // Act
            var lookupEntity = new LookupEntity(_DataRow);
            var actualIsValid = lookupEntity.IsValid;
            // Assert
            Assert.AreEqual(_ExpectedIsValid, actualIsValid);
        }

        [Test]
        public void LookupEntity_EmptyValue_InValid_Test()
        {
            // Arrange
            _DataRow = "GLAS\t";
            // Act
            var lookupEntity = new LookupEntity(_DataRow);
            var actualIsValid = lookupEntity.IsValid;
            // Assert
            Assert.AreEqual(_ExpectedIsValid, actualIsValid);
        }

        [Test]
        public void LookupEntity_IsValid_Test()
        {
            // Arrange
            _DataRow = "GLAS\tGlasgow";
            _ExpectedIsValid = true;
            // Act
            var lookupEntity = new LookupEntity(_DataRow);
            var actualIsValid = lookupEntity.IsValid;
            // Assert
            Assert.AreEqual(_ExpectedIsValid, actualIsValid);
        }
    }
}