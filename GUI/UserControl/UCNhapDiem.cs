using System;
using System.Windows.Forms;
using Bunifu.UI.WinForms;
using MTAStudentManagementSystem.DAO;

namespace MTAStudentManagementSystem.GUI.UserControl
{
    public partial class UcNhapDiem : System.Windows.Forms.UserControl
    {
        public UcNhapDiem()
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
            foreach (Control control in gb.Controls) control.DataBindings.Clear();
        }

        private void LoadDgvNhapDiem()
        {
            dgvPhieuDiem.DataSource = NhapDiemDao.Instance.GetThongTinPhieuDiem("", "");
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
                return null;
            return Convert.ToDecimal(s);
        }

        private void bLuuCS_Click(object sender, EventArgs e)
        {
            var mapd = tbMaPhieuDiemCS.Text;
            var diemcc = ConvertToDecimal(tbDiemChuyenCanCS.Text);
            var diemtx = ConvertToDecimal(tbDiemThuongXuyenCS.Text);
            var diemt = ConvertToDecimal(tbDiemThiCS.Text);
            var result = NhapDiemDao.Instance.SuaPhieuDiem(mapd, diemcc, diemtx, diemt);

            if (result == 0)
                MessageBox.Show(@"Thất bại", @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show(@"Thành công", @"Thông báo", MessageBoxButtons.OK);
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
            var masv = tbMaSinhVienTK.Text;
            var mahp = tbMaHocPhanTK.Text;
            dgvPhieuDiem.DataSource = NhapDiemDao.Instance.GetThongTinPhieuDiem(masv, mahp);
        }

        private void tbMaHocPhanTK_TextChange(object sender, EventArgs e)
        {
            var masv = tbMaSinhVienTK.Text;
            var mahp = tbMaHocPhanTK.Text;
            dgvPhieuDiem.DataSource = NhapDiemDao.Instance.GetThongTinPhieuDiem(masv, mahp);
        }
    }
}