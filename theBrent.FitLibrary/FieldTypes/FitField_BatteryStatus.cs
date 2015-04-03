using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theBrent.FitLibrary.FieldTypes
{
    public class FitField_BatteryStatus : FitField_UInt8
    {
        public new BatteryStatus? Value
        {
            get { return (BatteryStatus?)base.Value; }
        }

        public FitField_BatteryStatus(byte[] fieldData) : base(fieldData) { }
    }

    public enum BatteryStatus
    {
        New = 1,
        Good = 2,
        Ok = 3,
        Low = 4,
        Critical = 5
    }
}
