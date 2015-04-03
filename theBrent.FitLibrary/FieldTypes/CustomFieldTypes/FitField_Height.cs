using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theBrent.FitLibrary.FieldTypes.CustomFieldTypes
{
    public class FitField_Height : FitField_UInt8
    {
        private const int SCALE = 100;

        public FitField_Height(byte[] fieldData) : base(fieldData)
        {
        }

        public float? Meters
        {
            get { return base.Value / SCALE; }
        }

        public byte? Centimeters
        {
            get { return base.Value; }
        }
    }
}
