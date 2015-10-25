/*
 * Created by SharpDevelop.
 * User: I36107
 * Date: 20/10/2015
 * Time: 13:07
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Playdia
{
    partial class frmReader
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lblSectorPos = new System.Windows.Forms.Label();
            this.lblNbSectors = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSubHeader1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSubHeader0 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBlock = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSecond = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMinute = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label26 = new System.Windows.Forms.Label();
            this.txtFileFlags = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.txtRecordingDate = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.txtDataLength = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtExtentLocation = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtARLength = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtDRLength = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtVolumeCreationDate = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtVolumeSetIdentifier = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtPathTableLocation = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtPathTableSize = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtLogicalBlockSize = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtVolumeSet = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtVolumeSequence = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtVolumeSpace = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtVolumeIdentifier = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSystemIdentifier = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtVDVersion = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtStandardIdentifier = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtVDType = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label27 = new System.Windows.Forms.Label();
            this.txtFileUnitSize = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.txtInterleaveGapSize = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.txtVolumeSequenceNumber = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.txtFileIdentifierLength = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // lblSectorPos
            // 
            this.lblSectorPos.AutoSize = true;
            this.lblSectorPos.Location = new System.Drawing.Point(42, 370);
            this.lblSectorPos.Name = "lblSectorPos";
            this.lblSectorPos.Size = new System.Drawing.Size(0, 13);
            this.lblSectorPos.TabIndex = 15;
            // 
            // lblNbSectors
            // 
            this.lblNbSectors.AutoSize = true;
            this.lblNbSectors.Location = new System.Drawing.Point(106, 370);
            this.lblNbSectors.Name = "lblNbSectors";
            this.lblNbSectors.Size = new System.Drawing.Size(0, 13);
            this.lblNbSectors.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(84, 370);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(12, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "/";
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(12, 364);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(21, 24);
            this.btnPrev.TabIndex = 18;
            this.btnPrev.Text = "<";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(152, 364);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(21, 24);
            this.btnNext.TabIndex = 19;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtSubHeader1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtSubHeader0);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtMode);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtBlock);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtSecond);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtMinute);
            this.groupBox1.Location = new System.Drawing.Point(12, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(435, 79);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sector Info";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(216, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Sub Header 1";
            // 
            // txtSubHeader1
            // 
            this.txtSubHeader1.Location = new System.Drawing.Point(295, 45);
            this.txtSubHeader1.Name = "txtSubHeader1";
            this.txtSubHeader1.Size = new System.Drawing.Size(131, 20);
            this.txtSubHeader1.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Sub Header 0";
            // 
            // txtSubHeader0
            // 
            this.txtSubHeader0.Location = new System.Drawing.Point(86, 45);
            this.txtSubHeader0.Name = "txtSubHeader0";
            this.txtSubHeader0.Size = new System.Drawing.Size(124, 20);
            this.txtSubHeader0.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(342, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Mode";
            // 
            // txtMode
            // 
            this.txtMode.Location = new System.Drawing.Point(392, 19);
            this.txtMode.Name = "txtMode";
            this.txtMode.Size = new System.Drawing.Size(34, 20);
            this.txtMode.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(245, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Block";
            // 
            // txtBlock
            // 
            this.txtBlock.Location = new System.Drawing.Point(295, 20);
            this.txtBlock.Name = "txtBlock";
            this.txtBlock.Size = new System.Drawing.Size(34, 20);
            this.txtBlock.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(126, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Second";
            // 
            // txtSecond
            // 
            this.txtSecond.Location = new System.Drawing.Point(176, 20);
            this.txtSecond.Name = "txtSecond";
            this.txtSecond.Size = new System.Drawing.Size(34, 20);
            this.txtSecond.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Minute";
            // 
            // txtMinute
            // 
            this.txtMinute.Location = new System.Drawing.Point(86, 19);
            this.txtMinute.Name = "txtMinute";
            this.txtMinute.Size = new System.Drawing.Size(34, 20);
            this.txtMinute.TabIndex = 13;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.txtVolumeCreationDate);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.txtVolumeSetIdentifier);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.txtPathTableLocation);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.txtPathTableSize);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.txtLogicalBlockSize);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.txtVolumeSet);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.txtVolumeSequence);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txtVolumeSpace);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtVolumeIdentifier);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtSystemIdentifier);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtVDVersion);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtStandardIdentifier);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtVDType);
            this.groupBox2.Location = new System.Drawing.Point(12, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(567, 240);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Primary Volume Descriptor";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label30);
            this.groupBox3.Controls.Add(this.txtFileIdentifierLength);
            this.groupBox3.Controls.Add(this.label29);
            this.groupBox3.Controls.Add(this.txtVolumeSequenceNumber);
            this.groupBox3.Controls.Add(this.label28);
            this.groupBox3.Controls.Add(this.txtInterleaveGapSize);
            this.groupBox3.Controls.Add(this.label27);
            this.groupBox3.Controls.Add(this.txtFileUnitSize);
            this.groupBox3.Controls.Add(this.label26);
            this.groupBox3.Controls.Add(this.txtFileFlags);
            this.groupBox3.Controls.Add(this.label25);
            this.groupBox3.Controls.Add(this.txtRecordingDate);
            this.groupBox3.Controls.Add(this.label24);
            this.groupBox3.Controls.Add(this.txtDataLength);
            this.groupBox3.Controls.Add(this.label23);
            this.groupBox3.Controls.Add(this.txtExtentLocation);
            this.groupBox3.Controls.Add(this.label22);
            this.groupBox3.Controls.Add(this.txtARLength);
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Controls.Add(this.txtDRLength);
            this.groupBox3.Location = new System.Drawing.Point(10, 128);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(543, 106);
            this.groupBox3.TabIndex = 40;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Root Directory";
            // 
            // label26
            // 
            this.label26.Location = new System.Drawing.Point(246, 51);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(38, 14);
            this.label26.TabIndex = 43;
            this.label26.Text = "Flags";
            // 
            // txtFileFlags
            // 
            this.txtFileFlags.Location = new System.Drawing.Point(290, 48);
            this.txtFileFlags.Name = "txtFileFlags";
            this.txtFileFlags.Size = new System.Drawing.Size(242, 20);
            this.txtFileFlags.TabIndex = 42;
            // 
            // label25
            // 
            this.label25.Location = new System.Drawing.Point(4, 48);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(82, 17);
            this.label25.TabIndex = 41;
            this.label25.Text = "Recording Date";
            // 
            // txtRecordingDate
            // 
            this.txtRecordingDate.Location = new System.Drawing.Point(95, 48);
            this.txtRecordingDate.Name = "txtRecordingDate";
            this.txtRecordingDate.Size = new System.Drawing.Size(142, 20);
            this.txtRecordingDate.TabIndex = 40;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(393, 22);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(66, 13);
            this.label24.TabIndex = 7;
            this.label24.Text = "Data Length";
            // 
            // txtDataLength
            // 
            this.txtDataLength.Location = new System.Drawing.Point(465, 19);
            this.txtDataLength.Name = "txtDataLength";
            this.txtDataLength.Size = new System.Drawing.Size(67, 20);
            this.txtDataLength.TabIndex = 6;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(243, 22);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(81, 13);
            this.label23.TabIndex = 5;
            this.label23.Text = "Extent Location";
            // 
            // txtExtentLocation
            // 
            this.txtExtentLocation.Location = new System.Drawing.Point(330, 19);
            this.txtExtentLocation.Name = "txtExtentLocation";
            this.txtExtentLocation.Size = new System.Drawing.Size(61, 20);
            this.txtExtentLocation.TabIndex = 4;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(127, 22);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(58, 13);
            this.label22.TabIndex = 3;
            this.label22.Text = "AR Length";
            // 
            // txtARLength
            // 
            this.txtARLength.Location = new System.Drawing.Point(192, 19);
            this.txtARLength.Name = "txtARLength";
            this.txtARLength.Size = new System.Drawing.Size(45, 20);
            this.txtARLength.TabIndex = 2;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(6, 22);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(59, 13);
            this.label21.TabIndex = 1;
            this.label21.Text = "DR Length";
            // 
            // txtDRLength
            // 
            this.txtDRLength.Location = new System.Drawing.Point(71, 19);
            this.txtDRLength.Name = "txtDRLength";
            this.txtDRLength.Size = new System.Drawing.Size(45, 20);
            this.txtDRLength.TabIndex = 0;
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(262, 100);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(113, 17);
            this.label20.TabIndex = 39;
            this.label20.Text = "Volume Creation Date";
            // 
            // txtVolumeCreationDate
            // 
            this.txtVolumeCreationDate.Location = new System.Drawing.Point(381, 97);
            this.txtVolumeCreationDate.Name = "txtVolumeCreationDate";
            this.txtVolumeCreationDate.Size = new System.Drawing.Size(161, 20);
            this.txtVolumeCreationDate.TabIndex = 38;
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(7, 100);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(113, 17);
            this.label19.TabIndex = 37;
            this.label19.Text = "Volume Set  Identifier";
            // 
            // txtVolumeSetIdentifier
            // 
            this.txtVolumeSetIdentifier.Location = new System.Drawing.Point(126, 97);
            this.txtVolumeSetIdentifier.Name = "txtVolumeSetIdentifier";
            this.txtVolumeSetIdentifier.Size = new System.Drawing.Size(121, 20);
            this.txtVolumeSetIdentifier.TabIndex = 36;
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(338, 74);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(112, 17);
            this.label18.TabIndex = 35;
            this.label18.Text = "Path Table Location";
            // 
            // txtPathTableLocation
            // 
            this.txtPathTableLocation.Location = new System.Drawing.Point(456, 71);
            this.txtPathTableLocation.Name = "txtPathTableLocation";
            this.txtPathTableLocation.Size = new System.Drawing.Size(86, 20);
            this.txtPathTableLocation.TabIndex = 34;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(176, 74);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(86, 17);
            this.label17.TabIndex = 33;
            this.label17.Text = "Path Table Size";
            // 
            // txtPathTableSize
            // 
            this.txtPathTableSize.Location = new System.Drawing.Point(277, 71);
            this.txtPathTableSize.Name = "txtPathTableSize";
            this.txtPathTableSize.Size = new System.Drawing.Size(55, 20);
            this.txtPathTableSize.TabIndex = 32;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(7, 74);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(100, 17);
            this.label16.TabIndex = 31;
            this.label16.Text = "Logical Block Size";
            // 
            // txtLogicalBlockSize
            // 
            this.txtLogicalBlockSize.Location = new System.Drawing.Point(113, 71);
            this.txtLogicalBlockSize.Name = "txtLogicalBlockSize";
            this.txtLogicalBlockSize.Size = new System.Drawing.Size(57, 20);
            this.txtLogicalBlockSize.TabIndex = 30;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(401, 48);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(77, 17);
            this.label15.TabIndex = 29;
            this.label15.Text = "Volume# / Set";
            // 
            // txtVolumeSet
            // 
            this.txtVolumeSet.Location = new System.Drawing.Point(524, 45);
            this.txtVolumeSet.Name = "txtVolumeSet";
            this.txtVolumeSet.Size = new System.Drawing.Size(18, 20);
            this.txtVolumeSet.TabIndex = 28;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(508, 48);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(12, 13);
            this.label14.TabIndex = 27;
            this.label14.Text = "/";
            // 
            // txtVolumeSequence
            // 
            this.txtVolumeSequence.Location = new System.Drawing.Point(484, 45);
            this.txtVolumeSequence.Name = "txtVolumeSequence";
            this.txtVolumeSequence.Size = new System.Drawing.Size(18, 20);
            this.txtVolumeSequence.TabIndex = 26;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(401, 22);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 17);
            this.label13.TabIndex = 25;
            this.label13.Text = "Volume Space";
            // 
            // txtVolumeSpace
            // 
            this.txtVolumeSpace.Location = new System.Drawing.Point(484, 19);
            this.txtVolumeSpace.Name = "txtVolumeSpace";
            this.txtVolumeSpace.Size = new System.Drawing.Size(58, 20);
            this.txtVolumeSpace.TabIndex = 24;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(205, 48);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 17);
            this.label12.TabIndex = 23;
            this.label12.Text = "Volume Identifier";
            // 
            // txtVolumeIdentifier
            // 
            this.txtVolumeIdentifier.Location = new System.Drawing.Point(300, 45);
            this.txtVolumeIdentifier.Name = "txtVolumeIdentifier";
            this.txtVolumeIdentifier.Size = new System.Drawing.Size(95, 20);
            this.txtVolumeIdentifier.TabIndex = 22;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(7, 48);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 17);
            this.label11.TabIndex = 21;
            this.label11.Text = "System Identifier";
            // 
            // txtSystemIdentifier
            // 
            this.txtSystemIdentifier.Location = new System.Drawing.Point(102, 45);
            this.txtSystemIdentifier.Name = "txtSystemIdentifier";
            this.txtSystemIdentifier.Size = new System.Drawing.Size(97, 20);
            this.txtSystemIdentifier.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(295, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "VD Version";
            // 
            // txtVDVersion
            // 
            this.txtVDVersion.Location = new System.Drawing.Point(361, 19);
            this.txtVDVersion.Name = "txtVDVersion";
            this.txtVDVersion.Size = new System.Drawing.Size(34, 20);
            this.txtVDVersion.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(102, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Standard Identifier";
            // 
            // txtStandardIdentifier
            // 
            this.txtStandardIdentifier.Location = new System.Drawing.Point(205, 19);
            this.txtStandardIdentifier.Name = "txtStandardIdentifier";
            this.txtStandardIdentifier.Size = new System.Drawing.Size(84, 20);
            this.txtStandardIdentifier.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "VD Type";
            // 
            // txtVDType
            // 
            this.txtVDType.Location = new System.Drawing.Point(62, 19);
            this.txtVDType.Name = "txtVDType";
            this.txtVDType.Size = new System.Drawing.Size(34, 20);
            this.txtVDType.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(587, 24);
            this.menuStrip1.TabIndex = 23;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItemClick);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(6, 77);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(68, 13);
            this.label27.TabIndex = 45;
            this.label27.Text = "File Unit Size";
            // 
            // txtFileUnitSize
            // 
            this.txtFileUnitSize.Location = new System.Drawing.Point(80, 74);
            this.txtFileUnitSize.Name = "txtFileUnitSize";
            this.txtFileUnitSize.Size = new System.Drawing.Size(45, 20);
            this.txtFileUnitSize.TabIndex = 44;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(132, 77);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(62, 13);
            this.label28.TabIndex = 47;
            this.label28.Text = "IL Gap Size";
            // 
            // txtInterleaveGapSize
            // 
            this.txtInterleaveGapSize.Location = new System.Drawing.Point(200, 74);
            this.txtInterleaveGapSize.Name = "txtInterleaveGapSize";
            this.txtInterleaveGapSize.Size = new System.Drawing.Size(45, 20);
            this.txtInterleaveGapSize.TabIndex = 46;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(252, 77);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(104, 13);
            this.label29.TabIndex = 49;
            this.label29.Text = "Volume Sequence #";
            // 
            // txtVolumeSequenceNumber
            // 
            this.txtVolumeSequenceNumber.Location = new System.Drawing.Point(362, 74);
            this.txtVolumeSequenceNumber.Name = "txtVolumeSequenceNumber";
            this.txtVolumeSequenceNumber.Size = new System.Drawing.Size(45, 20);
            this.txtVolumeSequenceNumber.TabIndex = 48;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(416, 77);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(52, 13);
            this.label30.TabIndex = 51;
            this.label30.Text = "FI Length";
            // 
            // txtFileIdentifierLength
            // 
            this.txtFileIdentifierLength.Location = new System.Drawing.Point(487, 74);
            this.txtFileIdentifierLength.Name = "txtFileIdentifierLength";
            this.txtFileIdentifierLength.Size = new System.Drawing.Size(45, 20);
            this.txtFileIdentifierLength.TabIndex = 50;
            // 
            // frmReader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 390);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblNbSectors);
            this.Controls.Add(this.lblSectorPos);
            this.Controls.Add(this.menuStrip1);
            this.Name = "frmReader";
            this.Text = "ISO Reader";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMinute;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSecond;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBlock;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSubHeader0;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSubHeader1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label lblSectorPos;
        private System.Windows.Forms.Label lblNbSectors;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtStandardIdentifier;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtVDType;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtVDVersion;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtSystemIdentifier;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtVolumeIdentifier;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtVolumeSpace;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtVolumeSet;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtVolumeSequence;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtPathTableSize;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtLogicalBlockSize;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtPathTableLocation;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtVolumeSetIdentifier;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtVolumeCreationDate;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtDataLength;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtExtentLocation;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtARLength;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtDRLength;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtRecordingDate;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txtFileFlags;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox txtFileIdentifierLength;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox txtVolumeSequenceNumber;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox txtInterleaveGapSize;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox txtFileUnitSize;
    }
}
