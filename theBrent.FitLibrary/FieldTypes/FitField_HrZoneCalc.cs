using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theBrent.FitLibrary.FieldTypes
{
    public class FitField_HrZoneCalc : FitField_Enum
    {
        public new HrZoneCalc? Value
        {
            get { return (HrZoneCalc?)base.Value; }
        }

        public FitField_HrZoneCalc(byte[] fieldData) : base(fieldData) { }
    }

    public enum HrZoneCalc
    {
        Custom = 0,
        PercentMaxHr = 1,
        PercentHrr = 2
    }
}
