using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using Project.V14.Lib;

namespace Project.V14.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void CountCsvLines_ExcludeHeader_CorrectCount()
        {
            string testFilePath = @"C:\Users\f1zog\source\repos\Tyuiu.KozhevnikovDG.Sprint7\Project.V14\bin\Debug\проект.csv";

            int lineCount = 0;

            // Действие
            using (var reader = new StreamReader(testFilePath))
            {
                // Пропускаем заголовок
                reader.ReadLine();

                // Считаем оставшиеся строки
                while (reader.ReadLine() != null)
                {
                    lineCount++;
                }
            }

            // Проверка
            Assert.AreEqual(1, lineCount); // Предполагаемое количество строк: 14
        }
    }
}
