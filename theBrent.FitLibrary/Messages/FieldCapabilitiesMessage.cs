using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using theBrent.FitLibrary.FieldTypes;

namespace theBrent.FitLibrary.Messages
{
    public class FieldCapabilitiesMessage : DataMessage
    {
        public FitField_MessageIndex MessageIndex
        {
            get { return (FitField_MessageIndex)this["message_index"]; }
        }

        public FitField_FileType File
        {
            get { return (FitField_FileType)this["file"]; }
        }

        public FitField_MesgNum MesgNum
        {
            get { return (FitField_MesgNum)this["mesg_num"]; }
        }
        
        public FitField_UInt8 FieldNum
        {
            get { return (FitField_UInt8)this["field_num"]; }
        }

        public FitField_UInt16 Count
        {
            get { return (FitField_UInt16)this["count"]; }
        }

        public FieldCapabilitiesMessage(DataMessage message) : base(message) { }
    }
}
