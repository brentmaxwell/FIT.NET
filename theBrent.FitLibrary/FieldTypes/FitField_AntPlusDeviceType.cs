using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theBrent.FitLibrary.FieldTypes
{
    public class FitField_AntPlusDeviceType : FitField_UInt8
    {
        public new AntPlusDeviceType? Value
        {
            get { return (AntPlusDeviceType?)base.Value; }
        }

        public FitField_AntPlusDeviceType(byte[] fieldData) : base(fieldData) { }
    }

    public enum AntPlusDeviceType
    {
        antfs = 1,
        bike_power = 11,
        environment_sensor_legacy = 12,
        multi_sport_speed_distance = 15,
        control = 16,
        fitness_equipment = 17,
        blood_pressure = 18,
        geocache_node = 19,
        light_electric_vehicle = 20,
        env_sensor = 25,
        racquet = 26,
        weight_scale = 119,
        heart_rate = 120,
        bike_speed_cadence = 121,
        bike_cadence = 122,
        bike_speed = 123,
        stride_speed_distance = 124,



    }
}
