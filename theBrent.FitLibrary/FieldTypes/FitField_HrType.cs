using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theBrent.FitLibrary.FieldTypes
{
    public class FitField_HrType : FitField_Enum
    {
        public new HrType? Value
        {
            get { return (HrType?)base.Value; }
        }

        public FitField_HrType(byte[] fieldData) : base(fieldData) { }
    }

    public enum HrType
    {
        Normal = 0,
        Irregular = 1
    }
}
