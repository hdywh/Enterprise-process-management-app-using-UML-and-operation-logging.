using SiticoneNetFrameworkUI;
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
    public partial class MainF1 : Form
    {
        
        private int currentUserId;
        private bdd bd = new bdd();
        public MainF1()
        {
            InitializeComponent();
           

        }
        public MainF1(int userId)
        {
            InitializeComponent();
            currentUserId = userId;
        }

        private void parrotSlidingPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {

        }

        private void siticoneButtonAdvanced1_Click(object sender, EventArgs e)
        {

        }

        private void siticoneButtonAdvanced1_Click_1(object sender, EventArgs e)
        {

            siticonePanel2.Controls.Clear();

            Sotr1 LK = new Sotr1(currentUserId); // ВАЖНО

            LK.TopLevel = false;
            LK.FormBorderStyle = FormBorderStyle.None;
            LK.Dock = DockStyle.Fill;

            siticonePanel2.Controls.Add(LK);
            LK.Show();
        }

        private void siticonePanel2_Paint(object sender, PaintEventArgs e)
        {

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

        private void MainF1_Load(object sender, EventArgs e)
        {
            
            LoadWelcomeBlock();
            siticoneButtonAdvanced3.Text = "Коммен-\nтарии";
            
        }

        private void labelHello_Click(object sender, EventArgs e)
        {

        }

        private void labelRoleHello_Click(object sender, EventArgs e)
        {

        }

        private void siticoneButtonAdvanced2_Click(object sender, EventArgs e)
        {
           


            siticonePanel2.Controls.Clear();

            Sotr2 OP = new Sotr2(currentUserId); // ВАЖНО

            OP.TopLevel = false;
            OP.FormBorderStyle = FormBorderStyle.None;
            OP.Dock = DockStyle.Fill;

            siticonePanel2.Controls.Add(OP);
            OP.Show();
        }

        private void siticonePictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void siticonePictureBox2_Click(object sender, EventArgs e)
        {
            Form1 Check = new Form1();
            Check.Show();
            this.Close();
            MessageBox.Show("Вы вышли из аккаунта!");
        }

        private void siticoneButtonAdvanced3_Click(object sender, EventArgs e)
        {
            siticonePanel2.Controls.Clear();

            Sotr3 CM = new Sotr3(currentUserId); // ВАЖНО

            CM.TopLevel = false;
            CM.FormBorderStyle = FormBorderStyle.None;
            CM.Dock = DockStyle.Fill;

            siticonePanel2.Controls.Add(CM);
            CM.Show();
        }
    }
}
