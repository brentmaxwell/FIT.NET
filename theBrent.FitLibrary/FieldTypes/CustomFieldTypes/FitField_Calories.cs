using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theBrent.FitLibrary.FieldTypes.CustomFieldTypes
{
    public class FitField_Calories : FitField_UInt16
    {
        private const int SCALE = 10;

        public FitField_Calories(byte[] fieldData) : base(fieldData)
        {
        }

        public float? KCalPerMin
        {
            get { return base.Value / SCALE; }
        }
    }
}
