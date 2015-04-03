using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theBrent.FitLibrary.FieldTypes
{
    public class FitField_LapTrigger : FitField_Enum
    {
        public new LapTrigger? Value
        {
            get { return (LapTrigger?)base.Value; }
        }

        public FitField_LapTrigger(byte[] fieldData) : base(fieldData) { }
    }

    public enum LapTrigger
    {
        Manual = 0,
        Time = 1,
        Distance = 2,
        PositionStart = 3,
        PositionLap = 4,
        PositionWaypoint = 5,
        PositionMarked = 6,
        SessionEnd = 7,
        FitnessEquipment = 8
    }
}
