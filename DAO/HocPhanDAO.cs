using System.Collections.Generic;
using System.Data;
using MTAStudentManagementSystem.DTO;

namespace MTAStudentManagementSystem.DAO
{
    internal class HocPhanDao
    {
        private static HocPhanDao _instance;

        private HocPhanDao()
        {
        }

        internal static HocPhanDao Instance
        {
            get => _instance ?? (_instance = new HocPhanDao());
            set => _instance = value;
        }

        public DataTable GetHocPhanList()
        {
            var query = "SELECT * FROM HOCPHAN";
            var table = DataProvider.Instance.ExecuteQuery(query);
            return table;
        }

        public string TaoMaHocPhan()
        {
            var query = "SELECT [dbo].[TAOMAHP]()";
            var s = DataProvider.Instance.ExecuteScalar(query).ToString();
            return s;
        }

        public int ThemSuaHocPhan(string mahp, string tenhp, int sotc, string giangvien, string thu, string tiet,
            string magd)
        {
            var query = "EXEC dbo.ThemSuaHP @mahp , @tenhp , @sotc , @giangvien , @thu , @tiet , @magd";
            var i = DataProvider.Instance.ExecuteNonQuery(query,
                new object[] {mahp, tenhp, sotc, giangvien, thu, tiet, magd});
            return i;
        }

        public int XoaHocPhan(string mahp)
        {
            var query = "EXEC [dbo].[XoaHocPhan] @mahp";
            var i = DataProvider.Instance.ExecuteNonQuery(query, new object[] {mahp});
            return i;
        }

        public DataTable TimKiemHocPhan(string mahp, string tenhp)
        {
            var query = "EXEC [dbo].[TimKiemhocphan] @mahp , @tenhp";
            var table = DataProvider.Instance.ExecuteQuery(query, new object[] {mahp, tenhp});
            return table;
        }

        public List<HocPhan> GetListHocPhan()
        {
            var list = new List<HocPhan>();
            var query = "SELECT * FROM HOCPHAN";
            var data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow dataRow in data.Rows)
            {
                var hocphan = new HocPhan(dataRow);
                list.Add(hocphan);
            }

            return list;
        }

        public DataTable GetDanhSachLopHocPhan(string mahp, string tenhp)
        {
            var query = "EXEC [dbo].[GetDanhSachLopHocPhan] @mahp , @tenhp";
            var table = DataProvider.Instance.ExecuteQuery(query, new object[] {mahp, tenhp});
            return table;
        }
    }
}