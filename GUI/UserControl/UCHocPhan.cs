using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MTAStudentManagementSystem.DAO;
using MTAStudentManagementSystem.DTO;

namespace MTAStudentManagementSystem.GUI.UserControl
{
    public partial class UCHocPhan : System.Windows.Forms.UserControl
    {
        public UCHocPhan()
        {
            InitializeComponent();
            LoadChinhSua();
        }

        #region Chỉnh sửa thông tin

        private int i = -1;

        private void bChinhSua_Click(object sender, EventArgs e)
        {
            pHocPhan.SelectTab(tpChinhSua);
            LoadChinhSua();
        }

        private void LoadChinhSua()
        {
            ClearBindingCS();
            ClearBindingTK();
            LoadListHocPhan();
            ChinhSuaBinding();
            LoadComboBoxGiangDuong();
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
            dgvChinhSua.DataSource = HocPhanDAO.Instance.GetHocPhanList();
        }

        private void LoadComboBoxGiangDuong()
        {
            List<GiangDuong> list = GiangDuongDAO.Instance.GetListGiangDuong();
            cbGiangDuongCS.DataSource = list;
            cbGiangDuongCS.DisplayMember = "magd";
            cbGiangDuongCS.ValueMember = "magd";
        }

        private void DisEnableButtonCS(bool x)
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
            DisEnableButtonCS(false);
            ClearBindingCS();
            tbMaHocPhanCS.Text = HocPhanDAO.Instance.TaoMaHocPhan();
            tbTenHocPhanCS.Text = "";
            tbSoTinChiCS.Text = "";
            tbGiangVienCS.Text = "";
            cbThuCS.Text = "";
            tbTietCS.Text = "";
            cbGiangDuongCS.Text = "";
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
            string mahp = tbMaHocPhanCS.Text;
            string tenhp = tbTenHocPhanCS.Text;
            int sotc = Convert.ToInt32(tbSoTinChiCS.Text);
            string giangvien = tbGiangVienCS.Text;
            string thu = cbThuCS.SelectedItem.ToString();
            string tiet = tbTietCS.Text;
            string magd = cbGiangDuongCS.SelectedValue.ToString();
            int result = -1;
            if (i == 1)
            {
                result = HocPhanDAO.Instance.ThemSuaHocPhan(mahp, tenhp, sotc, giangvien, thu, tiet, magd);
            }
            else if (i == 2)
            {
                result = HocPhanDAO.Instance.XoaHocPhan(mahp);
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
            LoadListHocPhan();
        }

        private void bHuyCS_Click(object sender, EventArgs e)
        {
            ClearBindingCS();
            DisEnableButtonCS(true);
        }

        private void tbMaHocPhanTK_TextChange(object sender, EventArgs e)
        {
            string mahp = tbMaHocPhanTK.Text;
            string tenhp = tbTenHocPhanTK.Text;
            dgvChinhSua.DataSource = HocPhanDAO.Instance.TimKiemHocPhan(mahp, tenhp);
        }

        private void tbTenHocPhanTK_TextChange(object sender, EventArgs e)
        {
            string mahp = tbMaHocPhanTK.Text;
            string tenhp = tbTenHocPhanTK.Text;
            dgvChinhSua.DataSource = HocPhanDAO.Instance.TimKiemHocPhan(mahp, tenhp);
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