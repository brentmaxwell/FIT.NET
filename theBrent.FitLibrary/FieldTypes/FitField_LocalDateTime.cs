using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theBrent.FitLibrary.FieldTypes
{
    /// <summary>
    /// seconds since 00:00 Dec 31 1989 in local time zone
    /// </summary>
    public class FitField_LocalDateTime : FitField_DateTime
    {
        public FitField_LocalDateTime(byte[] fieldData) : base(fieldData) {}
    }
}
