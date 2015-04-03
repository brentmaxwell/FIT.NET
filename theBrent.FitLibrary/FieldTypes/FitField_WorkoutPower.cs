using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theBrent.FitLibrary.FieldTypes
{
    public class FitField_WorkoutPower : FitField_UInt32
    {
        /// <summary>
        /// 0 - 1000 indicates % of functional threshold power; >1000 indicates watts plus 1000.
        /// </summary>
        public const UInt32 WATTS_OFFSET = 1000;

        public WorkoutPower? ValueType
        {
            get { return (this.Value > WATTS_OFFSET) ? WorkoutPower.watts_offset : WorkoutPower.PercentFTP; }
        }
        public new uint? Value
        {
            get { return (base.Value > WATTS_OFFSET) ? base.Value - WATTS_OFFSET : base.Value; }
        }

        public FitField_WorkoutPower(byte[] fieldData) : base(fieldData) { }
    }

    public enum WorkoutPower
    {
        PercentFTP = 0,
        watts_offset = 1000
    }
}
