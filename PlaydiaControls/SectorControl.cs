using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ISO9660;

namespace PlaydiaControls
{
    public partial class SectorControl : UserControl
    {
        XASectorForm1 sec;
        public SectorControl()
        {
            InitializeComponent();
        }
        public SectorControl(XASectorForm1 sector) : this()
        {
            sec = sector;
            RefreshSectorInfo();
        }
        public XASectorForm1 Sector
        {
            get
            {
                return sec;
            }
            set
            {
                sec = value;
                RefreshSectorInfo();
            }
        }
        private void RefreshSectorInfo()
        {
            txtMinute.Text = sec.Minute.ToString();
            txtSecond.Text = sec.Second.ToString();
            txtBlock.Text = sec.Block.ToString();
            txtMode.Text = sec.Mode.ToString();
            txtSubHeader0.Text = sec.SubHeader1.ToString();
            txtSubHeader1.Text = sec.SubHeader2.ToString();
        }
    }
}
