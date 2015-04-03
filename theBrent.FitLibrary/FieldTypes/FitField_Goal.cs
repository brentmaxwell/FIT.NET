using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theBrent.FitLibrary.FieldTypes
{
    public class FitField_Goal : FitField_Enum
    {
        public new Goal? Value
        {
            get { return (Goal?)base.Value; }
        }

        public FitField_Goal(byte[] fieldData) : base(fieldData) { }
    }

    public enum Goal
    {
        Time = 0,
        Distance = 1,
        Calories = 2,
        Frequency = 3,
        Steps = 4,

        INVALID = 255
    }
}
