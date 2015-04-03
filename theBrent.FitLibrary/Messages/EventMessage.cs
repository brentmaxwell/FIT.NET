using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using theBrent.FitLibrary.FieldTypes;

namespace theBrent.FitLibrary.Messages
{
    public class EventMessage : DataMessage
    {
        public FitField_DateTime TimeStamp
        {
            get { return (FitField_DateTime)this["timestamp"]; }
        }

        public FitField_Event Event
        {
            get { return (FitField_Event)this["event"]; }
        }

        public FitField_EventType EventType
        {
            get { return (FitField_EventType)this["event_type"]; }
        }

        public FitField_UInt16 Data16
        {
            get { return (FitField_UInt16)this["data16"]; }
        }

        public FitField_UInt32 Data
        {
            get { return (FitField_UInt32)this["data"]; }
        }

        public FitField_UInt8 EventGroup
        {
            get { return (FitField_UInt8)this["event_group"]; }
        }

        public EventMessage(DataMessage message) : base(message) { }
    }
}
