using System;
using MTAStudentManagementSystem.DAO;

namespace MTAStudentManagementSystem.GUI.UserControl
{
    public partial class UcXemDiem : System.Windows.Forms.UserControl
    {
        public UcXemDiem()
        {
            InitializeComponent();
            LoadXemDiemSv();
        }

        #region Xem điểm sinh viên

        private void bXemDiemSV_Click(object sender, EventArgs e)
        {
            pXemDiem.SelectTab(tpXemDiemSV);
            LoadXemDiemSv();
        }

        private void LoadXemDiemSv()
        {
            LoadListSv();
        }

        private void LoadListSv()
        {
            dgvDiemSinhVien.DataSource = XemDiemDao.Instance.XemDiemSinhVien("", "");
        }

        private void tbMaSinhVien_TextChange(object sender, EventArgs e)
        {
            var masv = tbMaSinhVien.Text;
            var tensv = tbTenSV.Text;
            dgvDiemSinhVien.DataSource = XemDiemDao.Instance.XemDiemSinhVien(masv, tensv);
        }

        private void tbTenSV_TextChange(object sender, EventArgs e)
        {
            var masv = tbMaSinhVien.Text;
            var tensv = tbTenSV.Text;
            dgvDiemSinhVien.DataSource = XemDiemDao.Instance.XemDiemSinhVien(masv, tensv);
        }

        #endregion

        #region Xem điểm lớp học phần

        private void bXemDiemHP_Click(object sender, EventArgs e)
        {
            pXemDiem.SelectTab(tpXemDiemHP);
            LoadXemDiemLhp();
        }

        private void LoadXemDiemLhp()
        {
            LoadListHp();
            LoadComboBoxHocPhan();
        }

        private void LoadListHp()
        {
            dgvXemDiemLHP.DataSource = XemDiemDao.Instance.XemDiemLopHocPhan("", "");
        }

        private void LoadComboBoxHocPhan()
        {
            var list = HocPhanDao.Instance.GetListHocPhan();
            cbMaHocPhan.DataSource = list;
            cbMaHocPhan.DisplayMember = "mahp";
            cbMaHocPhan.ValueMember = "mahp";
        }

        private void cbMaHocPhan_SelectedValueChanged(object sender, EventArgs e)
        {
            var mahp = cbMaHocPhan.SelectedValue.ToString();
            var tenhp = tbTenHocPhan.Text;
            dgvXemDiemLHP.DataSource = XemDiemDao.Instance.XemDiemLopHocPhan(mahp, tenhp);
        }

        private void tbTenHocPhan_TextChange(object sender, EventArgs e)
        {
            var mahp = cbMaHocPhan.SelectedValue.ToString();
            var tenhp = tbTenHocPhan.Text;
            dgvXemDiemLHP.DataSource = XemDiemDao.Instance.XemDiemLopHocPhan(mahp, tenhp);
        }

        #endregion
    }
}