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
    public partial class Admin2 : Form
    {
        private int currentUserId;
        private bdd bd = new bdd();
        private int selectedTipProcId = -1;
        private int selectedProcessId = -1;
        public Admin2()
        {
            InitializeComponent();
        }
        public Admin2(int userId)
        {
            InitializeComponent();
            currentUserId = userId;
        }

        private void siticoneButtonAdvanced2_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedProcessId == -1)
                {
                    MessageBox.Show("Выберите процесс в таблице.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtNameProc.Text))
                {
                    MessageBox.Show("Введите название процесса.");
                    return;
                }

                int typeProcessId = GetIdFromComboBox(guna2ComboBox1);
                DateTime createDate = guna2DateTimePicker1.Value;

                string query = @"
            UPDATE [Процессы]
            SET
                НазваниеПроцесса = @Name,
                [ТипПроцесса№] = @TypeProcess,
                ДатаСоздания = @CreateDate
            WHERE proc_id = @Id";

                using (SqlConnection connection = bd.GetCon())
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Name", txtNameProc.Text.Trim());
                        cmd.Parameters.AddWithValue("@TypeProcess", typeProcessId);
                        cmd.Parameters.AddWithValue("@CreateDate", createDate);
                        cmd.Parameters.AddWithValue("@Id", selectedProcessId);

                        cmd.ExecuteNonQuery();
                    }
                }

                this.процессыTableAdapter.Fill(this.управлениеПроцессамиDataSet.Процессы);
                MessageBox.Show("Процесс обновлён.");
                ClearProcessFields();
                selectedProcessId = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка редактирования: " + ex.Message);
            }
        }

        private void Admin2_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "управлениеПроцессамиDataSet.Процессы". При необходимости она может быть перемещена или удалена.
            this.процессыTableAdapter.Fill(this.управлениеПроцессамиDataSet.Процессы);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "управлениеПроцессамиDataSet.ТипыПроцессов". При необходимости она может быть перемещена или удалена.
            this.типыПроцессовTableAdapter.Fill(this.управлениеПроцессамиDataSet.ТипыПроцессов);

        }
        private int GetIdFromComboBox(Guna.UI2.WinForms.Guna2ComboBox comboBox)
        {
            string text = comboBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(text))
                throw new Exception("Выберите тип процесса.");

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

        private void LoadTypeProcessComboBox()
        {
            try
            {
                guna2ComboBox1.Items.Clear();

                string query = "SELECT tiproc_id, НазваниеТипа FROM [ТипыПроцессов] ORDER BY tiproc_id";

                using (SqlConnection connection = bd.GetCon())
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string item = reader["tiproc_id"].ToString() + " " + reader["НазваниеТипа"].ToString();
                            guna2ComboBox1.Items.Add(item);
                        }
                    }
                }

                guna2ComboBox1.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки списка типов процессов: " + ex.Message);
            }
        }

        private void guna2DataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = guna2DataGridView2.Rows[e.RowIndex];
            DataRowView drv = row.DataBoundItem as DataRowView;

            if (drv == null)
                return;

            selectedTipProcId = Convert.ToInt32(drv["tiproc_id"]);

            txttipname.Text = drv["НазваниеТипа"].ToString();
            siticoneAdvancedTextAreaOpisaniye.Text = drv["ОписаниеТипа"].ToString();
            txtOtdel.Text = drv["Отдел"].ToString();
        }
        private void ClearTypeProcFields()
        {
            txttipname.Clear();
            siticoneAdvancedTextAreaOpisaniye.Clear();
            txtOtdel.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txttipname.Text))
                {
                    MessageBox.Show("Введите название типа.");
                    return;
                }
                if (string.IsNullOrWhiteSpace(siticoneAdvancedTextAreaOpisaniye.Text))
                {
                    MessageBox.Show("Введите описание типа.");
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtOtdel.Text))
                {
                    MessageBox.Show("Введите отдел.");
                    return;
                }

                string query = @"
INSERT INTO [ТипыПроцессов]
(
    НазваниеТипа,
    ОписаниеТипа,
    Отдел
)
VALUES
(
    @Name,
    @Description,
    @Department
);
SELECT SCOPE_IDENTITY();";  

                int newId;

                using (SqlConnection connection = bd.GetCon())
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Name", txttipname.Text.Trim());
                        cmd.Parameters.AddWithValue("@Description", siticoneAdvancedTextAreaOpisaniye.Text.Trim());
                        cmd.Parameters.AddWithValue("@Department", txtOtdel.Text.Trim());

                        newId = Convert.ToInt32(cmd.ExecuteScalar());  
                    }
                }

                
                string newItem = $"{newId} {txttipname.Text.Trim()}";
                guna2ComboBox1.Items.Add(newItem);

                this.типыПроцессовTableAdapter.Fill(this.управлениеПроцессамиDataSet.ТипыПроцессов);
                MessageBox.Show("Тип процесса добавлен.");
                LoadTypeProcessComboBox();
                ClearTypeProcFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка добавления: " + ex.Message);
            }
        }
     

        private void btDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedTipProcId == -1)
                {
                    MessageBox.Show("Выберите запись для удаления.");
                    return;
                }

                DialogResult result = MessageBox.Show(
                    "Удалить выбранный тип процесса?",
                    "Подтверждение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                    return;

                string query = "DELETE FROM [ТипыПроцессов] WHERE tiproc_id = @Id";

                using (SqlConnection connection = bd.GetCon())
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Id", selectedTipProcId);
                        cmd.ExecuteNonQuery();
                    }
                }

                // Удаляем элемент из ComboBox по ID
                for (int i = 0; i < guna2ComboBox1.Items.Count; i++)
                {
                    if (guna2ComboBox1.Items[i].ToString().StartsWith(selectedTipProcId + " "))
                    {
                        guna2ComboBox1.Items.RemoveAt(i);
                        break;
                    }
                }

                this.типыПроцессовTableAdapter.Fill(this.управлениеПроцессамиDataSet.ТипыПроцессов);
                MessageBox.Show("Тип процесса удалён.");
                LoadTypeProcessComboBox();
                ClearTypeProcFields();
                selectedTipProcId = -1;
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
                this.типыПроцессовTableAdapter.Fill(this.управлениеПроцессамиDataSet.ТипыПроцессов);
                selectedTipProcId = -1;
                ClearTypeProcFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка обновления: " + ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedTipProcId == -1)
                {
                    MessageBox.Show("Выберите запись в таблице.");
                    return;
                }
                if (string.IsNullOrWhiteSpace(txttipname.Text))
                {
                    MessageBox.Show("Введите название типа.");
                    return;
                }
                if (string.IsNullOrWhiteSpace(siticoneAdvancedTextAreaOpisaniye.Text))
                {
                    MessageBox.Show("Введите описание типа.");
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtOtdel.Text))
                {
                    MessageBox.Show("Введите отдел.");
                    return;
                }

                string query = @"
UPDATE [ТипыПроцессов]
SET
    НазваниеТипа = @Name,
    ОписаниеТипа = @Description,
    Отдел = @Department
WHERE tiproc_id = @Id";

                using (SqlConnection connection = bd.GetCon())
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Name", txttipname.Text.Trim());
                        cmd.Parameters.AddWithValue("@Description", siticoneAdvancedTextAreaOpisaniye.Text.Trim());
                        cmd.Parameters.AddWithValue("@Department", txtOtdel.Text.Trim());
                        cmd.Parameters.AddWithValue("@Id", selectedTipProcId);
                        cmd.ExecuteNonQuery();
                    }
                }

                // Обновляем элемент в ComboBox — ищем по ID в начале строки
                string updatedItem = $"{selectedTipProcId} {txttipname.Text.Trim()}";
                for (int i = 0; i < guna2ComboBox1.Items.Count; i++)
                {
                    string item = guna2ComboBox1.Items[i].ToString();
                    // Проверяем, начинается ли строка с нашего ID
                    if (item.StartsWith(selectedTipProcId + " "))
                    {
                        guna2ComboBox1.Items[i] = updatedItem;
                        break;
                    }
                }

                this.типыПроцессовTableAdapter.Fill(this.управлениеПроцессамиDataSet.ТипыПроцессов);
                MessageBox.Show("Тип процесса обновлён.");
                ClearTypeProcFields();
                LoadTypeProcessComboBox();
                selectedTipProcId = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка редактирования: " + ex.Message);
            }
        }

        private void siticoneButtonAdvanced4_Click(object sender, EventArgs e)
        {
            guna2DataGridView1.Visible = !guna2DataGridView1.Visible;
            txtOtdel.Visible = !txtOtdel.Visible;
            siticoneAdvancedTextAreaOpisaniye.Visible = !siticoneAdvancedTextAreaOpisaniye.Visible;
            txttipname.Visible = !txttipname.Visible; txtNameProc.Visible = !txtNameProc.Visible;
            guna2ComboBox1.Visible = !guna2ComboBox1.Visible;
            guna2DateTimePicker1.Visible = !guna2DateTimePicker1.Visible;
            siticoneButtonAdvanced1.Visible = !siticoneButtonAdvanced1.Visible;
            siticoneButtonAdvanced2.Visible = !siticoneButtonAdvanced2.Visible;
            siticoneButtonAdvanced3.Visible = !siticoneButtonAdvanced3.Visible;
            btnAdd.Visible = !btnAdd.Visible; btnEdit.Visible = !btnEdit.Visible; btDelete.Visible = !btDelete.Visible;
            siticoneButtonAdvanced1.Visible = siticoneButtonAdvanced1.Visible; siticoneButtonAdvanced2.Visible = siticoneButtonAdvanced2.Visible;
            siticoneButtonAdvanced3.Visible = siticoneButtonAdvanced3.Visible;
            if (siticoneButtonAdvanced4.Text == "Показать процессы")
            {
                siticoneButtonAdvanced4.Text = "Скрыть процессы";
            }
            else
            {
                siticoneButtonAdvanced4.Text = "Показать процессы";
            }
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = guna2DataGridView1.Rows[e.RowIndex];
            DataRowView drv = row.DataBoundItem as DataRowView;

            if (drv == null)
                return;

            selectedProcessId = Convert.ToInt32(drv["proc_id"]);

            txtNameProc.Text = drv["НазваниеПроцесса"].ToString();

            SelectComboItemById(guna2ComboBox1, drv["ТипПроцесса№"].ToString());

            if (drv["ДатаСоздания"] != DBNull.Value)
                guna2DateTimePicker1.Value = Convert.ToDateTime(drv["ДатаСоздания"]);
        }
        private void ClearProcessFields()
        {
            txtNameProc.Clear();
            guna2ComboBox1.SelectedIndex = -1;
            guna2DateTimePicker1.Value = DateTime.Now;
        }
        private void siticoneButtonAdvanced1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNameProc.Text))
                {
                    MessageBox.Show("Введите название процесса.");
                    return;
                }

                int typeProcessId = GetIdFromComboBox(guna2ComboBox1);
                DateTime createDate = guna2DateTimePicker1.Value;

                string query = @"
            INSERT INTO [Процессы]
            (
                НазваниеПроцесса,
                [ТипПроцесса№],
                ДатаСоздания
            )
            VALUES
            (
                @Name,
                @TypeProcess,
                @CreateDate
            )";

                using (SqlConnection connection = bd.GetCon())
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Name", txtNameProc.Text.Trim());
                        cmd.Parameters.AddWithValue("@TypeProcess", typeProcessId);
                        cmd.Parameters.AddWithValue("@CreateDate", createDate);

                        cmd.ExecuteNonQuery();
                    }
                }

                this.процессыTableAdapter.Fill(this.управлениеПроцессамиDataSet.Процессы);
                MessageBox.Show("Процесс добавлен.");
                ClearProcessFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка добавления: " + ex.Message);
            }
        }

        private void siticoneButtonAdvanced3_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedProcessId == -1)
                {
                    MessageBox.Show("Выберите процесс для удаления.");
                    return;
                }

                DialogResult result = MessageBox.Show(
                    "Удалить выбранный процесс?",
                    "Подтверждение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                    return;

                string query = "DELETE FROM [Процессы] WHERE proc_id = @Id";

                using (SqlConnection connection = bd.GetCon())
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Id", selectedProcessId);
                        cmd.ExecuteNonQuery();
                    }
                }

                this.процессыTableAdapter.Fill(this.управлениеПроцессамиDataSet.Процессы);
                MessageBox.Show("Процесс удалён.");
                ClearProcessFields();
                selectedProcessId = -1;
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
                this.процессыTableAdapter.Fill(this.управлениеПроцессамиDataSet.Процессы);
                selectedProcessId = -1;
                ClearProcessFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка обновления: " + ex.Message);
            }
        }
    }
}
