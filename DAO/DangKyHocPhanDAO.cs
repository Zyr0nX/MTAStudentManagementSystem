using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTAStudentManagementSystem.DAO
{
    class DangKyHocPhanDAO
    {
        private static DangKyHocPhanDAO instance;

        internal static DangKyHocPhanDAO Instance
        {
            get => instance ?? (instance = new DangKyHocPhanDAO());
            set => instance = value;
        }

        private DangKyHocPhanDAO() { }

        public DataTable GetHocPhanDangKyList(string masv)
        {
            string query = "SELECT * FROM DANGKYHOCPHAN WHERE MASV = @masv";
            DataTable table = DataProvider.Instance.ExecuteQuery(query, new object[] {masv});
            return table;
        }

        public int ThemHocPhanDangKy(string masv, string mahp)
        {
            string query = "EXEC [dbo].[ThemHocPhanDangKy] @masv , @mahp";
            int i = DataProvider.Instance.ExecuteNonQuery(query, new object[] {masv, mahp});
            return i;
        }

        public int XoaHocPhanDangKy(string masv, string mahp)
        {
            string query = "EXEC [dbo].[XoaHocPhanDangKy] @masv , @mahp";
            int i = DataProvider.Instance.ExecuteNonQuery(query, new object[] {masv, mahp});
            return i;
        }
    }
}