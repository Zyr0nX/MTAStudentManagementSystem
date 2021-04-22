using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MTAStudentManagementSystem.DAO;

namespace QuanLyDiem.DAO
{
    class LopDAO
    {
        private static LopDAO instance;

        internal static LopDAO Instance
        {
            get => instance ?? (instance = new LopDAO());
            set => instance = value;
        }

        private LopDAO() { }

        public DataTable GetLopList()
        {
            string query = "SELECT * FROM LOP";
            DataTable table = DataProvider.Instance.ExecuteQuery(query);
            return table;
        }

        public string TaoMaLop()
        {
            string query = "SELECT [dbo].[TAOMAL]()";
            string s = DataProvider.Instance.ExecuteScalar(query).ToString();
            return s;
        }

        public int ThemSuaLop(string mal, string tenl)
        {
            string query = "EXEC [dbo].[THEMSUAL] @mal , @tenl";
            int i = DataProvider.Instance.ExecuteNonQuery(query, new object[] {mal, tenl});
            return i;
        }

        public int XoaLop(string mal)
        {
            string query = "EXEC [dbo].[XoaLop] @mal";
            int i = DataProvider.Instance.ExecuteNonQuery(query, new object[] {mal});
            return i;
        }

        public DataTable TimKiemLop(string mal, string tenl)
        {
            string query = string.Format("SELECT * FROM LOP WHERE(MAL LIKE '%' + N'{0}' + '%' OR N'{0}' = '') AND(TENL LIKE N'%' + N'{1}' + N'%' OR N'{1}' = '')", mal, tenl);
            DataTable table = DataProvider.Instance.ExecuteQuery(query);
            return table;
        }
    }
}
