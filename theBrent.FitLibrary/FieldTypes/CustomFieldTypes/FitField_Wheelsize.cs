using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theBrent.FitLibrary.FieldTypes.CustomFieldTypes
{
    public class FitField_Wheelsize : FitField_UInt16
    {
        private const int SCALE = 1000;
        public float? Meters
        {
            get { return base.Value / SCALE; }
        }

        public float? Centimeters
        {
            get { return base.Value / (SCALE / 10); }
        }

        public ushort? Millimeters
        {
            get { return base.Value; }
        }

        public FitField_Wheelsize(byte[] fieldData) : base(fieldData) { }
    }
}
