using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theBrent.FitLibrary.FieldTypes
{
    public class FitField_ActivityLevel : FitField_Enum
    {
        public new ActivityLevel? Value
        {
            get { return (ActivityLevel?)base.Value; }
        }

        public FitField_ActivityLevel(byte[] fieldData) : base(fieldData) { }
    }

    public enum ActivityLevel
    {
        Low = 0,
        Medium = 1,
        High = 2
    }
}
