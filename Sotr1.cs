using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diplom
{
    public partial class Sotr1 : Form
    {
        private int currentUserId;
        private bdd bd = new bdd();
        public Sotr1()
        {
            InitializeComponent();
            this.Load += Sotr1_Load;
        }
        public Sotr1(int userId)
        {
            InitializeComponent();
            currentUserId = userId;
            this.Load += Sotr1_Load;
        }

        private void Sotr1_Load(object sender, EventArgs e)
        {
            LoadUserProfile();
        }
        private void LoadUserProfile()
        {
            string query = @"
                SELECT [id], [Логин], [Телефон], [Роль]
                FROM [Пользователи]
                WHERE [id] = @Id";

            try
            {
                using (SqlConnection connection = bd.GetCon())
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Id", currentUserId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                labelIdValue.Text = reader["id"].ToString();
                                labelLoginValue.Text = reader["Логин"].ToString();
                                labelPhoneValue.Text = reader["Телефон"].ToString();
                                labelRoleValue.Text = reader["Роль"].ToString();
                                labelEmailValue.Text = reader["Логин"].ToString() + "@mail.ru";

                            }
                            else
                            {
                                MessageBox.Show("Пользователь не найден.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки профиля: " + ex.Message);
            }
        }

        private void buttonChangePhone_Click(object sender, EventArgs e)
        {
            string newPhone = Interaction.InputBox(
                "Введите новый номер телефона:",
                "Изменение телефона",
                labelPhoneValue.Text);

            if (string.IsNullOrWhiteSpace(newPhone))
                return;

            string phonePattern = @"^[0-9\+\-\(\)\s]{6,20}$";
            if (!Regex.IsMatch(newPhone, phonePattern))
            {
                MessageBox.Show("Введите корректный номер телефона.");
                return;
            }

            string query = "UPDATE [Пользователи] SET [Телефон] = @Phone WHERE [id] = @Id";

            try
            {
                using (SqlConnection connection = bd.GetCon())
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Phone", newPhone);
                        cmd.Parameters.AddWithValue("@Id", currentUserId);

                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Телефон успешно изменён.");
                            LoadUserProfile();
                        }
                        else
                        {
                            MessageBox.Show("Не удалось изменить телефон.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при изменении телефона: " + ex.Message);
            }
        }

        private void buttonChangePassword_Click(object sender, EventArgs e)
        {
            string oldPassword = Interaction.InputBox(
                "Введите старый пароль:",
                "Смена пароля",
                "");

            if (string.IsNullOrWhiteSpace(oldPassword))
                return;

            string newPassword = Interaction.InputBox(
                "Введите новый пароль:",
                "Смена пароля",
                "");

            if (string.IsNullOrWhiteSpace(newPassword))
                return;

            string confirmPassword = Interaction.InputBox(
                "Повторите новый пароль:",
                "Смена пароля",
                "");

            if (string.IsNullOrWhiteSpace(confirmPassword))
                return;

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Новые пароли не совпадают.");
                return;
            }

            string passwordPattern = @"^(?=.*\d).{8,}$";
            if (!Regex.IsMatch(newPassword, passwordPattern))
            {
                MessageBox.Show("Новый пароль должен содержать минимум 8 символов и хотя бы одну цифру.");
                return;
            }

            string oldPasswordHash = ComputeSha256Hash(oldPassword);
            string newPasswordHash = ComputeSha256Hash(newPassword);

            try
            {
                using (SqlConnection connection = bd.GetCon())
                {
                    connection.Open();

                    string checkQuery = @"
                        SELECT COUNT(*)
                        FROM [Пользователи]
                        WHERE [id] = @Id AND [Пароль] = @OldPassword";

                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, connection))
                    {
                        checkCmd.Parameters.AddWithValue("@Id", currentUserId);
                        checkCmd.Parameters.AddWithValue("@OldPassword", oldPasswordHash);

                        int count = (int)checkCmd.ExecuteScalar();

                        if (count == 0)
                        {
                            MessageBox.Show("Старый пароль введён неверно.");
                            return;
                        }
                    }

                    string updateQuery = "UPDATE [Пользователи] SET [Пароль] = @NewPassword WHERE [id] = @Id";

                    using (SqlCommand updateCmd = new SqlCommand(updateQuery, connection))
                    {
                        updateCmd.Parameters.AddWithValue("@NewPassword", newPasswordHash);
                        updateCmd.Parameters.AddWithValue("@Id", currentUserId);

                        if (updateCmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Пароль успешно изменён.");
                        }
                        else
                        {
                            MessageBox.Show("Не удалось изменить пароль.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при смене пароля: " + ex.Message);
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

        private void labelPhoneValue_Click(object sender, EventArgs e)
        {

        }
    }
}
