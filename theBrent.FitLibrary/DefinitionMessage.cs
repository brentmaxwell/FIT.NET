using System.IO;
using theBrent.FitLibrary.FieldTypes;
using System;

namespace theBrent.FitLibrary
{
    public class DefinitionMessage : FitMessage
    {
        public bool Architecture;
        public byte NumberOfFields;

        public DefinitionMessage()
        {
        }

        public DefinitionMessage(byte messageHeader,BinaryReader r) : base(messageHeader)
        {
            this.LocalMessageType = (byte)(messageHeader & 0xF);
            r.ReadByte();
            this.Architecture = r.ReadByte() > 0;
            this.GlobalMessageNumber = this.Architecture ? (MessageNumber)BitConverter.ToUInt16(FitField.ReverseEndian(BitConverter.GetBytes(r.ReadInt16())),0) : (MessageNumber)r.ReadInt16();
            this.NumberOfFields = r.ReadByte();
            for (int i = 0; i < this.NumberOfFields; i++)
            {
                FitField f = FitField.FitFieldFactory(this.GlobalMessageNumber,r.ReadBytes(3),this.Architecture);
                Fields.Add(f);
            }
        }
    }
}
