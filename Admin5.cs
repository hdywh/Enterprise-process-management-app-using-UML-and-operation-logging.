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
using System.Xml.Linq;

namespace Diplom
{
    public partial class Admin5 : Form
    {
        private int currentUserId;
        private bdd bd = new bdd();
        private int selectedZHURId = -1;
        public Admin5()
        {
            InitializeComponent();
        }
        public Admin5(int userId)
        {
            InitializeComponent();
            currentUserId = userId;
        }


        private void Admin5_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "управлениеПроцессамиDataSet1.Пользователи". При необходимости она может быть перемещена или удалена.
            this.пользователиTableAdapter.Fill(this.управлениеПроцессамиDataSet1.Пользователи);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "управлениеПроцессамиDataSet1.Операции". При необходимости она может быть перемещена или удалена.
            this.операцииTableAdapter.Fill(this.управлениеПроцессамиDataSet1.Операции);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "управлениеПроцессамиDataSet1.ЖурналДействий". При необходимости она может быть перемещена или удалена.
            this.журналДействийTableAdapter1.Fill(this.управлениеПроцессамиDataSet1.ЖурналДействий);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "управлениеПроцессамиDataSet.ЖурналДействий". При необходимости она может быть перемещена или удалена.
            this.журналДействийTableAdapter.Fill(this.управлениеПроцессамиDataSet.ЖурналДействий);

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                this.журналДействийTableAdapter1.Fill(this.управлениеПроцессамиDataSet1.ЖурналДействий);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка обновления: " + ex.Message);
            }
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = guna2DataGridView1.Rows[e.RowIndex];
            DataRowView drv = row.DataBoundItem as DataRowView;
            if (drv == null) return;

            int selectedId = Convert.ToInt32(drv["zapis_id"]);
            selectedZHURId = selectedId;

            txtUser.Text = GetUserNameById(Convert.ToInt32(drv["Пользователь№"]));
            txtOperation.Text = GetOperationNameById(Convert.ToInt32(drv["Операция№"]));
            txtAction.Text = drv["Действие"].ToString();
            txtOldData.Text = drv["СтарыеДанные"].ToString();
            txtNewData.Text = drv["НовыеДанные"].ToString();
            txtDate.Text = drv["Дата"].ToString();
        }

        private string GetUserNameById(int userId)
        {
            string query = "SELECT Логин FROM Пользователи WHERE id = @userId";
            using (SqlConnection conn = bd.GetCon())  
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userId", userId);
                return cmd.ExecuteScalar()?.ToString() ?? "Не найден";
            }
        }
        private string GetOperationNameById(int operationId)
        {
            string query = "SELECT НазваниеОперации FROM Операции WHERE op_id = @operationId";
            using (SqlConnection conn = bd.GetCon())  
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@operationId", operationId);
                return cmd.ExecuteScalar()?.ToString() ?? "Не найдено";
            }
        }

        private void siticoneTextBoxAdvanced5_TextContentChanged(object sender, EventArgs e)
        {

        }
    }
}
