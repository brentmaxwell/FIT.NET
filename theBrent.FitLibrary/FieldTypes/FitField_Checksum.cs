using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theBrent.FitLibrary.FieldTypes
{
    public class FitField_Checksum : FitField_UInt8
    {
        public new Checksum? Value
        {
            get { return (Checksum?)base.Value; }
        }

        public FitField_Checksum(byte[] fieldData) : base(fieldData) { }
    }

    public enum Checksum
    {
        /// <summary>
        /// Allows clear of checksum for flash memory where can only write 1 to 0 without erasing sector.
        /// </summary>
        Clear = 0,

        /// <summary>
        /// Set to mark checksum as valid if computes to invalid values 0 or 0xFF.  Checksum can also be set to ok to save encoding computation time.
        /// </summary>
        Ok = 1
    }
}
