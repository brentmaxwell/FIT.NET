using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theBrent.FitLibrary.FieldTypes
{
    public class FitField_TimerTrigger : FitField_Enum
    {
        public new TimerTrigger? Value
        {
            get { return (TimerTrigger?)base.Value; }
        }

        public FitField_TimerTrigger(byte[] fieldData) : base(fieldData) { }
    }

    /// <summary>
    /// timer event data
    /// </summary>
    public enum TimerTrigger
    {
        Manual = 0,
        Auto = 1,
        FitnessEquipment = 2
    }
}
