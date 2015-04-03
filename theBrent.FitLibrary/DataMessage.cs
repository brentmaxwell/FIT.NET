using System.Collections.Generic;
using System.IO;
using System;


namespace theBrent.FitLibrary
{
    public class DataMessage : FitMessage
    {
        public DataMessage() {}

        public DataMessage(DataMessage message)
        {
            this.Fields = message.Fields;
            this.GlobalMessageNumber = message.GlobalMessageNumber;
        }

        public DataMessage(byte messageHeader, DefinitionMessage defMessage, BinaryReader r) : base(messageHeader)
        {
            this.GlobalMessageNumber = defMessage.GlobalMessageNumber;
            
            foreach (FitField ff in defMessage.Fields)
            {
                FitField f = FitField.FitFieldFactory(ff);
                f.Value = r.ReadBytes(f.Size);
                this.Fields.Add(f);
            }
        }
    }
}
