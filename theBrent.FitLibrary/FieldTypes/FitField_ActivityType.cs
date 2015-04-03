using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theBrent.FitLibrary.FieldTypes
{
    public class FitField_ActivityType : FitField_Enum
    {
        public new ActivityType? Value
        {
            get { return (ActivityType?)base.Value; }
        }

        public FitField_ActivityType(byte[] fieldData) : base(fieldData) { }
    }

    public enum ActivityType
    {
        Generic = 0,
        Running = 1,
        Cycling = 2,

        /// <summary>
        /// Mulitsport transition
        /// </summary>
        Transition = 3,
        FitnessEquipment = 4,
        Swimming = 5,
        Walking = 6,
        /// <summary>
        /// All is for goals only to include all sports.
        /// </summary>
        ALL = 254,
        INVALID = 255
    }
}
