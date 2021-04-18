using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MTAStudentManagementSystem.DAO
{
    class DataProvider
    {
        private static string connectionString = "Data Source=(local);Initial Catalog=MTASTudentManagement;Integrated Security=True";

        public static void TestConnection()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    connection.Close();
                }
            }
            catch (SqlException)
            {
                DialogResult result = MessageBox.Show("Không kết nối được với cơ sở dữ liệu", "Lỗi",
                    MessageBoxButtons.RetryCancel,
                    MessageBoxIcon.Error);
                if (result == DialogResult.Retry)
                {
                    TestConnection();
                }
                else if (result == DialogResult.Cancel)
                {
                    Environment.Exit(1);
                }
            }
        }

        public DataTable ExecuteQuery(string q, object[] parameter = null)
        {
            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(q, connection);
                if (parameter != null)
                {
                    string[] listPara = q.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, listPara[i]);
                            i++;
                        }
                    }
                }
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                connection.Close();
            }
            return data;
        }

        public int ExecuteNonQuery(string q, object[] parameter = null)
        {
            int data = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(q, connection);
                if (parameter != null)
                {
                    string[] listPara = q.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, listPara[i]);
                            i++;
                        }
                    }
                }
                data = command.ExecuteNonQuery();
                connection.Close();
            }
            return data;
        }

        public object ExecuteScalar(string q, object[] parameter = null)
        {
            object data = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(q, connection);
                if (parameter != null)
                {
                    string[] listPara = q.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, listPara[i]);
                            i++;
                        }
                    }
                }
                data = command.ExecuteNonQuery();
                connection.Close();
            }
            return data;
        }
    }
}
