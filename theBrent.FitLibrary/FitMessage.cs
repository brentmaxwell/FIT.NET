using System.Collections.Generic;
using System.Linq;
using theBrent.FitLibrary.FieldTypes;

namespace theBrent.FitLibrary
{
    public class FitMessage
    {
        public bool NormalHeader;
        public byte? LocalMessageType;
        public byte? TimeOffset;

        public MessageNumber GlobalMessageNumber { get; set;}
        public List<FitField> Fields = new List<FitField>(); 

        public FitField this[byte key]
        {
            get
            {
                return this.Fields.SingleOrDefault(f => f.FieldDefinitionNumber == key);
            }
        }

        public FitField this[string key]
        {
            get
            {
                return this.Fields.SingleOrDefault(f => f.FieldName == key);
            }
        }

        public FitMessage() { }

        public FitMessage(byte MessageHeader)
        {
            this.NormalHeader = (MessageHeader & 0x80) == 0x80;
            switch(MessageHeader & 0xC0)
            {
                case 0x00:
                case 0x40:
                    this.LocalMessageType = (byte)(MessageHeader & 0xF);
                    break;
                case 0x80:
                    this.LocalMessageType = (byte)((MessageHeader & 0x60) >> 5);
                    this.TimeOffset = (byte)(MessageHeader & 0x0F);
                    break;
            }
        }
    }
}
