using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using theBrent.FitLibrary.FieldTypes;

namespace theBrent.FitLibrary.Messages
{
    public class ActivityMessage : DataMessage
    {
        public FitField_DateTime TimeStamp
        {
            get { return (FitField_DateTime)this["timestamp"]; }
        }

        public FitField_UInt32 TotalTimerTime
        {
            get { return (FitField_UInt32)this["total_timer_time"]; }
        }

        public FitField_UInt16 NumSessions
        {
            get { return (FitField_UInt16)this["num_sessions"]; }
        }

        public FitField_Activity Type
        {
            get { return (FitField_Activity)this["type"]; }
        }

        public FitField_Event Event
        {
            get { return (FitField_Event)this["event"]; }
        }

        public FitField_EventType EventType
        {
            get { return (FitField_EventType)this["event_type"]; }
        }

        public FitField_DateTime LocalTimestamp
        {
            get { return (FitField_LocalDateTime)this["local_timestamp"]; }
        }

        public FitField_UInt8 EventGroup
        {
            get { return (FitField_UInt8)this["event_group"]; }
        }

        public ActivityMessage(DataMessage message) : base(message) { }
    }
}
