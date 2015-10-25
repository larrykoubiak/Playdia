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

namespace Playdia
{
    public partial class frmReader : Form
    {
        ISO9660.Image discimg;
        int sectorPos;
        PrimaryVolumeDescriptor pvd;
        public frmReader()
        {
            InitializeComponent();
            sectorPos = 0;
            discimg = null;
        }

        private void RefreshPVDInfo()
        {
        	txtVDType.Text = pvd.VolumeDescriptorType.ToString();
        	txtStandardIdentifier.Text = pvd.StandardIdentifier;
        	txtVDVersion.Text  =pvd.VolumeDescriptorVersion.ToString();
        	txtSystemIdentifier.Text = pvd.SystemIdentifier;
        	txtVolumeIdentifier.Text = pvd.VolumeIdentifier;
        	txtVolumeSpace.Text = pvd.VolumeSpaceSize.ToString();
        	txtVolumeSequence.Text = pvd.VolumeSequenceNumber.ToString();
        	txtVolumeSet.Text = pvd.VolumeSetSize.ToString();
        	txtLogicalBlockSize.Text = pvd.LogicalBlockSize.ToString();
        	txtPathTableSize.Text = pvd.PathTableSize.ToString();
        	txtPathTableLocation.Text = pvd.PathTableLocation.ToString();
        	txtVolumeSetIdentifier.Text = pvd.VolumeSetIdentifier;
        	txtVolumeCreationDate.Text = pvd.VolumeCreationDate.ToString();
            //Root direction info
            txtDRLength.Text = pvd.RootDirectoryRecord.Length.ToString();
            txtARLength.Text = pvd.RootDirectoryRecord.AttributeLength.ToString();
            txtExtentLocation.Text = pvd.RootDirectoryRecord.ExtentLocation.ToString();
            txtDataLength.Text = pvd.RootDirectoryRecord.DataLength.ToString();
            txtRecordingDate.Text = pvd.RootDirectoryRecord.RecordingDate.ToString();
            txtFileFlags.Text = pvd.RootDirectoryRecord.Flags.ToString();
            txtFileUnitSize.Text = pvd.RootDirectoryRecord.FileUnitSize.ToString();
            txtInterleaveGapSize.Text = pvd.RootDirectoryRecord.InterleaveGapSize.ToString();
            txtVolumeSequenceNumber.Text = pvd.RootDirectoryRecord.VolumeSequenceNumber.ToString();
            txtFileIdentifierLength.Text = pvd.RootDirectoryRecord.FileIdentifierLength.ToString();
        }
        
        private void RefreshSectorInfo()
        {
            txtMinute.Text = discimg[sectorPos].Minute.ToString();
            txtSecond.Text = discimg[sectorPos].Second.ToString();
            txtBlock.Text = discimg[sectorPos].Block.ToString();
            txtMode.Text = discimg[sectorPos].Mode.ToString();
            txtSubHeader0.Text = discimg[sectorPos].SubHeader1.ToString();
            txtSubHeader1.Text = discimg[sectorPos].SubHeader2.ToString();
            lblSectorPos.Text = (sectorPos).ToString();
            lblNbSectors.Text = (discimg.NbSectors -1).ToString();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (sectorPos <= 0)
                sectorPos = discimg.NbSectors-1;
            else
                sectorPos--;
            RefreshSectorInfo();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (sectorPos >= discimg.NbSectors-1)
                sectorPos = 0;
            else
                sectorPos++;
            RefreshSectorInfo();
        }
        
		void OpenToolStripMenuItemClick(object sender, EventArgs e)
		{
            if(openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                discimg = new ISO9660.Image(openFileDialog1.FileName);
                pvd = discimg.ReadPVD();
                RefreshPVDInfo();
                sectorPos = 0;
                RefreshSectorInfo();
            }	
		}
    }
}
