using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace ISO9660
{
    class ImageStream : Stream
    {
        private List<FileStream> _streams;
        private List<SectorHeader> _sectors;
        private long position;

        public ImageStream(string path, FileMode mode)
        {
            _streams = new List<FileStream>();
            _sectors = new List<SectorHeader>();
            if (path.EndsWith(".cue"))
            {
                string directory = Path.GetDirectoryName(path);
                string strCueSheet = File.ReadAllText(path);
                Regex rgx = new Regex(@"FILE ""(.*)"" BINARY\r\n\s+TRACK (\d+) MODE(\d)\/(\d+)\r\n\s+INDEX (\d+) (?:(\d+):(\d+):(\d+))", RegexOptions.Multiline);
                MatchCollection matches = rgx.Matches(strCueSheet);
                foreach (Match m in matches)
                {
                    _streams.Add(new FileStream(Path.Combine(directory,m.Groups[1].Value), mode));
                }
                ReadSectors();
            }
        }
        public override bool CanRead
        {
            get
            {
                bool canread = true;
                foreach (FileStream fs in _streams)
                {
                    if (!fs.CanRead)
                        canread = false;
                }
                return canread;
            }
        }
        public override bool CanSeek
        {
            get
            {
                bool canseek = true;
                foreach (FileStream fs in _streams)
                {
                    if (!fs.CanSeek)
                        canseek = false;
                }
                return canseek;
            }
        }
        public override bool CanWrite
        {
            get { return false; }
        }
        public override void Flush()
        {
            foreach (FileStream fs in _streams)
            {
                fs.Flush();
            }
        }
        public override long Length
        {
            get
            {
                long length = 0;
                foreach (FileStream fs in _streams)
                {
                    length += fs.Length;
                }
                return length;
            }
        }
        public override long Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }
        public override int Read(byte[] buffer, int LBAOffset, int count)
        {
            int bytesread = 0;
            int lba = LBAOffset;
            while(bytesread < count)
            {
                byte[] data;
                int datalength;
                if (_sectors[lba].SectorType == SectorType.XAForm1)
                    data = ReadXA1Sector(lba).Data;
                else if (_sectors[lba].SectorType == SectorType.XAForm2)
                    data = ReadXA2Sector(lba).Data;
                else
                    data = null;
                datalength = data.Length;
                if((count - bytesread) > datalength)
                {
                    Array.Copy(data, 0, buffer, bytesread, datalength);
                    bytesread += datalength;
                    lba++;
                }
                else
                {
                    Array.Copy(data, 0, buffer, bytesread, (count-bytesread));
                }
            }
            return bytesread;
        }
        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotImplementedException();
        }
        public override void SetLength(long value)
        {
            throw new NotImplementedException();
        }
        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotImplementedException();
        }

        private void ReadSectors()
        {
            int filestreamid;
            for(filestreamid=0; filestreamid < _streams.Count; filestreamid++)
            {
                FileStream fs = _streams[filestreamid];
                long index = 0;
                while (index < fs.Length)
                {
                    byte[] buffer = new byte[24];
                    fs.Seek(index, SeekOrigin.Begin);
                    fs.Read(buffer, 0, 24);
                    SectorHeader sector = new SectorHeader(buffer, filestreamid, index, SectorType.XAForm1);
                    _sectors.Add(sector);
                    index += 2352;
                }
            }            
        }

        public XASectorForm1 ReadXA1Sector(int LBAIndex)
        {
            byte[] buffer = new byte[2352];
            SectorHeader header = _sectors[LBAIndex];
            XASectorForm1 sector = new XASectorForm1();
            FileStream fs = _streams[header.FileStreamId];
            fs.Seek(header.FileStreamOffset, SeekOrigin.Begin);
            fs.Read(buffer, 0, 2352);
            sector.ReadBytes(buffer);
            return sector;
        }

        public XASectorForm2 ReadXA2Sector(int LBAIndex)
        {
            byte[] buffer = new byte[2352];
            SectorHeader header = _sectors[LBAIndex];
            XASectorForm2 sector = new XASectorForm2();
            FileStream fs = _streams[header.FileStreamId];
            fs.Seek(header.FileStreamOffset, SeekOrigin.Begin);
            fs.Read(buffer, 0, 2352);
            sector.ReadBytes(buffer);
            return sector;
        }
    }
}
