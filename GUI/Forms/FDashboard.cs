using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MTAStudentManagementSystem.GUI.UserControl;

namespace MTAStudentManagementSystem.GUI.Forms
{
    public partial class FDashboard : Form
    {
        public FDashboard()
        {
            InitializeComponent();
        }

        private void MoveSlider(Control bControl)
        {
            pSlider.Top = bControl.Top;
        }

        private void AddUserControlToPanel(Control ucControl)
        {
            pUserControl.Controls.Clear();
            pUserControl.Controls.Add(ucControl);
        }

        private void bTongQuan_Click(object sender, EventArgs e)
        {
            MoveSlider(bTongQuan);
            UCTongQuan uc = new UCTongQuan();
            AddUserControlToPanel(uc);
        }

        private void bSinhVien_Click(object sender, EventArgs e)
        {
            MoveSlider(bSinhVien);
            AddUserControlToPanel(new UCSinhVien());
        }

        private void bLop_Click(object sender, EventArgs e)
        {
            MoveSlider(bLop);
            AddUserControlToPanel(new UCLop());
        }

        private void bHocPhan_Click(object sender, EventArgs e)
        {
            MoveSlider(bHocPhan);
            AddUserControlToPanel(new UCHocPhan());
        }

        private void bPhong_Click(object sender, EventArgs e)
        {
            MoveSlider(bPhong);
            AddUserControlToPanel(new UCGiangDuong());
        }

        private void bBangDiem_Click(object sender, EventArgs e)
        {
            MoveSlider(bNhapDiem);
            AddUserControlToPanel(new UCNhapDiem());
        }

        private void bXemDiem_Click(object sender, EventArgs e)
        {
            MoveSlider(bXemDiem);
            AddUserControlToPanel(new UCXemDiem());
        }

        private void bDangXuat_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn thực sự muốn thoát chương trình?", "Thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                this.Close();
        }
    }
}
