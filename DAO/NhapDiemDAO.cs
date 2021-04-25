using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTAStudentManagementSystem.DAO
{
    class NhapDiemDAO
    {
        private static NhapDiemDAO instance;

        internal static NhapDiemDAO Instance
        {
            get => instance ?? (instance = new NhapDiemDAO());
            set => instance = value;
        }

        private NhapDiemDAO() { }

        public DataTable GetThongTinPhieuDiem(string masv, string mahp)
        {
            string query = "EXEC [dbo].[GetThongTinPhieuDiem] @masv , @mahp";
            DataTable table = DataProvider.Instance.ExecuteQuery(query, new object[] {masv, mahp});
            return table;
        }

        public int SuaPhieuDiem(string mapd, decimal? diemcc, decimal? diemtx, decimal? diemt)
        {
            string query = "EXEC [dbo].[SuaPhieuDiem] @mapd , @diemcc , @diemtx , @diemt";
            int i = DataProvider.Instance.ExecuteNonQuery(query, new object[] {mapd, diemcc, diemtx, diemt});
            return i;
        }
    }
}
