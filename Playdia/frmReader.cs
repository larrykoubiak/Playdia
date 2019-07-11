/*
 * Created by SharpDevelop.
 * User: I36107
 * Date: 20/10/2015
 * Time: 13:07
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
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
using PlaydiaControls;

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

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (sectorPos <= 0)
                sectorPos = discimg.NbSectors-1;
            else
                sectorPos--;
            //RefreshSectorInfo();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (sectorPos >= discimg.NbSectors-1)
                sectorPos = 0;
            else
                sectorPos++;
            //RefreshSectorInfo();
        }

        void OpenToolStripMenuItemClick(object sender, EventArgs e)
		{
            if(openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                TreeNode vdNode = tvSectors.Nodes["nodeVolumeDescriptors"];
                vdNode.Nodes.Clear();
                discimg = new ISO9660.Image(openFileDialog1.FileName);
                foreach(VolumeDescriptor vd in discimg.VolumeDescriptors)
                {
                    TreeNode node = vdNode.Nodes.Add(vd.VolumeDescriptorType.ToString());
                    node.Tag = vd;
                }
            }
        }

        private void tvSectors_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.pnlPrimaryVolumeDescriptor.Controls.Clear();
            VolumeDescriptor vd = (VolumeDescriptor)e.Node.Tag;
            VolumeDescriptorControl pvdctl = new VolumeDescriptorControl(vd);
            this.pnlPrimaryVolumeDescriptor.Controls.Add(pvdctl);
        }
    }
}
