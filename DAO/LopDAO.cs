using System.Collections.Generic;
using System.Data;
using MTAStudentManagementSystem.DTO;

namespace MTAStudentManagementSystem.DAO
{
    internal class LopDao
    {
        private static LopDao _instance;

        private LopDao()
        {
        }

        internal static LopDao Instance
        {
            get => _instance ?? (_instance = new LopDao());
            set => _instance = value;
        }

        public DataTable GetLopList()
        {
            var query = "SELECT * FROM LOP";
            var table = DataProvider.Instance.ExecuteQuery(query);
            return table;
        }

        public string TaoMaLop()
        {
            var query = "SELECT [dbo].[TAOMAL]()";
            var s = DataProvider.Instance.ExecuteScalar(query).ToString();
            return s;
        }

        public int ThemSuaLop(string mal, string tenl)
        {
            var query = "EXEC [dbo].[THEMSUAL] @mal , @tenl";
            var i = DataProvider.Instance.ExecuteNonQuery(query, new object[] {mal, tenl});
            return i;
        }

        public int XoaLop(string mal)
        {
            var query = "EXEC [dbo].[XoaLop] @mal";
            var i = DataProvider.Instance.ExecuteNonQuery(query, new object[] {mal});
            return i;
        }

        public DataTable TimKiemLop(string mal, string tenl)
        {
            var query = "EXEC [dbo].[TimKiemLop] @mal , @tenl";
            var table = DataProvider.Instance.ExecuteQuery(query, new object[] {mal, tenl});
            return table;
        }

        public List<Lop> GetListMaLop()
        {
            var list = new List<Lop>();
            var query = "SELECT * FROM LOP";
            var data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow dataRow in data.Rows)
            {
                var lop = new Lop(dataRow);
                list.Add(lop);
            }

            return list;
        }

        public DataTable GetDanhSachLop(string mal, string tenl)
        {
            var query = "EXEC [dbo].[GetDanhSachLop] @mal , @tenl";
            var table = DataProvider.Instance.ExecuteQuery(query, new object[] {mal, tenl});
            return table;
        }
    }
}