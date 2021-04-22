using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MTAStudentManagementSystem.DAO;

namespace MTAStudentManagementSystem.DAO
{
    class SinhVienDAO
    {
        private static SinhVienDAO instance;

        internal static SinhVienDAO Instance
        {
            get => instance ?? (instance = new SinhVienDAO());
            set => instance = value;
        }

        private SinhVienDAO() { }

        public DataTable GetSinhVienList()
        {
            string query = "SELECT * FROM SINHVIEN";
            DataTable table = DataProvider.Instance.ExecuteQuery(query);
            return table;
        }

        public string TaoMaSinhVien()
        {
            string query = "SELECT [dbo].[TAOMASV]()";
            string s = DataProvider.Instance.ExecuteScalar(query).ToString();
            return s;
        }

        public int ThemSuaSinhVien(string masv, string tensv, DateTime ngaysinhsv, string socmndsv, string mal)
        {
            string query = "EXEC [dbo].[THEMSUASV] @masv , @tensv , @ngaysinhsv , @socmndsv , @mal";
            int i = DataProvider.Instance.ExecuteNonQuery(query, new object[] {masv, tensv, ngaysinhsv, socmndsv, mal});
            return i;
        }

        public int XoaSinhVien(string masv)
        {
            string query = "EXEC [dbo].[XoaSinhVien] @masv";
            int i = DataProvider.Instance.ExecuteNonQuery(query, new object[] {masv});
            return i;
        }

        public DataTable TimKiemSinhVien(string masv, string tensv)
        {
            string query = string.Format("SELECT * FROM SINHVIEN WHERE(MASV LIKE '%' + N'{0}' + '%' OR N'{0}' = '') AND(TENSV LIKE N'%' + N'{1}' + N'%' OR N'{1}' = '')", masv, tensv);
            DataTable table = DataProvider.Instance.ExecuteQuery(query);
            return table;
        }
    }
}
