using Guna.UI2.WinForms;
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
    public partial class Sotr3 : Form
    {
        private int currentUserId;
        private bdd bd = new bdd();
        private int selectedCommentId = -1;
        public Sotr3()
        {
            InitializeComponent();
        }
        public Sotr3(int userId)
        {
            InitializeComponent();
            currentUserId = userId;
        }

        private void Sotr3_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "управлениеПроцессамиDataSet2.Операции". При необходимости она может быть перемещена или удалена.
            this.операцииTableAdapter.Fill(this.управлениеПроцессамиDataSet2.Операции);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "управлениеПроцессамиDataSet2.Операции". При необходимости она может быть перемещена или удалена.
            this.операцииTableAdapter.Fill(this.управлениеПроцессамиDataSet2.Операции);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "управлениеПроцессамиDataSet.Комментарии". При необходимости она может быть перемещена или удалена.
            this.комментарииTableAdapter.Fill(this.управлениеПроцессамиDataSet.Комментарии);
            LoadOperations();


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
        private int GetIdFromComboBox(Guna.UI2.WinForms.Guna2ComboBox comboBox)
        {
            string text = comboBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(text))
                throw new Exception("Выберите тип процесса.");

            string[] parts = text.Split(' ');
            return Convert.ToInt32(parts[0]);
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (guna2ComboBox1.SelectedItem == null)
                {
                    MessageBox.Show("Выберите операцию.");
                    return;
                }

                string selectedText = guna2ComboBox1.SelectedItem.ToString();

                string[] parts = selectedText.Split(' ');
                int operationId;
                if (parts.Length < 2 || !int.TryParse(parts[0], out operationId))
                {
                    MessageBox.Show("Неверный формат данных в комбобоксе.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(siticoneAdvancedTextArea1.Text))
                {
                    MessageBox.Show("Введите текст комментария.");
                    return;
                }

                if (!UserExists(currentUserId))
                {
                    MessageBox.Show("Ошибка: пользователь с id = " + currentUserId + " не найден в таблице Пользователи.");
                    return;
                }

                DateTime addDate = DateTime.Now; 


                string query = @"
    INSERT INTO [Комментарии]
    (
        [Операция№],
        [Пользователь№],
        [Текст],
        [ДатаДобавления]
    )
    VALUES
    (
        @OperationId,
        @UserId,
        @Text,
        @AddDate
    )";

                using (SqlConnection connection = bd.GetCon())
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@OperationId", operationId);
                        cmd.Parameters.AddWithValue("@UserId", currentUserId);
                        cmd.Parameters.AddWithValue("@Text", siticoneAdvancedTextArea1.Text.Trim());
                        cmd.Parameters.AddWithValue("@AddDate", addDate);
                        cmd.ExecuteNonQuery();
                    }
                }

 
                this.комментарииTableAdapter.Fill(this.управлениеПроцессамиDataSet.Комментарии);
                MessageBox.Show("Комментарий добавлен.");
                ClearCommentFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка добавления: " + ex.Message);
            }
        }
        private void WriteToJournal(int operationId, string action)
        {
            try
            {
                using (SqlConnection connection = bd.GetCon())
                {
                    connection.Open();
                    string insertQuery = @"INSERT INTO [ЖурналДействий] ([Пользователь№], [Операция№], [Действие], [Дата]) 
                                   VALUES (@UserId, @OperationId, @Action, @Date)";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@UserId", currentUserId);
                        cmd.Parameters.AddWithValue("@OperationId", operationId);
                        cmd.Parameters.AddWithValue("@Action", action);
                        cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка записи в журнал: " + ex.Message);
            }
        }
        private void ClearCommentFields()
        {
            txtopernom.Clear();
            siticoneAdvancedTextArea1.Clear();
            siticoneDateTimePicker1.Value = DateTime.Now;
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedCommentId == -1)
                {
                    MessageBox.Show("Выберите комментарий в таблице.");
                    return;
                }

                if (guna2ComboBox1.SelectedItem == null)
                {
                    MessageBox.Show("Выберите операцию.");
                    return;
                }
                int operationId;
                try
                {
                    operationId = GetIdFromComboBox(guna2ComboBox1);  
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);  
                    return;
                }

                if (string.IsNullOrWhiteSpace(siticoneAdvancedTextArea1.Text))
                {
                    MessageBox.Show("Введите текст комментария.");
                    return;
                }

                DateTime addDate = siticoneDateTimePicker1.Value ?? DateTime.Now;

                string query = @"
    UPDATE [Комментарии]
    SET
        [Операция№] = @OperationId,
        [Пользователь№] = @UserId,
        [Текст] = @Text,
        [ДатаДобавления] = @AddDate
    WHERE [com_id] = @CommentId";

                using (SqlConnection connection = bd.GetCon())
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@OperationId", operationId);
                        cmd.Parameters.AddWithValue("@UserId", currentUserId);
                        cmd.Parameters.AddWithValue("@Text", siticoneAdvancedTextArea1.Text.Trim());
                        cmd.Parameters.AddWithValue("@AddDate", addDate);
                        cmd.Parameters.AddWithValue("@CommentId", selectedCommentId);
                        cmd.ExecuteNonQuery();
                    }
                }

                this.комментарииTableAdapter.Fill(this.управлениеПроцессамиDataSet.Комментарии);

                MessageBox.Show("Комментарий обновлён.");
                ClearCommentFields();
                selectedCommentId = -1;
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
                if (selectedCommentId == -1)
                {
                    MessageBox.Show("Выберите комментарий для удаления.");
                    return;
                }
                DialogResult result = MessageBox.Show(
                    "Удалить выбранный комментарий?",
                    "Подтверждение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (result != DialogResult.Yes)
                    return;
                string query = "DELETE FROM [Комментарии] WHERE [com_id] = @CommentId";
                using (SqlConnection connection = bd.GetCon())
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@CommentId", selectedCommentId);
                        cmd.ExecuteNonQuery();
                    }
                }
                this.комментарииTableAdapter.Fill(this.управлениеПроцессамиDataSet.Комментарии);
                MessageBox.Show("Комментарий удалён.");
                ClearCommentFields();
                selectedCommentId = -1;
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
                this.комментарииTableAdapter.Fill(this.управлениеПроцессамиDataSet.Комментарии);
                selectedCommentId = -1;
                ClearCommentFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка обновления: " + ex.Message);
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
        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = guna2DataGridView1.Rows[e.RowIndex];
            DataRowView drv = row.DataBoundItem as DataRowView;

            if (drv == null)
                return;

            selectedCommentId = Convert.ToInt32(drv["com_id"]);

            guna2ComboBox1.Text = drv["Операция№"].ToString();
            siticoneAdvancedTextArea1.Text = drv["Текст"].ToString();

            if (drv["ДатаДобавления"] != DBNull.Value)
                siticoneDateTimePicker1.Value = Convert.ToDateTime(drv["ДатаДобавления"]);
        }
        private void LoadOperations()
        {
           
            guna2ComboBox1.Items.Clear();

            
            string query = "SELECT op_id, НазваниеОперации FROM Операции";
            using (SqlConnection connection = bd.GetCon())
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        
                        guna2ComboBox1.Items.Add(reader["op_id"] + " " + reader["НазваниеОперации"]);
                    }
                }
            }
        }

        private void txtopernom_TextContentChanged(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
