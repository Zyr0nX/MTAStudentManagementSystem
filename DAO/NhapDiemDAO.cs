using System.Data;

namespace MTAStudentManagementSystem.DAO
{
    internal class NhapDiemDao
    {
        private static NhapDiemDao _instance;

        private NhapDiemDao()
        {
        }

        internal static NhapDiemDao Instance
        {
            get => _instance ?? (_instance = new NhapDiemDao());
            set => _instance = value;
        }

        public DataTable GetThongTinPhieuDiem(string masv, string mahp)
        {
            var query = "EXEC [dbo].[GetThongTinPhieuDiem] @masv , @mahp";
            var table = DataProvider.Instance.ExecuteQuery(query, new object[] {masv, mahp});
            return table;
        }

        public int SuaPhieuDiem(string mapd, decimal? diemcc, decimal? diemtx, decimal? diemt)
        {
            var query = "EXEC [dbo].[SuaPhieuDiem] @mapd , @diemcc , @diemtx , @diemt";
            var i = DataProvider.Instance.ExecuteNonQuery(query, new object[] {mapd, diemcc, diemtx, diemt});
            return i;
        }
    }
}