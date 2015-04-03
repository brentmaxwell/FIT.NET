using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theBrent.FitLibrary.FieldTypes.CustomFieldTypes
{
    public class FitField_Timer : FitField_UInt32
    {
        private const int SCALE = 1000;

        public FitField_Timer(byte[] fieldData) : base(fieldData)
        {
        }

        public float Seconds
        {
            get { return ((float)base.Value / SCALE); }
        }
    }
}
