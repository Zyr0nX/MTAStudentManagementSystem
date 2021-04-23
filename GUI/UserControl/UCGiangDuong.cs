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

namespace MTAStudentManagementSystem.GUI.UserControl
{
    public partial class UCGiangDuong : System.Windows.Forms.UserControl
    {
        public UCGiangDuong()
        {
            InitializeComponent();
            LoadGiangDuong();
        }

        private int i;

        private void LoadGiangDuong()
        {
            ClearBindingCS();
            ClearBindingTK();
            LoadListGiangDuong();
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
            tbMaGiangDuongCS.DataBindings.Add(new Binding("text", dgvGiangDuong.DataSource, "magd"));
            tbMoTaGiangDuongCS.DataBindings.Add(new Binding("text", dgvGiangDuong.DataSource, "motagd"));
        }

        private void LoadListGiangDuong()
        {
            dgvGiangDuong.DataSource = GiangDuongDAO.Instance.GetGiangDuongList();
        }

        private void DisEnableButtonCS(bool x)
        {
            bThemCS.Enabled = x;
            bSuaCS.Enabled = x;
            bXoaCS.Enabled = x;
            bLuuCS.Enabled = !x;
            bHuyCS.Enabled = !x;
            tbMoTaGiangDuongCS.Enabled = !x;
        }

        private void bThemCS_Click(object sender, EventArgs e)
        {
            DisEnableButtonCS(false);
            ClearBindingCS();
            tbMaGiangDuongCS.Text = GiangDuongDAO.Instance.TaoMaGiangDuong();
            tbMoTaGiangDuongCS.Text = "";
            i = 1;
        }

        private void bSuaCS_Click(object sender, EventArgs e)
        {
            DisEnableButtonCS(false);
            ClearBindingCS();
            tbMaGiangDuongCS.DataBindings.Add(new Binding("text", dgvGiangDuong.DataSource, "MAGD"));
            tbMaGiangDuongCS.DataBindings.Add(new Binding("text", dgvGiangDuong.DataSource, "MOTAGD"));
            i = 1;
        }

        private void bXoaCS_Click(object sender, EventArgs e)
        {
            DisEnableButtonCS(false);
            ClearBindingCS();
            tbMaGiangDuongCS.DataBindings.Add(new Binding("text", dgvGiangDuong.DataSource, "MAGD"));
            tbMoTaGiangDuongCS.DataBindings.Add(new Binding("text", dgvGiangDuong.DataSource, "TENGD"));
            i = 2;
        }

        private void bLuuCS_Click(object sender, EventArgs e)
        {
            string magd = tbMaGiangDuongCS.Text;
            string motagd = tbMoTaGiangDuongCS.Text;
            int result = -1;
            if (i == 1)
            {
                result = GiangDuongDAO.Instance.ThemSuaGiangDuong(magd, motagd);
            }
            else if (i == 2)
            {
                result = GiangDuongDAO.Instance.XoaGiangDuong(magd);
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
            LoadListGiangDuong();
        }

        private void bHuyCS_Click(object sender, EventArgs e)
        {
            ClearBindingCS();
            DisEnableButtonCS(true);
        }

        private void tbMaGiangDuongTK_TextChange(object sender, EventArgs e)
        {
            string magd = tbMaGiangDuongTK.Text;
            string motagd = tbMoTaGiangDuongTK.Text;
            dgvGiangDuong.DataSource = GiangDuongDAO.Instance.TimKiemGiangDuong(magd, motagd); 
        }

        private void tbMoTaGiangDuongTK_TextChange(object sender, EventArgs e)
        {
            string magd = tbMaGiangDuongTK.Text;
            string motagd = tbMoTaGiangDuongTK.Text;
            dgvGiangDuong.DataSource = GiangDuongDAO.Instance.TimKiemGiangDuong(magd, motagd); 
        }
    }
}
