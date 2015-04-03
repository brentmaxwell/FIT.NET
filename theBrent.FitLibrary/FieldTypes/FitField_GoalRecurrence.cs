using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theBrent.FitLibrary.FieldTypes
{
    public class FitField_GoalRecurrence : FitField_Enum
    {
        public new GoalRecurrence? Value
        {
            get { return (GoalRecurrence?)base.Value; }
        }

        public FitField_GoalRecurrence(byte[] fieldData) : base(fieldData) { }
    }

    public enum GoalRecurrence
    {
        Off = 0, 
        Daily = 1, 
        Weekly = 2, 
        Monthly = 3, 
        Yearly = 4, 
        Custom = 5, 

        INVALID = 255
    }
}
