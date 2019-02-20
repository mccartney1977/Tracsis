using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TracsisData;

namespace Tracsis.Test
{
    public class DataContextTest
    {
        private Dictionary<string, string> _LookupData { get; set; }
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
            var _LookupData = new LookupContext("fileName");
            var actualHasData = _LookupData;
            // Assert
            Assert.AreEqual(_ExpectedHasData, actualHasData);
        }
    }
}
