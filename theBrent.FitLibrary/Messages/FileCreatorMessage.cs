using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using theBrent.FitLibrary.FieldTypes;

namespace theBrent.FitLibrary.Messages
{
    public class FileCreatorMessage : DataMessage
    {
        public FitField_UInt16 SoftwareVersion
        {
            get { return (FitField_UInt16)this["software_version"]; }
        }

        public FitField_UInt8 HardwareVersion
        {
            get { return (FitField_UInt8)this["hardware_vesion"]; }
        }

        public FileCreatorMessage(DataMessage message) : base(message) { }
    }
}
