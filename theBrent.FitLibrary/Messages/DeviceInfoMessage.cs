using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using theBrent.FitLibrary.FieldTypes;

namespace theBrent.FitLibrary.Messages
{
    public class DeviceInfoMessage : DataMessage
    {
        public FitField_DateTime TimeStamp
        {
            get { return (FitField_DateTime)this["timestamp"]; }
        }

        public FitField_DeviceIndex DeviceIndex
        {
            get { return (FitField_DeviceIndex)this["device_index"]; }
        }

        public FitField_DeviceType DeviceType
        {
            get { return (FitField_DeviceType)this["device_type"]; }
        }

        public FitField_Manufacturer Manufacturer
        {
            get { return (FitField_Manufacturer)this["manufacturer"]; }
        }

        public FitField_UInt32z SerialNumber
        {
            get { return (FitField_UInt32z)this["serial_number"]; }
        }

        public FitField_GarminProduct Product
        {
            get { return (FitField_GarminProduct)this["product"]; }
        }

        public FitField_UInt16 SoftwareVersion
        {
            get { return (FitField_UInt16)this["software_version"]; }
        }

        public FitField_UInt8 HardwareVersion
        {
            get { return (FitField_UInt8)this["hardware_vesion"]; }
        }

        public FitField_UInt32 CumulativeOperatingTime
        {
            get { return (FitField_UInt32)this["cum_operating_time"]; }
        }

        public FitField_UInt16 BatteryVoltage
        {
            get { return (FitField_UInt16)this["battery_voltage"]; }
        }

        public FitField_BatteryStatus BatteryStatus
        {
            get { return (FitField_BatteryStatus)this["battery_status"]; }
        }

        public DeviceInfoMessage(DataMessage message) : base(message) { }
    }
}
