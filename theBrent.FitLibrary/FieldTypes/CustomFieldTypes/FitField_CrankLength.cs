using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theBrent.FitLibrary.FieldTypes.CustomFieldTypes
{
    public class FitField_CrankLength : FitField_UInt8
    {
        private const int SCALE = 2;
        private const int OFFSET = -110;

        public FitField_CrankLength(byte[] fieldData) : base(fieldData)
        {
        }

        public int? Millimeters
        {
            get { return (base.Value / SCALE) - OFFSET; }
        }
    }
}
