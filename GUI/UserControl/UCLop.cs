using System;
using System.Windows.Forms;
using MTAStudentManagementSystem.DAO;

namespace MTAStudentManagementSystem.GUI.UserControl
{
    public partial class UcLop : System.Windows.Forms.UserControl
    {
        public UcLop()
        {
            InitializeComponent();
            LoadChinhSua();
        }

        #region Chỉnh sửa thông tin

        private int _i = -1;

        private void bChinhSua_Click(object sender, EventArgs e)
        {
            LoadChinhSua();
            pLop.SelectTab(tpChinhSua);
        }

        private void LoadChinhSua()
        {
            ClearBindingCs();
            ClearBindingTk();
            LoadListLop();
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
            tbMaLopCS.DataBindings.Add(new Binding("text", dgvChinhSua.DataSource, "mal"));
            tbTenLopCS.DataBindings.Add(new Binding("text", dgvChinhSua.DataSource, "TENL"));
        }

        private void LoadListLop()
        {
            dgvChinhSua.DataSource = LopDao.Instance.GetLopList();
        }

        private void DisEnableButtonCs(bool x)
        {
            bThemCS.Enabled = x;
            bSuaCS.Enabled = x;
            bXoaCS.Enabled = x;
            bLuuCS.Enabled = !x;
            bHuyCS.Enabled = !x;
            tbTenLopCS.Enabled = !x;
        }

        private void bThemCS_Click(object sender, EventArgs e)
        {
            DisEnableButtonCs(false);
            ClearBindingCs();
            tbMaLopCS.Text = LopDao.Instance.TaoMaLop();
            tbTenLopCS.Text = "";
            _i = 1;
        }

        private void bSuaCS_Click(object sender, EventArgs e)
        {
            DisEnableButtonCs(false);
            ClearBindingCs();
            tbMaLopCS.DataBindings.Add(new Binding("text", dgvChinhSua.DataSource, "MAL"));
            tbTenLopCS.DataBindings.Add(new Binding("text", dgvChinhSua.DataSource, "TENL"));
            _i = 1;
        }

        private void bXoaCS_Click(object sender, EventArgs e)
        {
            DisEnableButtonCs(false);
            ClearBindingCs();
            tbMaLopCS.DataBindings.Add(new Binding("text", dgvChinhSua.DataSource, "MAL"));
            tbTenLopCS.DataBindings.Add(new Binding("text", dgvChinhSua.DataSource, "TENL"));
            _i = 2;
        }

        private void bLuuCS_Click(object sender, EventArgs e)
        {
            var mal = tbMaLopCS.Text;
            var tenl = tbTenLopCS.Text;
            var result = -1;
            if (_i == 1)
                result = LopDao.Instance.ThemSuaLop(mal, tenl);
            else if (_i == 2) result = LopDao.Instance.XoaLop(mal);

            if (result == 0)
                MessageBox.Show(@"Thất bại", @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show(@"Thành công", @"Thông báo", MessageBoxButtons.OK);
            _i = -1;
            ClearBindingCs();
            DisEnableButtonCs(true);
            LoadListLop();
        }

        private void bHuyCS_Click(object sender, EventArgs e)
        {
            ClearBindingCs();
            DisEnableButtonCs(true);
        }

        private void tbMaLopTK_TextChange(object sender, EventArgs e)
        {
            var mal = tbMaLopTK.Text;
            var tenl = tbTenLopTK.Text;
            dgvChinhSua.DataSource = LopDao.Instance.TimKiemLop(mal, tenl);
        }

        private void tbTenLopTK_TextChange(object sender, EventArgs e)
        {
            var mal = tbMaLopTK.Text;
            var tenl = tbTenLopTK.Text;
            dgvChinhSua.DataSource = LopDao.Instance.TimKiemLop(mal, tenl);
        }

        #endregion

        #region Danh sách lớp

        private void bDanhSach_Click(object sender, EventArgs e)
        {
            pLop.SelectTab(tpDanhSach);
            LoadDanhSach();
        }

        private void LoadDanhSach()
        {
            LoadListDs();
            LoadComboBoxLop();
        }

        private void LoadListDs()
        {
            dgvDanhSach.DataSource = LopDao.Instance.GetDanhSachLop("", "");
        }

        private void LoadComboBoxLop()
        {
            var list = LopDao.Instance.GetListMaLop();
            cbMaLopDS.DataSource = list;
            cbMaLopDS.DisplayMember = "mal";
            cbMaLopDS.ValueMember = "mal";
        }

        private void cbMaLopDS_SelectedValueChanged(object sender, EventArgs e)
        {
            var mal = cbMaLopDS.SelectedValue.ToString();
            var tenl = tbTenLopDS.Text;
            dgvDanhSach.DataSource = LopDao.Instance.GetDanhSachLop(mal, tenl);
        }

        private void tbTenLopDS_TextChange(object sender, EventArgs e)
        {
            var mal = cbMaLopDS.SelectedValue.ToString();
            var tenl = tbTenLopDS.Text;
            dgvDanhSach.DataSource = LopDao.Instance.GetDanhSachLop(mal, tenl);
        }

        #endregion
    }
}