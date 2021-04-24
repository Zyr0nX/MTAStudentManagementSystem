using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MTAStudentManagementSystem.DTO;

namespace MTAStudentManagementSystem.DAO
{
    class HocPhanDAO
    {
        private static HocPhanDAO instance;

        internal static HocPhanDAO Instance
        {
            get => instance ?? (instance = new HocPhanDAO());
            set => instance = value;
        }

        private HocPhanDAO() { }

        public DataTable GetHocPhanList()
        {
            string query = "SELECT * FROM HOCPHAN";
            DataTable table = DataProvider.Instance.ExecuteQuery(query);
            return table;
        }

        public string TaoMaHocPhan()
        {
            string query = "SELECT [dbo].[TAOMAHP]()";
            string s = DataProvider.Instance.ExecuteScalar(query).ToString();
            return s;
        }

        public int ThemSuaHocPhan(string mahp, string tenhp, int sotc, string giangvien, string thu, string tiet, string magd)
        {
            string query = "EXEC dbo.ThemSuaHP @mahp , @tenhp , @sotc , @giangvien , @thu , @tiet , @magd";
            int i = DataProvider.Instance.ExecuteNonQuery(query, new object[] {mahp, tenhp, sotc, giangvien, thu, tiet, magd});
            return i;
        }

        public int XoaHocPhan(string mahp)
        {
            string query = "EXEC [dbo].[XoaHocPhan] @mahp";
            int i = DataProvider.Instance.ExecuteNonQuery(query, new object[] {mahp});
            return i;
        }

        public DataTable TimKiemHocPhan(string mahp, string tenhp)
        {
            string query = "EXEC [dbo].[TimKiemhocphan] @mahp , @tenhp";
            DataTable table = DataProvider.Instance.ExecuteQuery(query, new object[] {mahp, tenhp});
            return table;
        }

        public List<HocPhan> GetListHocPhan()
        {
            List<HocPhan> list = new List<HocPhan>();
            string query = "SELECT * FROM HOCPHAN";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow dataRow in data.Rows)
            {
                HocPhan hocphan = new HocPhan(dataRow);
                list.Add(hocphan);
            }
            return list;
        }
    }
}
