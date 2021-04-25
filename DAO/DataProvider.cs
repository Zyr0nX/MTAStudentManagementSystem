using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace MTAStudentManagementSystem.DAO
{
    internal class DataProvider
    {
        private static DataProvider _instance;

        private static readonly string ConnectionString =
            "Data Source=(local);Initial Catalog=MTASTudentManagement;Integrated Security=True";

        private DataProvider()
        {
        }

        internal static DataProvider Instance
        {
            get => _instance ?? (_instance = new DataProvider());
            set => _instance = value;
        }

        public static void TestConnection()
        {
            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    connection.Close();
                }
            }
            catch (SqlException)
            {
                var result = MessageBox.Show(@"Không kết nối được với cơ sở dữ liệu", @"Lỗi",
                    MessageBoxButtons.RetryCancel,
                    MessageBoxIcon.Error);
                switch (result)
                {
                    case DialogResult.Retry:
                        TestConnection();
                        break;
                    case DialogResult.Cancel:
                        Environment.Exit(1);
                        break;
                    case DialogResult.None:
                        break;
                    case DialogResult.OK:
                        break;
                    case DialogResult.Abort:
                        break;
                    case DialogResult.Ignore:
                        break;
                    case DialogResult.Yes:
                        break;
                    case DialogResult.No:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public DataTable ExecuteQuery(string q, object[] parameter = null)
        {
            var data = new DataTable();
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var command = new SqlCommand(q, connection);
                if (parameter != null)
                {
                    var listPara = q.Split(' ');
                    var i = 0;
                    foreach (var item in listPara)
                    {
                        if (!item.Contains('@')) continue;
                        command.Parameters.AddWithValue(item, parameter[i] ?? DBNull.Value);
                        i++;
                    }
                }
                var adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                connection.Close();
            }
            return data;
        }

        public int ExecuteNonQuery(string q, object[] parameter = null)
        {
            int data;
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var command = new SqlCommand(q, connection);
                if (parameter != null)
                {
                    var listPara = q.Split(' ');
                    var i = 0;
                    foreach (var item in listPara)
                    {
                        if (!item.Contains('@')) continue;
                        command.Parameters.AddWithValue(item, parameter[i] ?? DBNull.Value);
                        i++;
                    }
                }
                data = command.ExecuteNonQuery();
                connection.Close();
            }
            return data;
        }

        public object ExecuteScalar(string q, object[] parameter = null)
        {
            object data;
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var command = new SqlCommand(q, connection);
                if (parameter != null)
                {
                    var listPara = q.Split(' ');
                    var i = 0;
                    foreach (var item in listPara)
                    {
                        if (!item.Contains('@')) continue;
                        command.Parameters.AddWithValue(item, parameter[i] ?? DBNull.Value);
                        i++;
                    }
                }
                data = command.ExecuteScalar();
                connection.Close();
            }
            return data;
        }
    }
}