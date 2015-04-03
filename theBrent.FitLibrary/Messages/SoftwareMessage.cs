using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using theBrent.FitLibrary.FieldTypes;

namespace theBrent.FitLibrary.Messages
{
    public class SoftwareMessage : DataMessage
    {
        public FitField_MessageIndex MessageIndex
        {
            get { return (FitField_MessageIndex)this["message_index"]; }
        }

        public FitField_UInt16 Version
        {
            get { return (FitField_UInt16)this["version"]; }
        }

        public FitField_String PartNumber
        {
            get { return (FitField_String)this["part_number"]; }
        }

        public FitField_Manufacturer Manufacturer
        {
            get { return (FitField_Manufacturer)this["manufacturer"]; }
        }

        public FitField_GarminProduct Product
        {
            get { return (FitField_GarminProduct)this["product"]; }
        }

        public SoftwareMessage(DataMessage message) : base(message) { }
    }
}
