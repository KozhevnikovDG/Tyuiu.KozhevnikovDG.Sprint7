using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Project.V14.Lib
{
    public class DataService
    {
        public static int CountCsvLines(string filePath)
        {
            int lineCount = 0;

            using (var reader = new StreamReader(filePath))
            {
                // Пропускаем заголовок
                reader.ReadLine();

                // Считаем оставшиеся строки
                while (reader.ReadLine() != null)
                {
                    lineCount++;
                }
            }

            return lineCount;
        }
    }
}