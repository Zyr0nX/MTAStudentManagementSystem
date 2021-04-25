using System;
using System.Windows.Forms;
using Bunifu.UI.WinForms;
using MTAStudentManagementSystem.DAO;

namespace MTAStudentManagementSystem.GUI.UserControl
{
    public partial class UcSinhVien : System.Windows.Forms.UserControl
    {
        public UcSinhVien()
        {
            InitializeComponent();
            LoadChinhSua();
        }

        #region Chỉnh sửa thông tin

        private int _i = -1;

        private void bChinhSua_Click(object sender, EventArgs e)
        {
            LoadChinhSua();
            pSinhVien.SelectTab(tpChinhSua);
        }

        private void LoadChinhSua()
        {
            ClearBindingCs();
            ClearBindingTk();
            LoadListSinhVien();
            ChinhSuaBinding();
            LoadComboBoxLop();
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
            tbMaSinhVienCS.DataBindings.Add(new Binding("text", dgvChinhSua.DataSource, "masv"));
            tbTenSinhVienCS.DataBindings.Add(new Binding("text", dgvChinhSua.DataSource, "tensv"));
            dpNgaySinhCS.DataBindings.Add(new Binding("value", dgvChinhSua.DataSource, "ngaysinhsv"));
            tbSoCMNDCS.DataBindings.Add(new Binding("text", dgvChinhSua.DataSource, "socmndsv"));
        }

        private void LoadComboBoxLop()
        {
            var list = LopDao.Instance.GetListMaLop();
            cbLopCS.DataSource = list;
            cbLopCS.DisplayMember = "tenl";
            cbLopCS.ValueMember = "mal";
        }

        private void LoadListSinhVien()
        {
            dgvChinhSua.DataSource = SinhVienDao.Instance.GetSinhVienList();
        }

        private void DisEnableButtonCs(bool x)
        {
            bThemCS.Enabled = x;
            bSuaCS.Enabled = x;
            bXoaCS.Enabled = x;
            bLuuCS.Enabled = !x;
            bHuyCS.Enabled = !x;
            tbTenSinhVienCS.Enabled = !x;
            dpNgaySinhCS.Enabled = !x;
            tbSoCMNDCS.Enabled = !x;
            cbLopCS.Enabled = !x;
        }

        private void bThemCS_Click(object sender, EventArgs e)
        {
            DisEnableButtonCs(false);
            ClearBindingCs();
            tbMaSinhVienCS.Text = SinhVienDao.Instance.TaoMaSinhVien();
            tbTenSinhVienCS.Text = "";
            dpNgaySinhCS.Value = DateTime.Today;
            tbSoCMNDCS.Text = "";
            cbLopCS.Text = "";
            _i = 1;
        }

        private void bSuaCS_Click(object sender, EventArgs e)
        {
            DisEnableButtonCs(false);
            ClearBindingCs();
            ChinhSuaBinding();
            _i = 1;
        }

        private void bXoaCS_Click(object sender, EventArgs e)
        {
            DisEnableButtonCs(false);
            ClearBindingCs();
            ChinhSuaBinding();
            _i = 2;
        }

        private void bLuuCS_Click(object sender, EventArgs e)
        {
            var masv = tbMaSinhVienCS.Text;
            var tensv = tbTenSinhVienCS.Text;
            var ngaysinhsv = dpNgaySinhCS.Value;
            var socmndsv = tbSoCMNDCS.Text;
            var mal = cbLopCS.SelectedValue.ToString();
            var result = -1;
            if (_i == 1)
                result = SinhVienDao.Instance.ThemSuaSinhVien(masv, tensv, ngaysinhsv, socmndsv, mal);
            else if (_i == 2) result = SinhVienDao.Instance.XoaSinhVien(masv);

            if (result == 0)
                MessageBox.Show(@"Thất bại", @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show(@"Thành công", @"Thông báo", MessageBoxButtons.OK);
            _i = -1;
            ClearBindingCs();
            DisEnableButtonCs(true);
            LoadListSinhVien();
        }

        private void bHuyCS_Click(object sender, EventArgs e)
        {
            ClearBindingCs();
            DisEnableButtonCs(true);
        }

        private void tbMaSinhVienTK_TextChange(object sender, EventArgs e)
        {
            var masv = tbMaSinhVienTK.Text;
            var tensv = tbTenSInhVienTK.Text;
            dgvChinhSua.DataSource = SinhVienDao.Instance.TimKiemSinhVien(masv, tensv);
        }

        private void tbTenSInhVienTK_TextChange(object sender, EventArgs e)
        {
            var masv = tbMaSinhVienTK.Text;
            var tensv = tbTenSInhVienTK.Text;
            dgvChinhSua.DataSource = SinhVienDao.Instance.TimKiemSinhVien(masv, tensv);
        }

        #endregion

        #region Đăng ký học phần

        private void bDangKy_Click(object sender, EventArgs e)
        {
            pSinhVien.SelectTab(tpDangKy);
            LoadDangKy();
        }

        private void LoadDangKy()
        {
            ClearBinding(gbSinhVienTK);
            ClearBinding(gbHocPhanTK);
            ClearBinding(gbDangKy);
            LoadDataGridView();
            LoadComboBoxHocPhan();
            ChinhSuaBinding2();
        }

        private void ClearBinding(BunifuGroupBox gb)
        {
            foreach (Control gbControl in gb.Controls) gbControl.DataBindings.Clear();
        }

        private void LoadDataGridView()
        {
            dgvDangKy.DataSource = SinhVienDao.Instance.GetSinhVienList();
            dgvHocPhan.DataSource = HocPhanDao.Instance.GetHocPhanList();
        }

        private void LoadComboBoxHocPhan()
        {
            var list = HocPhanDao.Instance.GetListHocPhan();
            cbMaHocPhanDK.DataSource = list;
            cbMaHocPhanDK.DisplayMember = "mahp";
            cbMaHocPhanDK.ValueMember = "mahp";
        }

        private void ChinhSuaBinding2()
        {
            tbMaSinhVienDK.DataBindings.Add(new Binding("text", dgvChinhSua.DataSource, "masv"));
            tbTenSinhVienDK.DataBindings.Add(new Binding("text", dgvChinhSua.DataSource, "tensv"));
        }

        private void DisEnableButtonDk(bool x)
        {
            bThemDK.Enabled = x;
            bXoaDK.Enabled = x;
            bLuuDK.Enabled = !x;
            bHuyDK.Enabled = !x;
            tbMaSinhVienDK.Enabled = !x;
            tbTenSinhVienDK.Enabled = !x;
            cbMaHocPhanDK.Enabled = !x;
        }

        private void twXemHocPhan_CheckedChanged(object sender, BunifuToggleSwitch.CheckedChangedEventArgs e)
        {
            gbHocPhanTK.Visible = twXemHocPhan.Value;
            dgvHocPhan.Visible = twXemHocPhan.Value;
        }

        private void bThemDK_Click(object sender, EventArgs e)
        {
            DisEnableButtonDk(false);
            ClearBinding(gbDangKy);
            tbMaSinhVienDK.DataBindings.Add(new Binding("text", dgvDangKy.DataSource, "masv"));
            tbTenSinhVienDK.DataBindings.Add(new Binding("text", dgvDangKy.DataSource, "tensv"));
            dgvDangKy.DataSource = DangKyHocPhanDao.Instance.GetHocPhanDangKyList(tbMaSinhVienDK.Text);
            _i = 1;
        }

        private void bXoaDK_Click(object sender, EventArgs e)
        {
            DisEnableButtonDk(false);
            ClearBinding(gbDangKy);
            tbMaSinhVienDK.DataBindings.Add(new Binding("text", dgvDangKy.DataSource, "masv"));
            tbTenSinhVienDK.DataBindings.Add(new Binding("text", dgvDangKy.DataSource, "tensv"));
            dgvDangKy.DataSource = DangKyHocPhanDao.Instance.GetHocPhanDangKyList(tbMaSinhVienDK.Text);
            cbMaHocPhanDK.DataBindings.Add(new Binding("text", dgvDangKy.DataSource, "mahp"));
            _i = 2;
        }

        private void bLuuDK_Click(object sender, EventArgs e)
        {
            var masv = tbMaSinhVienDK.Text;
            var mahp = cbMaHocPhanDK.SelectedValue.ToString();
            var result = -1;
            if (_i == 1)
                result = DangKyHocPhanDao.Instance.ThemHocPhanDangKy(masv, mahp);
            else if (_i == 2) result = DangKyHocPhanDao.Instance.XoaHocPhanDangKy(masv, mahp);

            if (result == 0)
                MessageBox.Show(@"Thất bại", @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show(@"Thành công", @"Thông báo", MessageBoxButtons.OK);
            _i = -1;
            ClearBinding(gbDangKy);
            DisEnableButtonDk(true);
            LoadDataGridView();
        }

        private void bHuyDK_Click(object sender, EventArgs e)
        {
            ClearBinding(gbDangKy);
            DisEnableButtonDk(true);
            LoadDataGridView();
        }

        private void tbMaSinhVienTK2_TextChange(object sender, EventArgs e)
        {
            var masv = tbMaSinhVienTK2.Text;
            var tensv = tbTenSinhVienTK2.Text;
            dgvDangKy.DataSource = SinhVienDao.Instance.TimKiemSinhVien(masv, tensv);
        }

        private void tbTenSinhVienTK2_TextChange(object sender, EventArgs e)
        {
            var masv = tbMaSinhVienTK2.Text;
            var tensv = tbTenSinhVienTK2.Text;
            dgvDangKy.DataSource = SinhVienDao.Instance.TimKiemSinhVien(masv, tensv);
        }

        private void tbMaHocPhanTK_TextChange(object sender, EventArgs e)
        {
            var mahp = tbMaHocPhanTK.Text;
            var tenhp = tbTenHocPhanTK.Text;
            dgvHocPhan.DataSource = HocPhanDao.Instance.TimKiemHocPhan(mahp, tenhp);
        }

        private void tbTenHocPhanTK_TextChange(object sender, EventArgs e)
        {
            var mahp = tbMaHocPhanTK.Text;
            var tenhp = tbTenHocPhanTK.Text;
            dgvHocPhan.DataSource = HocPhanDao.Instance.TimKiemHocPhan(mahp, tenhp);
        }

        #endregion
    }
}