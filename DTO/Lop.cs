using System.Data;

namespace MTAStudentManagementSystem.DTO
{
    internal class Lop
    {
        public Lop(DataRow row)
        {
            Mal = row["mal"].ToString();
            Tenl = row["tenl"].ToString();
        }

        public string Mal { get; set; }
        public string Tenl { get; set; }
    }
}