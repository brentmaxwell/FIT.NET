using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theBrent.FitLibrary.FieldTypes
{
    public class FitField_WorkoutStepDuration : FitField_Enum
    {
        public new WorkoutStepDuration? Value
        {
            get { return (WorkoutStepDuration?)base.Value; }
        }

        public FitField_WorkoutStepDuration(byte[] fieldData) : base(fieldData) { }
    }

    public enum WorkoutStepDuration
    {
        Time = 0, 
        Distance = 1, 
        HrLessThan = 2, 
        HrGreaterThan = 3, 
        Calories = 4, 
        Open = 5, 
        RepeatUntilStepsCmplt = 6, 
        RepeatUntilTime = 7, 
        RepeatUntilDistance = 8, 
        RepeatUntilCalories = 9, 
        RepeatUntilHrLessThan = 10, 
        RepeatUntilHrGreaterThan = 11, 
        RepeatUntilPowerLessThan = 12, 
        RepeatUntilPowerGreaterThan = 13, 
        PowerLessThan = 14, 
        PowerGreaterThan = 15, 
        RepetitionTime = 28, 

        INVALID = 255
    }
}
