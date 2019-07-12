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
    public partial class DirectoryRecordControl : UserControl
    {
        DirectoryRecord dr;
        public DirectoryRecordControl()
        {
            InitializeComponent();
        }
        public DirectoryRecordControl(DirectoryRecord record) : this()
        {
            dr = record;
            RefreshDRInfo();
        }
        public void RefreshDRInfo()
        {
            //Root direction info
            txtDRLength.Text = dr.Length.ToString();
            txtARLength.Text = dr.AttributeLength.ToString();
            txtExtentLocation.Text = dr.ExtentLocation.ToString();
            txtDataLength.Text = dr.DataLength.ToString();
            txtRecordingDate.Text = dr.RecordingDate.ToString();
            txtFileFlags.Text = dr.Flags.ToString();
            txtFileUnitSize.Text = dr.FileUnitSize.ToString();
            txtInterleaveGapSize.Text = dr.InterleaveGapSize.ToString();
            txtVolumeSequenceNumber.Text = dr.VolumeSequenceNumber.ToString();
            txtFileIdentifierLength.Text = dr.FileIdentifierLength.ToString();
            txtFileIdentifier.Text = dr.FileIdentifier;
        }
    }
}
