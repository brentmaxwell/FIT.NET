using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theBrent.FitLibrary.FieldTypes
{
    public class FitField_DisplayPower : FitField_Enum
    {
        public new DisplayPower? Value
        {
            get { return (DisplayPower?)base.Value; }
        }

        public FitField_DisplayPower(byte[] fieldData) : base(fieldData) { }
    }

    public enum DisplayPower
    {
        Watts = 0,
        PercentFTP = 1
    }
}
