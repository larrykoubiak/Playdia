using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ISO9660
{
    public class Image
    {
        private int intNbSectors;
        private ImageStream fs;
        private List<VolumeDescriptor> volumeDescriptors;
        private DirectoryRecord rootDirectory;

        public Image()
        {
            fs = null;
            intNbSectors = 0;
            volumeDescriptors = new List<VolumeDescriptor>();
        }

        public Image(string path) : this()
        {
            fs = new ImageStream(path, FileMode.Open);
            intNbSectors = (int)(fs.Length / 2352);
            readVolumeDescriptors();
            if(volumeDescriptors.Count > 1)
            {
                readDirectoryRecord((int)rootDirectory.ExtentLocation);
            }
            fs.Close();
        }

        public XASectorForm1 this[int index]
        {
            get { return fs.ReadXA1Sector(index); }
        }

        public int NbSectors
        {
            get { return intNbSectors; }
        }

        public List<VolumeDescriptor> VolumeDescriptors
        {
            get { return volumeDescriptors; }
        }

        public DirectoryRecord RootDirectory
        {
            get { return rootDirectory; }
        }


        private void readVolumeDescriptors()
        {
            XASectorForm1 sector;
            VolumeDescriptor vd;
            int sectorId = 16;
            sector = fs.ReadXA1Sector(sectorId);
            vd = new VolumeDescriptor(sector.Data);
            while(vd.VolumeDescriptorType!= VolumeDescriptorType.VolumeDescriptionSetTerminator && sectorId < intNbSectors)
            {
                if (vd.StandardIdentifier == "CD001") //valid volume descriptor
                {
                    switch (vd.VolumeDescriptorType)
                    {
                        case VolumeDescriptorType.PrimaryVolumeDescriptor:
                            PrimaryVolumeDescriptor pvd = new PrimaryVolumeDescriptor(sector.Data);
                            rootDirectory = pvd.RootDirectoryRecord;
                            volumeDescriptors.Add(pvd);
                            break;
                        default:
                            break;
                    }
                }
                sectorId++;
                sector = fs.ReadXA1Sector(sectorId);
                vd = new VolumeDescriptor(sector.Data);
            }
            if(vd.StandardIdentifier=="CD001") //valid volume descriptor
                volumeDescriptors.Add(vd);
        }

        private void readDirectoryRecord(int sectorId)
        {
            PrimaryVolumeDescriptor pvd = (PrimaryVolumeDescriptor)volumeDescriptors[0];
            XASectorForm1 sector = fs.ReadXA1Sector(sectorId);
            int offset = 0;
            while(sector.Data[offset] !=0)
            {
                int size = sector.Data[offset];
                byte[] data = new byte[size];
                Array.Copy(sector.Data, offset, data, 0, size);
                DirectoryRecord dr = new DirectoryRecord(data);
                if (dr.FileIdentifierLength > 1)
                    dr.FileIdentifier = Encoding.ASCII.GetString(data, 33, dr.FileIdentifierLength -2);
                else
                    switch(data[33])
                    {
                        case 0:
                            dr.FileIdentifier = ".";
                            break;
                        case 1:
                            dr.FileIdentifier = "..";
                            break;
                        default:
                            dr.FileIdentifier = "";
                            break;
                    }
                rootDirectory.Children.Add(dr);
                offset += size;
            }
        }

        public void ExtractDirectoryRecord(DirectoryRecord dr, string path)
        {
            int size = (int)dr.DataLength;
            byte[] buffer = new byte[size];
            fs.Read(buffer, (int)dr.ExtentLocation, size);
            FileStream ds = new FileStream(path, FileMode.Create);
            ds.Write(buffer, 0, size);
            ds.Close();
        }

        public string SectorStats()
        {
            Dictionary<string, int> stats = new Dictionary<string, int>();
            foreach (SectorHeader s in fs.Sectors)
            {
                string subheaderhex = s.SubHeader1.ToString("X8");
                if (stats.ContainsKey(subheaderhex))
                    stats[subheaderhex]++;
                else
                    stats.Add(subheaderhex, 1);
            }
            string message = "";
            foreach (KeyValuePair<string, int> stat in stats)
            {
                message += stat.Key + " : " + stat.Value.ToString() + "\r\n";
            }
            return message;
        }
        public void ExtractAudio(DirectoryRecord dr, string path)
        {
            int sectorId = (int)dr.ExtentLocation;
            int filecounter = 0;
            List<Int16> pcms = new List<Int16>();
            SectorHeader sh = fs.Sectors[sectorId];
            while ((sh.Submode & Submodes.EOF)==0)
            {
                if((sh.Submode & Submodes.Audio) > 0)
                {
                    XASectorForm2 s = fs.ReadXA2Sector(sectorId); 
                    for(int sg=0; sg<18; sg++)
                    {
                        byte[] data = new byte[128];
                        Array.Copy(s.Data, sg * 128, data, 0, 128);
                        ADPCMBlock block = new ADPCMBlock(data);
                        pcms.AddRange(block.getPCM());
                    }
                    if ((sh.Submode & Submodes.EOR) > 0)
                    {
                        FileStream f = new FileStream(Path.Combine(path, "track" + filecounter.ToString("00") + ".wav"), FileMode.Create);
                        BinaryWriter bw = new BinaryWriter(f);
                        bw.Write(Encoding.ASCII.GetBytes("RIFF"));  // "RIFF"
                        bw.Write((Int32)(pcms.Count * 2) + 44);                  // size of entire file with 16-bit data
                        bw.Write(Encoding.ASCII.GetBytes("WAVE"));  // "WAVE"
                                                                    // chunk 1:
                        bw.Write(Encoding.ASCII.GetBytes("fmt "));  // "fmt "
                        bw.Write((Int32)16);                        // size of chunk in bytes
                        bw.Write((Int16)1);                         // 1 - for PCM
                        bw.Write((Int16)1);                         // only Stereo files in this version
                        bw.Write((Int32)44100);          // sample rate per second (usually 44100)
                        bw.Write((Int32)(2 * 44100));    // bytes per second (usually 176400)
                        bw.Write((Int16)2);                         // data align 4 bytes (2 bytes sample stereo)
                        bw.Write((Int16)16);                        // only 16-bit in this version
                                                                    // chunk 2:
                        bw.Write(Encoding.ASCII.GetBytes("data"));  // "data"
                        bw.Write((Int32)(pcms.Count * 2));   // size of audio data 16-bit
                        foreach (Int16 pcm in pcms)
                        {
                            bw.Write(pcm);
                        }
                        bw.Flush();
                        bw.Close();
                        f.Close();
                        pcms = new List<Int16>();
                        filecounter++;
                    }
                }
                sectorId++;
                sh = fs.Sectors[sectorId];
            }
        }
    }
}
