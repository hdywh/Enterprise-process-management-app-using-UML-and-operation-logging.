using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diplom
{
    public partial class MainF3 : Form
    {
        private int currentUserId;
        private bdd bd = new bdd();
        public MainF3()
        {
            InitializeComponent();
        }
        public MainF3(int userId)
        {
            InitializeComponent();
            currentUserId = userId;
        }

        private void siticoneButtonAdvanced4_Click(object sender, EventArgs e)
        {
            siticonePanel2.Controls.Clear();

            Admin3 LD = new Admin3(currentUserId); // ВАЖНО

            LD.TopLevel = false;
            LD.FormBorderStyle = FormBorderStyle.None;
            LD.Dock = DockStyle.Fill;

            siticonePanel2.Controls.Add(LD);
            LD.Show();
        }

        private void MainF3_Load(object sender, EventArgs e)
        {
            LoadWelcomeBlock();
            siticoneButtonAdvanced5.Text = "Настройки\nопераций";
        }

        private void siticoneButtonAdvanced1_Click(object sender, EventArgs e)
        {
            siticonePanel2.Controls.Clear();

            Sotr1 LK = new Sotr1(currentUserId);

            LK.TopLevel = false;
            LK.FormBorderStyle = FormBorderStyle.None;
            LK.StartPosition = FormStartPosition.Manual;
            LK.Dock = DockStyle.None;

            siticonePanel2.Controls.Add(LK);
            LK.Show();

            LK.Left = (siticonePanel2.Width - LK.Width) / 2;
            LK.Top = (siticonePanel2.Height - LK.Height) / 2;
        }

        private void siticonePictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void siticonePictureBox2_Click(object sender, EventArgs e)
        {
            Form1 Check = new Form1();
            Check.Show();
            this.Hide();
        }

        private void siticoneButtonAdvanced2_Click(object sender, EventArgs e)
        {
            siticonePanel2.Controls.Clear();

            Admin1 OP = new Admin1(currentUserId); 

            OP.TopLevel = false;
            OP.FormBorderStyle = FormBorderStyle.None;
            OP.Dock = DockStyle.Fill;

            siticonePanel2.Controls.Add(OP);
            OP.Show();
        }

        private void siticoneButtonAdvanced3_Click(object sender, EventArgs e)
        {
            siticonePanel2.Controls.Clear();

            Admin2 PP = new Admin2(currentUserId); 

            PP.TopLevel = false;
            PP.FormBorderStyle = FormBorderStyle.None;
            PP.Dock = DockStyle.Fill;

            siticonePanel2.Controls.Add(PP);
            PP.Show();
        }

        private void siticoneButtonAdvanced5_Click(object sender, EventArgs e)
        {
            siticonePanel2.Controls.Clear();

            Admin4 NO = new Admin4(currentUserId); 

            NO.TopLevel = false;
            NO.FormBorderStyle = FormBorderStyle.None;
            NO.Dock = DockStyle.Fill;

            siticonePanel2.Controls.Add(NO);
            NO.Show();
        }

        private void siticoneButtonAdvanced6_Click(object sender, EventArgs e)
        {
            siticonePanel2.Controls.Clear();

            Admin5 ZH = new Admin5(currentUserId); 

            ZH.TopLevel = false;
            ZH.FormBorderStyle = FormBorderStyle.None;
            ZH.Dock = DockStyle.Fill;

            siticonePanel2.Controls.Add(ZH);
            ZH.Show();
        }
        private void LoadWelcomeBlock()
        {
            string query = @"
        SELECT [Логин], [Роль]
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
                                string login = reader["Логин"].ToString();
                                string role = reader["Роль"].ToString();




                                labelHello.Text = "Здравствуйте, " + login + "!";
                                labelRoleHello.Text = "Ваша роль: " + role;

                            }
                            else
                            {
                                MessageBox.Show("По id = " + currentUserId + " ничего не найдено");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }
        private void siticonePanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
