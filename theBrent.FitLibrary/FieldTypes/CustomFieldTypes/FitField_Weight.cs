using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theBrent.FitLibrary.FieldTypes.CustomFieldTypes
{
    public class FitField_Weight : FitField_UInt16
    {
        private const int SCALE = 10;

        public FitField_Weight(byte[] fieldData) : base(fieldData)
        {
        }

        public float? Kilograms
        {
            get { return base.Value / SCALE; }
        }
    }
}
