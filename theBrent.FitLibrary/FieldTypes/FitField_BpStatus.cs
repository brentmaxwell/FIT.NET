using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theBrent.FitLibrary.FieldTypes
{
    public class FitField_BpStatus : FitField_Enum
    {
        public new BpStatus? Value
        {
            get { return (BpStatus?)base.Value; }
        }

        public FitField_BpStatus(byte[] fieldData) : base(fieldData) { }
    }

    public enum BpStatus
    {
        NO_ERROR = 0,
        ERROR_INCOMPLETE_DATA = 1,
        ERROR_NO_MEASUREMENT = 2,
        ERROR_DATA_OUT_OF_RANGE = 3,
        ERROR_IRREGULAR_HEART_RATE = 4,
        INVALID = 255
    }
}
