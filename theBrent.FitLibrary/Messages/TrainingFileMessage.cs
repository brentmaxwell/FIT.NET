using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using theBrent.FitLibrary.FieldTypes;

namespace theBrent.FitLibrary.Messages
{
    public class TrainingFileMessage : DataMessage
    {
        public FitField_DateTime TimeStamp
        {
            get { return (FitField_DateTime)this["timestamp"]; }
        }

        public FitField_FileType Type
        {
            get { return (FitField_FileType)this["file_type"]; }
        }

        public FitField_Manufacturer Manufacturer
        {
            get { return (FitField_Manufacturer)this["manufacturer"]; }
        }

        public FitField_GarminProduct Product
        {
            get { return (FitField_GarminProduct)this["product"]; }
        }

        public FitField_UInt32z SerialNumber
        {
            get { return (FitField_UInt32z)this["serial_number"]; }
        }

        public FitField_DateTime TimeCreated
        {
            get { return (FitField_DateTime)this["time_created"]; }
        }

        public TrainingFileMessage(DataMessage message) : base(message) { }
    }
}
