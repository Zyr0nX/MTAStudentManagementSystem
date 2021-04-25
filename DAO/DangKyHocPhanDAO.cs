using System.Data;

namespace MTAStudentManagementSystem.DAO
{
    internal class DangKyHocPhanDao
    {
        private static DangKyHocPhanDao _instance;

        private DangKyHocPhanDao()
        {
        }

        internal static DangKyHocPhanDao Instance
        {
            get => _instance ?? (_instance = new DangKyHocPhanDao());
            set => _instance = value;
        }

        public DataTable GetHocPhanDangKyList(string masv)
        {
            const string query = "SELECT * FROM DANGKYHOCPHAN WHERE MASV = @masv";
            var table = DataProvider.Instance.ExecuteQuery(query, new object[] {masv});
            return table;
        }

        public int ThemHocPhanDangKy(string masv, string mahp)
        {
            const string query = "EXEC [dbo].[ThemHocPhanDangKy] @masv , @mahp";
            var i = DataProvider.Instance.ExecuteNonQuery(query, new object[] {masv, mahp});
            return i;
        }

        public int XoaHocPhanDangKy(string masv, string mahp)
        {
            const string query = "EXEC [dbo].[XoaHocPhanDangKy] @masv , @mahp";
            var i = DataProvider.Instance.ExecuteNonQuery(query, new object[] {masv, mahp});
            return i;
        }
    }
}