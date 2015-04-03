using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theBrent.FitLibrary.FieldTypes
{
    public class FitField_WorkoutStepTarget : FitField_Enum
    {
        public new WorkoutStepTarget? Value
        {
            get { return (WorkoutStepTarget?)base.Value; }
        }

        public FitField_WorkoutStepTarget(byte[] fieldData) : base(fieldData) { }
    }

    public enum WorkoutStepTarget
    {
        Speed = 0, 
        HeartRate = 1, 
        Open = 2, 
        Cadence = 3, 
        Power = 4, 
        Grade = 5, 
        Resistance = 6, 

        INVALID = 255
    }
}
