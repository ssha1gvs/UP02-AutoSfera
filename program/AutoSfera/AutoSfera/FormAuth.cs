using System;
using System.Drawing;
using System.Windows.Forms;

namespace AutoSfera
{
    public class FormAuth : Form
    {
        private TextBox txtLogin;
        private TextBox txtPassword;
        private Button btnLogin;
        private Label lblTitle;
        private Label lblLogin;
        private Label lblPassword;
        private CheckBox chkRemember;
        private LinkLabel linkForgot;
        private LinkLabel linkRegister;
        private Panel panelHeader;

        public FormAuth()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.txtLogin = new TextBox();
            this.txtPassword = new TextBox();
            this.btnLogin = new Button();
            this.lblTitle = new Label();
            this.lblLogin = new Label();
            this.lblPassword = new Label();
            this.chkRemember = new CheckBox();
            this.linkForgot = new LinkLabel();
            this.linkRegister = new LinkLabel();
            this.panelHeader = new Panel();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();

            this.ClientSize = new Size(420, 520);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(26, 26, 46);
            this.Text = "Авторизация";

            panelHeader.Size = new Size(420, 200);
            panelHeader.BackColor = Color.FromArgb(15, 52, 96);
            panelHeader.Location = new Point(0, 0);

            lblTitle.Text = "АвтоСфера";
            lblTitle.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Size = new Size(300, 50);
            lblTitle.Location = new Point(60, 70);
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            panelHeader.Controls.Add(lblTitle);

            Label lblSub = new Label();
            lblSub.Text = "Система учёта и управления продажами";
            lblSub.Font = new Font("Segoe UI", 9);
            lblSub.ForeColor = Color.LightGray;
            lblSub.Size = new Size(300, 30);
            lblSub.Location = new Point(60, 120);
            lblSub.TextAlign = ContentAlignment.MiddleCenter;
            panelHeader.Controls.Add(lblSub);

            lblLogin.Text = "Логин";
            lblLogin.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblLogin.ForeColor = Color.White;
            lblLogin.Location = new Point(60, 230);
            lblLogin.Size = new Size(100, 20);

            txtLogin.Font = new Font("Segoe UI", 12);
            txtLogin.Location = new Point(60, 255);
            txtLogin.Size = new Size(300, 35);
            txtLogin.BackColor = Color.FromArgb(40, 40, 60);
            txtLogin.ForeColor = Color.White;
            txtLogin.BorderStyle = BorderStyle.FixedSingle;

            lblPassword.Text = "Пароль";
            lblPassword.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblPassword.ForeColor = Color.White;
            lblPassword.Location = new Point(60, 305);
            lblPassword.Size = new Size(100, 20);

            txtPassword.Font = new Font("Segoe UI", 12);
            txtPassword.Location = new Point(60, 330);
            txtPassword.Size = new Size(300, 35);
            txtPassword.BackColor = Color.FromArgb(40, 40, 60);
            txtPassword.ForeColor = Color.White;
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.UseSystemPasswordChar = true;

            chkRemember.Text = "Запомнить меня";
            chkRemember.Font = new Font("Segoe UI", 9);
            chkRemember.ForeColor = Color.LightGray;
            chkRemember.Location = new Point(60, 375);
            chkRemember.Size = new Size(140, 20);

            linkForgot.Text = "Забыли пароль?";
            linkForgot.Font = new Font("Segoe UI", 9);
            linkForgot.LinkColor = Color.LightGray;
            linkForgot.Location = new Point(260, 375);
            linkForgot.Size = new Size(100, 20);
            linkForgot.TextAlign = ContentAlignment.MiddleRight;

            btnLogin.Text = "Войти";
            btnLogin.Font = new Font("Segoe UI", 13, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.BackColor = Color.FromArgb(15, 52, 96);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.Location = new Point(60, 420);
            btnLogin.Size = new Size(300, 40);
            btnLogin.Click += btnLogin_Click;

            linkRegister.Text = "Нет учётной записи? Зарегистрироваться";
            linkRegister.Font = new Font("Segoe UI", 9);
            linkRegister.LinkColor = Color.LightGray;
            linkRegister.Location = new Point(80, 475);
            linkRegister.Size = new Size(260, 20);
            linkRegister.TextAlign = ContentAlignment.MiddleCenter;
            linkRegister.LinkClicked += linkRegister_LinkClicked;

            this.Controls.Add(panelHeader);
            this.Controls.Add(lblLogin);
            this.Controls.Add(txtLogin);
            this.Controls.Add(lblPassword);
            this.Controls.Add(txtPassword);
            this.Controls.Add(chkRemember);
            this.Controls.Add(linkForgot);
            this.Controls.Add(btnLogin);
            this.Controls.Add(linkRegister);

            panelHeader.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Введите логин и пароль.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (login == "admin" && password == "admin")
            {
                this.Hide();
                FormAdminDashboard adminForm = new FormAdminDashboard("Администратор");
                adminForm.ShowDialog();
                this.Close();
            }
            else if (login == "user" && password == "user")
            {
                this.Hide();
                FormUserCatalog userForm = new FormUserCatalog("Пользователь");
                userForm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            FormRegister regForm = new FormRegister();
            regForm.ShowDialog();
            this.Close();
        }
    }
}