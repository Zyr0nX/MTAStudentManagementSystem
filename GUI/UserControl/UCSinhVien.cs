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
    public partial class UCSinhVien : System.Windows.Forms.UserControl
    {
        public UCSinhVien()
        {
            InitializeComponent();
        }

        #region Chỉnh sửa thông tin

        private void bChinhSua_Click(object sender, EventArgs e)
        {
            pSinhVien.SelectTab(tpChinhSua);
        }

        #endregion

        #region Đăng ký học phần

        private void bDangKy_Click(object sender, EventArgs e)
        {
            pSinhVien.SelectTab(tpDangKy);
        }

        private void twXemHocPhan_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuToggleSwitch.CheckedChangedEventArgs e)
        {
            gbTimKiemHP.Visible = twXemHocPhan.Value;
            dgvHP.Visible = twXemHocPhan.Value;
        }

        #endregion

        
    }
}
