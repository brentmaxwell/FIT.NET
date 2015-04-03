using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theBrent.FitLibrary.FieldTypes
{
    public class FitField_DeviceIndex : FitField_UInt8
    {
        /// <summary>
        /// Creator of the file is always device index 0.
        /// </summary>
        public const byte CREATOR = 0;
        public FitField_DeviceIndex(byte[] fieldData) : base(fieldData) { }
    }
}
