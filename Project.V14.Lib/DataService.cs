using System;
using System.Collections.Generic;
using System.Linq;

namespace Project.V14.Lib
{
    public class TransportData
    {
        public string KindOfTransport { get; set; }
        public string Number { get; set; }
        public string Date { get; set; }
        public string StartStop { get; set; }
        public string EndStop { get; set; }
        public string TravelTime { get; set; }
    }

    public class StatisticsResult
    {
        public int Count { get; set; }
        public double Sum { get; set; }
        public double Average { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }
    }

    public static class DataService
    {

        public static StatisticsResult CalculateStatistics(List<TransportData> transportDataList)
        {
            if (transportDataList == null || !transportDataList.Any())
            {
                throw new ArgumentException("Список данных транспорта не может быть пустым.");
            }

            var travelTimes = transportDataList.Select(data => Convert.ToDouble(data.TravelTime));

            return new StatisticsResult
            {
                Count = travelTimes.Count(),
                Sum = travelTimes.Sum(),
                Average = travelTimes.Average(),
                Min = travelTimes.Min(),
                Max = travelTimes.Max()
            };
        }
    }
}