using System.Data;

namespace MTAStudentManagementSystem.DTO
{
    internal class GiangDuong
    {
        public GiangDuong(DataRow row)
        {
            Magd = row["magd"].ToString();
            Motagd = row["motagd"].ToString();
        }

        public string Magd { get; set; }
        public string Motagd { get; set; }
    }
}