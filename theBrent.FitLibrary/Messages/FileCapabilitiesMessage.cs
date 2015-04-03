using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using theBrent.FitLibrary.FieldTypes;

namespace theBrent.FitLibrary.Messages
{
    public class FileCapabilitiesMessage : DataMessage
    {
        public FitField_MessageIndex MessageIndex
        {
            get { return (FitField_MessageIndex)this["message_index"]; }
        }

        public FitField_FileType Type
        {
            get { return (FitField_FileType)this["type"]; }
        }

        public FitField_FileFlags Flags
        {
            get { return (FitField_FileFlags)this["flags"]; }
        }

        public FitField_String Directory
        {
            get { return (FitField_String)this["directory"]; }
        }

        public FitField_UInt16 MaxCount
        {
            get { return (FitField_UInt16)this["max_count"]; }
        }

        public FitField_UInt32 MaxSize
        {
            get { return (FitField_UInt32)this["max_size"]; }
        }

        public FileCapabilitiesMessage(DataMessage message) : base(message) { }
    }
}
