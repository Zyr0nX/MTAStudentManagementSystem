using System;
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
            var uc = new UcTongQuan();
            AddUserControlToPanel(uc);
        }

        private void bSinhVien_Click(object sender, EventArgs e)
        {
            MoveSlider(bSinhVien);
            AddUserControlToPanel(new UcSinhVien());
        }

        private void bLop_Click(object sender, EventArgs e)
        {
            MoveSlider(bLop);
            AddUserControlToPanel(new UcLop());
        }

        private void bHocPhan_Click(object sender, EventArgs e)
        {
            MoveSlider(bHocPhan);
            AddUserControlToPanel(new UcHocPhan());
        }

        private void bPhong_Click(object sender, EventArgs e)
        {
            MoveSlider(bPhong);
            AddUserControlToPanel(new UcGiangDuong());
        }

        private void bBangDiem_Click(object sender, EventArgs e)
        {
            MoveSlider(bNhapDiem);
            AddUserControlToPanel(new UcNhapDiem());
        }

        private void bXemDiem_Click(object sender, EventArgs e)
        {
            MoveSlider(bXemDiem);
            AddUserControlToPanel(new UcXemDiem());
        }

        private void bDangXuat_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }
    }
}