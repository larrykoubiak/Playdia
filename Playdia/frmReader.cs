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
                TreeNode drNode = tvSectors.Nodes["nodeDirectoryRecords"];
                drNode.Tag = discimg.RootDirectory;
                drNode.Nodes.Clear();
                foreach(DirectoryRecord dr in discimg.RootDirectory.Children)
                {
                    TreeNode node = drNode.Nodes.Add(dr.FileIdentifier);
                    node.Tag = dr;
                }
                this.txtSectorStats.Text = discimg.SectorStats();
            }
        }

        private void tvSectors_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if(e.Node.Parent!=null && e.Node.Parent.Name=="nodeVolumeDescriptors")
            {
                this.pnlPrimaryVolumeDescriptor.Controls.Clear();
                VolumeDescriptor vd = (VolumeDescriptor)e.Node.Tag;
                VolumeDescriptorControl pvdctl = new VolumeDescriptorControl(vd);
                this.pnlPrimaryVolumeDescriptor.Controls.Add(pvdctl);
            }
            else if(e.Node.Parent!=null && e.Node.Parent.Name=="nodeDirectoryRecords")
            {
                this.pnlDirectoryRecord.Controls.Clear();
                DirectoryRecord dr = (DirectoryRecord)e.Node.Tag;
                DirectoryRecordControl drctl = new DirectoryRecordControl(dr);
                this.pnlDirectoryRecord.Controls.Add(drctl);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = this.tvSectors.SelectedNode;
            if(node!=null && node.Parent.Name=="nodeDirectoryRecords")
            {
                DirectoryRecord dr = (DirectoryRecord)node.Tag;
                saveFileDialog1.FileName = dr.FileIdentifier;
                if(saveFileDialog1.ShowDialog()==DialogResult.OK)
                {
                    discimg.ExtractDirectoryRecord(dr, saveFileDialog1.FileName);
                }
            }
        }

        private void sectorStatsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(discimg.SectorStats());
        }

        private void extractAudioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = this.tvSectors.SelectedNode;
            if (node != null && node.Parent.Name == "nodeDirectoryRecords")
            {
                DirectoryRecord dr = (DirectoryRecord)node.Tag;
                folderBrowserDialog1.SelectedPath = "C:\\Temp";
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    discimg.ExtractAudio(dr, folderBrowserDialog1.SelectedPath);
                }
            }
        }

        private void extractVideoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = this.tvSectors.SelectedNode;
            if (node != null && node.Parent.Name == "nodeDirectoryRecords")
            {
                DirectoryRecord dr = (DirectoryRecord)node.Tag;
                folderBrowserDialog1.SelectedPath = "C:\\Temp";
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    discimg.ExtractVideo(dr, folderBrowserDialog1.SelectedPath);
                }
            }
        }
    }
}
