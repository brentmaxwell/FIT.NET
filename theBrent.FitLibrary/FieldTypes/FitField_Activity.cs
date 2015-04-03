using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theBrent.FitLibrary.FieldTypes
{
    public class FitField_Activity : FitField_Enum
    {
        public new Activity? Value
        {
            get { return (Activity?)base.Value; }
        }

        public FitField_Activity(byte[] fieldData) : base(fieldData) { }
    }

    public enum Activity
    {
        manual = 0,
        auto_multi_sport = 1
    }
}
