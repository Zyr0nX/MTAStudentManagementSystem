using System.Collections.Generic;
using System.Data;
using MTAStudentManagementSystem.DTO;

namespace MTAStudentManagementSystem.DAO
{
    internal class GiangDuongDao
    {
        private static GiangDuongDao _instance;

        private GiangDuongDao()
        {
        }

        internal static GiangDuongDao Instance
        {
            get => _instance ?? (_instance = new GiangDuongDao());
            set => _instance = value;
        }

        public DataTable GetGiangDuongList()
        {
            var query = "SELECT * FROM GIANGDUONG";
            var table = DataProvider.Instance.ExecuteQuery(query);
            return table;
        }

        public string TaoMaGiangDuong()
        {
            var query = "SELECT [dbo].[TAOMAGD]()";
            var s = DataProvider.Instance.ExecuteScalar(query).ToString();
            return s;
        }

        public int ThemSuaGiangDuong(string magd, string motagd)
        {
            var query = "EXEC [dbo].[THEMSUAGD] @magd , @motagd";
            var i = DataProvider.Instance.ExecuteNonQuery(query, new object[] {magd, motagd});
            return i;
        }

        public int XoaGiangDuong(string magd)
        {
            var query = "EXEC [dbo].[XoaGiangDuong] @magd";
            var i = DataProvider.Instance.ExecuteNonQuery(query, new object[] {magd});
            return i;
        }

        public DataTable TimKiemGiangDuong(string magd, string motagd)
        {
            var query = "EXEC [dbo].[TimKiemGiangDuong] @magd , @motagd";
            var table = DataProvider.Instance.ExecuteQuery(query, new object[] {magd, motagd});
            return table;
        }

        public List<GiangDuong> GetListGiangDuong()
        {
            var list = new List<GiangDuong>();
            var query = "SELECT * FROM GIANGDUONG";
            var data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow dataRow in data.Rows)
            {
                var giangduong = new GiangDuong(dataRow);
                list.Add(giangduong);
            }

            return list;
        }
    }
}