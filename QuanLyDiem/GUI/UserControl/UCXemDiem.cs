using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDiem.GUI.UserControl
{
    public partial class UCXemDiem : System.Windows.Forms.UserControl
    {
        public UCXemDiem()
        {
            InitializeComponent();
        }

        #region Xem điểm sinh viên

        private void bXemDiemSV_Click(object sender, EventArgs e)
        {
            pXemDiem.SelectTab(tpXemDiemSV);
        }


        #endregion

        #region Xem điểm lớp học phần

        private void bXemDiemHP_Click(object sender, EventArgs e)
        {
            pXemDiem.SelectTab(tpXemDiemHP);
        }

        #endregion

        
    }
}
