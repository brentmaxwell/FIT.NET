using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theBrent.FitLibrary.FieldTypes
{
    public class FitField_SportBits2 : FitField_UInt8z
    {
        public new SportBits2? Value
        {
            get { return (SportBits2?)base.Value; }
        }

        public FitField_SportBits2(byte[] fieldData) : base(fieldData) { }
    }

    /// <summary>
    /// Bit field corresponding to sport enum type (1 << (sport-16)).
    /// </summary>
    [Flags]
    public enum SportBits2
    {
        Mountaineering = 0x01,
        Hiking = 0x02,
        Multisport = 0x04,
        Paddling = 0x08


    }
}
