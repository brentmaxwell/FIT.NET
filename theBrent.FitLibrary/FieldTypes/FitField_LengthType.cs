using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theBrent.FitLibrary.FieldTypes
{
    public class FitField_LengthType : FitField_Enum
    {
        public new LengthType? Value
        {
            get { return (LengthType?)base.Value; }
        }

        public FitField_LengthType(byte[] fieldData) : base(fieldData) { }
    }

    public enum LengthType
    {
        /// <summary>
        /// Rest period. Length with no strokes
        /// </summary>
        Idle = 0,
        /// <summary>
        /// Length with strokes.
        /// </summary>
        Active = 1

    }
}
