using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ISO9660
{
    class ImageStream : Stream
    {
        private FileStream _stream;

        public ImageStream(string path, FileMode mode)
        {
            _stream = new FileStream(path,mode);
        }
        public override bool CanRead
        {
            get { return _stream.CanRead; }
        }
        public override bool CanSeek
        {
            get { return _stream.CanSeek; }
        }
        public override bool CanWrite
        {
            get { return _stream.CanWrite; }
        }
        public override void Flush()
        {
            _stream.Flush();
        }
        public override long Length
        {
            get { return _stream.Length; }
        }
        public override long Position
        {
            get
            {
                return _stream.Position ;
            }
            set
            {
                _stream.Position = value;
            }
        }
        public override int Read(byte[] buffer, int offset, int count)
        {
            return _stream.Read(buffer,offset,count);
        }
        public override long Seek(long offset, SeekOrigin origin)
        {
            return _stream.Seek(offset, origin);
        }
        public override void SetLength(long value)
        {
            _stream.SetLength(value);
        }
        public override void Write(byte[] buffer, int offset, int count)
        {
            _stream.Write(buffer,offset,count);
        }
    }
}
