using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theBrent.FitLibrary.FieldTypes.CustomFieldTypes
{
    public class FitField_Percentage : FitField_UInt16
    {
        private const int SCALE = 10;

        public FitField_Percentage(byte[] fieldData) : base(fieldData)
        {
        }

        public float? Percent
        {
            get { return base.Value / SCALE; }
        }
    }
}
