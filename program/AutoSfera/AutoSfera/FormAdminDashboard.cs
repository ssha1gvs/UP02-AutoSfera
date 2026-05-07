using System;
using System.Drawing;
using System.Windows.Forms;

namespace AutoSfera
{
    public class FormAdminDashboard : Form
    {
        private Panel sidebarPanel;
        private Panel contentPanel;
        private string accountName;

        public FormAdminDashboard(string account)
        {
            accountName = account;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.ClientSize = new Size(1100, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(244, 246, 249);
            this.Text = "Панель администратора";

            sidebarPanel = new Panel();
            sidebarPanel.Size = new Size(240, 700);
            sidebarPanel.BackColor = Color.FromArgb(15, 52, 96);
            sidebarPanel.Location = new Point(0, 0);

            Label logo = new Label();
            logo.Text = "АвтоСфера";
            logo.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            logo.ForeColor = Color.White;
            logo.Location = new Point(20, 30);
            logo.Size = new Size(200, 40);
            sidebarPanel.Controls.Add(logo);

            string[] menuItems = { "Главная", "Пользователи", "Справочник авто", "Продажи", "Отчёты" };
            int y = 100;
            foreach (string item in menuItems)
            {
                Button btn = new Button();
                btn.Text = item;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.ForeColor = Color.White;
                btn.BackColor = Color.Transparent;
                btn.Font = new Font("Segoe UI", 12, FontStyle.Regular);
                btn.TextAlign = ContentAlignment.MiddleLeft;
                btn.Location = new Point(10, y);
                btn.Size = new Size(220, 40);
                btn.Padding = new Padding(10, 0, 0, 0);
                btn.Click += MenuButton_Click;
                sidebarPanel.Controls.Add(btn);
                y += 45;
            }

            Panel accountPanel = new Panel();
            accountPanel.Size = new Size(240, 70);
            accountPanel.Location = new Point(0, 630);
            accountPanel.BackColor = Color.FromArgb(10, 40, 75);

            Label lblAccount = new Label();
            lblAccount.Text = accountName;
            lblAccount.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblAccount.ForeColor = Color.White;
            lblAccount.Location = new Point(15, 8);
            lblAccount.Size = new Size(210, 22);
            accountPanel.Controls.Add(lblAccount);

            Button btnChangeAccount = new Button();
            btnChangeAccount.Text = "Сменить аккаунт";
            btnChangeAccount.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            btnChangeAccount.ForeColor = Color.LightGray;
            btnChangeAccount.BackColor = Color.Transparent;
            btnChangeAccount.FlatStyle = FlatStyle.Flat;
            btnChangeAccount.FlatAppearance.BorderSize = 0;
            btnChangeAccount.TextAlign = ContentAlignment.MiddleLeft;
            btnChangeAccount.Location = new Point(10, 32);
            btnChangeAccount.Size = new Size(220, 28);
            btnChangeAccount.Click += BtnChangeAccount_Click;
            accountPanel.Controls.Add(btnChangeAccount);

            sidebarPanel.Controls.Add(accountPanel);

            contentPanel = new Panel();
            contentPanel.Size = new Size(840, 700);
            contentPanel.Location = new Point(240, 0);
            this.Controls.Add(sidebarPanel);
            this.Controls.Add(contentPanel);

            ShowMainDashboard();
        }

        private void BtnChangeAccount_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormAuth auth = new FormAuth();
            auth.ShowDialog();
            this.Close();
        }

        private void MenuButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null) return;
            contentPanel.Controls.Clear();
            switch (btn.Text)
            {
                case "Главная": ShowMainDashboard(); break;
                case "Пользователи": ShowUsersSection(); break;
                case "Справочник авто": ShowCarsSection(); break;
                case "Продажи": ShowSalesSection(); break;
                case "Отчёты": ShowReportsSection(); break;
            }
        }

        private void ShowMainDashboard()
        {
            Label lblTitle = new Label();
            lblTitle.Text = "Главная панель";
            lblTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            lblTitle.Location = new Point(30, 30);
            lblTitle.Size = new Size(300, 40);
            contentPanel.Controls.Add(lblTitle);

            string[] titles = { "Авто в наличии", "Продано за месяц", "Выручка", "Менеджеров" };
            string[] values = { "47", "28", "14,8M", "5" };
            int xCard = 30;
            for (int i = 0; i < 4; i++)
            {
                Panel card = new Panel();
                card.Size = new Size(180, 100);
                card.Location = new Point(xCard, 90);
                card.BackColor = Color.White;
                card.BorderStyle = BorderStyle.None;

                Label title = new Label();
                title.Text = titles[i];
                title.Font = new Font("Segoe UI", 9);
                title.ForeColor = Color.Gray;
                title.Location = new Point(15, 15);
                title.Size = new Size(150, 20);
                card.Controls.Add(title);

                Label value = new Label();
                value.Text = values[i];
                value.Font = new Font("Segoe UI", 20, FontStyle.Bold);
                value.ForeColor = Color.FromArgb(15, 52, 96);
                value.Location = new Point(15, 40);
                value.Size = new Size(150, 40);
                card.Controls.Add(value);

                contentPanel.Controls.Add(card);
                xCard += 200;
            }

            DataGridView dgvSales = new DataGridView();
            dgvSales.Location = new Point(30, 220);
            dgvSales.Size = new Size(780, 250);
            dgvSales.BackgroundColor = Color.White;
            dgvSales.BorderStyle = BorderStyle.None;
            dgvSales.ColumnHeadersHeight = 30;
            dgvSales.Columns.Add("Num", "№");
            dgvSales.Columns.Add("Auto", "Автомобиль");
            dgvSales.Columns.Add("Manager", "Менеджер");
            dgvSales.Columns.Add("Sum", "Сумма");
            dgvSales.Columns.Add("Date", "Дата");
            dgvSales.Columns.Add("Status", "Статус");
            dgvSales.Rows.Add("1284", "BMW X5", "Петров А.В.", "7,850,000 ₽", "28.04.2026", "Завершена");
            dgvSales.Rows.Add("1283", "Toyota Camry", "Сидорова Е.Н.", "3,420,000 ₽", "27.04.2026", "В обработке");
            contentPanel.Controls.Add(dgvSales);
        }

        private void ShowUsersSection()
        {
            Label lblTitle = new Label();
            lblTitle.Text = "Управление пользователями";
            lblTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            lblTitle.Location = new Point(30, 30);
            lblTitle.Size = new Size(400, 40);
            contentPanel.Controls.Add(lblTitle);

            DataGridView dgvUsers = new DataGridView();
            dgvUsers.Location = new Point(30, 90);
            dgvUsers.Size = new Size(780, 300);
            dgvUsers.BackgroundColor = Color.White;
            dgvUsers.BorderStyle = BorderStyle.None;
            dgvUsers.ColumnHeadersHeight = 30;
            dgvUsers.Columns.Add("ID", "ID");
            dgvUsers.Columns.Add("LastName", "Фамилия");
            dgvUsers.Columns.Add("FirstName", "Имя");
            dgvUsers.Columns.Add("Login", "Логин");
            dgvUsers.Columns.Add("Role", "Роль");
            dgvUsers.Columns.Add("Active", "Активен");
            dgvUsers.Rows.Add("1", "Смирнов", "Алексей", "admin", "Администратор", "Да");
            dgvUsers.Rows.Add("2", "Петров", "Андрей", "petrov", "Менеджер", "Да");
            dgvUsers.Rows.Add("3", "Сидорова", "Елена", "sidorova", "Менеджер", "Да");
            contentPanel.Controls.Add(dgvUsers);

            Button btnAdd = new Button();
            btnAdd.Text = "Добавить пользователя";
            btnAdd.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.BackColor = Color.FromArgb(15, 52, 96);
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.Location = new Point(30, 410);
            btnAdd.Size = new Size(200, 35);
            contentPanel.Controls.Add(btnAdd);
        }

        private void ShowCarsSection()
        {
            Label lblTitle = new Label();
            lblTitle.Text = "Справочник автомобилей";
            lblTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            lblTitle.Location = new Point(30, 30);
            lblTitle.Size = new Size(400, 40);
            contentPanel.Controls.Add(lblTitle);

            DataGridView dgvCars = new DataGridView();
            dgvCars.Location = new Point(30, 90);
            dgvCars.Size = new Size(780, 300);
            dgvCars.BackgroundColor = Color.White;
            dgvCars.BorderStyle = BorderStyle.None;
            dgvCars.ColumnHeadersHeight = 30;
            dgvCars.Columns.Add("ID", "ID");
            dgvCars.Columns.Add("Brand", "Марка");
            dgvCars.Columns.Add("Model", "Модель");
            dgvCars.Columns.Add("Year", "Год");
            dgvCars.Columns.Add("Price", "Цена");
            dgvCars.Columns.Add("Status", "Статус");
            dgvCars.Rows.Add("1", "BMW", "X5 xDrive30d", "2025", "7 850 000", "В наличии");
            dgvCars.Rows.Add("2", "Toyota", "Camry 2.5", "2024", "3 420 000", "В наличии");
            dgvCars.Rows.Add("3", "Kia", "Sportage 2.0", "2025", "2 890 000", "Забронирована");
            contentPanel.Controls.Add(dgvCars);
        }

        private void ShowSalesSection()
        {
            Label lblTitle = new Label();
            lblTitle.Text = "Продажи";
            lblTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            lblTitle.Location = new Point(30, 30);
            lblTitle.Size = new Size(400, 40);
            contentPanel.Controls.Add(lblTitle);

            DataGridView dgvAllSales = new DataGridView();
            dgvAllSales.Location = new Point(30, 90);
            dgvAllSales.Size = new Size(780, 350);
            dgvAllSales.BackgroundColor = Color.White;
            dgvAllSales.BorderStyle = BorderStyle.None;
            dgvAllSales.ColumnHeadersHeight = 30;
            dgvAllSales.Columns.Add("Num", "№");
            dgvAllSales.Columns.Add("Auto", "Автомобиль");
            dgvAllSales.Columns.Add("Manager", "Менеджер");
            dgvAllSales.Columns.Add("Client", "Клиент");
            dgvAllSales.Columns.Add("Sum", "Сумма");
            dgvAllSales.Columns.Add("Date", "Дата");
            dgvAllSales.Columns.Add("Status", "Статус");
            dgvAllSales.Rows.Add("1284", "BMW X5", "Петров А.В.", "Смирнов К.О.", "7 850 000", "28.04.2026", "Завершена");
            dgvAllSales.Rows.Add("1283", "Toyota Camry", "Сидорова Е.Н.", "Новикова А.С.", "3 420 000", "27.04.2026", "Завершена");
            dgvAllSales.Rows.Add("1282", "Kia Sportage", "Иванов И.И.", "Фёдоров П.Л.", "2 890 000", "22.04.2026", "В обработке");
            dgvAllSales.Rows.Add("1281", "Lada Vesta", "Козлов Д.М.", "Григорьев Д.И.", "1 750 000", "20.04.2026", "Отменена");
            contentPanel.Controls.Add(dgvAllSales);
        }

        private void ShowReportsSection()
        {
            Label lblTitle = new Label();
            lblTitle.Text = "Отчёты";
            lblTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            lblTitle.Location = new Point(30, 30);
            lblTitle.Size = new Size(400, 40);
            contentPanel.Controls.Add(lblTitle);

            string[] reportTypes = { "Отчёт по продажам менеджеров", "Отчёт по остаткам на складе", "Финансовый отчёт за период" };
            int yPos = 100;
            foreach (string report in reportTypes)
            {
                Button btnReport = new Button();
                btnReport.Text = report;
                btnReport.Font = new Font("Segoe UI", 12, FontStyle.Regular);
                btnReport.ForeColor = Color.White;
                btnReport.BackColor = Color.FromArgb(15, 52, 96);
                btnReport.FlatStyle = FlatStyle.Flat;
                btnReport.FlatAppearance.BorderSize = 0;
                btnReport.Location = new Point(30, yPos);
                btnReport.Size = new Size(350, 40);
                btnReport.Click += (s, ev) => MessageBox.Show("Формирование отчёта: " + report, "Отчёт", MessageBoxButtons.OK, MessageBoxIcon.Information);
                contentPanel.Controls.Add(btnReport);
                yPos += 55;
            }
        }
    }
}