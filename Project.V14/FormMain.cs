using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Project.V14.Lib;

namespace Project.V14
{
    public partial class FormMain : Form
    {
        private List<TransportData> transportDataList = new List<TransportData>();

        public FormMain()
        {
            InitializeComponent();
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            dataGridViewResult_KDG.AutoGenerateColumns = false;

            // Создание столбцов и указание соответствующих заголовков
            DataGridViewTextBoxColumn columnKindOfTransport = new DataGridViewTextBoxColumn();
            columnKindOfTransport.DataPropertyName = "KindOfTransport";
            columnKindOfTransport.HeaderText = "Вид транспорта";
            dataGridViewResult_KDG.Columns.Add(columnKindOfTransport);

            DataGridViewTextBoxColumn columnNumber = new DataGridViewTextBoxColumn();
            columnNumber.DataPropertyName = "Number";
            columnNumber.HeaderText = "Номер маршрута";
            dataGridViewResult_KDG.Columns.Add(columnNumber);

            DataGridViewTextBoxColumn columnDate = new DataGridViewTextBoxColumn();
            columnDate.DataPropertyName = "Date";
            columnDate.HeaderText = "Дата введения маршрута";
            dataGridViewResult_KDG.Columns.Add(columnDate);

            DataGridViewTextBoxColumn columnStartStop = new DataGridViewTextBoxColumn();
            columnStartStop.DataPropertyName = "StartStop";
            columnStartStop.HeaderText = "Начальная остановка";
            dataGridViewResult_KDG.Columns.Add(columnStartStop);

            DataGridViewTextBoxColumn columnEndStop = new DataGridViewTextBoxColumn();
            columnEndStop.DataPropertyName = "EndStop";
            columnEndStop.HeaderText = "Конечная остановка";
            dataGridViewResult_KDG.Columns.Add(columnEndStop);

            DataGridViewTextBoxColumn columnTravelTime = new DataGridViewTextBoxColumn();
            columnTravelTime.DataPropertyName = "TravelTime";
            columnTravelTime.HeaderText = "Время в пути";
            dataGridViewResult_KDG.Columns.Add(columnTravelTime);

            // Привязка к источнику данных
            dataGridViewResult_KDG.DataSource = transportDataList;
        }

        private void buttonAdd_KDG_Click(object sender, EventArgs e)
        {
            TransportData newData = new TransportData
            {
                KindOfTransport = textBoxKindOfTransport_KDG.Text,
                Number = textBoxNumber_KDG.Text,
                Date = textBoxDate_KDG.Text,
                StartStop = textBoxStartStop_KDG.Text,
                EndStop = TextBoxEndStop_KDG.Text,
                TravelTime = textBoxTravelTime_KDG.Text
            };

            transportDataList.Add(newData);

            // Обновление DataGridView
            dataGridViewResult_KDG.DataSource = null;
            dataGridViewResult_KDG.DataSource = transportDataList;
        }

        private void buttonSave_KDG_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV Files (*.csv)|*.csv";
            saveFileDialog.Title = "Save CSV File";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                    {
                        foreach (TransportData data in transportDataList)
                        {
                            sw.WriteLine($"{data.KindOfTransport},{data.Number},{data.Date},{data.StartStop},{data.EndStop},{data.TravelTime}");
                        }
                    }

                    MessageBox.Show("Данные успешно сохранены в файл.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка при сохранении данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonShowResult_KDG_Click(object sender, EventArgs e)
        {
            // Логика отображения статистики
            int count = transportDataList.Count;
            double sumTravelTime = transportDataList.Sum(data => Convert.ToDouble(data.TravelTime));
            double averageTravelTime = sumTravelTime / count;
            double minTravelTime = transportDataList.Min(data => Convert.ToDouble(data.TravelTime));
            double maxTravelTime = transportDataList.Max(data => Convert.ToDouble(data.TravelTime));

            MessageBox.Show($"Count: {count}\nSum: {sumTravelTime}\nAverage: {averageTravelTime}\nMin: {minTravelTime}\nMax: {maxTravelTime}", "Statistics");
        }

        private void buttonFind_KDG_Click(object sender, EventArgs e)
        {
            string searchTerm = textBoxFind_KDG.Text.ToLower();
            List<TransportData> searchResults = transportDataList
                .Where(data =>
                    data.KindOfTransport.ToLower().Contains(searchTerm) ||
                    data.Number.ToLower().Contains(searchTerm) ||
                    data.Date.ToLower().Contains(searchTerm) ||
                    data.StartStop.ToLower().Contains(searchTerm) ||
                    data.EndStop.ToLower().Contains(searchTerm) ||
                    data.TravelTime.ToLower().Contains(searchTerm))
                .ToList();

            // Обновление DataGridView
            dataGridViewResult_KDG.DataSource = null;
            dataGridViewResult_KDG.DataSource = searchResults;
        }
        public class TransportData
        {
            public string KindOfTransport { get; set; }
            public string Number { get; set; }
            public string Date { get; set; }
            public string StartStop { get; set; }
            public string EndStop { get; set; }
            public string TravelTime { get; set; }
        }

        private void buttonAddFile_KDG_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV Files (*.csv)|*.csv";
            openFileDialog.Title = "Open CSV File";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamReader sr = new StreamReader(openFileDialog.FileName))
                    {
                        while (!sr.EndOfStream)
                        {
                            string[] data = sr.ReadLine().Split(',');

                            // Проверка на правильное количество элементов
                            if (data.Length == 6)
                            {
                                TransportData newData = new TransportData
                                {
                                    KindOfTransport = data[0],
                                    Number = data[1],
                                    Date = data[2],
                                    StartStop = data[3],
                                    EndStop = data[4],
                                    TravelTime = data[5]
                                };

                                transportDataList.Add(newData);
                            }
                            else
                            {
                                MessageBox.Show("Ошибка при чтении файла: неверный формат данных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }

                    // Обновление DataGridView
                    dataGridViewResult_KDG.DataSource = null;
                    dataGridViewResult_KDG.DataSource = transportDataList;

                    MessageBox.Show("Данные успешно добавлены из файла.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка при чтении файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonHelp_KDG_Click(object sender, EventArgs e)
        {
            FormAbout formAbout = new FormAbout();
            formAbout.ShowDialog();
        }

        private void buttonAddFile_KDG_MouseEnter(object sender, EventArgs e)
        {
            toolTip_KDG.ToolTipTitle = "Открыть файл";
        }

        private void buttonShowResult_KDG_MouseHover(object sender, EventArgs e)
        {
            toolTip_KDG.ToolTipTitle = "Расчет элементов статистики";
        }

        private void buttonSave_KDG_MouseEnter(object sender, EventArgs e)
        {
            toolTip_KDG.ToolTipTitle = "Сохранить файл";
        }

        private void buttonAdd_KDG_MouseEnter(object sender, EventArgs e)
        {
            toolTip_KDG.ToolTipTitle = "Добавить характеристики в таблиц";
        }

        private void buttonHelp_KDG_MouseEnter(object sender, EventArgs e)
        {
            toolTip_KDG.ToolTipTitle = "Справка";
        }

        private void buttonFind_KDG_MouseEnter(object sender, EventArgs e)
        {
            toolTip_KDG.ToolTipTitle = "Найти элемент из таблицы";
        }
    }
}