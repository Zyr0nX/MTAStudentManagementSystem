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

namespace MTAStudentManagementSystem.GUI.UserControl
{
    public partial class UCNhapDiem : System.Windows.Forms.UserControl
    {
        public UCNhapDiem()
        {
            InitializeComponent();
            LoadNhapDiem();
        }

        private void LoadNhapDiem()
        {
            ClearBinding(gbChinhSua);
            LoadDgvNhapDiem();
            ChinhSuaBinding();
        }

        private void ClearBinding(BunifuGroupBox gb)
        {
            foreach (Control control in gb.Controls)
            {
                control.DataBindings.Clear();
            }
        }

        private void LoadDgvNhapDiem()
        {
            dgvPhieuDiem.DataSource = NhapDiemDAO.Instance.GetThongTinPhieuDiem("", "");
        }

        private void ChinhSuaBinding()
        {
            tbMaPhieuDiemCS.DataBindings.Add(new Binding("text", dgvPhieuDiem.DataSource, "mapd"));
            tbDiemChuyenCanCS.DataBindings.Add(new Binding("text", dgvPhieuDiem.DataSource, "diemcc"));
            tbDiemThuongXuyenCS.DataBindings.Add(new Binding("text", dgvPhieuDiem.DataSource, "diemtx"));
            tbDiemThiCS.DataBindings.Add(new Binding("text", dgvPhieuDiem.DataSource, "diemt"));
        }

        private void DisEnableButton(bool x)
        {
            bSuaCS.Enabled = x;
            bLuuCS.Enabled = !x;
            bHuyCS.Enabled = !x;
            tbDiemChuyenCanCS.Enabled = !x;
            tbDiemThuongXuyenCS.Enabled = !x;
            tbDiemThiCS.Enabled = !x;
        }

        private void bSuaCS_Click(object sender, EventArgs e)
        {
            DisEnableButton(false);
            ClearBinding(gbChinhSua);
            ChinhSuaBinding();
        }

        private decimal? ConvertToDecimal(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return null;
            }
            else
            {
                return Convert.ToDecimal(s);
            }
        }

        private void bLuuCS_Click(object sender, EventArgs e)
        {
            string mapd = tbMaPhieuDiemCS.Text;
            decimal? diemcc = ConvertToDecimal(tbDiemChuyenCanCS.Text);
            decimal? diemtx = ConvertToDecimal(tbDiemThuongXuyenCS.Text);
            decimal? diemt = ConvertToDecimal(tbDiemThiCS.Text);
            int result = NhapDiemDAO.Instance.SuaPhieuDiem(mapd, diemcc, diemtx, diemt);

            if (result == 0)
            {
                MessageBox.Show("Thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Thành công", "Thông báo", MessageBoxButtons.OK);
            }
            ClearBinding(gbChinhSua);
            DisEnableButton(true);
            LoadDgvNhapDiem();
        }

        private void bHuyCS_Click(object sender, EventArgs e)
        {
            ClearBinding(gbChinhSua);
            DisEnableButton(true);
        }

        private void tbMaSinhVienTK_TextChange(object sender, EventArgs e)
        {
            string masv = tbMaSinhVienTK.Text;
            string mahp = tbMaHocPhanTK.Text;
            dgvPhieuDiem.DataSource = NhapDiemDAO.Instance.GetThongTinPhieuDiem(masv, mahp);
        }

        private void tbMaHocPhanTK_TextChange(object sender, EventArgs e)
        {
            string masv = tbMaSinhVienTK.Text;
            string mahp = tbMaHocPhanTK.Text;
            dgvPhieuDiem.DataSource = NhapDiemDAO.Instance.GetThongTinPhieuDiem(masv, mahp);
        }
    }
}
