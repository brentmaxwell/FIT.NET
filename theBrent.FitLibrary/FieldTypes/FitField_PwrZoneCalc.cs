using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theBrent.FitLibrary.FieldTypes
{
    public class FitField_PwrZoneCalc : FitField_Enum
    {
        public new PwrZoneCalc? Value
        {
            get { return (PwrZoneCalc?)base.Value; }
        }

        public FitField_PwrZoneCalc(byte[] fieldData) : base(fieldData) { }
    }

    public enum PwrZoneCalc
    {
        Custom = 0,
        PercentFtp = 1
    }
}
