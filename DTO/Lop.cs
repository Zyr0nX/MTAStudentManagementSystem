using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTAStudentManagementSystem.DTO
{
    class Lop
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
