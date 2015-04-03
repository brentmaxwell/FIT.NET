using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theBrent.FitLibrary.FieldTypes
{
    public class FitField_DeviceType : FitField_UInt8
    {
        public new DeviceType? Value
        {
            get { return (DeviceType?)base.Value; }
        }

        public FitField_DeviceType(byte[] fieldData) : base(fieldData) { }
    }

    public enum DeviceType
    {
        antfs = 1,
        bike_power = 11,
        environment_sensor = 12,
        multi_sport_speed_distance = 15,
        fitness_equipment = 17,
        blood_pressure = 18,
        weight_scale = 119,
        heart_rate = 120,
        bike_speed_cadence = 121,
        bike_cadence = 122,
        bike_speed = 123,
        stride_speed_distance = 124

    }
}
