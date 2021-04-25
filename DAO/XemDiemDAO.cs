using System.Data;

namespace MTAStudentManagementSystem.DAO
{
    internal class XemDiemDao
    {
        private static XemDiemDao _instance;

        private XemDiemDao()
        {
        }

        internal static XemDiemDao Instance
        {
            get => _instance ?? (_instance = new XemDiemDao());
            set => _instance = value;
        }

        public DataTable XemDiemSinhVien(string masv, string tensv)
        {
            var query = "EXEC [dbo].[XemDiemSinhVien] @masv , @tensv";
            var table = DataProvider.Instance.ExecuteQuery(query, new object[] {masv, tensv});
            return table;
        }

        public DataTable XemDiemLopHocPhan(string mahp, string tenhp)
        {
            var query = "EXEC [dbo].[XemDiemLopHocPhan] @mahp , @tenhp";
            var table = DataProvider.Instance.ExecuteQuery(query, new object[] {mahp, tenhp});
            return table;
        }
    }
}