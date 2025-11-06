using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public struct UserSession
    {
        public string Login { get; set; }
        public DateTime SessionDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public double DataReceivedKb { get; set; }
        public double DataSentKb { get; set; }

        public TimeSpan Duration => EndTime - StartTime;
        public double TotalTrafficMb => (DataReceivedKb + DataSentKb) / 1024.0;
    }

    public partial class Form1 : Form
    {
        private List<UserSession> allSessions = new List<UserSession>();

        public Form1()
        {
            InitializeComponent();
            SetupDataGridView(); 
            AddTestData();       
            DisplaySessions(allSessions); 
        }

        private void btnAddSession_Click(object sender, EventArgs e)
        {
            if (!TimeSpan.TryParse(txtStartTime.Text, out TimeSpan startTime) ||
                !TimeSpan.TryParse(txtEndTime.Text, out TimeSpan endTime) ||
                !double.TryParse(txtDataReceived.Text, out double receivedKb) ||
                !double.TryParse(txtDataSent.Text, out double sentKb) ||
                string.IsNullOrWhiteSpace(txtLogin.Text))
            {
                MessageBox.Show("Помилка введення даних. Перевірте формат часу (гг:хв) та чисел.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var newSession = new UserSession
            {
                Login = txtLogin.Text,
                SessionDate = dtpSessionDate.Value.Date,
                StartTime = startTime,
                EndTime = endTime,
                DataReceivedKb = receivedKb,
                DataSentKb = sentKb
            };

            allSessions.Add(newSession);
            DisplaySessions(allSessions);

            txtLogin.Clear();
            txtStartTime.Clear();
            txtEndTime.Clear();
            txtDataReceived.Clear();
            txtDataSent.Clear();
        }

        private void btnFilterByTraffic_Click(object sender, EventArgs e)
        {
            DateTime startDate = dtpStartDate.Value.Date;
            DateTime endDate = dtpEndDate.Value.Date;

            List<UserSession> results = allSessions
                .Where(s => s.SessionDate >= startDate && s.SessionDate <= endDate && s.TotalTrafficMb > 20)
                .ToList();

            DisplaySessions(results, "Результати пошуку: Користувачі з трафіком > 20 Мб");
        }

        private void btnCountByMonth_Click(object sender, EventArgs e)
        {
            int month = (int)numMonth.Value;
            int lastYear = DateTime.Now.Year - 1;

            int sessionCount = allSessions.Count(s => s.SessionDate.Year == lastYear && s.SessionDate.Month == month);

            MessageBox.Show($"У {month}-му місяці {lastYear} року було знайдено {sessionCount} сеансів.", "Результат підрахунку");
        }

        private void btnFindMaxDuration_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = dtpSingleDate.Value.Date;
            var sessionsOnDate = allSessions.Where(s => s.SessionDate == selectedDate).ToList();

            if (!sessionsOnDate.Any())
            {
                MessageBox.Show($"Сеансів за {selectedDate:dd.MM.yyyy} не знайдено.", "Інформація");
                return;
            }

            TimeSpan maxDuration = sessionsOnDate.Max(s => s.Duration);
            MessageBox.Show($"Максимальна тривалість сеансу: {maxDuration:hh\\:mm\\:ss}", $"Результат за {selectedDate:dd.MM.yyyy}");
        }

        private void btnShowByDate_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = dtpSingleDate.Value.Date;
            var sessionsOnDate = allSessions.Where(s => s.SessionDate == selectedDate).ToList();
            DisplaySessions(sessionsOnDate, $"Всі сеанси за {selectedDate:dd.MM.yyyy}");
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            DisplaySessions(allSessions);
        }

        private void SetupDataGridView()
        {
            dgvSessions.Rows.Clear();
            dgvSessions.Columns.Clear();
            dgvSessions.AutoGenerateColumns = false; 

            dgvSessions.Columns.Add("Login", "Логін");
            dgvSessions.Columns.Add("SessionDate", "Дата сеансу");
            dgvSessions.Columns.Add("Duration", "Тривалість");
            dgvSessions.Columns.Add("TotalTrafficMb", "Трафік (Мб)");

            dgvSessions.Columns["SessionDate"].DefaultCellStyle.Format = "dd.MM.yyyy";
            dgvSessions.Columns["TotalTrafficMb"].DefaultCellStyle.Format = "F2"; 
            dgvSessions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Розтягуємо колон
        }

        // Універсальний метод для відображення будь-якого списку сеансів у таблиці
        private void DisplaySessions(List<UserSession> sessions, string message = "Всі сеанси")
        {
            dgvSessions.Rows.Clear(); 

            if (!sessions.Any())
            {
                // Якщо список порожній, можна додати рядок з повідомленням
                // Або просто залишити таблицю пустою
                // (Для MessageBox буде окреме повідомлення в логіці кнопок)
            }
            else
            {
                foreach (var s in sessions)
                {
                    dgvSessions.Rows.Add(s.Login, s.SessionDate, $"{s.Duration:hh\\:mm\\:ss}", s.TotalTrafficMb);
                }
            }
            this.Text = $"Білінгова система | {message}";
        }

        private void AddTestData()
        {
            allSessions.Add(new UserSession { Login = "user1", SessionDate = new DateTime(2025, 10, 20), StartTime = new TimeSpan(10, 0, 0), EndTime = new TimeSpan(11, 30, 0), DataReceivedKb = 25000, DataSentKb = 5000 });
            allSessions.Add(new UserSession { Login = "user2", SessionDate = new DateTime(2025, 10, 21), StartTime = new TimeSpan(14, 15, 0), EndTime = new TimeSpan(14, 45, 0), DataReceivedKb = 5000, DataSentKb = 1000 });
            allSessions.Add(new UserSession { Login = "user3", SessionDate = new DateTime(2025, 10, 21), StartTime = new TimeSpan(18, 0, 0), EndTime = new TimeSpan(20, 10, 0), DataReceivedKb = 18000, DataSentKb = 8000 });
            allSessions.Add(new UserSession { Login = "user1", SessionDate = new DateTime(2024, 5, 15), StartTime = new TimeSpan(20, 0, 0), EndTime = new TimeSpan(22, 0, 0), DataReceivedKb = 15000, DataSentKb = 2000 });
        }
    }
}