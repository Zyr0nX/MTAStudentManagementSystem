using System.Data;

namespace MTAStudentManagementSystem.DTO
{
    internal class HocPhan
    {
        public HocPhan(DataRow row)
        {
            Mahp = row["mahp"].ToString();
            Tenhp = row["tenhp"].ToString();
        }

        public string Mahp { get; set; }
        public string Tenhp { get; set; }
    }
}