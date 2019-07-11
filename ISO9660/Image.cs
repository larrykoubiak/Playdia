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
        private FileStream fs;
        private List<VolumeDescriptor> volumeDescriptors;

        public Image()
        {
            fs = null;
            intNbSectors = 0;
            volumeDescriptors = new List<VolumeDescriptor>();
        }

        public Image(string path) : this()
        {
            fs = new FileStream(path, FileMode.Open);
            intNbSectors = (int)(fs.Length / 2352);
            readVolumeDescriptors();
            fs.Close();
        }

        public XASectorForm1 this[int index]
        {
            get { return ReadSector(index); }
        }

        public int NbSectors
        {
            get { return intNbSectors; }
        }

        public List<VolumeDescriptor> VolumeDescriptors
        {
            get { return volumeDescriptors; }
        }

        private XASectorForm1 ReadSector(int index)
        {
            byte[] buffer = new byte[2352];
            XASectorForm1 sector = new XASectorForm1();
            fs.Seek(index * 2352, SeekOrigin.Begin);
            fs.Read(buffer, 0, 2352);
            sector.ReadBytes(buffer);
            return sector;
        }

        private void readVolumeDescriptors()
        {
            XASectorForm1 sector;
            VolumeDescriptor vd;
            int sectorId = 16;
            sector = ReadSector(sectorId);
            vd = new VolumeDescriptor(sector.Data);
            while(vd.VolumeDescriptorType!= SectorType.VolumeDescriptionSetTerminator)
            {
                switch(vd.VolumeDescriptorType)
                {
                    case SectorType.PrimaryVolumeDescriptor:
                        PrimaryVolumeDescriptor pvd = new PrimaryVolumeDescriptor(sector.Data);
                        volumeDescriptors.Add(pvd);
                        break;
                    default:
                        break;
                }
                sectorId++;
                sector = ReadSector(sectorId);
                vd = new VolumeDescriptor(sector.Data);
            }
            volumeDescriptors.Add(vd);
        }
    }
}
