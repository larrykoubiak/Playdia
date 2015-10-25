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

        public Image()
        {
            fs = null;
            intNbSectors = 0;
        }

        public Image(string path)
        {
            fs = new FileStream(path, FileMode.Open);
            intNbSectors = (int)(fs.Length / 2352);
        }

        ~Image()
        {
            if (fs != null)
            {
                fs.Close();
            }
        }

        public XASectorForm1 this[int index]
        {
            get { return ReadSector(index); }
        }

        public int NbSectors
        {
            get { return intNbSectors; }
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

        public PrimaryVolumeDescriptor ReadPVD()
        {
            XASectorForm1 sector = ReadSector(16);
            PrimaryVolumeDescriptor pvd = new PrimaryVolumeDescriptor();
            pvd.ReadByte(sector.Data);
            return pvd;
        }
    }
}
