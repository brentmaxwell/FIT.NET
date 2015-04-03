using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theBrent.FitLibrary.FieldTypes
{
    public class FitField_SportBits0 : FitField_UInt8z
    {
        public new SportBits0? Value
        {
            get { return (SportBits0?)base.Value; }
        }

        public FitField_SportBits0(byte[] fieldData) : base(fieldData) { }
    }

    /// <summary>
    /// Bit field corresponding to sport enum type (1 << sport).
    /// </summary>
    [Flags]
    public enum SportBits0
    {
        Generic = 0x01,

        Running = 0x02,

        Cycling = 0x04,

        /// <summary>
        /// Multisport transition
        /// </summary>
        Transition = 0x08,

        FitnessEquipment = 0x10,

        Swimming = 0x20,

        Basketball = 0x40,

        Soccer = 0x80
    }
}
