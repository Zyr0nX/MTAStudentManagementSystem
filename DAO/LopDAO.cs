using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MTAStudentManagementSystem.DTO;

namespace MTAStudentManagementSystem.DAO
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
            string query = "EXEC [dbo].[TimKiemLop] @mal , @tenl";
            DataTable table = DataProvider.Instance.ExecuteQuery(query, new object[] {mal, tenl});
            return table;
        }

        public List<Lop> GetListMaLop()
        {
            List<Lop> list = new List<Lop>();
            string query = "SELECT * FROM LOP";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow dataRow in data.Rows)
            {
                Lop lop = new Lop(dataRow);
                list.Add(lop);
            }
            return list;
        }

        public string GetTenLopByMaLop(string mal)
        {
            string query = "SELECT [dbo].[GetTenLopByMaLop]( @mal ) ";
            string tenl = DataProvider.Instance.ExecuteScalar(query, new object[] {mal}).ToString();
            return tenl;
        }

        public DataTable GetDanhSachLop(string mal, string tenl)
        {
            string query = "EXEC [dbo].[GetDanhSachLop] @mal , @tenl";
            DataTable table = DataProvider.Instance.ExecuteQuery(query, new object[] {mal, tenl});
            return table;
        }
    }
}
