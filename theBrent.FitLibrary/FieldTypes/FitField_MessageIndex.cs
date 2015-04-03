using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theBrent.FitLibrary.FieldTypes
{
    public class FitField_MessageIndex : FitField_UInt16
    {
        /// <summary>
        /// index
        /// </summary>
        private const ushort MASK = 0x0FFF;

        public new ushort? Value
        {
            get { return (ushort?)(base.Value & MASK); }
        }

        public MessageIndex? Flags
        {
            get { return (MessageIndex?)base.Value; }
        }

        public FitField_MessageIndex(byte[] fieldData) : base(fieldData) { }
    }

    [Flags]
    public enum MessageIndex
    {
        /// <summary>
        /// message is selected if set
        /// </summary>
        Selected = 0x8000,

        /// <summary>
        /// reserved (default 0)
        /// </summary>
        Reserved = 0x7000
    }
}
