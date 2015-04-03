using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theBrent.FitLibrary.FieldTypes
{
    public class FitField_LeftRightBalance : FitField_UInt8
    {
        /// <summary>
        /// % contribution
        /// </summary>
        public const byte MASK = 0x7F;

        /// <summary>
        /// data corresponds to right if set, otherwise unknown
        /// </summary>
        public const byte RIGHT = 0x80;

        public bool Right
        {
            get { return (base.Value & RIGHT) == RIGHT; }
        }

        public new byte? Value
        {
            get { return (byte?)(base.Value & MASK); }
        }
        public FitField_LeftRightBalance(byte[] fieldData) : base(fieldData) { }
    }
}
