using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTAStudentManagementSystem.DTO
{
    class GiangDuong
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
