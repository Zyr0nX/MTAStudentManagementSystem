using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MTAStudentManagementSystem.DAO;
using MTAStudentManagementSystem.DTO;

namespace MTAStudentManagementSystem.DAO
{
    class GiangDuongDAO
    {
        private static GiangDuongDAO instance;

        internal static GiangDuongDAO Instance
        {
            get => instance ?? (instance = new GiangDuongDAO());
            set => instance = value;
        }

        private GiangDuongDAO() { }

        public DataTable GetGiangDuongList()
        {
            string query = "SELECT * FROM GIANGDUONG";
            DataTable table = DataProvider.Instance.ExecuteQuery(query);
            return table;
        }

        public string TaoMaGiangDuong()
        {
            string query = "SELECT [dbo].[TAOMAGD]()";
            string s = DataProvider.Instance.ExecuteScalar(query).ToString();
            return s;
        }

        public int ThemSuaGiangDuong(string magd, string motagd)
        {
            string query = "EXEC [dbo].[THEMSUAGD] @magd , @motagd";
            int i = DataProvider.Instance.ExecuteNonQuery(query, new object[] {magd, motagd});
            return i;
        }

        public int XoaGiangDuong(string magd)
        {
            string query = "EXEC [dbo].[XoaGiangDuong] @magd";
            int i = DataProvider.Instance.ExecuteNonQuery(query, new object[] {magd});
            return i;
        }

        public DataTable TimKiemGiangDuong(string magd, string motagd)
        {
            string query = "EXEC [dbo].[TimKiemGiangDuong] @magd , @motagd";
            DataTable table = DataProvider.Instance.ExecuteQuery(query, new object[] {magd, motagd});
            return table;
        }

        public List<GiangDuong> GetListGiangDuong()
        {
            List<GiangDuong> list = new List<GiangDuong>();
            string query = "SELECT * FROM GIANGDUONG";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow dataRow in data.Rows)
            {
                GiangDuong giangduong = new GiangDuong(dataRow);
                list.Add(giangduong);
            }
            return list;
        }
    }
}
