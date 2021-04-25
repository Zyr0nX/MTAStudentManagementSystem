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
    public partial class UCXemDiem : System.Windows.Forms.UserControl
    {
        public UCXemDiem()
        {
            InitializeComponent();
            LoadXemDiemSV();
        }

        #region Xem điểm sinh viên

        private void bXemDiemSV_Click(object sender, EventArgs e)
        {
            pXemDiem.SelectTab(tpXemDiemSV);
            LoadXemDiemSV();
        }

        private void LoadXemDiemSV()
        {
            LoadListSV();
        }

        private void LoadListSV()
        {
            dgvDiemSinhVien.DataSource = XemDiemDAO.Instance.XemDiemSinhVien("", "");
        }

        private void tbMaSinhVien_TextChange(object sender, EventArgs e)
        {
            string masv = tbMaSinhVien.Text;
            string tensv = tbTenSV.Text;
            dgvDiemSinhVien.DataSource = XemDiemDAO.Instance.XemDiemSinhVien(masv, tensv);
        }

        private void tbTenSV_TextChange(object sender, EventArgs e)
        {
            string masv = tbMaSinhVien.Text;
            string tensv = tbTenSV.Text;
            dgvDiemSinhVien.DataSource = XemDiemDAO.Instance.XemDiemSinhVien(masv, tensv);
        }
        #endregion

        #region Xem điểm lớp học phần

        private void bXemDiemHP_Click(object sender, EventArgs e)
        {
            pXemDiem.SelectTab(tpXemDiemHP);
            LoadXemDiemLHP();
        }

        private void LoadXemDiemLHP()
        {
            LoadListHP();
            LoadComboBoxHocPhan();
        }

        private void LoadListHP()
        {
            dgvXemDiemLHP.DataSource = XemDiemDAO.Instance.XemDiemLopHocPhan("", "");
        }

        private void LoadComboBoxHocPhan()
        {
            List<HocPhan> list = HocPhanDAO.Instance.GetListHocPhan();
            cbMaHocPhan.DataSource = list;
            cbMaHocPhan.DisplayMember = "mahp";
            cbMaHocPhan.ValueMember = "mahp";
        }

        private void cbMaHocPhan_SelectedValueChanged(object sender, EventArgs e)
        {
            string mahp = cbMaHocPhan.SelectedValue.ToString();
            string tenhp = tbTenHocPhan.Text;
            dgvXemDiemLHP.DataSource = XemDiemDAO.Instance.XemDiemLopHocPhan(mahp, tenhp);
        }
        
        private void tbTenHocPhan_TextChange(object sender, EventArgs e)
        {
            string mahp = cbMaHocPhan.SelectedValue.ToString();
            string tenhp = tbTenHocPhan.Text;
            dgvXemDiemLHP.DataSource = XemDiemDAO.Instance.XemDiemLopHocPhan(mahp, tenhp);
        }
        
        #endregion

        
    }
}
