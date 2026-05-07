using System;
using System.Drawing;
using System.Windows.Forms;

namespace AutoSfera
{
    public class FormUserCatalog : Form
    {
        private Panel sidebarPanel;
        private Panel contentPanel;
        private string accountName;

        public FormUserCatalog(string account)
        {
            accountName = account;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.ClientSize = new Size(1100, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(244, 246, 249);
            this.Text = "Каталог автомобилей";

            sidebarPanel = new Panel();
            sidebarPanel.Size = new Size(230, 700);
            sidebarPanel.BackColor = Color.FromArgb(30, 30, 50);
            sidebarPanel.Location = new Point(0, 0);

            Label logo = new Label();
            logo.Text = "АвтоСфера";
            logo.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            logo.ForeColor = Color.White;
            logo.Location = new Point(15, 30);
            logo.Size = new Size(200, 40);
            sidebarPanel.Controls.Add(logo);

            string[] menuItems = { "Каталог авто", "Мои заявки", "Избранное", "История" };
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
                btn.Size = new Size(210, 40);
                btn.Padding = new Padding(10, 0, 0, 0);
                btn.Click += MenuButton_Click;
                sidebarPanel.Controls.Add(btn);
                y += 45;
            }

            Panel accountPanel = new Panel();
            accountPanel.Size = new Size(230, 70);
            accountPanel.Location = new Point(0, 630);
            accountPanel.BackColor = Color.FromArgb(20, 20, 40);

            Label lblAccount = new Label();
            lblAccount.Text = accountName;
            lblAccount.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblAccount.ForeColor = Color.White;
            lblAccount.Location = new Point(15, 8);
            lblAccount.Size = new Size(200, 22);
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
            btnChangeAccount.Size = new Size(210, 28);
            btnChangeAccount.Click += BtnChangeAccount_Click;
            accountPanel.Controls.Add(btnChangeAccount);

            sidebarPanel.Controls.Add(accountPanel);

            contentPanel = new Panel();
            contentPanel.Size = new Size(850, 700);
            contentPanel.Location = new Point(230, 0);
            this.Controls.Add(sidebarPanel);
            this.Controls.Add(contentPanel);

            ShowCatalog();
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
                case "Каталог авто": ShowCatalog(); break;
                case "Мои заявки": ShowBookings(); break;
                case "Избранное": ShowFavorites(); break;
                case "История": ShowHistory(); break;
            }
        }

        private void ShowCatalog()
        {
            Label lblTitle = new Label();
            lblTitle.Text = "Доступные автомобили";
            lblTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            lblTitle.Location = new Point(30, 30);
            lblTitle.Size = new Size(300, 40);
            contentPanel.Controls.Add(lblTitle);

            string[] imageFiles = { "bmw_x5.jpg", "toyota_camry.jpg", "kia_sportage.jpg" };
            string[] names = { "BMW X5 xDrive30d", "Toyota Camry 2.5", "Kia Sportage 2.0" };
            string[] prices = { "7 850 000 ₽", "3 420 000 ₽", "2 890 000 ₽" };
            string[] descs = { "2025 г. • 15 000 км • Дизель", "2024 г. • 42 000 км • Бензин", "2025 г. • 8 500 км • Бензин" };

            string imagePath = "C:\\Projects\\AutoSfera\\AutoSfera\\Images\\";

            int xPos = 30;
            for (int i = 0; i < 3; i++)
            {
                Panel card = new Panel();
                card.Size = new Size(250, 410);
                card.Location = new Point(xPos, 100);
                card.BackColor = Color.White;

                PictureBox pb = new PictureBox();
                pb.Size = new Size(250, 160);
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                try
                {
                    pb.Image = Image.FromFile(imagePath + imageFiles[i]);
                }
                catch
                {
                    pb.BackColor = Color.LightGray;
                }

                Label name = new Label();
                name.Text = names[i];
                name.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                name.Location = new Point(10, 170);
                name.Size = new Size(230, 25);

                Label price = new Label();
                price.Text = prices[i];
                price.Font = new Font("Segoe UI", 14, FontStyle.Bold);
                price.ForeColor = Color.FromArgb(15, 52, 96);
                price.Location = new Point(10, 200);
                price.Size = new Size(230, 25);

                Label desc = new Label();
                desc.Text = descs[i];
                desc.Font = new Font("Segoe UI", 9);
                desc.ForeColor = Color.Gray;
                desc.Location = new Point(10, 230);
                desc.Size = new Size(230, 40);

                Button btnDrive = new Button();
                btnDrive.Text = "Записаться на тест-драйв";
                btnDrive.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                btnDrive.ForeColor = Color.White;
                btnDrive.BackColor = Color.FromArgb(59, 130, 246);
                btnDrive.FlatStyle = FlatStyle.Flat;
                btnDrive.FlatAppearance.BorderSize = 0;
                btnDrive.Location = new Point(10, 280);
                btnDrive.Size = new Size(230, 32);
                btnDrive.Click += BtnDrive_Click;

                Button btnFavorite = new Button();
                btnFavorite.Text = "Добавить в избранное";
                btnFavorite.Font = new Font("Segoe UI", 9, FontStyle.Regular);
                btnFavorite.ForeColor = Color.FromArgb(59, 130, 246);
                btnFavorite.BackColor = Color.White;
                btnFavorite.FlatStyle = FlatStyle.Flat;
                btnFavorite.FlatAppearance.BorderColor = Color.FromArgb(59, 130, 246);
                btnFavorite.FlatAppearance.BorderSize = 1;
                btnFavorite.Location = new Point(10, 318);
                btnFavorite.Size = new Size(230, 28);
                btnFavorite.Click += BtnFavorite_Click;

                card.Controls.Add(pb);
                card.Controls.Add(name);
                card.Controls.Add(price);
                card.Controls.Add(desc);
                card.Controls.Add(btnDrive);
                card.Controls.Add(btnFavorite);

                contentPanel.Controls.Add(card);
                xPos += 270;
            }
        }

        private void ShowBookings()
        {
            Label lblTitle = new Label();
            lblTitle.Text = "Мои заявки и бронирования";
            lblTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            lblTitle.Location = new Point(30, 30);
            lblTitle.Size = new Size(400, 40);
            contentPanel.Controls.Add(lblTitle);

            DataGridView dgv = new DataGridView();
            dgv.Location = new Point(30, 90);
            dgv.Size = new Size(780, 350);
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.ColumnHeadersHeight = 30;
            dgv.Columns.Add("Num", "№");
            dgv.Columns.Add("Auto", "Автомобиль");
            dgv.Columns.Add("Type", "Тип заявки");
            dgv.Columns.Add("Date", "Дата");
            dgv.Columns.Add("Time", "Время");
            dgv.Columns.Add("Status", "Статус");
            dgv.Rows.Add("1042", "BMW X5 xDrive30d", "Тест-драйв", "30.04.2026", "11:00", "Подтверждена");
            dgv.Rows.Add("1038", "Toyota Camry 2.5", "Бронирование", "28.04.2026", "—", "Действует");
            dgv.Rows.Add("1031", "Kia Sportage 2.0", "Тест-драйв", "20.04.2026", "15:30", "Завершена");
            contentPanel.Controls.Add(dgv);
        }

        private void ShowFavorites()
        {
            Label lblTitle = new Label();
            lblTitle.Text = "Избранное";
            lblTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            lblTitle.Location = new Point(30, 30);
            lblTitle.Size = new Size(300, 40);
            contentPanel.Controls.Add(lblTitle);

            Label lblInfo = new Label();
            lblInfo.Text = "В избранном пока нет автомобилей. Добавьте их из каталога.";
            lblInfo.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            lblInfo.ForeColor = Color.Gray;
            lblInfo.Location = new Point(30, 100);
            lblInfo.Size = new Size(500, 30);
            contentPanel.Controls.Add(lblInfo);
        }

        private void ShowHistory()
        {
            Label lblTitle = new Label();
            lblTitle.Text = "История просмотров";
            lblTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            lblTitle.Location = new Point(30, 30);
            lblTitle.Size = new Size(300, 40);
            contentPanel.Controls.Add(lblTitle);

            DataGridView dgv = new DataGridView();
            dgv.Location = new Point(30, 90);
            dgv.Size = new Size(780, 300);
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.ColumnHeadersHeight = 30;
            dgv.Columns.Add("Date", "Дата");
            dgv.Columns.Add("Auto", "Автомобиль");
            dgv.Columns.Add("Action", "Действие");
            dgv.Rows.Add("30.04.2026", "BMW X5 xDrive30d", "Просмотр карточки");
            dgv.Rows.Add("29.04.2026", "Toyota Camry 2.5", "Запись на тест-драйв");
            dgv.Rows.Add("28.04.2026", "Kia Sportage 2.0", "Добавление в избранное");
            contentPanel.Controls.Add(dgv);
        }

        private void BtnDrive_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Заявка на тест-драйв отправлена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnFavorite_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Автомобиль добавлен в избранное!", "Избранное", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}