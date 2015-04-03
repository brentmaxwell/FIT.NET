using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using theBrent.FitLibrary.FieldTypes;

namespace theBrent.FitLibrary.Messages
{
    public class DeviceSettingsMessage : DataMessage
    {
        /// <summary>
        /// Index into time zone arrays.
        /// </summary>
        public FitField_UInt8 ActiveTimeZone
        {
            get { return (FitField_UInt8) this["active_time_zone"]; }
        }

        /// <summary>
        /// Offset from system time. Required to convert timestamp from system time to UTC.
        /// </summary>
        public FitField_UInt32 UtcOffset
        {
            get { return (FitField_UInt32)this["utc_offset"]; }
        }

        /// <summary>
        /// timezone offset in 1/4 hour increments
        /// </summary>
        public FitField_SInt8 TimeZoneOffset
        {
            get { return (FitField_SInt8)this["time_zone_offset"]; }
        }

        public DeviceSettingsMessage(DataMessage message) : base(message) { }
    }
}
