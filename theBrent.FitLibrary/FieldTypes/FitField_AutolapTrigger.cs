using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theBrent.FitLibrary.FieldTypes
{
    public class FitField_AutolapTrigger : FitField_Enum
    {
        public new AutolapTrigger? Value
        {
            get { return (AutolapTrigger?)base.Value; }
        }

        public FitField_AutolapTrigger(byte[] fieldData) : base(fieldData) { }
    }

    public enum AutolapTrigger
    {
        Time = 0,
        Distance = 1,
        PositionStart = 2,
        PositionLap = 3,
        PositionWaypoint = 4,
        PositionMarked = 5,
        Off = 6
    }
}
