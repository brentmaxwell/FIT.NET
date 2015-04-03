using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theBrent.FitLibrary.FieldTypes
{
    public class FitField_FileFlags : FitField_UInt8z
    {
        public new FileFlags? Value
        {
            get { return (FileFlags?)base.Value; }
        }

        public FitField_FileFlags(byte[] fieldData) : base(fieldData) { }
    }

    [Flags]
    public enum FileFlags
    {
        Read = 0x02,
        Write = 0x04,
        Erase = 0x08
    }
}
