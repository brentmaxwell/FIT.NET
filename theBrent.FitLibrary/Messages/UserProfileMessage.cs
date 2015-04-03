using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using theBrent.FitLibrary.FieldTypes;

namespace theBrent.FitLibrary.Messages
{
    public class UserProfileMessage : DataMessage
    {
        public FitField_MessageIndex MessageIndex
        {
            get { return (FitField_MessageIndex)this["message_index"]; }
        }

        public FitField_String FriendlyName
        {
            get { return (FitField_String)this["friendly_name"]; }
        }

        public FitField_Gender Gender
        {
            get { return (FitField_Gender)this["gender"]; }
        }

        public FitField_UInt8 Age
        {
            get { return (FitField_UInt8)this["age"]; }
        }
        public FitField_UInt8 Height
        {
            get { return (FitField_UInt8)this["height"]; }
        }

        public FitField_UInt16 Weight
        {
            get { return (FitField_UInt16)this["weight"]; }
        }

        public FitField_Language Language
        {
            get { return (FitField_Language)this["language"]; }
        }

        public FitField_DisplayMeasure ElevationSetting
        {
            get { return (FitField_DisplayMeasure)this["elev_setting"]; }
        }

        public FitField_DisplayMeasure WeightSetting
        {
            get { return (FitField_DisplayMeasure)this["weight_setting"]; }
        }

        public FitField_UInt8 RestingHeartRate
        {
            get { return (FitField_UInt8)this["resting_heart_rate"]; }
        }

        public FitField_UInt8 DefaultMaxRunningHeartRate
        {
            get { return (FitField_UInt8) this["default_max_running_heart_rate"]; }  
        }

        public FitField_UInt8 DefaultMaxBikingHeartRate
        {
            get { return (FitField_UInt8) this["default_max_biking_heart_rate"]; }
        }

        public FitField_UInt8 DefaultMaxHeartRate
        {
            get { return (FitField_UInt8) this["default_max_heart_rate"]; }
        }

        public FitField_DisplayHeart HrSetting
        {
            get { return (FitField_DisplayHeart) this["hr_setting"]; }
        }

        public FitField_DisplayMeasure SpeedSetting
        {
            get { return (FitField_DisplayMeasure) this["speed_setting"]; }
        }

        public FitField_DisplayMeasure DistanceSetting
        {
            get { return (FitField_DisplayMeasure)this["dist_setting"]; }
        }

        public FitField_DisplayPower PowerSetting
        {
            get { return (FitField_DisplayPower)this["power_setting"]; }
        }

        public FitField_ActivityClass ActivityClass
        {
            get { return (FitField_ActivityClass)this["activity_class"]; }
        }
        
        public FitField_DisplayPosition PositionSetting
        {
            get { return (FitField_DisplayPosition)this["position_setting"]; }
        }
        

        public FitField_DisplayMeasure TemperatureSetting
        {
            get { return (FitField_DisplayMeasure)this["temperature_setting"]; }
        }
        
        public FitField_DisplayMeasure HeightSetting
        {
            get { return (FitField_DisplayMeasure)this["height_setting"]; }
        }

        public FitField_UserLocalId LocalId
        {
            get { return (FitField_UserLocalId) this["local_id"]; }
        }

        public FitField_Byte GlobalId
        {
            get { return (FitField_Byte)this["global_id"]; }
        }

        public UserProfileMessage(DataMessage message) : base(message) { }
    }
}
