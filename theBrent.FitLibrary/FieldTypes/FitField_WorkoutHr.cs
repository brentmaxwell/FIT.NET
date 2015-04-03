using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theBrent.FitLibrary.FieldTypes
{
    public class FitField_WorkoutHr : FitField_UInt32
    {
        /// <summary>
        /// 0 - 100 indicates% of maz hr; >100 indicates bpm (255 max) plus 100
        /// </summary>
        public const UInt32 BPM_OFFSET = 100;

        public WorkoutHr? ValueType
        {
            get { return this.Value > BPM_OFFSET ? WorkoutHr.Bpm : WorkoutHr.PercentMax; }
        }
        public new uint? Value
        {
            get { return base.Value > BPM_OFFSET ? base.Value - BPM_OFFSET : base.Value; }
        }

        public FitField_WorkoutHr(byte[] fieldData) : base(fieldData) { }
    }

    public enum WorkoutHr
    {
        PercentMax = 0,
        Bpm = 100
    }
}
