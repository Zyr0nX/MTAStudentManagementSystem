using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.UI.WinForms;
using MTAStudentManagementSystem.DAO;
using MTAStudentManagementSystem.DTO;

namespace MTAStudentManagementSystem.GUI.UserControl
{
    public partial class UCSinhVien : System.Windows.Forms.UserControl
    {
        public UCSinhVien()
        {
            InitializeComponent();
            LoadChinhSua();
        }

        #region Chỉnh sửa thông tin

        private int i = -1;

        private void bChinhSua_Click(object sender, EventArgs e)
        {
            LoadChinhSua();
            pSinhVien.SelectTab(tpChinhSua);
        }

        private void LoadChinhSua()
        {
            ClearBindingCS();
            ClearBindingTK();
            LoadListSinhVien();
            ChinhSuaBinding();
            LoadComboBoxLop();
        }

        private void ClearBindingCS()
        {
            foreach (Control control in gbChinhSua.Controls)
            {
                control.DataBindings.Clear();
            }
        }

        private void ClearBindingTK()
        {
            foreach (Control control in gbTimKiem.Controls)
            {
                control.DataBindings.Clear();
            }
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
            List<Lop> list = LopDAO.Instance.GetListMaLop();
            cbLopCS.DataSource = list;
            cbLopCS.DisplayMember = "tenl";
            cbLopCS.ValueMember = "mal";
        }

        private void LoadListSinhVien()
        {
            dgvChinhSua.DataSource = SinhVienDAO.Instance.GetSinhVienList();
        }

        private void DisEnableButtonCS(bool x)
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
            DisEnableButtonCS(false);
            ClearBindingCS();
            tbMaSinhVienCS.Text = SinhVienDAO.Instance.TaoMaSinhVien();
            tbTenSinhVienCS.Text = "";
            dpNgaySinhCS.Value = DateTime.Today;
            tbSoCMNDCS.Text = "";
            cbLopCS.Text = "";
            i = 1;
        }

        private void bSuaCS_Click(object sender, EventArgs e)
        {
            DisEnableButtonCS(false);
            ClearBindingCS();
            ChinhSuaBinding();
            i = 1;
        }

        private void bXoaCS_Click(object sender, EventArgs e)
        {
            DisEnableButtonCS(false);
            ClearBindingCS();
            ChinhSuaBinding();
            i = 2;
        }

        private void bLuuCS_Click(object sender, EventArgs e)
        {
            string masv = tbMaSinhVienCS.Text;
            string tensv = tbTenSinhVienCS.Text;
            DateTime ngaysinhsv = dpNgaySinhCS.Value;
            string socmndsv = tbSoCMNDCS.Text;
            string mal = cbLopCS.SelectedValue.ToString();
            int result = -1;
            if (i == 1)
            {
                result = SinhVienDAO.Instance.ThemSuaSinhVien(masv, tensv, ngaysinhsv, socmndsv, mal);
            }
            else if (i == 2)
            {
                result = SinhVienDAO.Instance.XoaSinhVien(masv);
            }

            if (result == 0)
            {
                MessageBox.Show("Thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Thành công", "Thông báo", MessageBoxButtons.OK);
            }
            i = -1;
            ClearBindingCS();
            DisEnableButtonCS(true);
            LoadListSinhVien();
        }

        private void bHuyCS_Click(object sender, EventArgs e)
        {
            ClearBindingCS();
            DisEnableButtonCS(true);
        }

        private void tbMaSinhVienTK_TextChange(object sender, EventArgs e)
        {
            string masv = tbMaSinhVienTK.Text;
            string tensv = tbTenSInhVienTK.Text;
            dgvChinhSua.DataSource = SinhVienDAO.Instance.TimKiemSinhVien(masv, tensv);
        }

        private void tbTenSInhVienTK_TextChange(object sender, EventArgs e)
        {
            string masv = tbMaSinhVienTK.Text;
            string tensv = tbTenSInhVienTK.Text;
            dgvChinhSua.DataSource = SinhVienDAO.Instance.TimKiemSinhVien(masv, tensv);
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
            foreach (Control gbControl in gb.Controls)
            {
                gbControl.DataBindings.Clear();
            }
        }

        private void LoadDataGridView()
        {
            dgvDangKy.DataSource = SinhVienDAO.Instance.GetSinhVienList();
            dgvHocPhan.DataSource = HocPhanDAO.Instance.GetHocPhanList();
        }

        private void LoadComboBoxHocPhan()
        {
            List<HocPhan> list = HocPhanDAO.Instance.GetListHocPhan();
            cbMaHocPhanDK.DataSource = list;
            cbMaHocPhanDK.DisplayMember = "mahp";
            cbMaHocPhanDK.ValueMember = "mahp";
        }

        private void ChinhSuaBinding2()
        {
            tbMaSinhVienDK.DataBindings.Add(new Binding("text", dgvChinhSua.DataSource, "masv"));
            tbTenSinhVienDK.DataBindings.Add(new Binding("text", dgvChinhSua.DataSource, "tensv"));
        }

        private void DisEnableButtonDK(bool x)
        {
            bThemDK.Enabled = x;
            bXoaDK.Enabled = x;
            bLuuDK.Enabled = !x;
            bHuyDK.Enabled = !x;
            tbMaSinhVienDK.Enabled = !x;
            tbTenSinhVienDK.Enabled = !x;
            cbMaHocPhanDK.Enabled = !x;
        }

        private void twXemHocPhan_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuToggleSwitch.CheckedChangedEventArgs e)
        {
            gbHocPhanTK.Visible = twXemHocPhan.Value;
            dgvHocPhan.Visible = twXemHocPhan.Value;
        }

        private void bThemDK_Click(object sender, EventArgs e)
        {
            DisEnableButtonDK(false);
            ClearBinding(gbDangKy);
            tbMaSinhVienDK.DataBindings.Add(new Binding("text", dgvDangKy.DataSource, "masv"));
            tbTenSinhVienDK.DataBindings.Add(new Binding("text", dgvDangKy.DataSource, "tensv"));
            dgvDangKy.DataSource = DangKyHocPhanDAO.Instance.GetHocPhanDangKyList(tbMaSinhVienDK.Text);
            i = 1;
        }

        private void bXoaDK_Click(object sender, EventArgs e)
        {
            DisEnableButtonDK(false);
            ClearBinding(gbDangKy);
            tbMaSinhVienDK.DataBindings.Add(new Binding("text", dgvDangKy.DataSource, "masv"));
            tbTenSinhVienDK.DataBindings.Add(new Binding("text", dgvDangKy.DataSource, "tensv"));
            dgvDangKy.DataSource = DangKyHocPhanDAO.Instance.GetHocPhanDangKyList(tbMaSinhVienDK.Text);
            cbMaHocPhanDK.DataBindings.Add(new Binding("text", dgvDangKy.DataSource, "mahp"));
            i = 2;
        }

        private void bLuuDK_Click(object sender, EventArgs e)
        {
            string masv = tbMaSinhVienDK.Text;
            string mahp = cbMaHocPhanDK.SelectedValue.ToString();
            int result = -1;
            if (i == 1)
            {
                result = DangKyHocPhanDAO.Instance.ThemHocPhanDangKy(masv, mahp);
            }
            else if (i == 2)
            {
                result = DangKyHocPhanDAO.Instance.XoaHocPhanDangKy(masv, mahp);
            }

            if (result == 0)
            {
                MessageBox.Show("Thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Thành công", "Thông báo", MessageBoxButtons.OK);
            }
            i = -1;
            ClearBinding(gbDangKy);
            DisEnableButtonDK(true);
            LoadDataGridView();
        }

        private void bHuyDK_Click(object sender, EventArgs e)
        {
            ClearBinding(gbDangKy);
            DisEnableButtonDK(true);
            LoadDataGridView();
        }

        private void tbMaSinhVienTK2_TextChange(object sender, EventArgs e)
        {
            string masv = tbMaSinhVienTK2.Text;
            string tensv = tbTenSinhVienTK2.Text;
            dgvDangKy.DataSource = SinhVienDAO.Instance.TimKiemSinhVien(masv, tensv);
        }

        private void tbTenSinhVienTK2_TextChange(object sender, EventArgs e)
        {
            string masv = tbMaSinhVienTK2.Text;
            string tensv = tbTenSinhVienTK2.Text;
            dgvDangKy.DataSource = SinhVienDAO.Instance.TimKiemSinhVien(masv, tensv);
        }

        private void tbMaHocPhanTK_TextChange(object sender, EventArgs e)
        {
            string mahp = tbMaHocPhanTK.Text;
            string tenhp = tbTenHocPhanTK.Text;
            dgvHocPhan.DataSource = HocPhanDAO.Instance.TimKiemHocPhan(mahp, tenhp);
        }

        private void tbTenHocPhanTK_TextChange(object sender, EventArgs e)
        {
            string mahp = tbMaHocPhanTK.Text;
            string tenhp = tbTenHocPhanTK.Text;
            dgvHocPhan.DataSource = HocPhanDAO.Instance.TimKiemHocPhan(mahp, tenhp);
        }

        #endregion
    }
}
