using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theBrent.FitLibrary.FieldTypes
{
    public class FitField_ActivityClass : FitField_Enum
    {
        public new ActivityClass? Value
        {
            get { return (ActivityClass?)base.Value; }
        }

        public FitField_ActivityClass(byte[] fieldData) : base(fieldData) { }
    }

    public enum ActivityClass
    {
        Level = 0x7F,
        LevelMax = 100,
        Athlete = 0x80
    }
}
