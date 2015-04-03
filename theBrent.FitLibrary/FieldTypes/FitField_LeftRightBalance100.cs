using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theBrent.FitLibrary.FieldTypes
{
    public class FitField_LeftRightBalance100 : FitField_UInt16
    {
        /// <summary>
        /// % contribution scaled by 100
        /// </summary>
        public const UInt16 MASK = 0x3FFF;

        /// <summary>
        /// data corresponds to right if set, otherwise unknown
        /// </summary>
        public const UInt16 RIGHT = 0x8000;

        public bool Right
        {
            get { return (base.Value & RIGHT) == RIGHT; }
        }
        public new byte? Value
        {
            get { return (byte?)(base.Value & MASK); }
        }
        public FitField_LeftRightBalance100(byte[] fieldData) : base(fieldData) { }
    }
}
