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
using System.Windows.Forms.DataVisualization.Charting;

namespace Diplom
{
    public partial class Admin4 : Form
    {
        private int currentUserId;
        private bdd bd = new bdd();
        private int selectedCategoryId = -1;
        private int selectedCommentId = -1;
        public Admin4()
        {
            InitializeComponent();
        }
        public Admin4(int userId)
        {
            InitializeComponent();
            currentUserId = userId;
        }

        private void Admin4_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "управлениеПроцессамиDataSet2.Операции". При необходимости она может быть перемещена или удалена.
            this.операцииTableAdapter.Fill(this.управлениеПроцессамиDataSet2.Операции);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "управлениеПроцессамиDataSet.Комментарии". При необходимости она может быть перемещена или удалена.
            this.комментарииTableAdapter.Fill(this.управлениеПроцессамиDataSet.Комментарии);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "управлениеПроцессамиDataSet.КатегорииОпераций". При необходимости она может быть перемещена или удалена.
            this.категорииОперацийTableAdapter.Fill(this.управлениеПроцессамиDataSet.КатегорииОпераций);
            LoadOperations();
        }

        private void siticoneTextBoxKat_TextContentChanged(object sender, EventArgs e)
        {

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

        private void siticoneAdvancedTextArea1_Load(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private void siticoneAdvancedTextArea2_Load(object sender, EventArgs e)
        {

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


                if (string.IsNullOrWhiteSpace(siticoneAdvancedTextArea2.Text))
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
                        cmd.Parameters.AddWithValue("@Text", siticoneAdvancedTextArea2.Text.Trim());
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
                ClearCategoryFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка обновления: " + ex.Message);
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

            selectedCommentId = Convert.ToInt32(drv["com_id"]);

            SelectComboItemById(guna2ComboBox1, drv["Операция№"].ToString());
            siticoneAdvancedTextArea2.Text = drv["Текст"].ToString();

            if (drv["ДатаДобавления"] != DBNull.Value)
                siticoneDateTimePicker1.Value = Convert.ToDateTime(drv["ДатаДобавления"]);
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

        private void siticoneImageButton4_Click(object sender, EventArgs e)
        {
            
        }
    }
}
