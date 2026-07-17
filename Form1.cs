using SiticoneNetFrameworkUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static QRCoder.PayloadGenerator;
using System.Security.Cryptography;
using System.Text;


namespace Diplom
{
    public partial class Form1 : Form
    {
        bool isAuth = false;
        public static string curUser = "";
        public Form1()
        {
            InitializeComponent();
        }
        bdd bd = new bdd();
        private void airForm1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            siticoneTextBox2.UseSystemPasswordChar = true;
            siticoneTextBox3.UseSystemPasswordChar = true;
        }

        private void siticoneShimmerLabel1_Click(object sender, EventArgs e)
        {
            if (siticoneShimmerLabel1.Text == "Есть аккаунт? Войдите")
            {
                siticoneShimmerLabel1.Text = "Нет аккаунта? Создайте";
                button1.Text = "Войти";
                button1.Refresh();
                siticoneTextBox1.Visible = true;
                siticoneTextBox2.Visible = true;
                siticoneTextBox3.Visible = false;
                siticoneTextBox4.Visible = false;
                siticoneCheckBox1.Visible = false;
                siticoneLabel1.Text = "Авторизация";
                siticoneTextBox1.Location = new Point(164, 158);
                siticoneTextBox2.Location = new Point(164, 213);
                siticoneLinkedLabel2.Visible = true;
                siticoneTextBox1.PlaceholderText = "Введите Логин..." ;
                siticoneTextBox2.PlaceholderText = "Введите Пароль...";
                isAuth = true;
                

            }
            else
            {
                siticoneShimmerLabel1.Text = "Есть аккаунт? Войдите";
                button1.Text = "Зарегистрироваться";
                button1.Refresh();
                siticoneTextBox1.Visible = true;
                siticoneTextBox2.Visible = true;
                siticoneTextBox3.Visible = true;
                siticoneTextBox4.Visible = true;
                siticoneCheckBox1.Visible = true;
                isAuth = false;
                siticoneLabel1.Text = "Регистрация";
                siticoneTextBox1.Location = new Point(164, 103);
                siticoneTextBox2.Location = new Point(164, 158);
                siticoneTextBox3.Location = new Point(164, 213);
                siticoneTextBox4.Location = new Point(164, 268);
                siticoneLinkedLabel1.Visible = true;
                siticoneTextBox1.PlaceholderText = "Придумайте Логин...";
                siticoneTextBox2.PlaceholderText = "Придумайте Пароль...";

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Восстановить")
            {
                string phone = siticoneTextBox4.Text;
                using (SqlConnection conn = bd.GetCon())
                {
                    conn.Open();

                    string query = "SELECT COUNT(*) FROM Пользователи WHERE Телефон = @phone";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@phone", phone);

                    int count = (int)cmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Временный пароль для входа отправлен в СМС!");
                    }
                    else
                    {
                        MessageBox.Show("Такой номер не найден.");
                    }
                }
            }
            else if (isAuth == false)
            {
                RegisterUser();
            }
            else
            {
                LoginUser();
            }

        }

        private void RegisterUser()
        {
            string login = siticoneTextBox1.Text.Trim();
            string password = siticoneTextBox2.Text;
            string confirmPassword = siticoneTextBox3.Text;
            string phone = siticoneTextBox4.Text.Trim();

            if (string.IsNullOrWhiteSpace(login) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(confirmPassword) ||
                string.IsNullOrWhiteSpace(phone))
            {
                MessageBox.Show("Заполните все поля.");
                return;
            }

            if (!siticoneCheckBox1.Checked)
            {
                MessageBox.Show("Необходимо дать согласие на обработку персональных данных.");
                return;
            }

            string passwordPattern = @"^(?=.*\d).{8,}$";
            if (!Regex.IsMatch(password, passwordPattern))
            {
                MessageBox.Show("Пароль должен содержать минимум 8 символов и хотя бы одну цифру.");
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Пароли не совпадают.");
                return;
            }

            string phonePattern = @"^[0-9\+\-\(\)\s]{6,20}$";
            if (!Regex.IsMatch(phone, phonePattern))
            {
                MessageBox.Show("Введите корректный номер телефона.");
                return;
            }

            try
            {
                using (SqlConnection connection = bd.GetCon())
                {
                    connection.Open();

                    string checkQuery = "SELECT COUNT(*) FROM [Пользователи] WHERE [Логин] = @Login";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, connection))
                    {
                        checkCmd.Parameters.AddWithValue("@Login", login);
                        int count = (int)checkCmd.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show("Такой логин уже существует.");
                            return;
                        }
                    }

                    string hashedPassword = ComputeSha256Hash(password);

                    string insertQuery = @"
                INSERT INTO [Пользователи] ([Логин], [Пароль], [Телефон], [Роль])
                VALUES (@Login, @Password, @Phone, @Role)";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@Login", login);
                        cmd.Parameters.AddWithValue("@Password", hashedPassword);
                        cmd.Parameters.AddWithValue("@Phone", phone);
                        cmd.Parameters.AddWithValue("@Role", "Сотрудник");

                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Аккаунт зарегистрирован.");
                            ClearRegisterFields();
                        }
                        else
                        {
                            MessageBox.Show("Аккаунт не создан.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при регистрации: " + ex.Message);
            }
        }

        private void LoginUser()
        {
            string login = siticoneTextBox1.Text.Trim();
            string password = siticoneTextBox2.Text;

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Введите логин и пароль.");
                return;
            }

            string hashedPassword = ComputeSha256Hash(password);

            string query = @"
        SELECT [id], [Роль]
        FROM [Пользователи]
        WHERE [Логин] = @Login AND [Пароль] = @Password";

            try
            {
                using (SqlConnection connection = bd.GetCon())
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Login", login);
                        cmd.Parameters.AddWithValue("@Password", hashedPassword);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int userId = Convert.ToInt32(reader["id"]);
                                string role = reader["Роль"].ToString().Trim().ToLower();

                                MessageBox.Show("Вы успешно авторизованы.");

                                switch (role)
                                {
                                    case "сотрудник":
                                        new LoadingForm(new MainF1(userId)).Show();
                                        this.Hide();
                                        break;

                                    case "менеджер":
                                        new LoadingForm(new MainF2(userId)).Show();
                                        this.Hide();
                                        break;

                                    case "администратор":
                                        new LoadingForm(new MainF3(userId)).Show();
                                        this.Hide();
                                        break;

                                    default:
                                        MessageBox.Show("Роль не определена.");
                                        break;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Неверный логин или пароль.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при подключении к базе данных: " + ex.Message);
            }
        }
        private string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }

        private void ClearRegisterFields()
        {
            siticoneTextBox1.Clear();
            siticoneTextBox2.Clear();
            siticoneTextBox3.Clear();
            siticoneTextBox4.Clear();
            siticoneCheckBox1.Checked = false;
        }

        private void siticoneLinkedLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            siticoneTextBox4.Visible = true;
            button1.Text = "Восстановить";
            button1.Refresh();
            siticoneLabel1.Text = "Восстановление";
            siticoneTextBox4.Location = new Point(164, 213);
            siticoneTextBox1.Visible = false;
            siticoneTextBox2.Visible = false;
            siticoneTextBox3.Visible = false;
            siticoneLinkedLabel1.Visible = false;
            btnRefresh.Visible = false;


        }
        bool isPasswordVisible = false;
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;

            siticoneTextBox2.UseSystemPasswordChar = !isPasswordVisible;
            siticoneTextBox3.UseSystemPasswordChar = !isPasswordVisible;
        }

        private void siticoneButtonAdvanced5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void siticoneTextBox3_Click(object sender, EventArgs e)
        {

        }

        private void siticoneLinkedLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }
    }
}
