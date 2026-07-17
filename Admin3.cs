using Guna.UI2.WinForms;
using SiticoneNetFrameworkUI;
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
using System.Windows.Forms.DataVisualization.Charting;


namespace Diplom
{
    public partial class Admin3 : Form
    {
        private int currentUserId;
        private bdd bd = new bdd();
        private int selectedid = -1;
        private int selectedSotrId = -1;
        private int selectedDolzhId = -1;
        public Admin3()
        {
            InitializeComponent();
        }
        public Admin3(int userId)
        {
            InitializeComponent();
            currentUserId = userId;
        }
        private void Admin3_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "управлениеПроцессамиЛаст.Должности". При необходимости она может быть перемещена или удалена.
            this.должностиTableAdapter1.Fill(this.управлениеПроцессамиЛаст.Должности);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "управлениеПроцессамиЛаст.СотрудникиПредприятия". При необходимости она может быть перемещена или удалена.
            this.сотрудникиПредприятияTableAdapter2.Fill(this.управлениеПроцессамиЛаст.СотрудникиПредприятия);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "управлениеПроцессамиDataSet2.СотрудникиПредприятия". При необходимости она может быть перемещена или удалена.
            this.сотрудникиПредприятияTableAdapter1.Fill(this.управлениеПроцессамиDataSet2.СотрудникиПредприятия);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "управлениеПроцессамиDataSet2.Должности". При необходимости она может быть перемещена или удалена.
            this.должностиTableAdapter.Fill(this.управлениеПроцессамиDataSet2.Должности);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "управлениеПроцессамиDataSet.СотрудникиПредприятия". При необходимости она может быть перемещена или удалена.
            this.сотрудникиПредприятияTableAdapter.Fill(this.управлениеПроцессамиDataSet.СотрудникиПредприятия);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "управлениеПроцессамиDataSet.Пользователи". При необходимости она может быть перемещена или удалена.
            this.пользователиTableAdapter.Fill(this.управлениеПроцессамиDataSet.Пользователи);
            LoadPositionsComboBox();
        }

        private void siticoneButtonAdvanced1_Click(object sender, EventArgs e)
        {
            string login = txtName.Text.Trim();
            string password = txtpass.Text;
            string phone = txtnum.Text.Trim();
            string role = comborole.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(login) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(phone) ||
                string.IsNullOrWhiteSpace(role))
            {
                MessageBox.Show("Заполните все поля, включая роль.");
                return;
            }

            string passwordPattern = @"^(?=.*\d).{8,}$";
            if (!Regex.IsMatch(password, passwordPattern))
            {
                MessageBox.Show("Пароль должен содержать минимум 8 символов и хотя бы одну цифру.");
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
                        cmd.Parameters.AddWithValue("@Role", role); // <-- берётся из комбобокса
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
        private void SelectComboItemByText(ComboBox combo, string text)
        {
            foreach (var item in combo.Items)
            {
                if (item.ToString() == text)
                {
                    combo.SelectedItem = item;
                    return;
                }
            }
            combo.SelectedIndex = -1;
        }
        private void ClearRegisterFields()
        {
            txtName.Clear();
            txtpass.Clear();
            txtnum.Clear();

        }

        private void guna2DataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = guna2DataGridView2.Rows[e.RowIndex];
            DataRowView drv = row.DataBoundItem as DataRowView;

            if (drv == null)
                return;

            txtName.Text = drv["Логин"].ToString();
            txtpass.Text = drv["Пароль"].ToString();
            txtnum.Text = drv["Телефон"].ToString();
            SelectComboItemByText(comborole, drv["Роль"].ToString());
        }

        private void siticoneButtonAdvanced2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
        string.IsNullOrWhiteSpace(txtpass.Text) ||
        string.IsNullOrWhiteSpace(txtnum.Text) ||
        comborole.SelectedItem == null)
            {
                MessageBox.Show("Заполните все поля.");
                return;
            }

            string passwordPattern = @"^(?=.*\d).{8,}$";
            if (!Regex.IsMatch(txtpass.Text, passwordPattern))
            {
                MessageBox.Show("Пароль должен содержать минимум 8 символов и хотя бы одну цифру.");
                return;
            }

            string phonePattern = @"^[0-9\+\-\(\)\s]{6,20}$";
            if (!Regex.IsMatch(txtnum.Text, phonePattern))
            {
                MessageBox.Show("Введите корректный номер телефона.");
                return;
            }

            try
            {
                using (SqlConnection connection = bd.GetCon())
                {
                    connection.Open();
                    string hashedPassword = ComputeSha256Hash(txtpass.Text);
                    string updateQuery = @"UPDATE [Пользователи] 
                                   SET [Пароль] = @Password, 
                                       [Телефон] = @Phone, 
                                       [Роль] = @Role 
                                   WHERE [Логин] = @Login";

                    using (SqlCommand cmd = new SqlCommand(updateQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@Login", txtName.Text.Trim());
                        cmd.Parameters.AddWithValue("@Password", hashedPassword);
                        cmd.Parameters.AddWithValue("@Phone", txtnum.Text.Trim());
                        cmd.Parameters.AddWithValue("@Role", comborole.SelectedItem.ToString());

                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Данные успешно обновлены.");
                            siticoneImageButton1_Click(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Запись не найдена.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при редактировании: " + ex.Message);
            }
        }

        private void siticoneButtonAdvanced3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Выберите пользователя для удаления.");
                return;
            }

            if (MessageBox.Show($"Удалить пользователя '{txtName.Text}'?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                using (SqlConnection connection = bd.GetCon())
                {
                    connection.Open();
                    string deleteQuery = "DELETE FROM [Пользователи] WHERE [Логин] = @Login";

                    using (SqlCommand cmd = new SqlCommand(deleteQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@Login", txtName.Text.Trim());

                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Пользователь удалён.");
                            ClearRegisterFields();
                            siticoneImageButton1_Click(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Запись не найдена.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при удалении: " + ex.Message);
            }
        }
        private void Clearfields()
        {
            txtName.Clear();
            txtpass.Clear();
            txtnum.Clear();

        }
        private void siticoneImageButton1_Click(object sender, EventArgs e)
        {
            try
            {
                this.пользователиTableAdapter.Fill(this.управлениеПроцессамиDataSet.Пользователи);
                selectedid = -1;
                Clearfields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка обновления: " + ex.Message);
            }
        }

        private void siticoneButtonAdvanced6_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(siticoneTextBoxAdvanced1.Text) ||
    string.IsNullOrWhiteSpace(siticoneTextBoxAdvanced2.Text) ||
    guna2ComboBox1.SelectedItem == null)
            {
                MessageBox.Show("Заполните все поля.", "Ошибка");
                return;
            }

            try
            {
                int positionId = GetIdFromComboBox(guna2ComboBox1);

                using (SqlConnection connection = bd.GetCon())
                {
                    connection.Open();

                    string insertQuery = @"
INSERT INTO [СотрудникиПредприятия] 
(
    [Имя], 
    [Фамилия], 
    [Должность]
) 
VALUES 
(
    @Имя, 
    @Фамилия, 
    @Должность
)";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@Имя", siticoneTextBoxAdvanced1.Text.Trim());
                        cmd.Parameters.AddWithValue("@Фамилия", siticoneTextBoxAdvanced2.Text.Trim());
                        cmd.Parameters.AddWithValue("@Должность", positionId);

                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Сотрудник успешно добавлен.");
                            ClearSotrFields();
                            siticoneImageButton2_Click(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Сотрудник не добавлен.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении: " + ex.Message);
            }
        }
        private void ClearSotrFields()
        {
            siticoneTextBoxAdvanced1.Clear();
            siticoneTextBoxAdvanced2.Clear();
            siticoneTextBoxAdvanced3.Clear();

        }
        private void siticoneImageButton2_Click(object sender, EventArgs e)
        {
            try
            {
                this.сотрудникиПредприятияTableAdapter2.Fill(this.управлениеПроцессамиЛаст.СотрудникиПредприятия);
                selectedSotrId = -1;
                ClearSotrFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка обновления: " + ex.Message);
            }
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void siticoneButtonAdvanced5_Click(object sender, EventArgs e)
        {
            if (selectedSotrId <= 0)
            {
                MessageBox.Show("Выберите сотрудника из таблицы.", "Ошибка");
                return;
            }

            if (string.IsNullOrWhiteSpace(siticoneTextBoxAdvanced1.Text) ||
                string.IsNullOrWhiteSpace(siticoneTextBoxAdvanced2.Text) ||
                guna2ComboBox1.SelectedItem == null)
            {
                MessageBox.Show("Заполните все поля.", "Ошибка");
                return;
            }

            try
            {
                int positionId = GetIdFromComboBox(guna2ComboBox1);

                using (SqlConnection connection = bd.GetCon())
                {
                    connection.Open();

                    string updateQuery = @"
UPDATE [СотрудникиПредприятия] 
SET 
    [Имя] = @Имя, 
    [Фамилия] = @Фамилия, 
    [Должность] = @Должность 
WHERE [sotr_id] = @Id";

                    using (SqlCommand cmd = new SqlCommand(updateQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@Id", selectedSotrId);
                        cmd.Parameters.AddWithValue("@Имя", siticoneTextBoxAdvanced1.Text.Trim());
                        cmd.Parameters.AddWithValue("@Фамилия", siticoneTextBoxAdvanced2.Text.Trim());
                        cmd.Parameters.AddWithValue("@Должность", positionId);

                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Данные сотрудника обновлены.");
                            ClearSotrFields();
                            selectedSotrId = -1;
                            siticoneImageButton2_Click(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Запись не найдена.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при редактировании: " + ex.Message);
            }
        }

        private void siticoneButtonAdvanced4_Click(object sender, EventArgs e)
        {
            if (selectedSotrId <= 0)
            {
                MessageBox.Show("Выберите сотрудника из таблицы.", "Ошибка");
                return;
            }

            if (MessageBox.Show($"Удалить сотрудника '{siticoneTextBoxAdvanced1.Text} {siticoneTextBoxAdvanced2.Text}'?",
                "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                using (SqlConnection connection = bd.GetCon())
                {
                    connection.Open();
                    string deleteQuery = "DELETE FROM [СотрудникиПредприятия] WHERE [sotr_id] = @Id";

                    using (SqlCommand cmd = new SqlCommand(deleteQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@Id", selectedSotrId);

                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Сотрудник удалён.");
                            ClearSotrFields();
                            siticoneImageButton2_Click(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Запись не найдена.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при удалении: " + ex.Message);
            }
        }

        private void guna2DataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = guna2DataGridView3.Rows[e.RowIndex];
            DataRowView drv = row.DataBoundItem as DataRowView;

            if (drv == null)
                return;

            selectedSotrId = Convert.ToInt32(drv["sotr_id"]);
            siticoneTextBoxAdvanced1.Text = drv["Имя"].ToString();
            siticoneTextBoxAdvanced2.Text = drv["Фамилия"].ToString();
            siticoneTextBoxAdvanced3.Text = drv["Должность"].ToString();
        }

        private void guna2DataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private int GetIdFromComboBox(Guna.UI2.WinForms.Guna2ComboBox comboBox)
        {
            string text = comboBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(text))
                throw new Exception("Выберите значение из списка.");

            string[] parts = text.Split(' ');
            return Convert.ToInt32(parts[0]);
        }
        private void SelectComboItemById(Guna.UI2.WinForms.Guna2ComboBox comboBox, string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return;

            for (int i = 0; i < comboBox.Items.Count; i++)
            {
                string itemText = comboBox.Items[i].ToString();
                if (itemText.StartsWith(id + " "))
                {
                    comboBox.SelectedIndex = i;
                    return;
                }
            }
        }

        private void siticoneButtonAdvanced7_Click(object sender, EventArgs e)
        {
            guna2DataGridView3.Visible = !guna2DataGridView3.Visible;
            siticoneTextBoxAdvanced1.Visible = !siticoneTextBoxAdvanced1.Visible;
            siticoneTextBoxAdvanced2.Visible = !siticoneTextBoxAdvanced2.Visible;

            guna2ComboBox1.Visible = !guna2ComboBox1.Visible;
            siticoneButtonAdvanced6.Visible = !siticoneButtonAdvanced6.Visible;
            siticoneButtonAdvanced5.Visible = !siticoneButtonAdvanced5.Visible;
            siticoneButtonAdvanced4.Visible = !siticoneButtonAdvanced4.Visible;
            siticoneImageButton2.Visible = !siticoneImageButton2.Visible;
            guna2DataGridView1.Visible = !guna2DataGridView1.Visible;
            siticoneTextBoxAdvanced5.Visible = !siticoneTextBoxAdvanced5.Visible;
            siticoneTextBoxAdvanced4.Visible = !siticoneTextBoxAdvanced4.Visible;
            siticoneButtonAdvanced8.Visible = !siticoneButtonAdvanced8.Visible;
            siticoneButtonAdvanced9.Visible = !siticoneButtonAdvanced9.Visible;
            siticoneButtonAdvanced10.Visible = !siticoneButtonAdvanced10.Visible;
            siticoneImageButton3.Visible = !siticoneImageButton3.Visible;




        }

        private void siticoneButtonAdvanced8_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(siticoneTextBoxAdvanced4.Text))
                {
                    MessageBox.Show("Введите название должности.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(siticoneTextBoxAdvanced5.Text))
                {
                    MessageBox.Show("Введите описание должности.");
                    return;
                }

                string query = @"
INSERT INTO [Должности]
(
    [Название],
    [Описание]
)
VALUES
(
    @Name,
    @Description
)";

                using (SqlConnection connection = bd.GetCon())
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Name", siticoneTextBoxAdvanced4.Text.Trim());
                        cmd.Parameters.AddWithValue("@Description", siticoneTextBoxAdvanced5.Text.Trim());

                        cmd.ExecuteNonQuery();
                    }
                }

                this.должностиTableAdapter.Fill(this.управлениеПроцессамиDataSet2.Должности);

                MessageBox.Show("Должность добавлена.");

                ClearDolzhFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка добавления: " + ex.Message);
            }
        }
        private void ClearDolzhFields()
        {
            siticoneTextBoxAdvanced4.Clear();
            siticoneTextBoxAdvanced5.Clear();
        }

        private void guna2DataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = guna2DataGridView1.Rows[e.RowIndex];
            DataRowView drv = row.DataBoundItem as DataRowView;

            if (drv == null)
                return;

            selectedDolzhId = Convert.ToInt32(drv["dolzh_id"]);

            siticoneTextBoxAdvanced4.Text = drv["Название"].ToString();
            siticoneTextBoxAdvanced5.Text = drv["Описание"].ToString();
        }

        private void siticoneButtonAdvanced9_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedDolzhId == -1)
                {
                    MessageBox.Show("Выберите запись в таблице.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(siticoneTextBoxAdvanced4.Text))
                {
                    MessageBox.Show("Введите название должности.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(siticoneTextBoxAdvanced5.Text))
                {
                    MessageBox.Show("Введите описание должности.");
                    return;
                }

                string query = @"
UPDATE [Должности]
SET
    [Название] = @Name,
    [Описание] = @Description
WHERE [dolzh_id] = @Id";

                using (SqlConnection connection = bd.GetCon())
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Name", siticoneTextBoxAdvanced4.Text.Trim());
                        cmd.Parameters.AddWithValue("@Description", siticoneTextBoxAdvanced5.Text.Trim());
                        cmd.Parameters.AddWithValue("@Id", selectedDolzhId);

                        cmd.ExecuteNonQuery();
                    }
                }

                this.должностиTableAdapter.Fill(this.управлениеПроцессамиDataSet2.Должности);

                MessageBox.Show("Должность обновлена.");

                ClearDolzhFields();
                selectedDolzhId = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка редактирования: " + ex.Message);
            }
        }

        private void siticoneButtonAdvanced10_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedDolzhId == -1)
                {
                    MessageBox.Show("Выберите запись для удаления.");
                    return;
                }

                DialogResult result = MessageBox.Show(
                    "Удалить выбранную должность?",
                    "Подтверждение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                    return;

                string query = "DELETE FROM [Должности] WHERE [dolzh_id] = @Id";

                using (SqlConnection connection = bd.GetCon())
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Id", selectedDolzhId);
                        cmd.ExecuteNonQuery();
                    }
                }

                this.должностиTableAdapter.Fill(this.управлениеПроцессамиDataSet2.Должности);

                MessageBox.Show("Должность удалена.");

                ClearDolzhFields();
                selectedDolzhId = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка удаления: " + ex.Message);
            }
        }

        private void siticoneImageButton3_Click(object sender, EventArgs e)
        {
            try
            {
                this.должностиTableAdapter.Fill(this.управлениеПроцессамиDataSet2.Должности);

                selectedDolzhId = -1;
                ClearDolzhFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка обновления: " + ex.Message);
            }
        }
        private void LoadPositionsComboBox()
        {
            guna2ComboBox1.Items.Clear();

            string query = "SELECT dolzh_id, Название FROM Должности"; // замените на вашу таблицу

            using (SqlConnection connection = bd.GetCon())
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        string display = $"{id} {name}";
                        guna2ComboBox1.Items.Add(display);
                    }
                }
            }

            if (guna2ComboBox1.Items.Count > 0)
                guna2ComboBox1.SelectedIndex = 0;
        }
        private bool isChartVisible = false;

        private void siticoneImageButton4_Click(object sender, EventArgs e)
        {
            Control[] controlsToHide = new Control[]
    {
        guna2DataGridView2,
        txtName,
        txtpass,
        txtnum,
        comborole,
        siticoneButtonAdvanced1,
        siticoneButtonAdvanced2,
        siticoneButtonAdvanced3,
        siticoneImageButton1
    };

            if (!isChartVisible)
            {
                foreach (var c in controlsToHide) c.Visible = false;
                chart1.Visible = true;
                chart1.BringToFront();
                chart1.Width = 600;  
                chart1.Height = 300; 
                chart1.Left = 200;    
                chart1.Series.Clear();
                chart1.ChartAreas.Clear();
                chart1.ChartAreas.Add(new ChartArea("MainArea"));
                chart1.Titles.Clear();
                Title title = new Title();
                title.Text = "Статистика пользователей по ролям";
                title.Font = new Font("Segoe UI", 12, FontStyle.Bold); 
                chart1.Titles.Add(title);
                Series series = new Series("Пользователи");
                series.ChartType = SeriesChartType.Column;
                series.Color = Color.DodgerBlue;
                series.ChartArea = "MainArea";
                chart1.Series.Add(series);
                int countEmployee = 0, countManager = 0, countAdmin = 0;
                foreach (DataRow row in управлениеПроцессамиDataSet.Пользователи.Rows)
                {
                    if (row["Роль"] != DBNull.Value)
                    {
                        string role = row["Роль"].ToString();
                        switch (role)
                        {
                            case "Сотрудник": countEmployee++; break;
                            case "Менеджер": countManager++; break;
                            case "Администратор": countAdmin++; break;
                        }
                    }
                }
                series.Points.AddXY("Сотрудник", countEmployee);
                series.Points.AddXY("Менеджер", countManager);
                series.Points.AddXY("Администратор", countAdmin);
                isChartVisible = true;
            }
            else
            {
                chart1.Visible = false;
                foreach (var c in controlsToHide) c.Visible = true;
                isChartVisible = false;
            }
        }
    }
}
