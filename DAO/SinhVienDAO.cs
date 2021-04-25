using System;
using System.Data;

namespace MTAStudentManagementSystem.DAO
{
    internal class SinhVienDao
    {
        private static SinhVienDao _instance;

        private SinhVienDao()
        {
        }

        internal static SinhVienDao Instance
        {
            get => _instance ?? (_instance = new SinhVienDao());
            set => _instance = value;
        }

        public DataTable GetSinhVienList()
        {
            var query = "SELECT * FROM SINHVIEN";
            var table = DataProvider.Instance.ExecuteQuery(query);
            return table;
        }

        public string TaoMaSinhVien()
        {
            var query = "SELECT [dbo].[TAOMASV]()";
            var s = DataProvider.Instance.ExecuteScalar(query).ToString();
            return s;
        }

        public int ThemSuaSinhVien(string masv, string tensv, DateTime ngaysinhsv, string socmndsv, string mal)
        {
            var query = "EXEC [dbo].[THEMSUASV] @masv , @tensv , @ngaysinhsv , @socmndsv , @mal";
            var i = DataProvider.Instance.ExecuteNonQuery(query, new object[] {masv, tensv, ngaysinhsv, socmndsv, mal});
            return i;
        }

        public int XoaSinhVien(string masv)
        {
            var query = "EXEC [dbo].[XoaSinhVien] @masv";
            var i = DataProvider.Instance.ExecuteNonQuery(query, new object[] {masv});
            return i;
        }

        public DataTable TimKiemSinhVien(string masv, string tensv)
        {
            var query = string.Format(
                "SELECT * FROM SINHVIEN WHERE(MASV LIKE '%' + N'{0}' + '%' OR N'{0}' = '') AND(TENSV LIKE N'%' + N'{1}' + N'%' OR N'{1}' = '')",
                masv, tensv);
            var table = DataProvider.Instance.ExecuteQuery(query);
            return table;
        }
    }
}