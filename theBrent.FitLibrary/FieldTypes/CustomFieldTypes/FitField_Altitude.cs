using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theBrent.FitLibrary.FieldTypes.CustomFieldTypes
{
    public class FitField_Altitude : FitField_UInt16
    {
        private const int SCALE = 5;
        private const int OFFSET = 500;

        public FitField_Altitude(byte[] fieldData)
            : base(fieldData)
        {
        }

        public float? Value
        {
            get { return base.Value.HasValue ? ((float)base.Value / SCALE)  - OFFSET : (float?)null; }
        }
    }
}
