using System;
using System.Windows.Forms;
using MTAStudentManagementSystem.DAO;

namespace MTAStudentManagementSystem.GUI.UserControl
{
    public partial class UcGiangDuong : System.Windows.Forms.UserControl
    {
        private int _i;

        public UcGiangDuong()
        {
            InitializeComponent();
            LoadGiangDuong();
        }

        private void LoadGiangDuong()
        {
            ClearBindingCs();
            ClearBindingTk();
            LoadListGiangDuong();
            ChinhSuaBinding();
        }

        private void ClearBindingCs()
        {
            foreach (Control control in gbChinhSua.Controls) control.DataBindings.Clear();
        }

        private void ClearBindingTk()
        {
            foreach (Control control in gbTimKiem.Controls) control.DataBindings.Clear();
        }

        private void ChinhSuaBinding()
        {
            tbMaGiangDuongCS.DataBindings.Add(new Binding("text", dgvGiangDuong.DataSource, "magd"));
            tbMoTaGiangDuongCS.DataBindings.Add(new Binding("text", dgvGiangDuong.DataSource, "motagd"));
        }

        private void LoadListGiangDuong()
        {
            dgvGiangDuong.DataSource = GiangDuongDao.Instance.GetGiangDuongList();
        }

        private void DisEnableButtonCs(bool x)
        {
            bThemCS.Enabled = x;
            bSuaCS.Enabled = x;
            bXoaCS.Enabled = x;
            bLuuCS.Enabled = !x;
            bHuyCS.Enabled = !x;
            tbMoTaGiangDuongCS.Enabled = !x;
        }

        private void bThemCS_Click(object sender, EventArgs e)
        {
            DisEnableButtonCs(false);
            ClearBindingCs();
            tbMaGiangDuongCS.Text = GiangDuongDao.Instance.TaoMaGiangDuong();
            tbMoTaGiangDuongCS.Text = "";
            _i = 1;
        }

        private void bSuaCS_Click(object sender, EventArgs e)
        {
            DisEnableButtonCs(false);
            ClearBindingCs();
            tbMaGiangDuongCS.DataBindings.Add(new Binding("text", dgvGiangDuong.DataSource, "MAGD"));
            tbMaGiangDuongCS.DataBindings.Add(new Binding("text", dgvGiangDuong.DataSource, "MOTAGD"));
            _i = 1;
        }

        private void bXoaCS_Click(object sender, EventArgs e)
        {
            DisEnableButtonCs(false);
            ClearBindingCs();
            tbMaGiangDuongCS.DataBindings.Add(new Binding("text", dgvGiangDuong.DataSource, "MAGD"));
            tbMoTaGiangDuongCS.DataBindings.Add(new Binding("text", dgvGiangDuong.DataSource, "TENGD"));
            _i = 2;
        }

        private void bLuuCS_Click(object sender, EventArgs e)
        {
            var magd = tbMaGiangDuongCS.Text;
            var motagd = tbMoTaGiangDuongCS.Text;
            var result = -1;
            if (_i == 1)
                result = GiangDuongDao.Instance.ThemSuaGiangDuong(magd, motagd);
            else if (_i == 2) result = GiangDuongDao.Instance.XoaGiangDuong(magd);

            if (result == 0)
                MessageBox.Show(@"Thất bại", @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show(@"Thành công", @"Thông báo", MessageBoxButtons.OK);
            _i = -1;
            ClearBindingCs();
            DisEnableButtonCs(true);
            LoadListGiangDuong();
        }

        private void bHuyCS_Click(object sender, EventArgs e)
        {
            ClearBindingCs();
            DisEnableButtonCs(true);
        }

        private void tbMaGiangDuongTK_TextChange(object sender, EventArgs e)
        {
            var magd = tbMaGiangDuongTK.Text;
            var motagd = tbMoTaGiangDuongTK.Text;
            dgvGiangDuong.DataSource = GiangDuongDao.Instance.TimKiemGiangDuong(magd, motagd);
        }

        private void tbMoTaGiangDuongTK_TextChange(object sender, EventArgs e)
        {
            var magd = tbMaGiangDuongTK.Text;
            var motagd = tbMoTaGiangDuongTK.Text;
            dgvGiangDuong.DataSource = GiangDuongDao.Instance.TimKiemGiangDuong(magd, motagd);
        }
    }
}