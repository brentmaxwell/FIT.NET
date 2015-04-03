using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theBrent.FitLibrary.FieldTypes
{
    public class FitField_Gender : FitField_Enum
    {
        public new Gender? Value
        {
            get { return (Gender?)base.Value; }
        }

        public FitField_Gender(byte[] fieldData) : base(fieldData) { }
    }

    public enum Gender
    {
        Female = 0,
        Male = 1
    }
}
