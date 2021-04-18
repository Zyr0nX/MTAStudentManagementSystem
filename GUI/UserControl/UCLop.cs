using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MTAStudentManagementSystem.GUI.UserControl
{
    public partial class UCLop : System.Windows.Forms.UserControl
    {
        public UCLop()
        {
            InitializeComponent();
        }

        #region Chỉnh sửa thông tin

        private void bChinhSua_Click(object sender, EventArgs e)
        {
            pLop.SelectTab(tpChinhSua);
        }

        #endregion

        #region Danh sách lớp

        private void bDanhSach_Click(object sender, EventArgs e)
        {
            pLop.SelectTab(tpDanhSach);
        }

        #endregion

        
    }
}
