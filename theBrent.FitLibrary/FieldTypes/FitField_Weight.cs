using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theBrent.FitLibrary.FieldTypes
{
    public class FitField_Weight : FitField_UInt16
    {
        public const ushort CALCULATING = 0xFFFE;

        public new ushort? Value
        {
            get { return (base.Value == CALCULATING) ? new ushort?() : base.Value; }
        }
        public FitField_Weight(byte[] fieldData) : base(fieldData) { }
    }
}
