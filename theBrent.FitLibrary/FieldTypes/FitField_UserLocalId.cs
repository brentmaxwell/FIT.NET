using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theBrent.FitLibrary.FieldTypes
{
    public class FitField_UserLocalId : FitField_UInt16
    {
        public FitField_UserLocalId(byte[] fieldData) : base(fieldData) { }
    }

    public enum UserLocalId
    {
        LocalMin = 0x0001,
        LocalMax = 0x000F,
        StationaryMin = 0x0010,
        StationaryMax = 0x00FF,
        PortableMin = 0x0100,
        PortableMax = 0xFFFE
    }
}
