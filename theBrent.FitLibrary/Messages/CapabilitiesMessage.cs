using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using theBrent.FitLibrary.FieldTypes;

namespace theBrent.FitLibrary.Messages
{
    public class CapabilitiesMessage : DataMessage
    {
        public FitField_UInt8z Languages
        {
            get { return (FitField_UInt8z)this["languages"]; }
        }

        public FitField_SportBits0 Sports
        {
            get { return (FitField_SportBits0)this["sports"]; }
        }

        public FitField_WorkoutCapabilities WorkoutsSupported
        {
            get { return (FitField_WorkoutCapabilities)this["workouts_supported"]; }
        }

        public CapabilitiesMessage(DataMessage message) : base(message) { }
    }
}
