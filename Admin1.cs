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
using System.Windows.Controls;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using System.Diagnostics;




namespace Diplom
{
    public partial class Admin1 : Form
    {
        private int currentUserId;
        private bdd bd = new bdd();
        private int selectedOperationId = -1;
        public Admin1()
        {
            InitializeComponent();
        }
        public Admin1(int userId)
        {
            InitializeComponent();
            currentUserId = userId;
        }

        private void Admin1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "управлениеПроцессамиDataSet.Процессы". При необходимости она может быть перемещена или удалена.
            this.процессыTableAdapter.Fill(this.управлениеПроцессамиDataSet.Процессы);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "управлениеПроцессамиDataSet.КатегорииОпераций". При необходимости она может быть перемещена или удалена.
            this.категорииОперацийTableAdapter.Fill(this.управлениеПроцессамиDataSet.КатегорииОпераций);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "управлениеПроцессамиDataSet.СтатусыОпераций". При необходимости она может быть перемещена или удалена.
            this.статусыОперацийTableAdapter.Fill(this.управлениеПроцессамиDataSet.СтатусыОпераций);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "управлениеПроцессамиDataSet.Пользователи". При необходимости она может быть перемещена или удалена.
            this.пользователиTableAdapter.Fill(this.управлениеПроцессамиDataSet.Пользователи);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "управлениеПроцессамиDataSet.СотрудникиПредприятия". При необходимости она может быть перемещена или удалена.
            this.сотрудникиПредприятияTableAdapter.Fill(this.управлениеПроцессамиDataSet.СотрудникиПредприятия);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "управлениеПроцессамиDataSet.Операции". При необходимости она может быть перемещена или удалена.
            this.операцииTableAdapter.Fill(this.управлениеПроцессамиDataSet.Операции);
            guna2ComboBox6.Items.Clear();
            foreach (DataRow row in управлениеПроцессамиDataSet.Пользователи.Rows)
            {
                if (row["Роль"] != DBNull.Value && row["Роль"].ToString() == "Сотрудник")
                {
                    string id = row["id"].ToString();
                    string login = row["Логин"].ToString();
                    string item = $"{id} {login}";
                    guna2ComboBox6.Items.Add(item);
                }
            }
            if (guna2ComboBox6.Items.Count > 0)
                guna2ComboBox6.SelectedIndex = 0;
            guna2ComboBox4.Items.Clear();
            foreach (DataRow row in управлениеПроцессамиDataSet.Пользователи.Rows)
            {
                if (row["Роль"] != DBNull.Value && row["Роль"].ToString() == "Менеджер")
                {
                    string id = row["id"].ToString();
                    string login = row["Логин"].ToString();
                    string item = $"{id} {login}";
                    guna2ComboBox4.Items.Add(item);
                }
            }
            if (guna2ComboBox4.Items.Count > 0)
                guna2ComboBox4.SelectedIndex = 0;
        }
        private void ClearFields()
        {
            txtName.Clear();
            siticoneDateTimePicker1.Value = DateTime.Now;

            guna2ComboBox1.SelectedIndex = -1;
            guna2ComboBox2.SelectedIndex = -1;
            guna2ComboBox3.SelectedIndex = -1;
            guna2ComboBox4.SelectedIndex = -1;
            guna2ComboBox5.SelectedIndex = -1;
            guna2ComboBox6.SelectedIndex = -1;
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try { if (string.IsNullOrWhiteSpace(txtName.Text))
                { MessageBox.Show("Введите название."); return; }
                int processId = GetIdFromComboBox(guna2ComboBox1);
                int categoryId = GetIdFromComboBox(guna2ComboBox2);
                int statusId = GetIdFromComboBox(guna2ComboBox3);
                int managerId = GetIdFromComboBox(guna2ComboBox4);
                int employeeId = GetIdFromComboBox(guna2ComboBox5);
                int userId = GetIdFromComboBox(guna2ComboBox6);
                DateTime createDate = siticoneDateTimePicker1.Value.Value;
                string query = @" INSERT INTO [Операции] ( НазваниеОперации, [Процесс№], 
[Категория№], [Статус№], Менеджер, Пользователь, СотрудникПредприятия, ДатаСоздания, 
ДатаЗавершения )
VALUES ( @Name, @Process, @Category, @Status, @Manager, @User, @Employee, @CreateDate, NULL )";
                using (SqlConnection connection = bd.GetCon()) { connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    { cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                        cmd.Parameters.AddWithValue("@Process", processId);
                        cmd.Parameters.AddWithValue("@Category", categoryId);
                        cmd.Parameters.AddWithValue("@Status", statusId);
                        cmd.Parameters.AddWithValue("@Manager", managerId);
                        cmd.Parameters.AddWithValue("@User", userId);
                        cmd.Parameters.AddWithValue("@Employee", employeeId);
                        cmd.Parameters.AddWithValue("@CreateDate", createDate);
                        cmd.ExecuteNonQuery(); } } this.операцииTableAdapter.Fill(this.управлениеПроцессамиDataSet.Операции);
                MessageBox.Show("Операция добавлена."); ClearFields(); }
            catch (Exception ex) { MessageBox.Show("Ошибка добавления: " + ex.Message); }
        }

        private void guna2DataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = guna2DataGridView3.Rows[e.RowIndex];
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
            SelectComboItemById(guna2ComboBox4, drv["Менеджер"].ToString());
            SelectComboItemById(guna2ComboBox5, drv["СотрудникПредприятия"].ToString());
            SelectComboItemById(guna2ComboBox6, drv["Пользователь"].ToString());
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedOperationId == -1)
                {
                    MessageBox.Show("Выберите операцию для редактирования.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("Введите название.");
                    return;
                }

                int processId = GetIdFromComboBox(guna2ComboBox1);
                int categoryId = GetIdFromComboBox(guna2ComboBox2);
                int statusId = GetIdFromComboBox(guna2ComboBox3);
                int managerId = GetIdFromComboBox(guna2ComboBox4);
                int employeeId = GetIdFromComboBox(guna2ComboBox5);
                int userId = GetIdFromComboBox(guna2ComboBox6);

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
                ДатаСоздания = @CreateDate
            WHERE op_id = @OperationId";

                using (SqlConnection connection = bd.GetCon())
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                        cmd.Parameters.AddWithValue("@Process", processId);
                        cmd.Parameters.AddWithValue("@Category", categoryId);
                        cmd.Parameters.AddWithValue("@Status", statusId);
                        cmd.Parameters.AddWithValue("@Manager", managerId);
                        cmd.Parameters.AddWithValue("@User", userId);
                        cmd.Parameters.AddWithValue("@Employee", employeeId);
                        cmd.Parameters.AddWithValue("@CreateDate", createDate);
                        cmd.Parameters.AddWithValue("@OperationId", selectedOperationId);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            this.операцииTableAdapter.Fill(this.управлениеПроцессамиDataSet.Операции);
                            MessageBox.Show("Операция успешно обновлена.");
                            ClearFields();
                            selectedOperationId = -1;
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
                MessageBox.Show("Ошибка редактирования: " + ex.Message);
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedOperationId == -1)
                {
                    MessageBox.Show("Выберите операцию для удаления.");
                    return;
                }

                DialogResult confirm = MessageBox.Show(
                    "Вы уверены, что хотите удалить эту операцию?",
                    "Подтверждение удаления",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirm != DialogResult.Yes)
                    return;

                string query = "DELETE FROM [Операции] WHERE op_id = @OperationId";

                using (SqlConnection connection = bd.GetCon())
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@OperationId", selectedOperationId);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            this.операцииTableAdapter.Fill(this.управлениеПроцессамиDataSet.Операции);
                            MessageBox.Show("Операция успешно удалена.");
                            ClearFields();
                            selectedOperationId = -1;
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

        private void siticoneButtonAdvanced1_Click(object sender, EventArgs e)
        {

            txtSearchName.Visible = !txtSearchName.Visible;
            guna2ComboBoxStatusFilter.Visible = !guna2ComboBoxStatusFilter.Visible;
            txtSearchDate.Visible = !txtSearchDate.Visible;
            siticoneButtonAdvanced2.Visible = !siticoneButtonAdvanced2.Visible;

        }

        private void guna2ComboBoxStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void txtSearchName_TextContentChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void txtSearchDate_TextContentChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void siticoneButtonAdvanced2_Click(object sender, EventArgs e)
        {
            txtSearchName.Clear();
            txtSearchDate.Clear();
            guna2ComboBoxStatusFilter.SelectedIndex = -1;
            ApplyFilters();
        }
        private void ApplyFilters()
        {
            try
            {
                string nameFilter = txtSearchName.Text.Trim();
                string dateFilter = txtSearchDate.Text.Trim();

                System.Text.StringBuilder filter = new System.Text.StringBuilder();

                if (!string.IsNullOrWhiteSpace(nameFilter))
                {
                    filter.Append($"НазваниеОперации LIKE '%{nameFilter}%'");
                }

                if (!string.IsNullOrWhiteSpace(dateFilter))
                {
                    if (filter.Length > 0) filter.Append(" AND ");
                    // Используем CONVERT для DataView - правильный синтаксис
                    filter.Append($"CONVERT(ДатаСоздания, 'System.String') LIKE '%{dateFilter}%'");
                }

                if (guna2ComboBoxStatusFilter.SelectedIndex != -1)
                {
                    string[] parts = guna2ComboBoxStatusFilter.SelectedItem.ToString().Split(' ');
                    string selectedId = parts[0];

                    if (filter.Length > 0) filter.Append(" AND ");
                    filter.Append($"Статус№ = {selectedId}");
                }

                управлениеПроцессамиDataSet.Операции.DefaultView.RowFilter = filter.ToString();
                guna2DataGridView3.DataSource = управлениеПроцессамиDataSet.Операции.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка фильтрации: " + ex.Message);
            }
        }

        private void siticoneImageButton1_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView3.Rows.Count == 0)
            {
                MessageBox.Show("Нет данных для отчета.");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Word файл (*.doc)|*.doc";
            sfd.FileName = "Отчет_по_операциям";

            if (sfd.ShowDialog() != DialogResult.OK) return;

            StringBuilder html = new StringBuilder();
            html.AppendLine("<html><head><meta charset='UTF-8'><style>");
            html.AppendLine("body { font-family: Times New Roman; font-size: 10pt; }");
            html.AppendLine("h2 { text-align: center; font-weight: bold; }");
            // Центрируем таблицу через div + display:inline-table
            html.AppendLine("div.table-container { text-align: center; }");
            html.AppendLine("table { display: inline-table; border-collapse: collapse; width: 90%; table-layout: fixed; }");
            html.AppendLine("th, td { border: 1px solid black; padding: 5px; word-wrap: break-word; }");
            html.AppendLine("th { background-color: #d9eaf7; font-weight: bold; }");
            html.AppendLine("</style></head><body>");

            html.AppendLine("<h2>Отчет по таблице операций</h2>");
            html.AppendLine("<div class='table-container'>"); // div контейнер
            html.AppendLine("<table>");

            // Заголовки
            html.AppendLine("<tr>");
            foreach (DataGridViewColumn col in guna2DataGridView3.Columns)
            {
                html.AppendLine("<th style='width:" + (90 / guna2DataGridView3.Columns.Count) + "%'>" + HtmlEncode(col.HeaderText) + "</th>");
            }
            html.AppendLine("</tr>");

            // Данные
            foreach (DataGridViewRow row in guna2DataGridView3.Rows)
            {
                if (row.IsNewRow) continue;
                html.AppendLine("<tr>");
                foreach (DataGridViewColumn col in guna2DataGridView3.Columns)
                {
                    string value = row.Cells[col.Index].Value?.ToString() ?? "";
                    html.AppendLine("<td>" + HtmlEncode(value) + "</td>");
                }
                html.AppendLine("</tr>");
            }

            html.AppendLine("</table>");
            html.AppendLine("</div>"); // закрываем div
            html.AppendLine("</body></html>");

            File.WriteAllText(sfd.FileName, html.ToString(), Encoding.UTF8);

            MessageBox.Show("Word-отчет успешно создан!");
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

        private void ExportDataGridViewToJson(DataGridView dgv, string path)
        {
            StringBuilder json = new StringBuilder();

            json.AppendLine("[");

            bool firstRow = true;

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue;

                if (!firstRow)
                    json.AppendLine(",");

                json.AppendLine("  {");

                bool firstColumn = true;

                foreach (DataGridViewColumn column in dgv.Columns)
                {
                    if (!column.Visible) continue;

                    if (!firstColumn)
                        json.AppendLine(",");

                    string header = JsonEscape(column.HeaderText);
                    object valueObj = row.Cells[column.Index].Value;
                    string value = JsonEscape(valueObj == null ? "" : valueObj.ToString());

                    json.Append("    \"" + header + "\": \"" + value + "\"");

                    firstColumn = false;
                }

                json.AppendLine();
                json.Append("  }");

                firstRow = false;
            }

            json.AppendLine();
            json.AppendLine("]");

            File.WriteAllText(path, json.ToString(), Encoding.UTF8);
        }
       

        private string JsonEscape(string text)
        {
            if (text == null) return "";

            return text
                .Replace("\\", "\\\\")
                .Replace("\"", "\\\"")
                .Replace("\r", "\\r")
                .Replace("\n", "\\n")
                .Replace("\t", "\\t");
        }

        private void siticoneImageButton2_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView3.Rows.Count == 0)
            {
                MessageBox.Show("Нет данных для экспорта.");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "JSON файл (*.json)|*.json";
            sfd.FileName = "Отчет.json";

            if (sfd.ShowDialog() != DialogResult.OK) return;

            var rows = new List<Dictionary<string, string>>();

            foreach (DataGridViewRow row in guna2DataGridView3.Rows)
            {
                if (row.IsNewRow) continue;
                var dict = new Dictionary<string, string>();

                foreach (DataGridViewColumn col in guna2DataGridView3.Columns)
                {
                    dict[col.HeaderText] = row.Cells[col.Index].Value?.ToString() ?? "";
                }

                rows.Add(dict);
            }

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(rows, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(sfd.FileName, json, Encoding.UTF8);

            MessageBox.Show("JSON-отчет создан!");
        }
    }
}

