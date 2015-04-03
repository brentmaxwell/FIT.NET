using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theBrent.FitLibrary.FieldTypes.CustomFieldTypes
{
    public class FitField_Distance : FitField_UInt32
    {
        private const int SCALE = 100;

        public FitField_Distance(byte[] fieldData) : base(fieldData)
        {
        }

        public float? Meters
        {
            get { return base.Value / SCALE; }
        }

        public uint? Centimeters
        {
            get { return base.Value; }
        }
    }
}
