using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTAStudentManagementSystem.DTO
{
    class HocPhan
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
