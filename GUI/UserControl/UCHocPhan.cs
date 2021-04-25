using System;
using System.Windows.Forms;
using MTAStudentManagementSystem.DAO;

namespace MTAStudentManagementSystem.GUI.UserControl
{
    public partial class UcHocPhan : System.Windows.Forms.UserControl
    {
        public UcHocPhan()
        {
            InitializeComponent();
            LoadChinhSua();
        }

        #region Chỉnh sửa thông tin

        private int _i = -1;

        private void bChinhSua_Click(object sender, EventArgs e)
        {
            pHocPhan.SelectTab(tpChinhSua);
            LoadChinhSua();
        }

        private void LoadChinhSua()
        {
            ClearBindingCs();
            ClearBindingTk();
            LoadListHocPhan();
            ChinhSuaBinding();
            LoadComboBoxGiangDuong();
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
            tbMaHocPhanCS.DataBindings.Add(new Binding("text", dgvChinhSua.DataSource, "MAHP"));
            tbTenHocPhanCS.DataBindings.Add(new Binding("text", dgvChinhSua.DataSource, "TENHP"));
            tbSoTinChiCS.DataBindings.Add(new Binding("text", dgvChinhSua.DataSource, "SOTC"));
            tbGiangVienCS.DataBindings.Add(new Binding("text", dgvChinhSua.DataSource, "GIANGVIEN"));
            cbThuCS.DataBindings.Add(new Binding("text", dgvChinhSua.DataSource, "THU"));
            tbTietCS.DataBindings.Add(new Binding("text", dgvChinhSua.DataSource, "TIET"));
            cbGiangDuongCS.DataBindings.Add(new Binding("text", dgvChinhSua.DataSource, "MAGD"));
        }

        private void LoadListHocPhan()
        {
            dgvChinhSua.DataSource = HocPhanDao.Instance.GetHocPhanList();
        }

        private void LoadComboBoxGiangDuong()
        {
            var list = GiangDuongDao.Instance.GetListGiangDuong();
            cbGiangDuongCS.DataSource = list;
            cbGiangDuongCS.DisplayMember = "magd";
            cbGiangDuongCS.ValueMember = "magd";
        }

        private void DisEnableButtonCs(bool x)
        {
            bThemCS.Enabled = x;
            bSuaCS.Enabled = x;
            bXoaCS.Enabled = x;
            bLuuCS.Enabled = !x;
            bHuyCS.Enabled = !x;
            tbTenHocPhanCS.Enabled = !x;
            tbSoTinChiCS.Enabled = !x;
            tbGiangVienCS.Enabled = !x;
            cbThuCS.Enabled = !x;
            tbTietCS.Enabled = !x;
            cbGiangDuongCS.Enabled = !x;
        }

        private void bThemCS_Click(object sender, EventArgs e)
        {
            DisEnableButtonCs(false);
            ClearBindingCs();
            tbMaHocPhanCS.Text = HocPhanDao.Instance.TaoMaHocPhan();
            tbTenHocPhanCS.Text = "";
            tbSoTinChiCS.Text = "";
            tbGiangVienCS.Text = "";
            cbThuCS.Text = "";
            tbTietCS.Text = "";
            cbGiangDuongCS.Text = "";
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
            var mahp = tbMaHocPhanCS.Text;
            var tenhp = tbTenHocPhanCS.Text;
            var sotc = Convert.ToInt32(tbSoTinChiCS.Text);
            var giangvien = tbGiangVienCS.Text;
            var thu = cbThuCS.SelectedItem.ToString();
            var tiet = tbTietCS.Text;
            var magd = cbGiangDuongCS.SelectedValue.ToString();
            var result = -1;
            if (_i == 1)
                result = HocPhanDao.Instance.ThemSuaHocPhan(mahp, tenhp, sotc, giangvien, thu, tiet, magd);
            else if (_i == 2) result = HocPhanDao.Instance.XoaHocPhan(mahp);

            if (result == 0)
                MessageBox.Show(@"Thất bại", @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show(@"Thành công", @"Thông báo", MessageBoxButtons.OK);

            _i = -1;
            ClearBindingCs();
            DisEnableButtonCs(true);
            LoadListHocPhan();
        }

        private void bHuyCS_Click(object sender, EventArgs e)
        {
            ClearBindingCs();
            DisEnableButtonCs(true);
        }

        private void tbMaHocPhanTK_TextChange(object sender, EventArgs e)
        {
            var mahp = tbMaHocPhanTK.Text;
            var tenhp = tbTenHocPhanTK.Text;
            dgvChinhSua.DataSource = HocPhanDao.Instance.TimKiemHocPhan(mahp, tenhp);
        }

        private void tbTenHocPhanTK_TextChange(object sender, EventArgs e)
        {
            var mahp = tbMaHocPhanTK.Text;
            var tenhp = tbTenHocPhanTK.Text;
            dgvChinhSua.DataSource = HocPhanDao.Instance.TimKiemHocPhan(mahp, tenhp);
        }

        #endregion

        #region Danh sách lớp học phần

        private void bDanhSach_Click(object sender, EventArgs e)
        {
            pHocPhan.SelectTab(tpDanhSach);
            LoadDanhSach();
        }

        private void LoadDanhSach()
        {
            LoadComboBoxHocPhan();
            LoadListLopHocPhan();
        }

        private void LoadComboBoxHocPhan()
        {
            var list = HocPhanDao.Instance.GetListHocPhan();
            cbMaHocPhanDS.DataSource = list;
            cbMaHocPhanDS.DisplayMember = "mahp";
            cbMaHocPhanDS.ValueMember = "mahp";
        }

        private void LoadListLopHocPhan()
        {
            dgvDanhSach.DataSource = HocPhanDao.Instance.GetDanhSachLopHocPhan("", "");
        }

        private void cbMaHocPhanDS_SelectedValueChanged(object sender, EventArgs e)
        {
            var mahp = cbMaHocPhanDS.SelectedValue.ToString();
            var tenhp = tbTenHocPhanDS.Text;
            dgvDanhSach.DataSource = HocPhanDao.Instance.GetDanhSachLopHocPhan(mahp, tenhp);
        }

        private void tbTenHocPhanDS_TextChange(object sender, EventArgs e)
        {
            var mahp = cbMaHocPhanDS.SelectedValue.ToString();
            var tenhp = tbTenHocPhanDS.Text;
            dgvDanhSach.DataSource = HocPhanDao.Instance.GetDanhSachLopHocPhan(mahp, tenhp);
        }

        #endregion
    }
}