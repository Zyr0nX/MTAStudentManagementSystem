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
    public partial class UCLop : System.Windows.Forms.UserControl
    {
        public UCLop()
        {
            InitializeComponent();
            LoadChinhSua();
        }

        #region Chỉnh sửa thông tin

        private int i = -1;

        private void bChinhSua_Click(object sender, EventArgs e)
        {
            LoadChinhSua();
            pLop.SelectTab(tpChinhSua);
        }

        private void LoadChinhSua()
        {
            ClearBindingCS();
            ClearBindingTK();
            LoadListLop();
            ChinhSuaBinding();
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
            tbMaLopCS.DataBindings.Add(new Binding("text", dgvChinhSua.DataSource, "mal"));
            tbTenLopCS.DataBindings.Add(new Binding("text", dgvChinhSua.DataSource, "TENL"));
        }

        private void LoadListLop()
        {
            dgvChinhSua.DataSource = LopDAO.Instance.GetLopList();
        }

        private void DisEnableButtonCS(bool x)
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
            DisEnableButtonCS(false);
            ClearBindingCS();
            tbMaLopCS.Text = LopDAO.Instance.TaoMaLop();
            tbTenLopCS.Text = "";
            i = 1;
        }

        private void bSuaCS_Click(object sender, EventArgs e)
        {
            DisEnableButtonCS(false);
            ClearBindingCS();
            tbMaLopCS.DataBindings.Add(new Binding("text", dgvChinhSua.DataSource, "MAL"));
            tbTenLopCS.DataBindings.Add(new Binding("text", dgvChinhSua.DataSource, "TENL"));
            i = 1;
        }

        private void bXoaCS_Click(object sender, EventArgs e)
        {
            DisEnableButtonCS(false);
            ClearBindingCS();
            tbMaLopCS.DataBindings.Add(new Binding("text", dgvChinhSua.DataSource, "MAL"));
            tbTenLopCS.DataBindings.Add(new Binding("text", dgvChinhSua.DataSource, "TENL"));
            i = 2;

        }

        private void bLuuCS_Click(object sender, EventArgs e)
        {
            string mal = tbMaLopCS.Text;
            string tenl = tbTenLopCS.Text;
            int result = -1;
            if (i == 1)
            {
                result = LopDAO.Instance.ThemSuaLop(mal, tenl);
            }
            else if (i == 2)
            {
                result = LopDAO.Instance.XoaLop(mal);
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
            LoadListLop();
        }

        private void bHuyCS_Click(object sender, EventArgs e)
        {
            ClearBindingCS();
            DisEnableButtonCS(true);
        }

        private void tbMaLopTK_TextChange(object sender, EventArgs e)
        {
            string mal = tbMaLopTK.Text;
            string tenl = tbTenLopTK.Text;
            dgvChinhSua.DataSource = LopDAO.Instance.TimKiemLop(mal, tenl); 
        }

        private void tbTenLopTK_TextChange(object sender, EventArgs e)
        {
            string mal = tbMaLopTK.Text;
            string tenl = tbTenLopTK.Text;
            dgvChinhSua.DataSource = LopDAO.Instance.TimKiemLop(mal, tenl);
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
            LoadListDS();
            LoadComboBoxLop();
        }

        private void LoadListDS()
        {
            dgvDanhSach.DataSource = LopDAO.Instance.GetDanhSachLop("", "");
        }

        private void LoadComboBoxLop()
        {
            List<Lop> list = LopDAO.Instance.GetListMaLop();
            cbMaLopDS.DataSource = list;
            cbMaLopDS.DisplayMember = "mal";
            cbMaLopDS.ValueMember = "mal";
        }

        private void cbMaLopDS_SelectedValueChanged(object sender, EventArgs e)
        {
            string mal = cbMaLopDS.SelectedValue.ToString();
            string tenl = tbTenLopDS.Text;
            dgvDanhSach.DataSource = LopDAO.Instance.GetDanhSachLop(mal, tenl);
        }

        private void tbTenLopDS_TextChange(object sender, EventArgs e)
        {
            string mal = cbMaLopDS.SelectedValue.ToString();
            string tenl = tbTenLopDS.Text;
            dgvDanhSach.DataSource = LopDAO.Instance.GetDanhSachLop(mal, tenl);
        }

        #endregion

        
    }
}
