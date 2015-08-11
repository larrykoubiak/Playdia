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
        private XASectorForm1[] sectors;
        private int intNbSectors;
        private FileStream fs;

        public Image()
        {
            sectors = new XASectorForm1[0];
            intNbSectors = 0;
            fs = null;
        }
        public Image(string path)
        {
            ReadFile(path);
        }

        public XASectorForm1[] Sectors
        {
            get { return sectors; }
        }

        public int NbSectors
        {
            get { return intNbSectors; }
        }

        public void ReadFile(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open);
            byte[] buffer = new byte[2352];
            intNbSectors = (int)(fs.Length / 2352);
            sectors = new XASectorForm1[intNbSectors];
            for(int pos=0;pos<intNbSectors;pos++)
            {
                sectors[pos] = new XASectorForm1();
                fs.Read(buffer,0, 2352);
                sectors[pos].ReadBytes(buffer);
            }
            fs.Close();
        }
    }
}
