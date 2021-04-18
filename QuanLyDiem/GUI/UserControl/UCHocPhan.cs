using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDiem.GUI.UserControl
{
    public partial class UCHocPhan : System.Windows.Forms.UserControl
    {
        public UCHocPhan()
        {
            InitializeComponent();
        }

        #region Chỉnh sửa thông tin

        private void bChinhSua_Click(object sender, EventArgs e)
        {
            pHocPhan.SelectTab(tpChinhSua);
        }

        #endregion

        #region Danh sách lớp học phần

        private void bDanhSach_Click(object sender, EventArgs e)
        {
            pHocPhan.SelectTab(tpDanhSach);
        }

        #endregion
    }
}
