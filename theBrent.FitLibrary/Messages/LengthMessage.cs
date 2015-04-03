using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using theBrent.FitLibrary.FieldTypes;

namespace theBrent.FitLibrary.Messages
{
    public class LengthMessage : DataMessage
    {
        public FitField_MessageIndex MessageIndex
        {
            get { return (FitField_MessageIndex)this["message_index"]; }
        }

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

        public FitField_DateTime StartTime
        {
            get { return (FitField_DateTime)this["start_time"]; }
        }

        public FitField_UInt32 TotalElapsedTime
        {
            get { return (FitField_UInt32)this["total_elapsed_time"]; }
        }

        public FitField_UInt32 TotalTimerTime
        {
            get { return (FitField_UInt32)this["total_timer_time"]; }
        }

        public FitField_UInt16 TotalStrokes
        {
            get { return (FitField_UInt16)this["total_strokes"]; }
        }

        public FitField_UInt16 AverageSpeed
        {
            get { return (FitField_UInt16)this["avg_speed"]; }
        }

        public FitField_SwimStroke SwimStroke
        {
            get { return (FitField_SwimStroke)this["swim_stroke"]; }
        }

        public FitField_UInt8 AverageSwimmingCadence
        {
            get { return (FitField_UInt8)this["avg_swimming_cadence"]; }
        }

        public FitField_UInt8 EventGroup
        {
            get { return (FitField_UInt8)this["event_group"]; }
        }

        public FitField_UInt16 TotalCalories
        {
            get { return (FitField_UInt16)this["total_calories"]; }
        }

        public FitField_LengthType LengthType
        {
            get { return (FitField_LengthType)this["length_type"]; }
        }

        public LengthMessage(DataMessage message) : base(message) { }
    }
}
