using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theBrent.FitLibrary.FieldTypes
{
    public class FitField_Schedule : FitField_Enum
    {
        public new Schedule? Value
        {
            get { return (Schedule?)base.Value; }
        }

        public FitField_Schedule(byte[] fieldData) : base(fieldData) { }
    }

    public enum Schedule
    {
        Workout = 0,
        Course = 1
    }
}
