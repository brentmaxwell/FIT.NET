using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using theBrent.FitLibrary.FieldTypes;

namespace theBrent.FitLibrary.Messages
{
    public class HrvMessage : DataMessage
    {
        public FitField_UInt16 Time
        {
            get { return (FitField_UInt16)this["time"]; }
        }

        public HrvMessage(DataMessage message) : base(message) { }
    }
}
