using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ISO9660;

namespace Playdia
{
    public partial class frmReader : Form
    {
        ISO9660.Image discimg;
        int sectorPos;
        public frmReader()
        {
            InitializeComponent();
            sectorPos = 0;
            discimg = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                discimg = new ISO9660.Image(openFileDialog1.FileName);
                sectorPos = 0;
                RefreshControls();
            }
        }

        private void RefreshControls()
        {
            txtMinute.Text = discimg.Sectors[sectorPos].Minute.ToString();
            txtSecond.Text = discimg.Sectors[sectorPos].Second.ToString();
            txtBlock.Text = discimg.Sectors[sectorPos].Block.ToString();
            txtMode.Text = discimg.Sectors[sectorPos].Mode.ToString();
            txtSubHeader0.Text = discimg.Sectors[sectorPos].SubHeader1.ToString();
            txtSubHeader1.Text = discimg.Sectors[sectorPos].SubHeader2.ToString();
            txtData.Text = BitConverter.ToString(discimg.Sectors[sectorPos].Data).Replace('-', ' ');
            lblSectorPos.Text = (sectorPos + 1).ToString();
            lblNbSectors.Text = discimg.NbSectors.ToString();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (sectorPos <= 0)
                sectorPos = discimg.NbSectors-1;
            else
                sectorPos--;
            RefreshControls();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (sectorPos >= discimg.NbSectors-1)
                sectorPos = 0;
            else
                sectorPos++;
            RefreshControls();
        }

    }
}
