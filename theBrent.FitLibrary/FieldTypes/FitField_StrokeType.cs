using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theBrent.FitLibrary.FieldTypes
{
    public class FitField_StrokeType : FitField_Enum
    {
        public new StrokeType? Value
        {
            get { return (StrokeType?)base.Value; }
        }

        public FitField_StrokeType(byte[] fieldData) : base(fieldData) { }
    }

    public enum StrokeType
    {
        NoEvent = 0,
        /// <summary>
        /// stroke was detected but cannot be identified
        /// </summary>
        Other = 1,
        Serve = 2,
        Forehand = 3,
        Backhand = 4,
        Smash = 5
    }
}
