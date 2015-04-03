using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using theBrent.FitLibrary.FieldTypes;

namespace theBrent.FitLibrary
{
    public class FitFile
    {
        public byte HeaderSize;
        public byte[] Header;
        public byte ProtocolVersion;
        public Int16 ProfileVersion;
        public Int32 DataSize;
        public string DataType;
        public Int16 CRC;

        public byte[] Content;

        public FileType FileType;

        public List<DefinitionMessage> DefinitionMessages;
        public List<DataMessage> DataMessages;

        private Stream s;
        private BinaryReader r;

        public FitFile(Stream stream)
        {
            s = stream;
            r = new BinaryReader(s);
            this.Content = new byte[s.Length];
            this.Content = r.ReadBytes(this.Content.Length);
            s.Seek(0, SeekOrigin.Begin);

            this.DefinitionMessages = new List<DefinitionMessage>();
            this.DataMessages = new List<DataMessage>();

            this.HeaderSize = r.ReadByte();
            this.Header = r.ReadBytes(this.HeaderSize - 1);
            this.ProtocolVersion = this.Header[0];
            
            //this.ProfileVersion = r.ReadInt16();
            //this.DataSize = r.ReadInt32();
            //this.DataType = Encoding.ASCII.GetString(r.ReadBytes(4));
            //this.CRC = r.ReadInt16();

            //if (this.DataType != ".FIT")
            //{
            //    throw new InvalidDataException("File is not in the .FIT format.");
            //}
            //try
            //{
                while (s.Position < s.Length - 3)
                {
                    byte messageHeader = (byte)r.ReadByte();
                    switch (messageHeader & 0xC0)
                    {
                        case 0x40:
                            ReadDefinitionMessage(messageHeader);
                            break;
                        case 0x80:
                            ReadCompressedTimestampMessage(messageHeader);
                            break;
                        default:
                            ReadNormalDataMessage(messageHeader);
                            break;
                    }
                }
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }
        public FitFile(byte[] data) : this(new MemoryStream(data))
        {
            
        }

        private void ReadDefinitionMessage(byte messageHeader)
        {
            DefinitionMessage defMessage = new DefinitionMessage(messageHeader, r);
            if (DefinitionMessages.Count(m => m.LocalMessageType == defMessage.LocalMessageType) > 0)
            {
                this.DefinitionMessages.Single(m => m.LocalMessageType == defMessage.LocalMessageType).LocalMessageType = null;
            }
            this.DefinitionMessages.Add(defMessage);
        }

        private void ReadDataMessage(byte localMessageType, byte messageHeader)
        {
            DefinitionMessage defMessage = this.DefinitionMessages.Single(m => m.LocalMessageType == localMessageType);
            DataMessage dataMessageTmp = new DataMessage(messageHeader, defMessage, this.r);
            Type messageType;
            if(FitProfile.MessageMap.ContainsKey(defMessage.GlobalMessageNumber))
            {
                messageType = FitProfile.MessageMap[defMessage.GlobalMessageNumber].MessageType;
            }
            else
            {
                messageType = typeof(DataMessage);
            }
            DataMessage dataMessage = (DataMessage)Activator.CreateInstance(messageType, dataMessageTmp);
            if (defMessage.GlobalMessageNumber == MessageNumber.FileId)
            {
                FitField_Enum FileField = (FitField_Enum)(dataMessage.Fields.Single(m => m.FieldDefinitionNumber == 0));
                this.FileType = (FileType)FileField.Value;
            }
            this.DataMessages.Add(dataMessage);
        }

        private void ReadNormalDataMessage(byte messageHeader)
        {
            byte localMessageType = (byte)(messageHeader & 0xF);
            this.ReadDataMessage(localMessageType, messageHeader);
        }

        private void ReadCompressedTimestampMessage(byte messageHeader)
        {
            byte localMessageType = (byte)((messageHeader & 0x60) >> 5);
            this.ReadDataMessage(localMessageType, messageHeader);
        }

        internal static byte GetEndian()
        {
            ushort arch = 0x0100;
            return (byte)arch;
        }
    }

    public class MessageDefinition
    {
        public string Name;
        public Type MessageType;
        public Dictionary<byte, FieldDefinition> Fields;

        public MessageDefinition(string name, Type messageType, Dictionary<byte, FieldDefinition> fields)
        {
            this.Name = name;
            this.MessageType = messageType;
            this.Fields = fields;
        }
    }

    public class FieldDefinition
    {
        public string Name;
        public Type FieldType;

        public FieldDefinition(string name, Type fieldType)
        {
            this.Name = name;
            this.FieldType = fieldType;
        }
    }
}
