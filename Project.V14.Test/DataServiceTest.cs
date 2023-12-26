using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Project.V14.Lib;

namespace Project.V14.Test
{
    [TestClass]
    public class DataServiceTest
    {

        [TestMethod]
        public void CalculateStatistics_ValidData_ReturnsCorrectStatistics()
        {
            // Arrange
            var transportDataList = new List<TransportData>
            {
                new TransportData { TravelTime = "10" },
                new TransportData { TravelTime = "15" },
                new TransportData { TravelTime = "20" },
            };

            // Act
            var result = DataService.CalculateStatistics(transportDataList);

            // Assert
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual(45, result.Sum);
            Assert.AreEqual(15, result.Average);
            Assert.AreEqual(10, result.Min);
            Assert.AreEqual(20, result.Max);
        }
    }
}