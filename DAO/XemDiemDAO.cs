using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTAStudentManagementSystem.DAO
{
    class XemDiemDAO
    {
        private static XemDiemDAO instance;

        internal static XemDiemDAO Instance
        {
            get => instance ?? (instance = new XemDiemDAO());
            set => instance = value;
        }

        private XemDiemDAO() { }

        public DataTable XemDiemSinhVien(string masv, string tensv)
        {
            string query = "EXEC [dbo].[XemDiemSinhVien] @masv , @tensv";
            DataTable table = DataProvider.Instance.ExecuteQuery(query, new object[] {masv, tensv});
            return table;
        }

        public DataTable XemDiemLopHocPhan(string mahp, string tenhp)
        {
            string query = "EXEC [dbo].[XemDiemLopHocPhan] @mahp , @tenhp";
            DataTable table = DataProvider.Instance.ExecuteQuery(query, new object[] {mahp, tenhp});
            return table;
        }
    }
}
