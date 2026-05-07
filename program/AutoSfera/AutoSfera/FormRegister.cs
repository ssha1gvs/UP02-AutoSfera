using System;
using System.Drawing;
using System.Windows.Forms;

namespace AutoSfera
{
    public class FormRegister : Form
    {
        private TextBox txtLastName;
        private TextBox txtFirstName;
        private TextBox txtLogin;
        private TextBox txtPassword;
        private ComboBox cmbRole;
        private Button btnRegister;
        private LinkLabel linkLogin;
        private Panel panelHeader;

        public FormRegister()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.ClientSize = new Size(420, 550);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(26, 26, 46);
            this.Text = "Регистрация";

            panelHeader = new Panel();
            panelHeader.Size = new Size(420, 140);
            panelHeader.BackColor = Color.FromArgb(15, 52, 96);
            panelHeader.Location = new Point(0, 0);

            Label lblTitle = new Label();
            lblTitle.Text = "АвтоСфера";
            lblTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Size = new Size(300, 40);
            lblTitle.Location = new Point(60, 50);
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            panelHeader.Controls.Add(lblTitle);

            this.Controls.Add(panelHeader);

            int yPos = 160;

            Label lblLastName = new Label();
            lblLastName.Text = "Фамилия";
            lblLastName.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblLastName.ForeColor = Color.White;
            lblLastName.Location = new Point(60, yPos);
            lblLastName.Size = new Size(150, 20);
            this.Controls.Add(lblLastName);

            txtLastName = new TextBox();
            txtLastName.Font = new Font("Segoe UI", 11);
            txtLastName.Location = new Point(60, yPos + 25);
            txtLastName.Size = new Size(300, 30);
            txtLastName.BackColor = Color.FromArgb(40, 40, 60);
            txtLastName.ForeColor = Color.White;
            txtLastName.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(txtLastName);
            yPos += 60;

            Label lblFirstName = new Label();
            lblFirstName.Text = "Имя";
            lblFirstName.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblFirstName.ForeColor = Color.White;
            lblFirstName.Location = new Point(60, yPos);
            lblFirstName.Size = new Size(150, 20);
            this.Controls.Add(lblFirstName);

            txtFirstName = new TextBox();
            txtFirstName.Font = new Font("Segoe UI", 11);
            txtFirstName.Location = new Point(60, yPos + 25);
            txtFirstName.Size = new Size(300, 30);
            txtFirstName.BackColor = Color.FromArgb(40, 40, 60);
            txtFirstName.ForeColor = Color.White;
            txtFirstName.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(txtFirstName);
            yPos += 60;

            Label lblLogin = new Label();
            lblLogin.Text = "Логин";
            lblLogin.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblLogin.ForeColor = Color.White;
            lblLogin.Location = new Point(60, yPos);
            lblLogin.Size = new Size(150, 20);
            this.Controls.Add(lblLogin);

            txtLogin = new TextBox();
            txtLogin.Font = new Font("Segoe UI", 11);
            txtLogin.Location = new Point(60, yPos + 25);
            txtLogin.Size = new Size(300, 30);
            txtLogin.BackColor = Color.FromArgb(40, 40, 60);
            txtLogin.ForeColor = Color.White;
            txtLogin.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(txtLogin);
            yPos += 60;

            Label lblPassword = new Label();
            lblPassword.Text = "Пароль";
            lblPassword.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblPassword.ForeColor = Color.White;
            lblPassword.Location = new Point(60, yPos);
            lblPassword.Size = new Size(150, 20);
            this.Controls.Add(lblPassword);

            txtPassword = new TextBox();
            txtPassword.Font = new Font("Segoe UI", 11);
            txtPassword.Location = new Point(60, yPos + 25);
            txtPassword.Size = new Size(300, 30);
            txtPassword.BackColor = Color.FromArgb(40, 40, 60);
            txtPassword.ForeColor = Color.White;
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.UseSystemPasswordChar = true;
            this.Controls.Add(txtPassword);
            yPos += 60;

            Label lblRole = new Label();
            lblRole.Text = "Роль в системе";
            lblRole.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblRole.ForeColor = Color.White;
            lblRole.Location = new Point(60, yPos);
            lblRole.Size = new Size(150, 20);
            this.Controls.Add(lblRole);

            cmbRole = new ComboBox();
            cmbRole.Items.AddRange(new object[] { "Менеджер по продажам", "Администратор" });
            cmbRole.Font = new Font("Segoe UI", 10);
            cmbRole.Location = new Point(60, yPos + 25);
            cmbRole.Size = new Size(300, 30);
            cmbRole.BackColor = Color.FromArgb(40, 40, 60);
            cmbRole.ForeColor = Color.White;
            this.Controls.Add(cmbRole);
            yPos += 70;

            btnRegister = new Button();
            btnRegister.Text = "Зарегистрироваться";
            btnRegister.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnRegister.ForeColor = Color.White;
            btnRegister.BackColor = Color.FromArgb(15, 52, 96);
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.Location = new Point(60, yPos);
            btnRegister.Size = new Size(300, 40);
            btnRegister.Click += btnRegister_Click;
            this.Controls.Add(btnRegister);

            linkLogin = new LinkLabel();
            linkLogin.Text = "Уже есть учётная запись? Войти";
            linkLogin.Font = new Font("Segoe UI", 9);
            linkLogin.LinkColor = Color.LightGray;
            linkLogin.Location = new Point(80, yPos + 45);
            linkLogin.Size = new Size(260, 20);
            linkLogin.TextAlign = ContentAlignment.MiddleCenter;
            linkLogin.LinkClicked += linkLogin_LinkClicked;
            this.Controls.Add(linkLogin);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Заявка на регистрацию отправлена администратору!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
            FormAuth auth = new FormAuth();
            auth.ShowDialog();
            this.Close();
        }

        private void linkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            FormAuth auth = new FormAuth();
            auth.ShowDialog();
            this.Close();
        }
    }
}