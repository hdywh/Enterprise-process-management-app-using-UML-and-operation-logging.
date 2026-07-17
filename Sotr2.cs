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
using System.Text;
using System.IO;
using System.Diagnostics;
using Guna.UI2.WinForms;


namespace Diplom
{
    public partial class Sotr2 : Form
    {
        private int currentUserId;
        private bdd bd = new bdd();
        private int selectedOperationId = -1;
        
        public Sotr2()
        {
            InitializeComponent();
           
        }
        public Sotr2(int userId)
        {
            InitializeComponent();
            currentUserId = userId;
        }
        private void Sotr2_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "управлениеПроцессамиDataSet.Процессы". При необходимости она может быть перемещена или удалена.
            this.процессыTableAdapter.Fill(this.управлениеПроцессамиDataSet.Процессы);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "управлениеПроцессамиDataSet.КатегорииОпераций". При необходимости она может быть перемещена или удалена.
            this.категорииОперацийTableAdapter.Fill(this.управлениеПроцессамиDataSet.КатегорииОпераций);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "управлениеПроцессамиDataSet.СтатусыОпераций". При необходимости она может быть перемещена или удалена.
            this.статусыОперацийTableAdapter.Fill(this.управлениеПроцессамиDataSet.СтатусыОпераций);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "управлениеПроцессамиDataSet.СотрудникиПредприятия". При необходимости она может быть перемещена или удалена.
            this.сотрудникиПредприятияTableAdapter.Fill(this.управлениеПроцессамиDataSet.СотрудникиПредприятия);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "управлениеПроцессамиDataSet.Операции". При необходимости она может быть перемещена или удалена.
            this.операцииTableAdapter.Fill(this.управлениеПроцессамиDataSet.Операции);
            
        }
        private int GetIdFromComboBox(Guna.UI2.WinForms.Guna2ComboBox comboBox)
        {
            string text = comboBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(text))
                throw new Exception("Выберите значение из списка.");

            string[] parts = text.Split(' ');
            return Convert.ToInt32(parts[0]);
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = guna2DataGridView1.Rows[e.RowIndex];
            DataRowView drv = row.DataBoundItem as DataRowView;

            if (drv == null)
                return;

            selectedOperationId = Convert.ToInt32(drv["op_id"]);
            txtName.Text = drv["НазваниеОперации"].ToString();

            if (drv["ДатаСоздания"] != DBNull.Value)
                siticoneDateTimePicker1.Value = Convert.ToDateTime(drv["ДатаСоздания"]);

            SelectComboItemById(guna2ComboBox1, drv["Процесс№"].ToString());
            SelectComboItemById(guna2ComboBox2, drv["Категория№"].ToString());
            SelectComboItemById(guna2ComboBox3, drv["Статус№"].ToString());
            SelectComboItemById(guna2ComboBox4, drv["СотрудникПредприятия"].ToString());

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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("Введите название.");
                    return;
                }

                int processId = GetIdFromComboBox(guna2ComboBox1);
                int categoryId = GetIdFromComboBox(guna2ComboBox2);
                int statusId = GetIdFromComboBox(guna2ComboBox3);
                int employeeId = GetIdFromComboBox(guna2ComboBox4);


                DateTime createDate = siticoneDateTimePicker1.Value.Value;

                string query = @"
            INSERT INTO [Операции]
            (
                НазваниеОперации,
                [Процесс№],
                [Категория№],
                [Статус№],
                Менеджер,
                Пользователь,
                СотрудникПредприятия,
                ДатаСоздания,
                ДатаЗавершения
            )
            VALUES
            (
                @Name,
                @Process,
                @Category,
                @Status,
                @Manager,
                @User,
                @Employee,
                @CreateDate,
                NULL
            )";

                using (SqlConnection connection = bd.GetCon())
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                        cmd.Parameters.AddWithValue("@Process", processId);
                        cmd.Parameters.AddWithValue("@Category", categoryId);
                        cmd.Parameters.AddWithValue("@Status", statusId);
                        cmd.Parameters.AddWithValue("@Manager", 2);
                        cmd.Parameters.AddWithValue("@User", currentUserId);
                        cmd.Parameters.AddWithValue("@Employee", employeeId);
                        cmd.Parameters.AddWithValue("@CreateDate", createDate);

                        cmd.ExecuteNonQuery();
                    }
                }

                this.операцииTableAdapter.Fill(this.управлениеПроцессамиDataSet.Операции);
                MessageBox.Show("Операция добавлена.");
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка добавления: " + ex.Message);
            }
        }
        private bool UserExists(int userId)
        {
            string query = "SELECT COUNT(*) FROM [Пользователи] WHERE [id] = @Id";

            using (SqlConnection connection = bd.GetCon())
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", userId);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        private void ClearFields()
        {
            txtName.Clear();
            siticoneDateTimePicker1.Value = DateTime.Now;

            guna2ComboBox1.SelectedIndex = -1;
            guna2ComboBox2.SelectedIndex = -1;
            guna2ComboBox3.SelectedIndex = -1;
            guna2ComboBox4.SelectedIndex = -1;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedOperationId == -1)
                {
                    MessageBox.Show("Выберите запись в таблице.");
                    return;
                }

                int processId = GetIdFromComboBox(guna2ComboBox1);
                int categoryId = GetIdFromComboBox(guna2ComboBox2);
                int statusId = GetIdFromComboBox(guna2ComboBox3);
                int employeeId = GetIdFromComboBox(guna2ComboBox4);

                DateTime createDate = siticoneDateTimePicker1.Value.Value;

                string query = @"
            UPDATE [Операции]
            SET
                НазваниеОперации = @Name,
                [Процесс№] = @Process,
                [Категория№] = @Category,
                [Статус№] = @Status,
                Менеджер = @Manager,
                Пользователь = @User,
                СотрудникПредприятия = @Employee,
                ДатаСоздания = @CreateDate,
                ДатаЗавершения = NULL
            WHERE op_id = @Id";

                using (SqlConnection connection = bd.GetCon())
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                        cmd.Parameters.AddWithValue("@Process", processId);
                        cmd.Parameters.AddWithValue("@Category", categoryId);
                        cmd.Parameters.AddWithValue("@Status", statusId);
                        cmd.Parameters.AddWithValue("@Manager", 2);
                        cmd.Parameters.AddWithValue("@User", currentUserId);
                        cmd.Parameters.AddWithValue("@Employee", employeeId);
                        cmd.Parameters.AddWithValue("@CreateDate", createDate);
                        cmd.Parameters.AddWithValue("@Id", selectedOperationId);

                        cmd.ExecuteNonQuery();
                    }
                }

                this.операцииTableAdapter.Fill(this.управлениеПроцессамиDataSet.Операции);
                MessageBox.Show("Операция обновлена.");
                ClearFields();
                selectedOperationId = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка редактирования: " + ex.Message);
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedOperationId == -1)
                {
                    MessageBox.Show("Выберите запись для удаления.");
                    return;
                }

                DialogResult result = MessageBox.Show(
                    "Удалить выбранную запись?",
                    "Подтверждение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result != DialogResult.Yes)
                    return;

                using (SqlConnection connection = bd.GetCon())
                {
                    connection.Open();

                    // Отключаем все FK в базе на таблицу Operations
                    using (SqlCommand cmd = new SqlCommand(
                        "ALTER TABLE [dbo].[ЖурналДействий] NOCHECK CONSTRAINT ALL", connection))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    // Удаляем запись из Operations
                    using (SqlCommand cmd = new SqlCommand(
                        "DELETE FROM [dbo].[Операции] WHERE op_id = @Id", connection))
                    {
                        cmd.Parameters.AddWithValue("@Id", selectedOperationId);
                        cmd.ExecuteNonQuery();
                    }

                    // Включаем FK обратно
                    using (SqlCommand cmd = new SqlCommand(
                        "ALTER TABLE [dbo].[ЖурналДействий] CHECK CONSTRAINT ALL", connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }

                this.операцииTableAdapter.Fill(this.управлениеПроцессамиDataSet.Операции);
                MessageBox.Show("Операция удалена принудительно.");
                ClearFields();
                selectedOperationId = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка удаления: " + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                
                this.операцииTableAdapter.Fill(this.управлениеПроцессамиDataSet.Операции);

               
                selectedOperationId = -1;

                
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка обновления таблицы: " + ex.Message);
            }
        }
       
            private void ApplyFilters()
            {
            try
            {
                List<string> filters = new List<string>();

                string nameText = txtSearchName.Text.Trim().Replace("'", "''");
                string dateText = txtSearchDate.Text.Trim().Replace("'", "''");

                
                if (!string.IsNullOrWhiteSpace(nameText))
                {
                    filters.Add($"НазваниеОперации LIKE '%{nameText}%'");
                }

                if (guna2ComboBoxStatusFilter.SelectedIndex > 0)
                {
                    string statusText = guna2ComboBoxStatusFilter.Text;
                    string statusId = statusText.Split(' ')[0]; 

                    filters.Add($"[Статус№] = {statusId}");
                }

                if (!string.IsNullOrWhiteSpace(dateText))
                {
                    filters.Add($"Convert(ДатаСоздания, 'System.String') LIKE '%{dateText}%'");
                }

                операцииBindingSource.Filter = string.Join(" AND ", filters);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка фильтрации: " + ex.Message);
            }
        }
        
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtSearchName_TextContentChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void txtSearchStatus_TextContentChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void txtSearchDate_TextContentChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void siticoneButtonAdvanced1_Click(object sender, EventArgs e)
        {
            siticoneLabel5.Visible = !siticoneLabel5.Visible;
            txtSearchName.Visible = !txtSearchName.Visible;
            guna2ComboBoxStatusFilter.Visible = !guna2ComboBoxStatusFilter.Visible;
            txtSearchDate.Visible = !txtSearchDate.Visible;
            siticoneButtonAdvanced2.Visible = !siticoneButtonAdvanced2.Visible;
        }

        private void siticoneButtonAdvanced2_Click(object sender, EventArgs e)
        {
            txtSearchName.Clear();
            txtSearchDate.Clear();

            guna2ComboBoxStatusFilter.SelectedIndex = 0;

            операцииBindingSource.Filter = "";
        }

        private void guna2ComboBoxStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void siticoneImageButton3_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Нет данных для отчета.");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Word файл (*.doc)|*.doc";
            sfd.FileName = "Отчет_Сотрудника";

            if (sfd.ShowDialog() != DialogResult.OK) return;

            StringBuilder html = new StringBuilder();
            html.AppendLine("<html><head><meta charset='UTF-8'><style>");
            html.AppendLine("body { font-family: Times New Roman; font-size: 10pt; }");
            html.AppendLine("h2 { text-align: center; font-weight: bold; }");
            html.AppendLine("div.table-container { text-align: center; }");
            html.AppendLine("table { display: inline-table; border-collapse: collapse; width: 90%; table-layout: fixed; }");
            html.AppendLine("th, td { border: 1px solid black; padding: 5px; word-wrap: break-word; }");
            html.AppendLine("th { background-color: #d9eaf7; font-weight: bold; }");
            html.AppendLine("</style></head><body>");

            html.AppendLine("<h2>Отчет по таблице операций </h2>");
            html.AppendLine("<div class='table-container'>");
            html.AppendLine("<table>");

            // Заголовки без Менеджер, Пользователь, Завершение
            html.AppendLine("<tr>");
            foreach (DataGridViewColumn col in guna2DataGridView1.Columns)
            {
                if (col.HeaderText == "Менеджер" || col.HeaderText == "Пользователь" || col.HeaderText == "Завершение") continue;
                html.AppendLine("<th style='width:" + (90 / (guna2DataGridView1.Columns.Count - 3)) + "%'>" + HtmlEncode(col.HeaderText) + "</th>");
            }
            html.AppendLine("</tr>");

            // Данные без этих полей
            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
            {
                if (row.IsNewRow) continue;
                html.AppendLine("<tr>");
                foreach (DataGridViewColumn col in guna2DataGridView1.Columns)
                {
                    if (col.HeaderText == "Менеджер" || col.HeaderText == "Пользователь" || col.HeaderText == "Завершение") continue;
                    string value = row.Cells[col.Index].Value?.ToString() ?? "";
                    html.AppendLine("<td>" + HtmlEncode(value) + "</td>");
                }
                html.AppendLine("</tr>");
            }

            html.AppendLine("</table>");
            html.AppendLine("</div>");
            html.AppendLine("</body></html>");

            File.WriteAllText(sfd.FileName, html.ToString(), Encoding.UTF8);

            MessageBox.Show("Word-отчет Сотрудника успешно создан!");
            Process.Start(new ProcessStartInfo(sfd.FileName) { UseShellExecute = true });
        }
        private string HtmlEncode(string text)
        {
            if (text == null) return "";
            return text.Replace("&", "&amp;")
                       .Replace("<", "&lt;")
                       .Replace(">", "&gt;")
                       .Replace("\"", "&quot;");
        }

        private void siticoneImageButton2_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Нет данных для отчета.");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "JSON файл (*.json)|*.json";
            sfd.FileName = "Отчет_по_операциям_без_Менеджера_Пользователя_Завершение";

            if (sfd.ShowDialog() != DialogResult.OK) return;

            StringBuilder json = new StringBuilder();
            json.AppendLine("[");

            bool firstRow = true;

            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                if (!firstRow)
                    json.AppendLine(",");

                json.AppendLine("  {");

                bool firstColumn = true;

                foreach (DataGridViewColumn col in guna2DataGridView1.Columns)
                {
                    if (!col.Visible) continue;

                    // исключаем ненужные столбцы
                    if (col.HeaderText == "Менеджер" || col.HeaderText == "Пользователь" || col.HeaderText == "Завершение") continue;

                    if (!firstColumn)
                        json.AppendLine(",");

                    string header = JsonEscape(col.HeaderText);
                    string value = row.Cells[col.Index].Value?.ToString() ?? "";
                    value = JsonEscape(value);

                    json.Append("    \"" + header + "\": \"" + value + "\"");

                    firstColumn = false;
                }

                json.AppendLine();
                json.Append("  }");

                firstRow = false;
            }

            json.AppendLine();
            json.AppendLine("]");

            File.WriteAllText(sfd.FileName, json.ToString(), Encoding.UTF8);

            MessageBox.Show("JSON-отчет!");

            // открываем JSON сразу
            Process.Start(new ProcessStartInfo(sfd.FileName) { UseShellExecute = true });
        }
        private string JsonEscape(string text)
        {
            if (text == null) return "";
            return text.Replace("\\", "\\\\")
                       .Replace("\"", "\\\"")
                       .Replace("\r", "\\r")
                       .Replace("\n", "\\n")
                       .Replace("\t", "\\t");
        }
    }
}
