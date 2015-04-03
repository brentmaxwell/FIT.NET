using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theBrent.FitLibrary.FieldTypes
{
    public class FitField_CourseCapabilities : FitField_UInt32z
    {
        public new CourseCapabilities? Value
        {
            get { return (CourseCapabilities?)base.Value; }
        }

        public FitField_CourseCapabilities(byte[] fieldData) : base(fieldData) { }
    }

    public enum CourseCapabilities
    {
        Processed = 0x00000001,
        Valid = 0x00000002,
        Time = 0x00000004,
        Distance = 0x00000008,
        Position = 0x00000010,
        HeartRate = 0x00000020,
        Power = 0x00000040,
        Cadence = 0x00000080,
        Training = 0x00000100,
        Navigation = 0x00000200

    }
}
