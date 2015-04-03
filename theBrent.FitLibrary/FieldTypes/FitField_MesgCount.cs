using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theBrent.FitLibrary.FieldTypes
{
    public class FitField_MesgCount : FitField_Enum
    {
        public new MesgCount? Value
        {
            get { return (MesgCount?)base.Value; }
        }

        public FitField_MesgCount(byte[] fieldData) : base(fieldData) { }
    }

    public enum MesgCount
    {
        NumPerFile = 0,
        MaxPerFile = 1,
        MaxPerFileType = 2
    }
}
