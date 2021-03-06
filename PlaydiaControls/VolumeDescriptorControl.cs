﻿using System;
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
    public partial class VolumeDescriptorControl: UserControl
    {
        private VolumeDescriptor vd;
        public VolumeDescriptorControl()
        {
            InitializeComponent();
        }
        public VolumeDescriptorControl(VolumeDescriptor volumedescriptor) : this()
        {
            vd = volumedescriptor;
            RefreshPVDInfo();
        }
        private void RefreshPVDInfo()
        {
            txtVDType.Text = vd.VolumeDescriptorType.ToString();
            txtStandardIdentifier.Text = vd.StandardIdentifier;
            txtVDVersion.Text = vd.VolumeDescriptorVersion.ToString();
            if(vd.VolumeDescriptorType== VolumeDescriptorType.PrimaryVolumeDescriptor)
            {
                PrimaryVolumeDescriptor pvd = (PrimaryVolumeDescriptor)vd;
                gbPrimaryVolumeDescriptor.Visible = true;
                txtSystemIdentifier.Text = pvd.SystemIdentifier;
                txtVolumeIdentifier.Text = pvd.VolumeIdentifier;
                txtVolumeSpace.Text = pvd.VolumeSpaceSize.ToString();
                txtVolumeSequence.Text = pvd.VolumeSequenceNumber.ToString();
                txtVolumeSet.Text = pvd.VolumeSetSize.ToString();
                txtLogicalBlockSize.Text = pvd.LogicalBlockSize.ToString();
                txtPathTableSize.Text = pvd.PathTableSize.ToString();
                txtPathTableLocation.Text = pvd.PathTableLocation.ToString();
                txtVolumeSetIdentifier.Text = pvd.VolumeSetIdentifier;
                txtPublisherIdentifier.Text = pvd.PublisherIdentifier;
                txtDataPrepIdentifier.Text = pvd.DataPreparerIdentifier;
                txtApplicationIdentifier.Text = pvd.ApplicationIdentifier;
                txtCopyrightIdentifier.Text = pvd.CopyrightFileIdentifier;
                txtAbstractFileIdentifier.Text = pvd.AbstractFileIdentifier;
                txtBibliographicalIdentifier.Text = pvd.BibliographicFileIdentifier;
                txtVolumeCreationDate.Text = pvd.VolumeCreationDate.ToString();
                txtLastModificationDate.Text = pvd.VolumeModificationdDate.ToString();
                txtExpiryDate.Text = pvd.VolumeExpirationDate.ToString();
                txtEffectiveDate.Text = pvd.VolumeEffectiveDate.ToString();
            }
            else
            {
                gbPrimaryVolumeDescriptor.Visible = false;
            }
        }
    }
}
