using SiticoneNetFrameworkUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;

namespace Diplom
{
    

    public partial class Manager1 : Form
    {
        private int currentUserId;
        private bdd bd = new bdd();
        private int selectedOperationId = -1;
        private int selectedCategoryId = -1;
        public Manager1()
        {
            InitializeComponent();
        }
        public Manager1(int userId)
        {
            InitializeComponent();
            currentUserId = userId;
        }

        private void Manager1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "управлениеПроцессамиDataSet.Процессы". При необходимости она может быть перемещена или удалена.
            this.процессыTableAdapter.Fill(this.управлениеПроцессамиDataSet.Процессы);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "управлениеПроцессамиDataSet.СтатусыОпераций". При необходимости она может быть перемещена или удалена.
            this.статусыОперацийTableAdapter.Fill(this.управлениеПроцессамиDataSet.СтатусыОпераций);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "управлениеПроцессамиDataSet.СотрудникиПредприятия". При необходимости она может быть перемещена или удалена.
            this.сотрудникиПредприятияTableAdapter.Fill(this.управлениеПроцессамиDataSet.СотрудникиПредприятия);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "управлениеПроцессамиDataSet.КатегорииОпераций". При необходимости она может быть перемещена или удалена.
            this.категорииОперацийTableAdapter.Fill(this.управлениеПроцессамиDataSet.КатегорииОпераций);
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
        private void ClearFields()
        {
            txtName.Clear();
            siticoneDateTimePicker1.Value = DateTime.Now;

            guna2ComboBox1.SelectedIndex = -1;
            guna2ComboBox2.SelectedIndex = -1;
            guna2ComboBox3.SelectedIndex = -1;
            guna2ComboBox4.SelectedIndex = -1;
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
                        cmd.Parameters.AddWithValue("@Manager", currentUserId);
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

        private void siticoneButtonAdvanced1_Click(object sender, EventArgs e)
        {
            siticoneLabel5.Visible = !siticoneLabel5.Visible;
            txtSearchName.Visible = !txtSearchName.Visible;
            guna2ComboBoxStatusFilter.Visible = !guna2ComboBoxStatusFilter.Visible;
            txtSearchDate.Visible = !txtSearchDate.Visible;
            siticoneButtonAdvanced2.Visible = !siticoneButtonAdvanced2.Visible;
            siticoneButtonAdvanced3.Visible = !siticoneButtonAdvanced3.Visible;
        }

        private void siticoneButtonAdvanced3_Click(object sender, EventArgs e)
        {
            guna2DataGridView1.Visible = !guna2DataGridView1.Visible;
            siticoneButtonAdvanced1.Visible = !siticoneButtonAdvanced1.Visible;
            txtName.Visible = !txtName.Visible;
            siticoneDateTimePicker1.Visible = !siticoneDateTimePicker1.Visible;
            siticoneLabel4.Visible = !siticoneLabel4.Visible;
            siticoneLabel1.Visible = !siticoneLabel1.Visible;
            siticoneLabel2.Visible = !siticoneLabel2.Visible;
            siticoneLabel3.Visible = !siticoneLabel3.Visible;
            guna2ComboBox4.Visible = !guna2ComboBox4.Visible;
            guna2ComboBox3.Visible = !guna2ComboBox3.Visible;
            guna2ComboBox2.Visible = !guna2ComboBox2.Visible;
            guna2ComboBox1.Visible = !guna2ComboBox1.Visible;
            siticoneTextBoxKat.Visible = !siticoneTextBoxKat.Visible;
            siticoneAdvancedTextArea1.Visible = !siticoneAdvancedTextArea1.Visible;
            siticoneButtonAdvanced4.Visible = !siticoneButtonAdvanced4.Visible;
            siticoneButtonAdvanced5.Visible = !siticoneButtonAdvanced5.Visible;
            siticoneButtonAdvanced6.Visible = !siticoneButtonAdvanced6.Visible;
            siticoneImageButton3.Visible = !siticoneImageButton3.Visible;
            siticoneImageButton2.Visible = !siticoneImageButton2.Visible;
            btnAdd.Visible = !btnAdd.Visible;
            btDelete.Visible = !btDelete.Visible;
            btnEdit.Visible = !btnEdit.Visible;
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
                    MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                    return;

                string query = "DELETE FROM [Операции] WHERE op_id = @Id";

                using (SqlConnection connection = bd.GetCon())
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Id", selectedOperationId);
                        cmd.ExecuteNonQuery();
                    }
                }

                this.операцииTableAdapter.Fill(this.управлениеПроцессамиDataSet.Операции);
                MessageBox.Show("Операция удалена.");
                ClearFields();
                selectedOperationId = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка удаления: " + ex.Message);
            }
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
                        cmd.Parameters.AddWithValue("@Manager", currentUserId);
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
            SelectComboItemById(guna2ComboBox4, drv["СотрудникПредприятия"].ToString());
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = guna2DataGridView1.Rows[e.RowIndex];
            DataRowView drv = row.DataBoundItem as DataRowView;

            if (drv == null)
                return;

            selectedCategoryId = Convert.ToInt32(drv["cat_id"]);

            siticoneTextBoxKat.Text = drv["НазваниеКатегории"].ToString();
            siticoneAdvancedTextArea1.Text = drv["ОписаниеКатегории"].ToString();
        }

        private void siticoneButtonAdvanced4_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(siticoneTextBoxKat.Text))
                {
                    MessageBox.Show("Введите название категории.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(siticoneAdvancedTextArea1.Text))
                {
                    MessageBox.Show("Введите описание категории.");
                    return;
                }

                string query = @"
            INSERT INTO [КатегорииОпераций]
            (НазваниеКатегории, ОписаниеКатегории)
            VALUES (@Name, @Description)";

                using (SqlConnection connection = bd.GetCon())
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Name", siticoneTextBoxKat.Text.Trim());
                        cmd.Parameters.AddWithValue("@Description", siticoneAdvancedTextArea1.Text.Trim());

                        cmd.ExecuteNonQuery();
                    }
                }

                this.категорииОперацийTableAdapter.Fill(this.управлениеПроцессамиDataSet.КатегорииОпераций);
                MessageBox.Show("Категория добавлена.");
                ClearCategoryFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка добавления: " + ex.Message);
            }
        }

        private void siticoneButtonAdvanced5_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedCategoryId == -1)
                {
                    MessageBox.Show("Выберите категорию.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(siticoneTextBoxKat.Text))
                {
                    MessageBox.Show("Введите название категории.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(siticoneAdvancedTextArea1.Text))
                {
                    MessageBox.Show("Введите описание категории.");
                    return;
                }

                string query = @"
            UPDATE [КатегорииОпераций]
            SET НазваниеКатегории = @Name,
                ОписаниеКатегории = @Description
            WHERE cat_id = @Id";

                using (SqlConnection connection = bd.GetCon())
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Name", siticoneTextBoxKat.Text.Trim());
                        cmd.Parameters.AddWithValue("@Description", siticoneAdvancedTextArea1.Text.Trim());
                        cmd.Parameters.AddWithValue("@Id", selectedCategoryId);

                        cmd.ExecuteNonQuery();
                    }
                }

                this.категорииОперацийTableAdapter.Fill(this.управлениеПроцессамиDataSet.КатегорииОпераций);
                MessageBox.Show("Категория обновлена.");
                ClearCategoryFields();
                selectedCategoryId = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка редактирования: " + ex.Message);
            }
        }

        private void siticoneButtonAdvanced6_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedCategoryId == -1)
                {
                    MessageBox.Show("Выберите категорию.");
                    return;
                }

                DialogResult result = MessageBox.Show(
                    "Удалить категорию?",
                    "Подтверждение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                    return;

                string query = "DELETE FROM [КатегорииОпераций] WHERE cat_id = @Id";

                using (SqlConnection connection = bd.GetCon())
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Id", selectedCategoryId);
                        cmd.ExecuteNonQuery();
                    }
                }

                this.категорииОперацийTableAdapter.Fill(this.управлениеПроцессамиDataSet.КатегорииОпераций);
                MessageBox.Show("Категория удалена.");
                ClearCategoryFields();
                selectedCategoryId = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка удаления: " + ex.Message);
            }
        }

        private void siticoneImageButton1_Click(object sender, EventArgs e)
        {
            try
            {
                this.категорииОперацийTableAdapter.Fill(this.управлениеПроцессамиDataSet.КатегорииОпераций);
                selectedCategoryId = -1;
                ClearCategoryFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка обновления: " + ex.Message);
            }
        }
        private void ClearCategoryFields()
        {
            siticoneTextBoxKat.Clear();
            siticoneAdvancedTextArea1.Clear();
        }

        private void siticoneImageButton3_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView3.Rows.Count == 0)
            {
                MessageBox.Show("Нет данных для отчета.");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Word файл (*.doc)|*.doc";
            sfd.FileName = "Отчет_по_операциям_менеджера";

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

            html.AppendLine("<tr>");
            foreach (DataGridViewColumn col in guna2DataGridView3.Columns)
            {
                if (col.HeaderText != "Менеджер") 
                {
                    html.AppendLine("<th style='width:" + (90 / (guna2DataGridView3.Columns.Count - 1)) + "%'>" + HtmlEncode(col.HeaderText) + "</th>");
                }
            }
            html.AppendLine("</tr>");

            foreach (DataGridViewRow row in guna2DataGridView3.Rows)
            {
                if (row.IsNewRow) continue;
                html.AppendLine("<tr>");
                foreach (DataGridViewColumn col in guna2DataGridView3.Columns)
                {
                    if (col.HeaderText != "Менеджер") 
                    {
                        string value = row.Cells[col.Index].Value?.ToString() ?? "";
                        html.AppendLine("<td>" + HtmlEncode(value) + "</td>");
                    }
                }
                html.AppendLine("</tr>");
            }

            html.AppendLine("</table>");
            html.AppendLine("</div>");
            html.AppendLine("</body></html>");

            File.WriteAllText(sfd.FileName, html.ToString(), Encoding.UTF8);

            MessageBox.Show("Word-отчет Менеджера успешно создан!");
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
            if (guna2DataGridView3.Rows.Count == 0)
            {
                MessageBox.Show("Нет данных для отчета.");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "JSON файл (*.json)|*.json";
            sfd.FileName = "Отчет_по_операциям";

            if (sfd.ShowDialog() != DialogResult.OK) return;

            StringBuilder json = new StringBuilder();

            json.AppendLine("[");

            bool firstRow = true;

            foreach (DataGridViewRow row in guna2DataGridView3.Rows)
            {
                if (row.IsNewRow) continue;

                if (!firstRow)
                    json.AppendLine(",");

                json.AppendLine("  {");

                bool firstColumn = true;

                foreach (DataGridViewColumn col in guna2DataGridView3.Columns)
                {
                    if (!col.Visible) continue;

                    if (col.HeaderText == "Менеджер") continue;

                    if (!firstColumn)
                        json.AppendLine(",");

                    string header = JsonEscape(col.HeaderText);
                    string value = "";

                    if (row.Cells[col.Index].Value != null)
                        value = JsonEscape(row.Cells[col.Index].Value.ToString());

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

            MessageBox.Show("JSON-отчет Менеджера успешно создан!");

            Process.Start(new ProcessStartInfo(sfd.FileName) { UseShellExecute = true });
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
    }
}
