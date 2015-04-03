using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theBrent.FitLibrary.FieldTypes
{
    public class FitField_SportBits1 : FitField_UInt8z
    {
        public new SportBits1? Value
        {
            get { return (SportBits1?)base.Value; }
        }

        public FitField_SportBits1(byte[] fieldData) : base(fieldData) { }
    }

    /// <summary>
    /// Bit field corresponding to sport enum type (1 << (sport-8)).
    /// </summary>
    [Flags]
    public enum SportBits1
    {
        Tennis = 0x01,
        AmericanFootball = 0x02,
        Training = 0x04,
        Walking = 0x08,
        CrossCountrySkiing = 0x10,
        AlpineSkiing = 0x20,
        Snowboarding = 0x40,
        Rowing = 0x80

    }
}
