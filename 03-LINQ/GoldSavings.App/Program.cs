using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace GoldSavings.App.Model
{
    public class GoldPrice
    {
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
    }
}

namespace GoldSavings.App.Services
{
        public class GoldDataService
    {
        public List<GoldPrice> GetGoldPrices(DateTime startDate, DateTime endDate)
        {
            return new List<GoldPrice>
            {
                new GoldPrice { Date = new DateTime(2020, 01, 01), Price = 1500m },
                new GoldPrice { Date = new DateTime(2020, 02, 01), Price = 1550m },
                new GoldPrice { Date = new DateTime(2021, 01, 01), Price = 1700m },
                new GoldPrice { Date = new DateTime(2022, 01, 01), Price = 1750m },
                new GoldPrice { Date = new DateTime(2023, 01, 01), Price = 1800m },
                new GoldPrice { Date = new DateTime(2024, 01, 01), Price = 1900m }
            };
        }
    }
}

namespace GoldSavings.App
{
    using GoldSavings.App.Model;
    using GoldSavings.App.Services;

    class Program
    {
        static void Main(string[] args)
        {
            string outputFilePath = "goldPricesAnalysis.txt";
            File.WriteAllText(outputFilePath, "Gold Prices Analysis Results\n\n");

            // Step 1: Retrieve the gold prices
            GoldDataService dataService = new GoldDataService();
            DateTime startDate = new DateTime(2020, 01, 01); // Start is data retrieval
            DateTime endDate = DateTime.Now; // End is current date
            List<GoldPrice> goldPrices = dataService.GetGoldPrices(startDate, endDate);

            if (goldPrices.Count == 0)
            {
                File.AppendAllText(outputFilePath, "No data found. Exiting.\n");
                return;
            }

            File.AppendAllText(outputFilePath, $"Retrieved {goldPrices.Count} records. Ready for analysis.\n");

            // Step 2: Perform LINQ Queries for Analysis

            // a. Top 3 highest and lowest prices in the last year
            File.AppendAllText(outputFilePath, "\nTop 3 Highest and Lowest Gold Prices:\n");
            AnalyzeGoldPrices(goldPrices, outputFilePath);

            // b. Check if one could earn more than 5% since January 2020
            File.AppendAllText(outputFilePath, "\nEarnings More Than 5% Since January 2020:\n");
            CheckEarningsFromJan2020(goldPrices, outputFilePath);

            // c. Dates of 2022-2019 in the second ten of the prices ranking
            File.AppendAllText(outputFilePath, "\nSecond Ten Prices of 2022-2019:\n");
            GetSecondTenDates(goldPrices, outputFilePath);

            // d. Average prices in 2020, 2023, and 2024
            File.AppendAllText(outputFilePath, "\nAverage Gold Prices in 2020, 2023, 2024:\n");
            GetAveragePrices(goldPrices, outputFilePath);

            // e. Best buy/sell times and ROI between 2020-2024
            File.AppendAllText(outputFilePath, "\nBest Time to Buy and Sell Gold Between 2020-2024:\n");
            BestBuySellTimes(goldPrices, outputFilePath);

            // Step 3: Save Gold Prices to XML
            string filePath = "goldPrices.xml";
            SaveGoldPricesToXML(goldPrices, filePath);

            // Step 4: Read Gold Prices from XML (One Instruction)
            var goldPricesFromFile = ReadGoldPricesFromXML(filePath);
            File.AppendAllText(outputFilePath, "\nRead Gold Prices from XML:\n");
            foreach (var price in goldPricesFromFile)
            {
                File.AppendAllText(outputFilePath, $"{price.Date.ToShortDateString()} - {price.Price}\n");
            }

            File.AppendAllText(outputFilePath, "\nGold Analysis Queries Completed.\n");
        }

        // a. TOP 3 highest and TOP 3 lowest prices
        public static void AnalyzeGoldPrices(List<GoldPrice> goldPrices, string outputFilePath)
        {
            var top3HighestPrices = goldPrices.OrderByDescending(p => p.Price).Take(3).ToList();
            var top3LowestPrices = goldPrices.OrderBy(p => p.Price).Take(3).ToList();

            File.AppendAllText(outputFilePath, "Top 3 Highest Gold Prices:\n");
            foreach (var price in top3HighestPrices)
            {
                File.AppendAllText(outputFilePath, $"{price.Date.ToShortDateString()} - {price.Price}\n");
            }

            File.AppendAllText(outputFilePath, "\nTop 3 Lowest Gold Prices:\n");
            foreach (var price in top3LowestPrices)
            {
                File.AppendAllText(outputFilePath, $"{price.Date.ToShortDateString()} - {price.Price}\n");
            }
        }

        // b. Earnings more than 5% from January 2020
        public static void CheckEarningsFromJan2020(List<GoldPrice> goldPrices, string outputFilePath)
        {
            var january2020Price = goldPrices.FirstOrDefault(p => p.Date.Month == 1 && p.Date.Year == 2020)?.Price;

            if (january2020Price == null)
            {
                File.AppendAllText(outputFilePath, "No data found for January 2020.\n");
                return;
            }

            var datesWith5PercentEarnings = goldPrices.Where(p => p.Price > january2020Price * 1.05)
                                                      .Select(p => p.Date)
                                                      .ToList();

            File.AppendAllText(outputFilePath, "Dates with more than 5% earnings since January 2020:\n");
            foreach (var date in datesWith5PercentEarnings)
            {
                File.AppendAllText(outputFilePath, $"{date.ToShortDateString()}\n");
            }
        }

        // c. Dates of 2022-2019 in the second ten of the prices ranking
        public static void GetSecondTenDates(List<GoldPrice> goldPrices, string outputFilePath)
        {
            var secondTenPrices = goldPrices.Where(p => p.Date.Year >= 2019 && p.Date.Year <= 2022)
                                            .OrderBy(p => p.Price)
                                            .Skip(10)
                                            .Take(3)
                                            .ToList();

            File.AppendAllText(outputFilePath, "Second Ten Prices in 2019-2022:\n");
            foreach (var price in secondTenPrices)
            {
                File.AppendAllText(outputFilePath, $"{price.Date.ToShortDateString()} - {price.Price}\n");
            }
        }

        // d. Average prices in 2020, 2023, and 2024
        public static void GetAveragePrices(List<GoldPrice> goldPrices, string outputFilePath)
        {
            var avgPricesByYear = from price in goldPrices
                                  where price.Date.Year == 2020 || price.Date.Year == 2023 || price.Date.Year == 2024
                                  group price by price.Date.Year into g
                                  select new
                                  {
                                      Year = g.Key,
                                      AveragePrice = g.Average(p => p.Price)
                                  };

            foreach (var yearPrice in avgPricesByYear)
            {
                File.AppendAllText(outputFilePath, $"Average price in {yearPrice.Year}: {yearPrice.AveragePrice}\n");
            }
        }

        // e. Best time to buy and sell gold, and calculate ROI
        public static void BestBuySellTimes(List<GoldPrice> goldPrices, string outputFilePath)
        {
            var bestBuySell = goldPrices.Where(p => p.Date.Year >= 2020 && p.Date.Year <= 2024)
                                        .OrderBy(p => p.Date)
                                        .Select((price, index) => new { Price = price, Index = index })
                                        .SelectMany((p, i) => goldPrices.Skip(i + 1).Select(s => new { Buy = p.Price, Sell = s }))
                                        .Where(b => b.Sell.Price > b.Buy.Price)
                                        .OrderByDescending(b => b.Sell.Price - b.Buy.Price)
                                        .FirstOrDefault();

            if (bestBuySell != null)
            {
                File.AppendAllText(outputFilePath, $"Best time to buy: {bestBuySell.Buy.Date.ToShortDateString()} at {bestBuySell.Buy.Price}\n");
                File.AppendAllText(outputFilePath, $"Best time to sell: {bestBuySell.Sell.Date.ToShortDateString()} at {bestBuySell.Sell.Price}\n");
                File.AppendAllText(outputFilePath, $"Return on Investment: {((bestBuySell.Sell.Price - bestBuySell.Buy.Price) / bestBuySell.Buy.Price) * 100}%\n");
            }
            else
            {
                File.AppendAllText(outputFilePath, "No profitable buy and sell opportunities found.\n");
            }
        }

        // Step 3: Save Gold Prices to XML
        public static void SaveGoldPricesToXML(List<GoldPrice> goldPrices, string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<GoldPrice>));
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, goldPrices);
            }
            File.AppendAllText("goldPricesAnalysis.txt", "\nGold prices saved to XML file.\n");
        }

        // Step 4: Read Gold Prices from XML (One Instruction)
        public static List<GoldPrice> ReadGoldPricesFromXML(string filePath)
        {
            return new XmlSerializer(typeof(List<GoldPrice>))
                .Deserialize(new StreamReader(filePath)) as List<GoldPrice>;
        }
    }
}
