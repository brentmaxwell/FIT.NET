using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theBrent.FitLibrary.FieldTypes
{
    /// <summary>
    /// seconds since UTC 00:00 Dec 31 1989
    /// </summary>
    public class FitField_DateTime : FitField_UInt32
    {
        /// <summary>
        /// if date_time is < 0x10000000 then it is system time (seconds from device power on)
        /// </summary>
        public const UInt32 MIN = 0x10000000;

        public new DateTime? Value
        {
            get
            {
                if (!base.Value.HasValue)
                    return null;
                if (base.Value.Value < MIN)
                    return new DateTime().AddSeconds(base.Value.Value);
                else
                    return new DateTime(1989, 12, 31, 0, 0, 0, DateTimeKind.Utc).AddSeconds(base.Value.Value);
            }
        }

        public FitField_DateTime(byte[] fieldData) : base(fieldData) {}
    }
}
