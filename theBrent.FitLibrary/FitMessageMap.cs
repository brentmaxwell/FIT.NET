using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using theBrent.FitLibrary.FieldTypes;
using theBrent.FitLibrary.FieldTypes.CustomFieldTypes;
using theBrent.FitLibrary.Messages;
using FitField_Weight = theBrent.FitLibrary.FieldTypes.FitField_Weight;

namespace theBrent.FitLibrary
{
    public static partial class FitProfile
    {
        public static Dictionary<MessageNumber, MessageDefinition> MessageMap = new Dictionary<MessageNumber, MessageDefinition>()
        {
            #region Common Messages
            {
                MessageNumber.FileId,
                new MessageDefinition
                (
                    "FileId",
                    typeof(FileIdMessage),
                    new Dictionary<byte,FieldDefinition>()
                    {
                        { 0, new FieldDefinition("type", typeof(FitField_FileType))},
                        { 1, new FieldDefinition("manufacturer", typeof(FitField_Manufacturer))},
                        { 2, new FieldDefinition("product", typeof(FitField_GarminProduct))},
                        { 3, new FieldDefinition("serial_number", typeof(FitField_UInt32z))},
                        { 4, new FieldDefinition("time_created", typeof(FitField_DateTime))},
                        { 5, new FieldDefinition("number", typeof(FitField_UInt16))},
                        { 6, new FieldDefinition("manufacturer_partner", typeof(FitField_UInt16))} //UNDOCUMENTED
                    }
                )
            },
            { 
                MessageNumber.FileCreator,
                new MessageDefinition
                (
                    "FileCreator",
                    typeof(FileCreatorMessage),
                    new Dictionary<byte,FieldDefinition>()
                    {
                        { 0, new FieldDefinition("software_version", typeof(FitField_UInt16))},
                        { 1, new FieldDefinition("hardware_version", typeof(FitField_UInt8))}
                    }
                )
            },
            #endregion

            #region Device File Messages
            { 
                MessageNumber.Software,
                new MessageDefinition
                (
                    "Software",
                    typeof(SoftwareMessage),
                    new Dictionary<byte,FieldDefinition>()
                    {
                        { 254, new FieldDefinition("message_index", typeof(FitField_MessageIndex))},
                        { 3,   new FieldDefinition("version",      typeof(FitField_UInt16))},
                        { 5,   new FieldDefinition("part_number",   typeof(FitField_String))},
                        { 0,   new FieldDefinition("manufacturer", typeof(FitField_Manufacturer))},
                        { 1,   new FieldDefinition("product",      typeof(FitField_GarminProduct))},
                        { 6 ,  new FieldDefinition("version_string", typeof(FitField_String))}, //UNDOCUMENTED
                    }
                )
            },
            {
                MessageNumber.SlaveDevice,
                new MessageDefinition
                (
                    "SlaveDevice",
                    typeof(DataMessage),
                    new Dictionary<byte,FieldDefinition>()
                    {
                        { 0, new FieldDefinition("manufacturer", typeof(FitField_Manufacturer))},
                        { 1, new FieldDefinition("product", typeof(FitField_GarminProduct))},
                        { 2, new FieldDefinition("serial_number", typeof(FitField_UInt32z))}, //UNDOCUMENTED
                        { 3, new FieldDefinition("software_index", typeof(FitField_UInt16))}, //UNDOCUMENTED
                    }
                )
            },
            {
                MessageNumber.Capabilities,
                new MessageDefinition
                (
                    "Capabilities",
                    typeof(CapabilitiesMessage),
                    new Dictionary<byte,FieldDefinition>()
                    {
                        { 0, new FieldDefinition("languages", typeof(FitField_Language))},
                        { 1, new FieldDefinition("sports", typeof(FitField_SportBits0))},
                        { 21, new FieldDefinition("workouts_supported", typeof(FitField_WorkoutCapabilities))},
                        { 23, new FieldDefinition("connectivity_supported", typeof(FitField_ConnectivityCapabilities))},
                        { 21, new FieldDefinition("activity_profile_supported", typeof(FitField_Enum))}, // UNDOCUMENTED
                    }
                )
            },
            { 
                MessageNumber.FileCapabilities,
                new MessageDefinition
                (
                    "FileCapabilities",
                    typeof(FileCapabilitiesMessage),
                    new Dictionary<byte,FieldDefinition>()
                    {
                        { 254, new FieldDefinition("message_index", typeof(FitField_MessageIndex))},
                        { 0, new FieldDefinition("type", typeof(FitField_FileType))},
                        { 1, new FieldDefinition("flags", typeof(FitField_FileFlags))},
                        { 2, new FieldDefinition("directory", typeof(FitField_String))},
                        { 3, new FieldDefinition("max_count", typeof(FitField_UInt16))},
                        { 4, new FieldDefinition("max_size", typeof(FitField_UInt32))},


                    }
                )
            },
            { 
                MessageNumber.MesgCapabilities,
                new MessageDefinition
                (
                    "MesgCapabilities",
                    typeof(MesgCapabilitiesMessage),
                    new Dictionary<byte,FieldDefinition>()
                    {
                        { 254, new FieldDefinition("message_index", typeof(FitField_MessageIndex))},
                        { 0, new FieldDefinition("file", typeof(FitField_FileType))},
                        { 1, new FieldDefinition("mesg_num", typeof(FitField_MesgNum))},
                        { 2, new FieldDefinition("count_type", typeof(FitField_MesgCount))},
                        { 3, new FieldDefinition("count", typeof(FitField_UInt16))},
                    }
                )
            },
            { 
                MessageNumber.FieldCapabilities,
                new MessageDefinition
                (
                    "FieldCapabilities",
                    typeof(FieldCapabilitiesMessage),
                    new Dictionary<byte,FieldDefinition>()
                    {
                        { 254, new FieldDefinition("message_index", typeof(FitField_MessageIndex))},
                        { 0, new FieldDefinition("file", typeof(FitField_FileType))},
                        { 1, new FieldDefinition("mesg_num", typeof(FitField_MesgNum))},
                        { 2, new FieldDefinition("field_num", typeof(FitField_UInt8))},
                        { 3, new FieldDefinition("count", typeof(FitField_UInt16))},
                    }
                )
            },
            #endregion

            #region Settings File Messages
            {
                MessageNumber.DeviceSettings,
                new MessageDefinition
                (
                    "DeviceSettings",
                    typeof(DeviceSettingsMessage),
                    new Dictionary<byte,FieldDefinition>()
                    {
                        { 0, new FieldDefinition("active_time_zone", typeof(FitField_UInt8))},
                        { 1, new FieldDefinition("utc_offset", typeof(FitField_UInt32))},
                        { 5, new FieldDefinition("time_zone_offset", typeof(FitField_SInt8))},
                        { 2, new FieldDefinition("time_offset,", typeof(FitField_UInt32))}, //UNDOCUMENTED
                        { 3, new FieldDefinition("time_daylight_savings,", typeof(FitField_Enum))}, //UNDOCUMENTED
                        { 4, new FieldDefinition("time_mode,", typeof(FitField_Enum))}, //UNDOCUMENTED
                        { 8, new FieldDefinition("alarm_time,", typeof(FitField_UInt16))}, //UNDOCUMENTED
                        { 9, new FieldDefinition("alarm_mode,", typeof(FitField_Enum))}, //UNDOCUMENTED
                        { 10, new FieldDefinition("key_tones_enabled,", typeof(FitField_Enum))}, //UNDOCUMENTED
                        { 11, new FieldDefinition("message_tones_enabled,", typeof(FitField_Enum))}, //UNDOCUMENTED
                        { 12, new FieldDefinition("backlight_mode,", typeof(FitField_Enum))}, //UNDOCUMENTED
                        { 13, new FieldDefinition("backlight_timeout,", typeof(FitField_UInt8))}, //UNDOCUMENTED
                        { 14, new FieldDefinition("backlight_brightness,", typeof(FitField_UInt8))}, //UNDOCUMENTED
                        { 15, new FieldDefinition("display_contrast,", typeof(FitField_UInt8))}, //UNDOCUMENTED
                        { 16, new FieldDefinition("computer_beacon,", typeof(FitField_Enum))}, //UNDOCUMENTED
                        { 17, new FieldDefinition("computer_pairing,", typeof(FitField_Enum))}, //UNDOCUMENTED
                        { 18, new FieldDefinition("fitness_equipment_pairing,", typeof(FitField_Enum))}, //UNDOCUMENTED
                        { 19, new FieldDefinition("bezel_sensitivity,", typeof(FitField_Enum))}, //UNDOCUMENTED
                        { 21, new FieldDefinition("gps_enabled,", typeof(FitField_Enum))}, //UNDOCUMENTED
                        { 22, new FieldDefinition("weight_scale_enabled,", typeof(FitField_Enum))}, //UNDOCUMENTED
                        { 23, new FieldDefinition("map_orientation,", typeof(FitField_Enum))}, //UNDOCUMENTED
                        { 24, new FieldDefinition("map_show,", typeof(FitField_Enum))}, //UNDOCUMENTED
                        { 25, new FieldDefinition("map_show_locations,", typeof(FitField_Enum))}, //UNDOCUMENTED
                        { 26, new FieldDefinition("time_zone,", typeof(FitField_Enum))}, //UNDOCUMENTED
                        { 27, new FieldDefinition("auto_shutdown,", typeof(FitField_Enum))}, //UNDOCUMENTED
                        { 28, new FieldDefinition("alarm_tone,", typeof(FitField_Enum))}, //UNDOCUMENTED
                        { 29, new FieldDefinition("data_storage,", typeof(FitField_Enum))}, //UNDOCUMENTED
                        { 30, new FieldDefinition("map_auto_zoom,", typeof(FitField_Enum))}, //UNDOCUMENTED
                        { 31, new FieldDefinition("map_guidance,", typeof(FitField_Enum))}, //UNDOCUMENTED
                        { 32, new FieldDefinition("current_map_profile,", typeof(FitField_UInt8))}, //UNDOCUMENTED
                        { 33, new FieldDefinition("current_routing_profile,", typeof(FitField_UInt8))}, //UNDOCUMENTED
                        { 34, new FieldDefinition("display_mode,", typeof(FitField_Enum))}, //UNDOCUMENTED
                        { 35, new FieldDefinition("first_day_of_week,", typeof(FitField_Enum))}, //UNDOCUMENTED
                        { 36, new FieldDefinition("activity_tracker_enabled,", typeof(FitField_Enum))}, //UNDOCUMENTED
                        { 37, new FieldDefinition("sleep_enabled,", typeof(FitField_Enum))}, //UNDOCUMENTED

                    }
                )
            },
            {
                MessageNumber.UserProfile,
                new MessageDefinition
                (
                    "UserProfile",
                    typeof(UserProfileMessage),
                    new Dictionary<byte,FieldDefinition>()
                    {
                        { 254, new FieldDefinition("message_index", typeof(FitField_MessageIndex))},
                        { 0, new FieldDefinition("friendly_name", typeof(FitField_String))},
                        { 1, new FieldDefinition("gender", typeof(FitField_Gender))},
                        { 2, new FieldDefinition("age", typeof(FitField_UInt8))},
                        { 3, new FieldDefinition("height", typeof(FitField_UInt8))},
                        { 4, new FieldDefinition("weight", typeof(FitField_UInt16))},
                        { 5, new FieldDefinition("language", typeof(FitField_Language))},
                        { 6, new FieldDefinition("elev_setting", typeof(FitField_DisplayMeasure))},
                        { 7, new FieldDefinition("weight_setting", typeof(FitField_DisplayMeasure))},
                        { 8, new FieldDefinition("resting_heart_rate", typeof(FitField_UInt8))},
                        { 9, new FieldDefinition("default_max_running_heart_rate", typeof(FitField_UInt8))},
                        { 10, new FieldDefinition("default_max_biking_heart_rate", typeof(FitField_UInt8))},
                        { 11, new FieldDefinition("default_max_heart_rate", typeof(FitField_UInt8))},
                        { 12, new FieldDefinition("hr_setting", typeof(FitField_DisplayHeart))},
                        { 13, new FieldDefinition("speed_setting", typeof(FitField_DisplayMeasure))},
                        { 14, new FieldDefinition("dist_setting", typeof(FitField_DisplayMeasure))},
                        { 16, new FieldDefinition("power_setting", typeof(FitField_DisplayPower))},
                        { 17, new FieldDefinition("activity_class", typeof(FitField_ActivityClass))},
                        { 18, new FieldDefinition("position_setting", typeof(FitField_DisplayPosition))},
                        { 21, new FieldDefinition("temperature_setting", typeof(FitField_DisplayMeasure))},
                        { 22, new FieldDefinition("local_id", typeof(FitField_UserLocalId))},
                        { 23, new FieldDefinition("global_id", typeof(FitField_Byte))},
                        { 30, new FieldDefinition("height_setting", typeof(FitField_DisplayMeasure))},
                        { 19, new FieldDefinition("rmr", typeof(FitField_UInt16))}, //UNDOCUMENTED
                        { 20, new FieldDefinition("active_time", typeof(FitField_UInt8))}, //UNDOCUMENTED
                        { 24, new FieldDefinition("birth_year", typeof(FitField_UInt8))}, //UNDOCUMENTED
                        { 25, new FieldDefinition("avg_cycle_length", typeof(FitField_UInt16))}, //UNDOCUMENTED
                        { 26, new FieldDefinition("pressure_setting", typeof(FitField_Enum))}, //UNDOCUMENTED

                    }
                )
            },
            {
                MessageNumber.HrmProfile,
                new MessageDefinition
                (
                    "HrmProfile",
                    typeof(HrmProfileMessage),
                    new Dictionary<byte,FieldDefinition>()
                    {
                        { 254, new FieldDefinition("message_index", typeof(FitField_MessageIndex))},
                        { 0, new FieldDefinition("enabled", typeof(FitField_Bool))},
                        { 1, new FieldDefinition("hrm_ant_id", typeof(FitField_UInt16z))},
                        { 2, new FieldDefinition("log_hrv", typeof(FitField_Bool))},
                        { 3, new FieldDefinition("hrm_ant_id_trans_type", typeof(FitField_UInt8z))}
                    }
                )
            },
            { 
                MessageNumber.SdmProfile,
                new MessageDefinition
                (
                    "SdmProfile",
                    typeof(SdmProfileMessage),
                    new Dictionary<byte,FieldDefinition>()
                    {
                        { 254, new FieldDefinition("message_index", typeof(FitField_MessageIndex))},
                        { 0, new FieldDefinition("enabled", typeof(FitField_Bool))},
                        { 1, new FieldDefinition("sdm_ant_id", typeof(FitField_UInt16z))},
                        { 2, new FieldDefinition("sdm_cal_factor", typeof(FitField_UInt16))},
                        { 3, new FieldDefinition("odometer", typeof(FitField_UInt32))},
                        { 4, new FieldDefinition("speed_source", typeof(FitField_Bool))},
                        { 5, new FieldDefinition("sdm_ant_id_trans_type", typeof(FitField_UInt8z))},
                        { 7, new FieldDefinition("odometer_rollover", typeof(FitField_UInt8))},
                        { 6, new FieldDefinition("led_blink_min_speed", typeof(FitField_UInt8))}  //UNDOCUMENTED
                    }
                )
            },
            { 
                MessageNumber.BikeProfile,
                new MessageDefinition
                (
                    "BikeProfile",
                    typeof(DataMessage),
                    new Dictionary<byte,FieldDefinition>()
                    {
                        { 254, new FieldDefinition("message_index", typeof(FitField_MessageIndex))},
                        { 0, new FieldDefinition("name", typeof(FitField_String))},
                        { 1, new FieldDefinition("sport", typeof(FitField_Sport))},
                        { 2, new FieldDefinition("sub_sport", typeof(FitField_SubSport))},
                        { 3, new FieldDefinition("odometer", typeof(FitField_UInt32))},
                        { 4, new FieldDefinition("bike_spd_ant_id", typeof(FitField_UInt16z))},
                        { 5, new FieldDefinition("bike_cad_ant_id", typeof(FitField_UInt16z))},
                        { 6, new FieldDefinition("bike_spdcad_ant_id", typeof(FitField_UInt16z))},
                        { 7, new FieldDefinition("bike_power_ant_id", typeof(FitField_UInt16z))},
                        { 8, new FieldDefinition("custom_wheelsize", typeof(FitField_UInt16))},
                        { 9, new FieldDefinition("auto_wheelsize", typeof(FitField_UInt16))},
                        { 10, new FieldDefinition("bike_weight", typeof(FitField_UInt16))},
                        { 11, new FieldDefinition("power_cal_factor", typeof(FitField_UInt16))},
                        { 12, new FieldDefinition("auto_wheel_cal", typeof(FitField_Bool))},
                        { 13, new FieldDefinition("auto_power_zero", typeof(FitField_Bool))},
                        { 14, new FieldDefinition("id", typeof(FitField_UInt8))},
                        { 15, new FieldDefinition("spd_enabled", typeof(FitField_Bool))},
                        { 16, new FieldDefinition("cad_enabled", typeof(FitField_Bool))},
                        { 17, new FieldDefinition("spdcad_enabled", typeof(FitField_Bool))},
                        { 18, new FieldDefinition("power_enabled", typeof(FitField_Bool))},
                        { 19, new FieldDefinition("crank_length", typeof(FitField_UInt8))},
                        { 20, new FieldDefinition("enabled", typeof(FitField_Bool))},
                        { 21, new FieldDefinition("bike_spd_ant_id_trans_type", typeof(FitField_UInt8z))},
                        { 22, new FieldDefinition("bike_cad_ant_id_trans_type", typeof(FitField_UInt8z))},
                        { 23, new FieldDefinition("bike_spdcad_ant_id_trans_type", typeof(FitField_UInt8z))},
                        { 24, new FieldDefinition("bike_power_ant_id_trans_type", typeof(FitField_UInt8z))},
                        { 37, new FieldDefinition("odometer_rollover", typeof(FitField_UInt8))},
                        { 38, new FieldDefinition("front_gear_num", typeof(FitField_UInt8z))},
                        { 39, new FieldDefinition("front_gear", typeof(FitField_UInt8z))},
                        { 40, new FieldDefinition("rear_gear_num", typeof(FitField_UInt8z))},
                        { 41, new FieldDefinition("rear_gear", typeof(FitField_UInt8z))},
                        { 25, new FieldDefinition("fork_id", typeof(FitField_String))}, //UNDOCUMENTED
                        { 26, new FieldDefinition("fork_pressure", typeof(FitField_UInt16))}, //UNDOCUMENTED
                        { 27, new FieldDefinition("fork_sag", typeof(FitField_UInt8))}, //UNDOCUMENTED
                        { 28, new FieldDefinition("fork_rebound", typeof(FitField_UInt8))}, //UNDOCUMENTED
                        { 29, new FieldDefinition("shock_id", typeof(FitField_String))}, //UNDOCUMENTED
                        { 30, new FieldDefinition("shock_pressure", typeof(FitField_UInt16))}, //UNDOCUMENTED
                        { 31, new FieldDefinition("shock_sag", typeof(FitField_UInt8))}, //UNDOCUMENTED
                        { 32, new FieldDefinition("shock_rebound", typeof(FitField_UInt8))}, //UNDOCUMENTED
                        { 33, new FieldDefinition("lever_ratio_a", typeof(FitField_UInt16))}, //UNDOCUMENTED
                        { 34, new FieldDefinition("auto_crank_length", typeof(FitField_Enum))}, //UNDOCUMENTED
                        { 35, new FieldDefinition("color", typeof(FitField_UInt8))}, //UNDOCUMENTED
                        { 36, new FieldDefinition("bike_image", typeof(FitField_Enum))}, //UNDOCUMENTED
                    }
                )
            },
            #endregion

            #region Sport Settings File Messages
            { 
                MessageNumber.ZonesTarget,
                new MessageDefinition
                (
                    "ZonesTarget",
                    typeof(DataMessage),
                    new Dictionary<byte,FieldDefinition>()
                    {
                        { 1, new FieldDefinition("max_heart_rate", typeof(FitField_UInt8))},
                        { 2, new FieldDefinition("threshold_heart_rate", typeof(FitField_UInt8))},
                        { 3, new FieldDefinition("functional_threshold_power", typeof(FitField_UInt16))},
                        { 5, new FieldDefinition("hr_calc_type", typeof(FitField_HrZoneCalc))},
                        { 7, new FieldDefinition("pwr_calc_type", typeof(FitField_PwrZoneCalc))},
                        { 8, new FieldDefinition("max_met", typeof(FitField_UInt16))}, //UNDOCUMENTED
                    }
                )
            },
            { 
                MessageNumber.Sport,
                new MessageDefinition
                (
                    "Sport",
                    typeof(DataMessage),
                    new Dictionary<byte,FieldDefinition>()
                    {
                        { 0, new FieldDefinition("sport", typeof(FitField_Sport))},
                        { 1, new FieldDefinition("sub_sport", typeof(FitField_SubSport))},
                        { 3, new FieldDefinition("name", typeof(FitField_String))},
                        { 4, new FieldDefinition("calorie_sources", typeof(FitField_UInt16))}, //UNDOCUMENTED
                        { 5, new FieldDefinition("enabled", typeof(FitField_Enum))}, //UNDOCUMENTED
                        { 6, new FieldDefinition("sport_event", typeof(FitField_Enum))}, //UNDOCUMENTED
                        { 7, new FieldDefinition("background_index", typeof(FitField_UInt8))}, //UNDOCUMENTED
                        { 8, new FieldDefinition("current_map_profile", typeof(FitField_UInt8))}, //UNDOCUMENTED
                        { 9, new FieldDefinition("current_routing_profile", typeof(FitField_UInt8))}, //UNDOCUMENTED

                    }
                )
            },
            { 
                MessageNumber.HrZone,
                new MessageDefinition
                (
                    "HrZone",
                    typeof(DataMessage),
                    new Dictionary<byte,FieldDefinition>()
                    {
                        { 254, new FieldDefinition("message_index", typeof(FitField_MessageIndex))},
                        { 1, new FieldDefinition("high_bpm", typeof(FitField_UInt8))},
                        { 2, new FieldDefinition("name", typeof(FitField_String))},
                    }
                )
            },
            { 
                MessageNumber.SpeedZone,
                new MessageDefinition
                (
                    "SpeedZone",
                    typeof(DataMessage),
                    new Dictionary<byte,FieldDefinition>()
                    {
                        { 254, new FieldDefinition("message_index", typeof(FitField_MessageIndex))},
                        { 0, new FieldDefinition("high_value", typeof(FitField_UInt8))},
                        { 1, new FieldDefinition("name", typeof(FitField_String))},
                    }
                )
            },
            { 
                MessageNumber.CadenceZone,
                new MessageDefinition
                (
                    "CadenceZone",
                    typeof(DataMessage),
                    new Dictionary<byte,FieldDefinition>()
                    {
                        { 254, new FieldDefinition("message_index", typeof(FitField_MessageIndex))},
                        { 0, new FieldDefinition("high_value", typeof(FitField_UInt8))},
                        { 1, new FieldDefinition("name", typeof(FitField_String))},
                    }
                )
            },
            { 
                MessageNumber.PowerZone,
                new MessageDefinition
                (
                    "PowerZone",
                    typeof(DataMessage),
                    new Dictionary<byte,FieldDefinition>()
                    {
                        { 254, new FieldDefinition("message_index", typeof(FitField_MessageIndex))},
                        { 1, new FieldDefinition("high_value", typeof(FitField_UInt16))},
                        { 2, new FieldDefinition("name", typeof(FitField_String))},

                    }
                )
            },
            { 
                MessageNumber.MetZone,
                new MessageDefinition
                (
                    "MetZone",
                    typeof(DataMessage),
                    new Dictionary<byte,FieldDefinition>()
                    {
                        { 254, new FieldDefinition("message_index", typeof(FitField_MessageIndex))},
                        { 1, new FieldDefinition("high_bpm", typeof(FitField_UInt8))},
                        { 2, new FieldDefinition("calories", typeof(FitField_UInt16))},
                        { 3, new FieldDefinition("fat_calories", typeof(FitField_UInt8))},
                    }
                )
            },
            #endregion

            #region Goals File Messages
            { 
                MessageNumber.Goal,
                new MessageDefinition
                (
                    "Goal",
                    typeof(DataMessage),
                    new Dictionary<byte,FieldDefinition>()
                    {
                        { 254, new FieldDefinition("message_index", typeof(FitField_MessageIndex))},
                        { 0, new FieldDefinition("sport", typeof(FitField_Sport))},
                        { 1, new FieldDefinition("sub_sport", typeof(FitField_SubSport))},
                        { 2, new FieldDefinition("start_date", typeof(FitField_DateTime))},
                        { 3, new FieldDefinition("end_date", typeof(FitField_DateTime))},
                        { 4, new FieldDefinition("type", typeof(FitField_Goal))},
                        { 5, new FieldDefinition("value", typeof(FitField_UInt32))},
                        { 6, new FieldDefinition("repeat", typeof(FitField_Bool))},
                        { 7, new FieldDefinition("target_value", typeof(FitField_UInt32))},
                        { 8, new FieldDefinition("recurrence", typeof(FitField_GoalRecurrence))},
                        { 9, new FieldDefinition("recurrence_value", typeof(FitField_UInt16))},
                        { 10, new FieldDefinition("enabled", typeof(FitField_Bool))},

                    }
                )
            },
            #endregion

            #region Activity File Messages
            {
                MessageNumber.Activity,
                new MessageDefinition
                (
                    "Activity",
                    typeof(ActivityMessage),
                    new Dictionary<byte,FieldDefinition>()
                    {
                        { 253, new FieldDefinition("timestamp",        typeof(FitField_DateTime)) },
                        { 0,   new FieldDefinition("total_timer_time", typeof(FitField_UInt32))   },
                        { 1,   new FieldDefinition("num_sessions",     typeof(FitField_UInt16))   },
                        { 2,   new FieldDefinition("type",             typeof(FitField_Activity)) },
                        { 3,   new FieldDefinition("event",            typeof(FitField_Event))    },
                        { 4,   new FieldDefinition("event_type",       typeof(FitField_EventType))     },
                        { 5,   new FieldDefinition("local_timestamp",  typeof(FitField_LocalDateTime)) },
                        { 6,   new FieldDefinition("event_group",      typeof(FitField_UInt8))    }
                    }
                )
            },
            { 
                MessageNumber.Session,
                new MessageDefinition
                (
                    "Session",
                    typeof(SessionMessage),
                    new Dictionary<byte,FieldDefinition>()
                    {
                        { 254, new FieldDefinition("message_index", typeof(FitField_MessageIndex))},
                        { 253, new FieldDefinition("timestamp", typeof(FitField_DateTime))},
                        { 0, new FieldDefinition("event", typeof(FitField_Event))},
                        { 1, new FieldDefinition("event_type", typeof(FitField_EventType))},
                        { 2, new FieldDefinition("start_time", typeof(FitField_DateTime))},
                        { 3, new FieldDefinition("start_position_lat", typeof(FitField_SInt32))},
                        { 4, new FieldDefinition("start_position_long", typeof(FitField_SInt32))},
                        { 5, new FieldDefinition("sport", typeof(FitField_Sport))},
                        { 6, new FieldDefinition("sub_sport", typeof(FitField_SubSport))},
                        { 7, new FieldDefinition("total_elapsed_time", typeof(FitField_UInt32))},
                        { 8, new FieldDefinition("total_timer_time", typeof(FitField_UInt32))},
                        { 9, new FieldDefinition("total_distance", typeof(FitField_UInt32))},
                        { 10, new FieldDefinition("total_cycles", typeof(FitField_UInt32))},
                        { 11, new FieldDefinition("total_calories", typeof(FitField_UInt16))},
                        { 13, new FieldDefinition("total_fat_calories", typeof(FitField_UInt16))},
                        { 14, new FieldDefinition("avg_speed", typeof(FitField_UInt16))},
                        { 15, new FieldDefinition("max_speed", typeof(FitField_UInt16))},
                        { 16, new FieldDefinition("avg_heart_rate", typeof(FitField_UInt8))},
                        { 17, new FieldDefinition("max_heart_rate", typeof(FitField_UInt8))},
                        { 18, new FieldDefinition("avg_cadence", typeof(FitField_UInt8))},
                        { 19, new FieldDefinition("max_cadence", typeof(FitField_UInt8))},
                        { 20, new FieldDefinition("avg_power", typeof(FitField_UInt16))},
                        { 21, new FieldDefinition("max_power", typeof(FitField_UInt16))},
                        { 22, new FieldDefinition("total_ascent", typeof(FitField_UInt16))},
                        { 23, new FieldDefinition("total_descent", typeof(FitField_UInt16))},
                        { 24, new FieldDefinition("total_training_effect", typeof(FitField_UInt8))},
                        { 25, new FieldDefinition("first_lap_index", typeof(FitField_UInt16))},
                        { 26, new FieldDefinition("num_laps", typeof(FitField_UInt16))},
                        { 27, new FieldDefinition("event_group", typeof(FitField_UInt8))},
                        { 28, new FieldDefinition("trigger", typeof(FitField_SessionTrigger))},
                        { 29, new FieldDefinition("nec_lat", typeof(FitField_SInt32))},
                        { 30, new FieldDefinition("nec_long", typeof(FitField_SInt32))},
                        { 31, new FieldDefinition("swc_lat", typeof(FitField_SInt32))},
                        { 32, new FieldDefinition("swc_long", typeof(FitField_SInt32))},
                        { 34, new FieldDefinition("normalized_power", typeof(FitField_UInt16))},
                        { 35, new FieldDefinition("training_stress_score", typeof(FitField_UInt16))},
                        { 36, new FieldDefinition("intensity_factor", typeof(FitField_UInt16))},
                        { 37, new FieldDefinition("left_right_balance", typeof(FitField_LeftRightBalance100))},
                        { 41, new FieldDefinition("avg_stroke_count", typeof(FitField_UInt32))},
                        { 42, new FieldDefinition("avg_stroke_distance", typeof(FitField_UInt16))},
                        { 43, new FieldDefinition("swim_stroke", typeof(FitField_SwimStroke))},
                        { 44, new FieldDefinition("pool_length", typeof(FitField_UInt16))},
                        { 46, new FieldDefinition("pool_length_unit", typeof(FitField_DisplayMeasure))},
                        { 47, new FieldDefinition("num_active_lengths", typeof(FitField_UInt16))},
                        { 48, new FieldDefinition("total_work", typeof(FitField_UInt32))},
                        { 49, new FieldDefinition("avg_altitude", typeof(FitField_UInt16))},
                        { 50, new FieldDefinition("max_altitude", typeof(FitField_UInt16))},
                        { 51, new FieldDefinition("gps_accuracy", typeof(FitField_UInt8))},
                        { 52, new FieldDefinition("avg_grade", typeof(FitField_SInt16))},
                        { 53, new FieldDefinition("avg_pos_grade", typeof(FitField_SInt16))},
                        { 54, new FieldDefinition("avg_neg_grade", typeof(FitField_SInt16))},
                        { 55, new FieldDefinition("max_pos_grade", typeof(FitField_SInt16))},
                        { 56, new FieldDefinition("max_neg_grade", typeof(FitField_SInt16))},
                        { 57, new FieldDefinition("avg_temperature", typeof(FitField_SInt8))},
                        { 58, new FieldDefinition("max_temperature", typeof(FitField_SInt8))},
                        { 59, new FieldDefinition("total_moving_time", typeof(FitField_UInt32))},
                        { 60, new FieldDefinition("avg_pos_vertical_speed", typeof(FitField_SInt16))},
                        { 61, new FieldDefinition("avg_neg_vertical_speed", typeof(FitField_SInt16))},
                        { 62, new FieldDefinition("max_pos_vertical_speed", typeof(FitField_SInt16))},
                        { 63, new FieldDefinition("max_neg_vertical_speed", typeof(FitField_SInt16))},
                        { 64, new FieldDefinition("min_heart_rate", typeof(FitField_UInt8))},
                        { 65, new FieldDefinition("time_in_hr_zone", typeof(FitField_UInt32))},
                        { 66, new FieldDefinition("time_in_speed_zone", typeof(FitField_UInt32))},
                        { 67, new FieldDefinition("time_in_cadence_zone", typeof(FitField_UInt32))},
                        { 68, new FieldDefinition("time_in_power_zone", typeof(FitField_UInt32))},
                        { 69, new FieldDefinition("avg_lap_time", typeof(FitField_UInt32))},
                        { 70, new FieldDefinition("best_lap_index", typeof(FitField_UInt16))},
                        { 71, new FieldDefinition("min_altitude", typeof(FitField_UInt16))},
                        { 82, new FieldDefinition("player_score", typeof(FitField_UInt16))},
                        { 83, new FieldDefinition("opponent_score", typeof(FitField_UInt16))},
                        { 84, new FieldDefinition("opponent_name", typeof(FitField_String))},
                        { 85, new FieldDefinition("stroke_count", typeof(FitField_UInt16))},
                        { 86, new FieldDefinition("zone_count", typeof(FitField_UInt16))},
                        { 87, new FieldDefinition("max_ball_speed", typeof(FitField_UInt16))},
                        { 88, new FieldDefinition("avg_ball_speed", typeof(FitField_UInt16))},
                        { 89, new FieldDefinition("avg_vertical_oscillation", typeof(FitField_UInt16))},
                        { 90, new FieldDefinition("avg_stance_time_percent", typeof(FitField_UInt16))},
                        { 91, new FieldDefinition("avg_stance_time", typeof(FitField_UInt16))},
                        { 92, new FieldDefinition("avg_fractional_cadence", typeof(FitField_UInt8))},
                        { 93, new FieldDefinition("max_fractional_cadence", typeof(FitField_UInt8))},
                        { 94, new FieldDefinition("total_fractional_cycles", typeof(FitField_UInt8))},
                        { 95, new FieldDefinition("avg_total_hemoglobin_conc", typeof(FitField_UInt16))},
                        { 96, new FieldDefinition("min_total_hemoglobin_conc", typeof(FitField_UInt16))},
                        { 97, new FieldDefinition("max_total_hemoglobin_conc", typeof(FitField_UInt16))},
                        { 98, new FieldDefinition("avg_saturated_hemoglobin_percent", typeof(FitField_UInt16))},
                        { 99, new FieldDefinition("min_saturated_hemoglobin_percent", typeof(FitField_UInt16))},
                        { 100, new FieldDefinition("max_saturated_hemoglobin_percent", typeof(FitField_UInt16))},
                        { 101, new FieldDefinition("avg_left_torque_effectiveness", typeof(FitField_UInt8))},
                        { 102, new FieldDefinition("avg_right_torque_effectiveness", typeof(FitField_UInt8))},
                        { 103, new FieldDefinition("avg_left_pedal_smoothness", typeof(FitField_UInt8))},
                        { 104, new FieldDefinition("avg_right_pedal_smoothness", typeof(FitField_UInt8))},
                        { 105, new FieldDefinition("avg_combined_pedal_smoothness", typeof(FitField_UInt8))},
                        { 33, new FieldDefinition("num_lengths", typeof(FitField_UInt16))}, //UNDOCUMENTED
                        { 38, new FieldDefinition("end_position_lat", typeof(FitField_SInt32))}, //UNDOCUMENTED
                        { 39, new FieldDefinition("end_position_long", typeof(FitField_SInt32))}, //UNDOCUMENTED
                        { 45, new FieldDefinition("threshold_power", typeof(FitField_UInt16))}, //UNDOCUMENTED
                        { 72, new FieldDefinition("reserved_1", typeof(FitField_UInt8))}, //UNDOCUMENTED
                        { 73, new FieldDefinition("reserved_2", typeof(FitField_UInt8))}, //UNDOCUMENTED
                        { 74, new FieldDefinition("reserved_3", typeof(FitField_UInt8))}, //UNDOCUMENTED
                        { 75, new FieldDefinition("reserved_4", typeof(FitField_UInt8))}, //UNDOCUMENTED
                        { 76, new FieldDefinition("reserved_5", typeof(FitField_UInt8))}, //UNDOCUMENTED
                        { 77, new FieldDefinition("reserved_6", typeof(FitField_UInt8))}, //UNDOCUMENTED
                        { 78, new FieldDefinition("active_time", typeof(FitField_UInt32))}, //UNDOCUMENTED
                        { 79, new FieldDefinition("avg_strokes_per_length", typeof(FitField_UInt16))}, //UNDOCUMENTED
                        { 80, new FieldDefinition("avg_swolf", typeof(FitField_UInt16))}, //UNDOCUMENTED
                        { 81, new FieldDefinition("sport_event", typeof(FitField_Enum))}, //UNDOCUMENTED

    
                    }
                )
            },
            { 
                MessageNumber.Lap,
                new MessageDefinition
                (
                    "Lap",
                    typeof(LapMessage),
                    new Dictionary<byte,FieldDefinition>()
                    {
                        { 254, new FieldDefinition("message_index", typeof(FitField_MessageIndex))},
                        { 253, new FieldDefinition("timestamp", typeof(FitField_DateTime))},
                        { 0, new FieldDefinition("event", typeof(FitField_Event))},
                        { 1, new FieldDefinition("event_type", typeof(FitField_EventType))},
                        { 2, new FieldDefinition("start_time", typeof(FitField_DateTime))},
                        { 3, new FieldDefinition("start_position_lat", typeof(FitField_SInt32))},
                        { 4, new FieldDefinition("start_position_long", typeof(FitField_SInt32))},
                        { 5, new FieldDefinition("end_position_lat", typeof(FitField_SInt32))},
                        { 6, new FieldDefinition("end_position_long", typeof(FitField_SInt32))},
                        { 7, new FieldDefinition("total_elapsed_time", typeof(FitField_UInt32))},
                        { 8, new FieldDefinition("total_timer_time", typeof(FitField_UInt32))},
                        { 9, new FieldDefinition("total_distance", typeof(FitField_UInt32))},
                        { 10, new FieldDefinition("total_cycles", typeof(FitField_UInt32))},
                        { 11, new FieldDefinition("total_calories", typeof(FitField_UInt16))},
                        { 12, new FieldDefinition("total_fat_calories", typeof(FitField_UInt16))},
                        { 13, new FieldDefinition("avg_speed", typeof(FitField_UInt16))},
                        { 14, new FieldDefinition("max_speed", typeof(FitField_UInt16))},
                        { 15, new FieldDefinition("avg_heart_rate", typeof(FitField_UInt8))},
                        { 16, new FieldDefinition("max_heart_rate", typeof(FitField_UInt8))},
                        { 17, new FieldDefinition("avg_cadence", typeof(FitField_UInt8))},
                        { 18, new FieldDefinition("max_cadence", typeof(FitField_UInt8))},
                        { 19, new FieldDefinition("avg_power", typeof(FitField_UInt16))},
                        { 20, new FieldDefinition("max_power", typeof(FitField_UInt16))},
                        { 21, new FieldDefinition("total_ascent", typeof(FitField_UInt16))},
                        { 22, new FieldDefinition("total_descent", typeof(FitField_UInt16))},
                        { 23, new FieldDefinition("intensity", typeof(FitField_Intensity))},
                        { 24, new FieldDefinition("lap_trigger", typeof(FitField_LapTrigger))},
                        { 25, new FieldDefinition("sport", typeof(FitField_Sport))},
                        { 26, new FieldDefinition("event_group", typeof(FitField_UInt8))},
                        { 32, new FieldDefinition("num_lengths", typeof(FitField_UInt16))},
                        { 33, new FieldDefinition("normalized_power", typeof(FitField_UInt16))},
                        { 34, new FieldDefinition("left_right_balance", typeof(FitField_LeftRightBalance100))},
                        { 35, new FieldDefinition("first_length_index", typeof(FitField_UInt16))},
                        { 37, new FieldDefinition("avg_stroke_distance", typeof(FitField_UInt16))},
                        { 38, new FieldDefinition("swim_stroke", typeof(FitField_SwimStroke))},
                        { 39, new FieldDefinition("sub_sport", typeof(FitField_SubSport))},
                        { 40, new FieldDefinition("num_active_lengths", typeof(FitField_UInt16))},
                        { 41, new FieldDefinition("total_work", typeof(FitField_UInt32))},
                        { 42, new FieldDefinition("avg_altitude", typeof(FitField_UInt16))},
                        { 43, new FieldDefinition("max_altitude", typeof(FitField_UInt16))},
                        { 44, new FieldDefinition("gps_accuracy", typeof(FitField_UInt8))},
                        { 45, new FieldDefinition("avg_grade", typeof(FitField_SInt16))},
                        { 46, new FieldDefinition("avg_pos_grade", typeof(FitField_SInt16))},
                        { 47, new FieldDefinition("avg_neg_grade", typeof(FitField_SInt16))},
                        { 48, new FieldDefinition("max_pos_grade", typeof(FitField_SInt16))},
                        { 49, new FieldDefinition("max_neg_grade", typeof(FitField_SInt16))},
                        { 50, new FieldDefinition("avg_temperature", typeof(FitField_SInt8))},
                        { 51, new FieldDefinition("max_temperature", typeof(FitField_SInt8))},
                        { 52, new FieldDefinition("total_moving_time", typeof(FitField_UInt32))},
                        { 53, new FieldDefinition("avg_pos_vertical_speed", typeof(FitField_SInt16))},
                        { 54, new FieldDefinition("avg_neg_vertical_speed", typeof(FitField_SInt16))},
                        { 55, new FieldDefinition("max_pos_vertical_speed", typeof(FitField_SInt16))},
                        { 56, new FieldDefinition("max_neg_vertical_speed", typeof(FitField_SInt16))},
                        { 57, new FieldDefinition("time_in_hr_zone", typeof(FitField_UInt32))},
                        { 58, new FieldDefinition("time_in_speed_zone", typeof(FitField_UInt32))},
                        { 59, new FieldDefinition("time_in_cadence_zone", typeof(FitField_UInt32))},
                        { 60, new FieldDefinition("time_in_power_zone", typeof(FitField_UInt32))},
                        { 61, new FieldDefinition("repetition_num", typeof(FitField_UInt16))},
                        { 62, new FieldDefinition("min_altitude", typeof(FitField_UInt16))},
                        { 63, new FieldDefinition("min_heart_rate", typeof(FitField_UInt8))},
                        { 71, new FieldDefinition("wkt_step_index", typeof(FitField_MessageIndex))},
                        { 74, new FieldDefinition("opponent_score", typeof(FitField_UInt16))},
                        { 75, new FieldDefinition("stroke_count", typeof(FitField_UInt16))},
                        { 76, new FieldDefinition("zone_count", typeof(FitField_UInt16))},
                        { 77, new FieldDefinition("avg_vertical_oscillation", typeof(FitField_UInt16))},
                        { 78, new FieldDefinition("avg_stance_time_percent", typeof(FitField_UInt16))},
                        { 79, new FieldDefinition("avg_stance_time", typeof(FitField_UInt16))},
                        { 80, new FieldDefinition("avg_fractional_cadence", typeof(FitField_UInt8))},
                        { 81, new FieldDefinition("max_fractional_cadence", typeof(FitField_UInt8))},
                        { 82, new FieldDefinition("total_fractional_cycles", typeof(FitField_UInt8))},
                        { 83, new FieldDefinition("player_score", typeof(FitField_UInt16))},
                        { 84, new FieldDefinition("avg_total_hemoglobin_conc", typeof(FitField_UInt16))},
                        { 85, new FieldDefinition("min_total_hemoglobin_conc", typeof(FitField_UInt16))},
                        { 86, new FieldDefinition("max_total_hemoglobin_conc", typeof(FitField_UInt16))},
                        { 87, new FieldDefinition("avg_saturated_hemoglobin_percent", typeof(FitField_UInt16))},
                        { 88, new FieldDefinition("min_saturated_hemoglobin_percent", typeof(FitField_UInt16))},
                        { 89, new FieldDefinition("max_saturated_hemoglobin_percent", typeof(FitField_UInt16))},
                        { 91, new FieldDefinition("avg_left_torque_effectiveness", typeof(FitField_UInt8))},
                        { 92, new FieldDefinition("avg_right_torque_effectiveness", typeof(FitField_UInt8))},
                        { 93, new FieldDefinition("avg_left_pedal_smoothness", typeof(FitField_UInt8))},
                        { 94, new FieldDefinition("avg_right_pedal_smoothness", typeof(FitField_UInt8))},
                        { 95, new FieldDefinition("avg_combined_pedal_smoothness", typeof(FitField_UInt8))},
                        { 27, new FieldDefinition("nec_lat", typeof(FitField_SInt32))}, //UNDOCUMENTED
                        { 28, new FieldDefinition("nec_long", typeof(FitField_SInt32))}, //UNDOCUMENTED
                        { 29, new FieldDefinition("swc_lat", typeof(FitField_SInt32))}, //UNDOCUMENTED
                        { 30, new FieldDefinition("swc_long", typeof(FitField_SInt32))}, //UNDOCUMENTED
                        { 31, new FieldDefinition("name", typeof(FitField_String))}, //UNDOCUMENTED
                        { 64, new FieldDefinition("reserved_1", typeof(FitField_UInt8))}, //UNDOCUMENTED
                        { 65, new FieldDefinition("reserved_2", typeof(FitField_UInt8))}, //UNDOCUMENTED
                        { 66, new FieldDefinition("reserved_3", typeof(FitField_UInt8))}, //UNDOCUMENTED
                        { 67, new FieldDefinition("reserved_4", typeof(FitField_UInt8))}, //UNDOCUMENTED
                        { 68, new FieldDefinition("reserved_5", typeof(FitField_UInt8))}, //UNDOCUMENTED
                        { 69, new FieldDefinition("reserved_6", typeof(FitField_UInt8))}, //UNDOCUMENTED
                        { 70, new FieldDefinition("active_time", typeof(FitField_UInt32))}, //UNDOCUMENTED
                        //{ 72, new FieldDefinition("avg_strokes_per_length", typeof(FitField_UInt16))}, //UNDOCUMENTED
                        { 73, new FieldDefinition("avg_swolf", typeof(FitField_UInt16))}, //UNDOCUMENTED
                        //{ 72, new FieldDefinition("sport_event", typeof(FitField_Enum))}, //UNDOCUMENTED

                    }
                )
            },
            { 
                MessageNumber.Length,
                new MessageDefinition
                (
                    "Length",
                    typeof(LengthMessage),
                    new Dictionary<byte,FieldDefinition>()
                    {
                        { 254, new FieldDefinition("message_index", typeof(FitField_MessageIndex))},
                        { 253, new FieldDefinition("timestamp", typeof(FitField_DateTime))},
                        { 0, new FieldDefinition("event", typeof(FitField_Event))},
                        { 1, new FieldDefinition("event_type", typeof(FitField_EventType))},
                        { 2, new FieldDefinition("start_time", typeof(FitField_DateTime))},
                        { 3, new FieldDefinition("total_elapsed_time", typeof(FitField_UInt32))},
                        { 4, new FieldDefinition("total_timer_time", typeof(FitField_UInt32))},
                        { 5, new FieldDefinition("total_strokes", typeof(FitField_UInt16))},
                        { 6, new FieldDefinition("avg_speed", typeof(FitField_UInt16))},
                        { 7, new FieldDefinition("swim_stroke", typeof(FitField_SwimStroke))},
                        { 9, new FieldDefinition("avg_swimming_cadence", typeof(FitField_UInt8))},
                        { 10, new FieldDefinition("event_group", typeof(FitField_UInt8))},
                        { 11, new FieldDefinition("total_calories", typeof(FitField_UInt16))},
                        { 12, new FieldDefinition("length_type", typeof(FitField_LengthType))},
                        { 18, new FieldDefinition("player_score", typeof(FitField_UInt16))},
                        { 19, new FieldDefinition("opponent_score", typeof(FitField_UInt16))},
                        { 20, new FieldDefinition("stroke_count", typeof(FitField_UInt16))},
                        { 21, new FieldDefinition("zone_count", typeof(FitField_UInt16))},
                        { 13, new FieldDefinition("reserved_1", typeof(FitField_UInt8))}, //UNDOCUMENTED
                        { 14, new FieldDefinition("reserved_2", typeof(FitField_UInt8))}, //UNDOCUMENTED
                        { 15, new FieldDefinition("reserved_3", typeof(FitField_UInt8))}, //UNDOCUMENTED
                        { 16, new FieldDefinition("reserved_4", typeof(FitField_UInt8))}, //UNDOCUMENTED
                        { 17, new FieldDefinition("reserved_5", typeof(FitField_UInt8))}, //UNDOCUMENTED

                    }
                )
            },
            { 
                MessageNumber.Record,
                new MessageDefinition
                (
                    "Record",
                    typeof(RecordMessage),
                    new Dictionary<byte,FieldDefinition>()
                    {
                        { 253, new FieldDefinition("timestamp", typeof(FitField_DateTime))},
                        { 0, new FieldDefinition("position_lat", typeof(FitField_SInt32))},
                        { 1, new FieldDefinition("position_long", typeof(FitField_SInt32))},
                        { 2, new FieldDefinition("altitude", typeof(FitField_UInt16))},
                        { 3, new FieldDefinition("heart_rate", typeof(FitField_UInt8))},
                        { 4, new FieldDefinition("cadence", typeof(FitField_UInt8))},
                        { 5, new FieldDefinition("distance", typeof(FitField_UInt32))},
                        { 6, new FieldDefinition("speed", typeof(FitField_UInt16))},
                        { 7, new FieldDefinition("power", typeof(FitField_UInt16))},
                        { 8, new FieldDefinition("compressed_speed_distance", typeof(FitField_Byte))},
                        { 9, new FieldDefinition("grade", typeof(FitField_SInt16))},
                        { 10, new FieldDefinition("resistance", typeof(FitField_UInt8))},
                        { 11, new FieldDefinition("time_from_course", typeof(FitField_SInt32))},
                        { 12, new FieldDefinition("cycle_length", typeof(FitField_UInt8))},
                        { 13, new FieldDefinition("temperature", typeof(FitField_SInt8))},
                        { 17, new FieldDefinition("speed_1s", typeof(FitField_UInt8))},
                        { 18, new FieldDefinition("cycles", typeof(FitField_UInt8))},
                        { 19, new FieldDefinition("total_cycles", typeof(FitField_UInt32))},
                        { 28, new FieldDefinition("compressed_accumulated_power", typeof(FitField_UInt16))},
                        { 29, new FieldDefinition("accumulated_power", typeof(FitField_UInt32))},
                        { 30, new FieldDefinition("left_right_balance", typeof(FitField_LeftRightBalance))},
                        { 31, new FieldDefinition("gps_accuracy", typeof(FitField_UInt8))},
                        { 32, new FieldDefinition("vertical_speed", typeof(FitField_SInt16))},
                        { 33, new FieldDefinition("calories", typeof(FitField_UInt16))},
                        { 39, new FieldDefinition("vertical_oscillation", typeof(FitField_UInt16))},
                        { 40, new FieldDefinition("stance_time_percent", typeof(FitField_UInt16))},
                        { 41, new FieldDefinition("stance_time", typeof(FitField_UInt16))},
                        { 42, new FieldDefinition("activity_type", typeof(FitField_ActivityType))},
                        { 43, new FieldDefinition("left_torque_effectiveness", typeof(FitField_UInt8))},
                        { 44, new FieldDefinition("right_torque_effectiveness", typeof(FitField_UInt8))},
                        { 45, new FieldDefinition("left_pedal_smoothness", typeof(FitField_UInt8))},
                        { 46, new FieldDefinition("right_pedal_smoothness", typeof(FitField_UInt8))},
                        { 47, new FieldDefinition("combined_pedal_smoothness", typeof(FitField_UInt8))},
                        { 48, new FieldDefinition("time128", typeof(FitField_UInt8))},
                        { 49, new FieldDefinition("stroke_type", typeof(FitField_StrokeType))},
                        { 50, new FieldDefinition("zone", typeof(FitField_UInt8))},
                        { 51, new FieldDefinition("ball_speed", typeof(FitField_UInt16))},
                        { 52, new FieldDefinition("cadence256", typeof(FitField_UInt16))},
                        { 53, new FieldDefinition("fractional_cadence",typeof(FitField_UInt8))},
                        { 54, new FieldDefinition("total_hemoglobin_conc", typeof(FitField_UInt16))},
                        { 55, new FieldDefinition("total_hemoglobin_conc_min", typeof(FitField_UInt16))},
                        { 56, new FieldDefinition("total_hemoglobin_conc_max", typeof(FitField_UInt16))},
                        { 57, new FieldDefinition("saturated_hemoglobin_percent", typeof(FitField_UInt16))},
                        { 58, new FieldDefinition("saturated_hemoglobin_percent_min", typeof(FitField_UInt16))},
                        { 59, new FieldDefinition("saturated_hemoglobin_percent_max", typeof(FitField_UInt16))},
                        { 62, new FieldDefinition("device_index", typeof(FitField_DeviceIndex))},
                        { 14, new FieldDefinition("timer_time", typeof(FitField_UInt32))}, //UNDOCUMENTED
                        { 15, new FieldDefinition("elapsed_time", typeof(FitField_UInt32))}, //UNDOCUMENTED
                        { 16, new FieldDefinition("moving_time", typeof(FitField_UInt32))}, //UNDOCUMENTED
                        { 20, new FieldDefinition("heart_rate_max", typeof(FitField_UInt8))}, //UNDOCUMENTED
                        { 21, new FieldDefinition("heart_rate_min", typeof(FitField_UInt8))}, //UNDOCUMENTED
                        { 22, new FieldDefinition("cadence_max", typeof(FitField_UInt8))}, //UNDOCUMENTED
                        { 23, new FieldDefinition("cadence_min", typeof(FitField_UInt8))}, //UNDOCUMENTED
                        { 24, new FieldDefinition("speed_max", typeof(FitField_UInt16))}, //UNDOCUMENTED
                        { 25, new FieldDefinition("speed_min", typeof(FitField_UInt16))}, //UNDOCUMENTED
                        { 26, new FieldDefinition("power_max", typeof(FitField_UInt16))}, //UNDOCUMENTED
                        { 27, new FieldDefinition("power_min", typeof(FitField_UInt16))}, //UNDOCUMENTED
                        { 34, new FieldDefinition("reserved_1", typeof(FitField_UInt8))}, //UNDOCUMENTED
                        { 35, new FieldDefinition("reserved_2", typeof(FitField_UInt8))}, //UNDOCUMENTED
                        { 36, new FieldDefinition("reserved_3", typeof(FitField_UInt8))}, //UNDOCUMENTED
                        { 37, new FieldDefinition("reserved_4", typeof(FitField_UInt8))}, //UNDOCUMENTED
                        { 38, new FieldDefinition("reserved_5", typeof(FitField_UInt8))}, //UNDOCUMENTED
                    }
                )
            },
            { 
                MessageNumber.Event,
                new MessageDefinition
                (
                    "Event",
                    typeof(EventMessage),
                    new Dictionary<byte,FieldDefinition>()
                    {
                        { 253, new FieldDefinition("timestamp", typeof(FitField_DateTime))},
                        { 0,   new FieldDefinition("event", typeof(FitField_Event))},
                        { 1,   new FieldDefinition("event_type", typeof(FitField_EventType))},
                        { 2,   new FieldDefinition("data16", typeof(FitField_UInt16))},
                        { 3,   new FieldDefinition("data", typeof(FitField_UInt32))},
                        { 4,   new FieldDefinition("event_group", typeof(FitField_UInt8))},
                        { 7	,  new FieldDefinition("score", typeof(FitField_UInt16))},
                        { 8	,  new FieldDefinition("opponent_score", typeof(FitField_UInt16))},
                        { 9	,  new FieldDefinition("front_gear_num", typeof(FitField_UInt8z))},
                        { 10,  new FieldDefinition("front_gear", typeof(FitField_UInt8z))},
                        { 11,  new FieldDefinition("rear_gear_num", typeof(FitField_UInt8z))},
                        { 12,  new FieldDefinition("rear_gear", typeof(FitField_UInt8z))}

                    }
                )
            },
            { 
                MessageNumber.DeviceInfo,
                new MessageDefinition
                (
                    "DeviceInfo",
                    typeof(DeviceInfoMessage),
                    new Dictionary<byte,FieldDefinition>()
                    {
                        { 253, new FieldDefinition("timestamp", typeof(FitField_DateTime))},
                        { 0, new FieldDefinition("device_index", typeof(FitField_DeviceIndex))},
                        { 1, new FieldDefinition("device_type", typeof(FitField_DeviceType))},
                        { 2, new FieldDefinition("manufacturer", typeof(FitField_Manufacturer))},
                        { 3, new FieldDefinition("serial_number", typeof(FitField_UInt32z))},
                        { 4, new FieldDefinition("product", typeof(FitField_GarminProduct))},
                        { 5, new FieldDefinition("software_version", typeof(FitField_UInt16))},
                        { 6, new FieldDefinition("hardware_version", typeof(FitField_UInt8))},
                        { 7, new FieldDefinition("cum_operating_time", typeof(FitField_UInt32))},
                        { 10, new FieldDefinition("battery_voltage", typeof(FitField_UInt16))},
                        { 11, new FieldDefinition("battery_status", typeof(FitField_BatteryStatus))},
                        { 18, new FieldDefinition("sensor_position", typeof(FitField_BodyLocation))},
                        { 19, new FieldDefinition("descriptor", typeof(FitField_String))},
                        { 20, new FieldDefinition("ant_transmission_type", typeof(FitField_UInt8z))},
                        { 21, new FieldDefinition("ant_device_number", typeof(FitField_UInt16z))},
                        { 22, new FieldDefinition("ant_network", typeof(FitField_AntNetwork))},
                        { 25, new FieldDefinition("source_type", typeof(FitField_SourceType))}
    //deviceInfoMesg.addField(new Field("cum_training_time", 8, 134, 1.0D, 0.0D, "s"));
    //deviceInfoMesg.addField(new Field("reception", 9, 2, 1.0D, 0.0D, "%"));
    //deviceInfoMesg.addField(new Field("x_uint8_search_count", 12, 2, 1.0D, 0.0D, ""));
    //((Field)deviceInfoMesg.fields.get(13)).components.add(new FieldComponent(13, false, 8, 1.0D, 0.0D));
    //deviceInfoMesg.addField(new Field("search_count", 13, 132, 1.0D, 0.0D, ""));
    //deviceInfoMesg.addField(new Field("connect_count", 14, 132, 1.0D, 0.0D, ""));
    //deviceInfoMesg.addField(new Field("rx_pass_count", 15, 134, 1.0D, 0.0D, "messages"));
    //deviceInfoMesg.addField(new Field("rx_fail_count", 16, 134, 1.0D, 0.0D, "messages"));
    //deviceInfoMesg.addField(new Field("software_version_string", 17, 7, 1.0D, 0.0D, ""));

                    }
                )
            },
            {
                MessageNumber.TrainingFile,
                new MessageDefinition(
                    "TrainingFile",
                    typeof(TrainingFileMessage),
                     new Dictionary<byte,FieldDefinition>()
                    {
                        { 253, new FieldDefinition("timestamp", typeof(FitField_DateTime))},
                        { 0, new FieldDefinition("type", typeof(FitField_FileType))},
                        { 1, new FieldDefinition("manufacturer", typeof(FitField_Manufacturer))},
                        { 2, new FieldDefinition("product", typeof(FitField_GarminProduct))},
                        { 3, new FieldDefinition("serial_number", typeof(FitField_UInt32z))},
                        { 4, new FieldDefinition("time_created", typeof(FitField_DateTime))},
                    }
                )
            },
            { 
                MessageNumber.Hrv,
                new MessageDefinition
                (
                    "Hrv",
                    typeof(HrvMessage),
                    new Dictionary<byte,FieldDefinition>()
                    {
                        { 0, new FieldDefinition("Time", typeof(FitField_UInt16))}
                    }
                )
            },

            #endregion
            
            #region Course File Messages
            { 
                MessageNumber.Course,
                new MessageDefinition
                (
                    "Course",
                    typeof(DataMessage),
                    new Dictionary<byte,FieldDefinition>()
                    {
                        { 4, new FieldDefinition("sport", typeof(FitField_Sport))},
                        { 5, new FieldDefinition("name", typeof(FitField_String))},
                        { 6, new FieldDefinition("capabilities", typeof(FitField_CourseCapabilities))}

                    }
                )
            },
            { 
                MessageNumber.CoursePoint,
                new MessageDefinition
                (
                    "CoursePoint",
                    typeof(DataMessage),
                    new Dictionary<byte,FieldDefinition>()
                    {
                        { 254, new FieldDefinition("message_index", typeof(FitField_MessageIndex))},
                        { 1, new FieldDefinition("timestamp", typeof(FitField_DateTime))},
                        { 2, new FieldDefinition("position_lat", typeof(FitField_SInt32))},
                        { 3, new FieldDefinition("position_long", typeof(FitField_SInt32))},
                        { 4, new FieldDefinition("distance", typeof(FitField_UInt32))},
                        { 5, new FieldDefinition("type", typeof(FitField_CoursePoint))},
                        { 6, new FieldDefinition("name", typeof(FitField_String))},
                    }
                )
            },
            #endregion

            #region Segment File Messages, Segment List File Messages, Workout File Messages
            { 
                MessageNumber.Workout,
                new MessageDefinition
                (
                    "Workout",
                    typeof(DataMessage),
                    new Dictionary<byte,FieldDefinition>()
                    {
                        { 4, new FieldDefinition("sport", typeof(FitField_Sport))},
                        { 5, new FieldDefinition("capabilities", typeof(FitField_WorkoutCapabilities))},
                        { 6, new FieldDefinition("num_valid_steps", typeof(FitField_UInt16))},
                        { 8, new FieldDefinition("wkt_name", typeof(FitField_String))}
    //workoutMesg.addField(new Field("protection", 7, 132, 1.0D, 0.0D, ""));
                    }
                )
            },
            { 
                MessageNumber.WorkoutStep,
                new MessageDefinition
                (
                    "WorkoutStep",
                    typeof(DataMessage),
                    new Dictionary<byte,FieldDefinition>()
                    {
                        { 254, new FieldDefinition("message_index", typeof(FitField_MessageIndex))},
                        { 0, new FieldDefinition("wkt_step_name", typeof(FitField_String))},
                        { 1, new FieldDefinition("duration_type", typeof(FitField_WorkoutStepDuration))},
                        { 2, new FieldDefinition("duration_value", typeof(FitField_UInt32))},
                        { 3, new FieldDefinition("target_type", typeof(FitField_WorkoutStepTarget))},
                        { 4, new FieldDefinition("target_value", typeof(FitField_UInt32))},
                        { 5, new FieldDefinition("custom_target_value_low", typeof(FitField_UInt32))},
                        { 6, new FieldDefinition("custom_target_value_high", typeof(FitField_UInt32))},
                        { 7, new FieldDefinition("intensity", typeof(FitField_Intensity))}

                    }
                )
            },
            #endregion

            #region Schedule File Messages
            { 
                MessageNumber.Schedule,
                new MessageDefinition
                (
                    "Schedule",
                    typeof(DataMessage),
                    new Dictionary<byte,FieldDefinition>()
                    {
                        { 0, new FieldDefinition("manufacturer", typeof(FitField_Manufacturer))},
                        { 1, new FieldDefinition("product", typeof(FitField_GarminProduct))},
                        { 2, new FieldDefinition("serial_number", typeof(FitField_UInt32z))},
                        { 3, new FieldDefinition("time_created", typeof(FitField_DateTime))},
                        { 4, new FieldDefinition("completed", typeof(FitField_Bool))},
                        { 5, new FieldDefinition("type", typeof(FitField_Schedule))},
                        { 6, new FieldDefinition("scheduled_time", typeof(FitField_LocalDateTime))},
                    }
                )
            },
            #endregion

            #region Totals File Messages
            { 
                MessageNumber.Totals,
                new MessageDefinition
                (
                    "Totals",
                    typeof(DataMessage),
                    new Dictionary<byte,FieldDefinition>()
                    {
                        { 254, new FieldDefinition("message_index", typeof(FitField_MessageIndex))},
                        { 253, new FieldDefinition("timestamp", typeof(FitField_DateTime))},
                        { 0, new FieldDefinition("timer_time", typeof(FitField_UInt32))},
                        { 1, new FieldDefinition("distance", typeof(FitField_UInt32))},
                        { 2, new FieldDefinition("calories", typeof(FitField_UInt32))},
                        { 3, new FieldDefinition("sport", typeof(FitField_Sport))},
                        { 4, new FieldDefinition("elapsed_time", typeof(FitField_UInt32))},
                        { 5, new FieldDefinition("sessions", typeof(FitField_UInt16))},
                        { 6, new FieldDefinition("active_time", typeof(FitField_UInt32))},
                    }
                )
            },
            #endregion

            #region Weight Scale File Messages
            { 
                MessageNumber.WeightScale,
                new MessageDefinition
                (
                    "WeightScale",
                    typeof(DataMessage),
                    new Dictionary<byte,FieldDefinition>()
                    {
                        { 253, new FieldDefinition("timestamp", typeof(FitField_DateTime))},
                        { 0, new FieldDefinition("weight", typeof(FitField_Weight))},
                        { 1, new FieldDefinition("percent_fat", typeof(FitField_UInt16))},
                        { 2, new FieldDefinition("percent_hydration", typeof(FitField_UInt16))},
                        { 3, new FieldDefinition("visceral_fat_mass", typeof(FitField_UInt16))},
                        { 4, new FieldDefinition("bone_mass", typeof(FitField_UInt16))},
                        { 5, new FieldDefinition("muscle_mass", typeof(FitField_UInt16))},
                        { 7, new FieldDefinition("basal_met", typeof(FitField_UInt16))},
                        { 8, new FieldDefinition("physique_rating", typeof(FitField_UInt8))},
                        { 9, new FieldDefinition("active_met", typeof(FitField_UInt16))},
                        { 10, new FieldDefinition("metabolic_age", typeof(FitField_UInt8))},
                        { 11, new FieldDefinition("visceral_fat_rating", typeof(FitField_UInt8))},
                        { 12, new FieldDefinition("user_profile_index", typeof(FitField_MessageIndex))}
                    }
                )
            },
            #endregion

            #region Blood Pressure File Messages
            { 
                MessageNumber.BloodPressure,
                new MessageDefinition
                (
                    "BloodPressure",
                    typeof(DataMessage),
                    new Dictionary<byte,FieldDefinition>()
                    {
                        { 253, new FieldDefinition("timestamp", typeof(FitField_DateTime))},
                        { 0, new FieldDefinition("systolic_pressure", typeof(FitField_UInt16))},
                        { 1, new FieldDefinition("diastolic_pressure", typeof(FitField_UInt16))},
                        { 2, new FieldDefinition("mean_arterial_pressure", typeof(FitField_UInt16))},
                        { 3, new FieldDefinition("map_3_sample_mean", typeof(FitField_UInt16))},
                        { 4, new FieldDefinition("map_morning_values", typeof(FitField_UInt16))},
                        { 5, new FieldDefinition("map_evening_values", typeof(FitField_UInt16))},
                        { 6, new FieldDefinition("heart_rate", typeof(FitField_UInt8))},
                        { 7, new FieldDefinition("heart_rate_type", typeof(FitField_HrType))},
                        { 8, new FieldDefinition("status", typeof(FitField_BpStatus))},
                        { 9, new FieldDefinition("user_profile_index", typeof(FitField_MessageIndex))}
                    }
                )
            },
            #endregion

            #region Monitoring File Messages
            {
                MessageNumber.MonitoringInfo,
                new MessageDefinition
                (
                    "MonitoringInfo",
                    typeof(DataMessage),
                    new Dictionary<byte,FieldDefinition>()
                    {
                        { 253, new FieldDefinition("timestamp", typeof(FitField_DateTime))},
                        { 0, new FieldDefinition("local_timestamp", typeof(FitField_LocalDateTime))},
                        { 2, new FieldDefinition("activity_type", typeof(FitField_ActivityType))},
                        { 3, new FieldDefinition("cycles_to_distance", typeof(FitField_UInt16))},
                        { 4, new FieldDefinition("cycles_to_calories", typeof(FitField_UInt16))},
                        { 5, new FieldDefinition("resting_metabolic_rate", typeof(FitField_UInt16))},

                    }
                )
            },
            { 
                MessageNumber.Monitoring,
                new MessageDefinition
                (
                    "Monitoring",
                    typeof(DataMessage),
                    new Dictionary<byte,FieldDefinition>()
                    {
                        { 253, new FieldDefinition("timestamp", typeof(FitField_DateTime))},
                        { 0, new FieldDefinition("device_index", typeof(FitField_DeviceIndex))},
                        { 1, new FieldDefinition("calories", typeof(FitField_UInt16))},
                        { 2, new FieldDefinition("distance", typeof(FitField_UInt32))},
                        { 3, new FieldDefinition("cycles", typeof(FitField_UInt32))},
                        { 4, new FieldDefinition("active_time", typeof(FitField_UInt32))},
                        { 5, new FieldDefinition("activity_type", typeof(FitField_ActivityType))},
                        { 6, new FieldDefinition("activity_subtype", typeof(FitField_ActivitySubType))},
                        { 7, new FieldDefinition("activity_level", typeof(FitField_ActivityLevel))},
                        { 8, new FieldDefinition("distance_16", typeof(FitField_UInt16))},
                        { 9, new FieldDefinition("cycles_16", typeof(FitField_UInt16))},
                        { 10, new FieldDefinition("active_time_16", typeof(FitField_UInt16))},
                        { 11, new FieldDefinition("local_timestamp", typeof(FitField_LocalDateTime))},
                        { 12, new FieldDefinition("temperature", typeof(FitField_SInt16))},
                        { 14, new FieldDefinition("temperature_min", typeof(FitField_SInt16))},
                        { 15, new FieldDefinition("temperature_max", typeof(FitField_SInt16))},
                        { 16, new FieldDefinition("activity_time", typeof(FitField_UInt16))},
                        { 19, new FieldDefinition("active_calories", typeof(FitField_UInt16))},
                        { 24, new FieldDefinition("current_activity_type_intensity", typeof(FitField_Byte))},
                        { 25, new FieldDefinition("timestamp_min_8", typeof(FitField_UInt8))},
                        { 26, new FieldDefinition("timestamp_16", typeof(FitField_UInt16))},
                        { 27, new FieldDefinition("heart_rate", typeof(FitField_UInt8))},
                        { 28, new FieldDefinition("intensity", typeof(FitField_UInt8))},
                        { 29, new FieldDefinition("duration_min", typeof(FitField_UInt16))},
                        { 30, new FieldDefinition("duration", typeof(FitField_UInt32))},

                    }
                )
            },
            #endregion

            #region Other Messages
            { 
                MessageNumber.MemoGlob,
                new MessageDefinition
                (
                    "MemoGlob",
                    typeof(DataMessage),
                    new Dictionary<byte,FieldDefinition>()
                    {
                        { 250, new FieldDefinition("part_index", typeof(FitField_UInt32))},
                        { 0, new FieldDefinition("memo", typeof(FitField_Byte))},
                        { 1, new FieldDefinition("message_number", typeof(FitField_UInt16))},
                        { 2, new FieldDefinition("message_index", typeof(FitField_MessageIndex))}
                    }
                )
            },
            #endregion

            #region Custom Garmin Messages
           
            
            {
                MessageNumber.Pad,
                new MessageDefinition
                (
                    "Pad",
                    typeof(DataMessage),
                    new Dictionary<byte,FieldDefinition>()
                    {
                    }
                )
            },

            {
                MessageNumber.ActivityMonitorProfile,
                new MessageDefinition(
                    "ActivityMonitorProfile",
                    typeof(DataMessage),
                    new Dictionary<byte, FieldDefinition>()
                    {
                        {0, new FieldDefinition("logging_interval", typeof(FitField_UInt16))},
                        {252, new FieldDefinition("checksum", typeof(FitField_UInt8))},
                        {251, new FieldDefinition("pad", typeof(FitField_Byte))},
                    }
                )

            },
            {
                MessageNumber.Connectivity,
                new MessageDefinition(
                    "Connectivity",
                    typeof(DataMessage),
                    new Dictionary<byte, FieldDefinition>()
                    {
                        {0, new FieldDefinition("bluetooth_enabled", typeof(FitField_Enum))},
                        {1, new FieldDefinition("bluetooth_le_enabled", typeof(FitField_Enum))},
                        {2, new FieldDefinition("ant_enabled", typeof(FitField_Enum))},
                        {3, new FieldDefinition("name", typeof(FitField_String))},
                        //connectivityMesg.addField(new Field("live_tracking_enabled", 4, 0, 1.0D, 0.0D, ""));
                        //connectivityMesg.addField(new Field("weather_conditions_enabled", 5, 0, 1.0D, 0.0D, ""));
                        //connectivityMesg.addField(new Field("weather_alerts_enabled", 6, 0, 1.0D, 0.0D, ""));
                        //connectivityMesg.addField(new Field("auto_activity_upload_enabled", 7, 0, 1.0D, 0.0D, ""));
                        //connectivityMesg.addField(new Field("course_download_enabled", 8, 0, 1.0D, 0.0D, ""));
                        //connectivityMesg.addField(new Field("workout_download_enabled", 9, 0, 1.0D, 0.0D, ""));
                        //connectivityMesg.addField(new Field("gps_ephemeris_download_enabled", 10, 0, 1.0D, 0.0D, ""));
                        //connectivityMesg.addField(new Field("checksum", 252, 2, 1.0D, 0.0D, ""));
                        //connectivityMesg.addField(new Field("pad", 251, 13, 1.0D, 0.0D, ""));
                    }
                    )
            },

    //Mesg localMesg22 = new Mesg("delta_zone", 11);
    //deltaZoneMesg = localMesg22;
    //localMesg22.addField(new Field("message_index", 254, 132, 1.0D, 0.0D, ""));
    //deltaZoneMesg.addField(new Field("type", 1, 0, 1.0D, 0.0D, ""));
    //deltaZoneMesg.addField(new Field("value", 2, 134, 1.0D, 0.0D, ""));
    //deltaZoneMesg.addField(new Field("name", 3, 7, 1.0D, 0.0D, ""));
    //deltaZoneMesg.addField(new Field("delta", 4, 2, 1.0D, 0.0D, ""));
    //deltaZoneMesg.addField(new Field("checksum", 252, 2, 1.0D, 0.0D, ""));
    //deltaZoneMesg.addField(new Field("pad", 251, 13, 1.0D, 0.0D, ""));


    //Mesg localMesg23 = new Mesg("training_settings", 13);
    //trainingSettingsMesg = localMesg23;
    //localMesg23.addField(new Field("message_index", 254, 132, 1.0D, 0.0D, ""));
    //trainingSettingsMesg.addField(new Field("virtualpartner_on", 1, 0, 1.0D, 0.0D, ""));
    //trainingSettingsMesg.addField(new Field("virtualpartner_speed", 2, 132, 1000.0D, 0.0D, "m/s"));
    //trainingSettingsMesg.addField(new Field("autolap_trigger", 3, 0, 1.0D, 0.0D, ""));
    //trainingSettingsMesg.addField(new Field("autolap_distance", 4, 134, 100.0D, 0.0D, "m"));
    //trainingSettingsMesg.addField(new Field("autolap_position_lat", 5, 133, 1.0D, 0.0D, "semicircles"));
    //trainingSettingsMesg.addField(new Field("autolap_position_long", 6, 133, 1.0D, 0.0D, "semicircles"));
    //trainingSettingsMesg.addField(new Field("autopause_mode", 7, 0, 1.0D, 0.0D, ""));
    //trainingSettingsMesg.addField(new Field("autopause_speed", 8, 132, 1000.0D, 0.0D, "m/s"));
    //trainingSettingsMesg.addField(new Field("data_recording_interval", 9, 0, 1.0D, 0.0D, ""));
    //trainingSettingsMesg.addField(new Field("data_recording_value", 10, 132, 1.0D, 0.0D, ""));
    //((Field)trainingSettingsMesg.fields.get(10)).subFields.add(new SubField("data_recording_time", 132, 1.0D, 0.0D, "s"));
    //((SubField)((Field)trainingSettingsMesg.fields.get(10)).subFields.get(0)).addMap(9, 1L);
    //((Field)trainingSettingsMesg.fields.get(10)).subFields.add(new SubField("data_recording_distance", 132, 1.0D, 0.0D, "m"));
    //((SubField)((Field)trainingSettingsMesg.fields.get(10)).subFields.get(1)).addMap(9, 2L);
    //trainingSettingsMesg.addField(new Field("num_training_pages", 11, 2, 1.0D, 0.0D, ""));
    //trainingSettingsMesg.addField(new Field("non_zero_avg_power", 12, 0, 1.0D, 0.0D, ""));
    //trainingSettingsMesg.addField(new Field("non_zero_avg_cadence", 13, 0, 1.0D, 0.0D, ""));
    //trainingSettingsMesg.addField(new Field("display_pace", 14, 0, 1.0D, 0.0D, ""));
    //trainingSettingsMesg.addField(new Field("autoscroll", 15, 0, 1.0D, 0.0D, ""));
    //trainingSettingsMesg.addField(new Field("default_training_pages", 16, 0, 1.0D, 0.0D, ""));
    //trainingSettingsMesg.addField(new Field("auto_start_prompt", 17, 0, 1.0D, 0.0D, ""));
    //trainingSettingsMesg.addField(new Field("auto_start_mode", 18, 0, 1.0D, 0.0D, ""));
    //trainingSettingsMesg.addField(new Field("auto_start_delay", 19, 132, 1.0D, 0.0D, "s"));
    //trainingSettingsMesg.addField(new Field("virtualpartner_alert", 20, 0, 1.0D, 0.0D, ""));
    //trainingSettingsMesg.addField(new Field("virtualracer_alert", 21, 0, 1.0D, 0.0D, ""));
    //trainingSettingsMesg.addField(new Field("pool_length", 22, 132, 100.0D, 0.0D, "m"));
    //trainingSettingsMesg.addField(new Field("manual_lap_enabled", 23, 0, 1.0D, 0.0D, ""));
    //trainingSettingsMesg.addField(new Field("checksum", 252, 2, 1.0D, 0.0D, ""));
    //trainingSettingsMesg.addField(new Field("pad", 251, 13, 1.0D, 0.0D, ""));
 
    { 
                MessageNumber.TrainingPages,
                new MessageDefinition
                (
                    "TrainingPages",
                    typeof(DataMessage),
                    new Dictionary<byte,FieldDefinition>()
                    {
                        { 254, new FieldDefinition("message_index",typeof(FitField_MessageIndex))},
                        { 1, new FieldDefinition("enabled", typeof(FitField_Enum))},
                        { 3, new FieldDefinition("num_zones",typeof(FitField_UInt8))},
                        { 4, new FieldDefinition("field_zone",typeof(FitField_UInt8))},
                        { 5, new FieldDefinition("field_display",typeof(FitField_UInt8))},
                        { 6, new FieldDefinition("name",typeof(FitField_String))},
                    }
                )
 
                },
                

    //Mesg localMesg25 = new Mesg("training_duration_alert", 16);
    //trainingDurationAlertMesg = localMesg25;
    //localMesg25.addField(new Field("message_index", 254, 132, 1.0D, 0.0D, ""));
    //trainingDurationAlertMesg.addField(new Field("alert_type", 1, 0, 1.0D, 0.0D, ""));
    //trainingDurationAlertMesg.addField(new Field("alert_value", 2, 134, 1.0D, 0.0D, ""));
    //((Field)trainingDurationAlertMesg.fields.get(2)).subFields.add(new SubField("alert_time", 134, 1000.0D, 0.0D, "s"));
    //((SubField)((Field)trainingDurationAlertMesg.fields.get(2)).subFields.get(0)).addMap(1, 0L);
    //((Field)trainingDurationAlertMesg.fields.get(2)).subFields.add(new SubField("alert_distance", 134, 100.0D, 0.0D, "m"));
    //((SubField)((Field)trainingDurationAlertMesg.fields.get(2)).subFields.get(1)).addMap(1, 1L);
    //((Field)trainingDurationAlertMesg.fields.get(2)).subFields.add(new SubField("alert_calories", 134, 1.0D, 0.0D, "calories"));
    //((SubField)((Field)trainingDurationAlertMesg.fields.get(2)).subFields.get(2)).addMap(1, 2L);
    //trainingDurationAlertMesg.addField(new Field("enabled", 3, 0, 1.0D, 0.0D, ""));
    //trainingDurationAlertMesg.addField(new Field("checksum", 252, 2, 1.0D, 0.0D, ""));
    //trainingDurationAlertMesg.addField(new Field("pad", 251, 13, 1.0D, 0.0D, ""));

    //mesgs[24] = trainingDurationAlertMesg;
    //Mesg localMesg26 = new Mesg("training_interval_alert", 74);
    //trainingIntervalAlertMesg = localMesg26;
    //localMesg26.addField(new Field("message_index", 254, 132, 1.0D, 0.0D, ""));
    //trainingIntervalAlertMesg.addField(new Field("active_alert_type", 1, 0, 1.0D, 0.0D, ""));
    //trainingIntervalAlertMesg.addField(new Field("active_alert_value", 2, 134, 1.0D, 0.0D, ""));
    //((Field)trainingIntervalAlertMesg.fields.get(2)).subFields.add(new SubField("active_alert_time", 134, 1000.0D, 0.0D, "s"));
    //((SubField)((Field)trainingIntervalAlertMesg.fields.get(2)).subFields.get(0)).addMap(1, 0L);
    //((Field)trainingIntervalAlertMesg.fields.get(2)).subFields.add(new SubField("active_alert_distance", 134, 100.0D, 0.0D, "m"));
    //((SubField)((Field)trainingIntervalAlertMesg.fields.get(2)).subFields.get(1)).addMap(1, 1L);
    //((Field)trainingIntervalAlertMesg.fields.get(2)).subFields.add(new SubField("active_alert_calories", 134, 1.0D, 0.0D, "calories"));
    //((SubField)((Field)trainingIntervalAlertMesg.fields.get(2)).subFields.get(2)).addMap(1, 2L);
    //trainingIntervalAlertMesg.addField(new Field("rest_alert_type", 3, 0, 1.0D, 0.0D, ""));
    //trainingIntervalAlertMesg.addField(new Field("rest_alert_value", 4, 134, 1.0D, 0.0D, ""));
    //((Field)trainingIntervalAlertMesg.fields.get(4)).subFields.add(new SubField("rest_alert_time", 134, 1000.0D, 0.0D, "s"));
    //((SubField)((Field)trainingIntervalAlertMesg.fields.get(4)).subFields.get(0)).addMap(3, 0L);
    //((Field)trainingIntervalAlertMesg.fields.get(4)).subFields.add(new SubField("rest_alert_distance", 134, 100.0D, 0.0D, "m"));
    //((SubField)((Field)trainingIntervalAlertMesg.fields.get(4)).subFields.get(1)).addMap(3, 1L);
    //((Field)trainingIntervalAlertMesg.fields.get(4)).subFields.add(new SubField("rest_alert_calories", 134, 1.0D, 0.0D, "calories"));
    //((SubField)((Field)trainingIntervalAlertMesg.fields.get(4)).subFields.get(2)).addMap(3, 2L);
    //trainingIntervalAlertMesg.addField(new Field("enabled", 5, 0, 1.0D, 0.0D, ""));
    //trainingIntervalAlertMesg.addField(new Field("checksum", 252, 2, 1.0D, 0.0D, ""));
    //trainingIntervalAlertMesg.addField(new Field("pad", 251, 13, 1.0D, 0.0D, ""));

    //Mesg localMesg27 = new Mesg("training_target_alert", 17);
    //trainingTargetAlertMesg = localMesg27;
    //localMesg27.addField(new Field("message_index", 254, 132, 1.0D, 0.0D, ""));
    //trainingTargetAlertMesg.addField(new Field("alert_type", 1, 0, 1.0D, 0.0D, ""));
    //trainingTargetAlertMesg.addField(new Field("low_alert_mode", 2, 0, 1.0D, 0.0D, ""));
    //trainingTargetAlertMesg.addField(new Field("low_alert_value", 3, 132, 1.0D, 0.0D, ""));
    //((Field)trainingTargetAlertMesg.fields.get(3)).subFields.add(new SubField("low_alert_heart_rate", 132, 1.0D, 0.0D, "bpm"));
    //((SubField)((Field)trainingTargetAlertMesg.fields.get(3)).subFields.get(0)).addMap(1, 0L);
    //((Field)trainingTargetAlertMesg.fields.get(3)).subFields.add(new SubField("low_alert_speed", 132, 1000.0D, 0.0D, "m/s"));
    //((SubField)((Field)trainingTargetAlertMesg.fields.get(3)).subFields.get(1)).addMap(1, 1L);
    //((Field)trainingTargetAlertMesg.fields.get(3)).subFields.add(new SubField("low_alert_cadence", 132, 1.0D, 0.0D, "rpm"));
    //((SubField)((Field)trainingTargetAlertMesg.fields.get(3)).subFields.get(2)).addMap(1, 2L);
    //((Field)trainingTargetAlertMesg.fields.get(3)).subFields.add(new SubField("low_alert_power", 132, 1.0D, 0.0D, "watts"));
    //((SubField)((Field)trainingTargetAlertMesg.fields.get(3)).subFields.get(3)).addMap(1, 3L);
    //trainingTargetAlertMesg.addField(new Field("high_alert_mode", 4, 0, 1.0D, 0.0D, ""));
    //trainingTargetAlertMesg.addField(new Field("high_alert_value", 5, 132, 1.0D, 0.0D, ""));
    //((Field)trainingTargetAlertMesg.fields.get(5)).subFields.add(new SubField("high_alert_heart_rate", 132, 1.0D, 0.0D, "bpm"));
    //((SubField)((Field)trainingTargetAlertMesg.fields.get(5)).subFields.get(0)).addMap(1, 0L);
    //((Field)trainingTargetAlertMesg.fields.get(5)).subFields.add(new SubField("high_alert_speed", 132, 1000.0D, 0.0D, "m/s"));
    //((SubField)((Field)trainingTargetAlertMesg.fields.get(5)).subFields.get(1)).addMap(1, 1L);
    //((Field)trainingTargetAlertMesg.fields.get(5)).subFields.add(new SubField("high_alert_cadence", 132, 1.0D, 0.0D, "rpm"));
    //((SubField)((Field)trainingTargetAlertMesg.fields.get(5)).subFields.get(2)).addMap(1, 2L);
    //((Field)trainingTargetAlertMesg.fields.get(5)).subFields.add(new SubField("high_alert_power", 132, 1.0D, 0.0D, "watts"));
    //((SubField)((Field)trainingTargetAlertMesg.fields.get(5)).subFields.get(3)).addMap(1, 3L);
    //trainingTargetAlertMesg.addField(new Field("checksum", 252, 2, 1.0D, 0.0D, ""));
    //trainingTargetAlertMesg.addField(new Field("pad", 251, 13, 1.0D, 0.0D, ""));

    //Mesg localMesg28 = new Mesg("map_profile", 70);
    //mapProfileMesg = localMesg28;
    //localMesg28.addField(new Field("message_index", 254, 132, 1.0D, 0.0D, ""));
    //mapProfileMesg.addField(new Field("mode", 0, 0, 1.0D, 0.0D, ""));
    //mapProfileMesg.addField(new Field("detail", 1, 0, 1.0D, 0.0D, ""));
    //mapProfileMesg.addField(new Field("shaded_relief", 2, 0, 1.0D, 0.0D, ""));
    //mapProfileMesg.addField(new Field("points_zoom", 3, 0, 1.0D, 0.0D, ""));
    //mapProfileMesg.addField(new Field("locations_zoom", 4, 0, 1.0D, 0.0D, ""));
    //mapProfileMesg.addField(new Field("street_zoom", 5, 0, 1.0D, 0.0D, ""));
    //mapProfileMesg.addField(new Field("land_cover_zoom", 6, 0, 1.0D, 0.0D, ""));
    //mapProfileMesg.addField(new Field("points_text", 7, 0, 1.0D, 0.0D, ""));
    //mapProfileMesg.addField(new Field("locations_text", 8, 0, 1.0D, 0.0D, ""));
    //mapProfileMesg.addField(new Field("street_text", 9, 0, 1.0D, 0.0D, ""));
    //mapProfileMesg.addField(new Field("land_cover_text", 10, 0, 1.0D, 0.0D, ""));
    //mapProfileMesg.addField(new Field("map_orientation", 11, 0, 1.0D, 0.0D, ""));
    //mapProfileMesg.addField(new Field("map_show", 12, 0, 1.0D, 0.0D, ""));
    //mapProfileMesg.addField(new Field("map_show_locations", 13, 0, 1.0D, 0.0D, ""));
    //mapProfileMesg.addField(new Field("map_auto_zoom", 14, 0, 1.0D, 0.0D, ""));
    //mapProfileMesg.addField(new Field("map_guidance", 15, 0, 1.0D, 0.0D, ""));
    //mapProfileMesg.addField(new Field("checksum", 252, 2, 1.0D, 0.0D, ""));
    //mapProfileMesg.addField(new Field("pad", 251, 13, 1.0D, 0.0D, ""));

    //Mesg localMesg29 = new Mesg("routing_profile", 71);
    //routingProfileMesg = localMesg29;
    //localMesg29.addField(new Field("message_index", 254, 132, 1.0D, 0.0D, ""));
    //routingProfileMesg.addField(new Field("mode", 0, 0, 1.0D, 0.0D, ""));
    //routingProfileMesg.addField(new Field("guidance_mode", 1, 0, 1.0D, 0.0D, ""));
    //routingProfileMesg.addField(new Field("lock_on_road", 2, 0, 1.0D, 0.0D, ""));
    //routingProfileMesg.addField(new Field("avoidance", 3, 132, 1.0D, 0.0D, ""));
    //routingProfileMesg.addField(new Field("recalculate_mode", 4, 0, 1.0D, 0.0D, ""));
    //routingProfileMesg.addField(new Field("checksum", 252, 2, 1.0D, 0.0D, ""));
    //routingProfileMesg.addField(new Field("pad", 251, 13, 1.0D, 0.0D, ""));
    //mesgs[28] = routingProfileMesg;

    //Mesg localMesg37 = new Mesg("sources", 22);
    //sourcesMesg = localMesg37;
    //localMesg37.addField(new Field("timestamp", 253, 134, 1.0D, 0.0D, "s"));
    //sourcesMesg.addField(new Field("speed_source", 0, 2, 1.0D, 0.0D, ""));
    //sourcesMesg.addField(new Field("distance_source", 1, 2, 1.0D, 0.0D, ""));
    //sourcesMesg.addField(new Field("cadence_source", 2, 2, 1.0D, 0.0D, ""));
    //sourcesMesg.addField(new Field("alti_source", 3, 2, 1.0D, 0.0D, ""));
    //sourcesMesg.addField(new Field("hr_source", 4, 2, 1.0D, 0.0D, ""));
    //sourcesMesg.addField(new Field("calorie_source", 5, 0, 1.0D, 0.0D, ""));
    //sourcesMesg.addField(new Field("power_source", 6, 2, 1.0D, 0.0D, ""));
    //sourcesMesg.addField(new Field("grade_source", 7, 2, 1.0D, 0.0D, ""));
    //sourcesMesg.addField(new Field("resistance_source", 8, 2, 1.0D, 0.0D, ""));
    //sourcesMesg.addField(new Field("cycle_length_source", 9, 2, 1.0D, 0.0D, ""));
    //sourcesMesg.addField(new Field("checksum", 252, 2, 1.0D, 0.0D, ""));
    //sourcesMesg.addField(new Field("pad", 251, 13, 1.0D, 0.0D, ""));
    //mesgs[36] = sourcesMesg;

    // Mesg localMesg40 = new Mesg("firstbeat_profile", 79);
    //firstbeatProfileMesg = localMesg40;
    //localMesg40.addField(new Field("timestamp", 253, 134, 1.0D, 0.0D, ""));
    //firstbeatProfileMesg.addField(new Field("max_met", 0, 132, 1024.0D, 0.0D, ""));
    //firstbeatProfileMesg.addField(new Field("age", 1, 2, 1.0D, 0.0D, "years"));
    //firstbeatProfileMesg.addField(new Field("height", 2, 2, 100.0D, 0.0D, "m"));
    //firstbeatProfileMesg.addField(new Field("weight", 3, 132, 10.0D, 0.0D, "kg"));
    //firstbeatProfileMesg.addField(new Field("gender", 4, 0, 1.0D, 0.0D, ""));
    //firstbeatProfileMesg.addField(new Field("activity_class", 5, 0, 1.0D, 0.0D, ""));
    //firstbeatProfileMesg.addField(new Field("max_hr", 6, 2, 1.0D, 0.0D, ""));
    //firstbeatProfileMesg.addField(new Field("fb_status", 7, 1, 1.0D, 0.0D, ""));
    //firstbeatProfileMesg.addField(new Field("checksum", 252, 2, 1.0D, 0.0D, ""));
    //firstbeatProfileMesg.addField(new Field("pad", 251, 13, 1.0D, 0.0D, ""));
    //mesgs[39] = firstbeatProfileMesg;

    //    Mesg localMesg42 = new Mesg("battery", 104);
    //batteryMesg = localMesg42;
    //localMesg42.addField(new Field("timestamp", 253, 134, 1.0D, 0.0D, ""));
    //batteryMesg.addField(new Field("voltage", 0, 132, 1.0D, 0.0D, "mV"));
    //batteryMesg.addField(new Field("current", 1, 131, 1.0D, 0.0D, "mA"));
    //batteryMesg.addField(new Field("capacity", 2, 2, 1.0D, 0.0D, "%"));
    //batteryMesg.addField(new Field("temperature", 3, 1, 1.0D, 0.0D, "C"));
    //batteryMesg.addField(new Field("checksum", 252, 2, 1.0D, 0.0D, ""));
    //batteryMesg.addField(new Field("pad", 251, 13, 1.0D, 0.0D, ""));
    //mesgs[41] = batteryMesg;

    
    //Mesg localMesg43 = new Mesg("pr_event", 113);
    //prEventMesg = localMesg43;
    //localMesg43.addField(new Field("timestamp", 253, 134, 1.0D, 0.0D, ""));
    //prEventMesg.addField(new Field("category", 0, 132, 1.0D, 0.0D, ""));
    //prEventMesg.addField(new Field("sport", 1, 0, 1.0D, 0.0D, ""));
    //prEventMesg.addField(new Field("duration", 2, 134, 1.0D, 0.0D, ""));
    //((Field)prEventMesg.fields.get(3)).subFields.add(new SubField("duration_distance", 134, 100.0D, 0.0D, "m"));
    //((SubField)((Field)prEventMesg.fields.get(3)).subFields.get(0)).addMap(0, 0L);
    //((Field)prEventMesg.fields.get(3)).subFields.add(new SubField("duration_time", 134, 1000.0D, 0.0D, "s"));
    //((SubField)((Field)prEventMesg.fields.get(3)).subFields.get(1)).addMap(0, 1L);
    //((SubField)((Field)prEventMesg.fields.get(3)).subFields.get(1)).addMap(0, 2L);
    //((SubField)((Field)prEventMesg.fields.get(3)).subFields.get(1)).addMap(0, 3L);
    //prEventMesg.addField(new Field("result", 3, 134, 1.0D, 0.0D, ""));
    //((Field)prEventMesg.fields.get(4)).subFields.add(new SubField("result_time", 134, 1000.0D, 0.0D, "s"));
    //((SubField)((Field)prEventMesg.fields.get(4)).subFields.get(0)).addMap(0, 0L);
    //((Field)prEventMesg.fields.get(4)).subFields.add(new SubField("result_distance", 134, 100.0D, 0.0D, "m"));
    //((SubField)((Field)prEventMesg.fields.get(4)).subFields.get(1)).addMap(0, 1L);
    //((Field)prEventMesg.fields.get(4)).subFields.add(new SubField("result_ascent", 134, 1.0D, 0.0D, "m"));
    //((SubField)((Field)prEventMesg.fields.get(4)).subFields.get(2)).addMap(0, 2L);
    //((Field)prEventMesg.fields.get(4)).subFields.add(new SubField("result_power", 134, 1.0D, 0.0D, "watts"));
    //((SubField)((Field)prEventMesg.fields.get(4)).subFields.get(3)).addMap(0, 3L);
    //prEventMesg.addField(new Field("start_time", 4, 134, 1.0D, 0.0D, ""));
    //prEventMesg.addField(new Field("new_record", 5, 0, 1.0D, 0.0D, ""));
    //prEventMesg.addField(new Field("checksum", 252, 2, 1.0D, 0.0D, ""));
    //prEventMesg.addField(new Field("pad", 251, 13, 1.0D, 0.0D, ""));
    //mesgs[42] = prEventMesg;
    
    //Mesg localMesg44 = new Mesg("weather_conditions", 128);
    //weatherConditionsMesg = localMesg44;
    //localMesg44.addField(new Field("timestamp", 253, 134, 1.0D, 0.0D, ""));
    //weatherConditionsMesg.addField(new Field("weather_report", 0, 0, 1.0D, 0.0D, ""));
    //weatherConditionsMesg.addField(new Field("temperature", 1, 1, 1.0D, 0.0D, "C"));
    //weatherConditionsMesg.addField(new Field("condition", 2, 0, 1.0D, 0.0D, ""));
    //weatherConditionsMesg.addField(new Field("wind_direction", 3, 132, 1.0D, 0.0D, "degrees"));
    //weatherConditionsMesg.addField(new Field("wind_speed", 4, 132, 1000.0D, 0.0D, "m/s"));
    //weatherConditionsMesg.addField(new Field("precipitation_probability", 5, 2, 1.0D, 0.0D, ""));
    //weatherConditionsMesg.addField(new Field("temperature_feels_like", 6, 1, 1.0D, 0.0D, "C"));
    //weatherConditionsMesg.addField(new Field("relative_humidity", 7, 2, 1.0D, 0.0D, ""));
    //weatherConditionsMesg.addField(new Field("location", 8, 7, 1.0D, 0.0D, ""));
    //weatherConditionsMesg.addField(new Field("observed_at_time", 9, 134, 1.0D, 0.0D, ""));
    //weatherConditionsMesg.addField(new Field("observed_location_lat", 10, 133, 1.0D, 0.0D, "semicircles"));
    //weatherConditionsMesg.addField(new Field("observed_location_long", 11, 133, 1.0D, 0.0D, "semicircles"));
    //weatherConditionsMesg.addField(new Field("checksum", 252, 2, 1.0D, 0.0D, ""));
    //weatherConditionsMesg.addField(new Field("pad", 251, 13, 1.0D, 0.0D, ""));
    //mesgs[43] = weatherConditionsMesg;

    //Mesg localMesg45 = new Mesg("weather_alert", 129);
    //weatherAlertMesg = localMesg45;
    //localMesg45.addField(new Field("timestamp", 253, 134, 1.0D, 0.0D, ""));
    //weatherAlertMesg.addField(new Field("report_id", 0, 7, 1.0D, 0.0D, ""));
    //weatherAlertMesg.addField(new Field("issue_time", 1, 134, 1.0D, 0.0D, ""));
    //weatherAlertMesg.addField(new Field("expire_time", 2, 134, 1.0D, 0.0D, ""));
    //weatherAlertMesg.addField(new Field("severity", 3, 0, 1.0D, 0.0D, ""));
    //weatherAlertMesg.addField(new Field("type", 4, 0, 1.0D, 0.0D, ""));
    //weatherAlertMesg.addField(new Field("checksum", 252, 2, 1.0D, 0.0D, ""));
    //weatherAlertMesg.addField(new Field("pad", 251, 13, 1.0D, 0.0D, ""));
    //mesgs[44] = weatherAlertMesg;

    //Mesg localMesg46 = new Mesg("graph_series", 99);
    //graphSeriesMesg = localMesg46;
    //localMesg46.addField(new Field("index", 0, 2, 1.0D, 0.0D, ""));
    //graphSeriesMesg.addField(new Field("type", 1, 132, 1.0D, 0.0D, ""));
    //graphSeriesMesg.addField(new Field("x_max", 2, 134, 1.0D, 0.0D, ""));
    //graphSeriesMesg.addField(new Field("y_max", 3, 134, 1.0D, 0.0D, ""));
    //graphSeriesMesg.addField(new Field("x_width", 4, 134, 1.0D, 0.0D, ""));
    //graphSeriesMesg.addField(new Field("x_start", 5, 133, 1.0D, 0.0D, ""));
    //graphSeriesMesg.addField(new Field("x_type", 6, 2, 1.0D, 0.0D, ""));
    //graphSeriesMesg.addField(new Field("y_type", 7, 2, 1.0D, 0.0D, ""));
    //graphSeriesMesg.addField(new Field("checksum", 252, 2, 1.0D, 0.0D, ""));
    //graphSeriesMesg.addField(new Field("pad", 251, 13, 1.0D, 0.0D, ""));
    //mesgs[45] = graphSeriesMesg;

    //Mesg localMesg47 = new Mesg("graph_data_point", 100);
    //graphDataPointMesg = localMesg47;
    //localMesg47.addField(new Field("series_index", 0, 2, 1.0D, 0.0D, ""));
    //graphDataPointMesg.addField(new Field("x_sint8", 1, 1, 1.0D, 0.0D, ""));
    //graphDataPointMesg.addField(new Field("x_sint16", 2, 131, 1.0D, 0.0D, ""));
    //graphDataPointMesg.addField(new Field("x_sint32", 3, 133, 1.0D, 0.0D, ""));
    //graphDataPointMesg.addField(new Field("x_sint8_width", 4, 1, 1.0D, 0.0D, ""));
    //graphDataPointMesg.addField(new Field("x_sint16_width", 5, 131, 1.0D, 0.0D, ""));
    //graphDataPointMesg.addField(new Field("x_sint32_width", 6, 133, 1.0D, 0.0D, ""));
    //graphDataPointMesg.addField(new Field("y_sint8", 7, 1, 1.0D, 0.0D, ""));
    //graphDataPointMesg.addField(new Field("y_sint16", 8, 131, 1.0D, 0.0D, ""));
    //graphDataPointMesg.addField(new Field("y_sint32", 9, 133, 1.0D, 0.0D, ""));
    //graphDataPointMesg.addField(new Field("checksum", 252, 2, 1.0D, 0.0D, ""));
    //graphDataPointMesg.addField(new Field("pad", 251, 13, 1.0D, 0.0D, ""));
    //mesgs[46] = graphDataPointMesg;

            { 
                MessageNumber.Location,
                new MessageDefinition
                (
                    "Location",
                    typeof(DataMessage),
                    new Dictionary<byte,FieldDefinition>()
                    {
                        { 254, new FieldDefinition("message_index", typeof(FitField_MessageIndex))},
                        { 253, new FieldDefinition("timestamp", typeof(FitField_DateTime))},
                        { 0, new FieldDefinition("name", typeof(FitField_String)) },
                        { 1, new FieldDefinition("position_lat", typeof(FitField_Point))},
                        { 2, new FieldDefinition("position_long", typeof(FitField_Point))},
                        { 3, new FieldDefinition("symbol", typeof(FitField_UInt16))},
                        { 4, new FieldDefinition("altitude", typeof(FitField_Altitude))},
                        { 5, new FieldDefinition("altitude_reference_radius", typeof(FitField_UInt16))},
                        { 6, new FieldDefinition("comment", typeof(FitField_String))},
                    }
                )
            },

    //    Mesg localMesg57 = new Mesg("glucose", 62);
    //glucoseMesg = localMesg57;
    //localMesg57.addField(new Field("timestamp", 253, 134, 1.0D, 0.0D, "s"));
    //glucoseMesg.addField(new Field("concentration", 0, 132, 1.0D, 0.0D, "mg/dL"));
    //glucoseMesg.addField(new Field("marker", 1, 0, 1.0D, 0.0D, ""));
    //glucoseMesg.addField(new Field("checksum", 252, 2, 1.0D, 0.0D, ""));
    //glucoseMesg.addField(new Field("pad", 251, 13, 1.0D, 0.0D, ""));
    //mesgs[56] = glucoseMesg;
    
    //Mesg localMesg58 = new Mesg("glucose_influencer", 63);
    //glucoseInfluencerMesg = localMesg58;
    //localMesg58.addField(new Field("timestamp", 253, 134, 1.0D, 0.0D, "s"));
    //glucoseInfluencerMesg.addField(new Field("type", 0, 0, 1.0D, 0.0D, ""));
    //glucoseInfluencerMesg.addField(new Field("subtype", 1, 2, 1.0D, 0.0D, ""));
    //((Field)glucoseInfluencerMesg.fields.get(2)).subFields.add(new SubField("calories_subtype", 0, 1.0D, 0.0D, ""));
    //((SubField)((Field)glucoseInfluencerMesg.fields.get(2)).subFields.get(0)).addMap(0, 0L);
    //((Field)glucoseInfluencerMesg.fields.get(2)).subFields.add(new SubField("medication_subtype", 0, 1.0D, 0.0D, ""));
    //((SubField)((Field)glucoseInfluencerMesg.fields.get(2)).subFields.get(1)).addMap(0, 0L);
    //((Field)glucoseInfluencerMesg.fields.get(2)).subFields.add(new SubField("health_subtype", 0, 1.0D, 0.0D, ""));
    //((SubField)((Field)glucoseInfluencerMesg.fields.get(2)).subFields.get(2)).addMap(0, 0L);
    //glucoseInfluencerMesg.addField(new Field("amount", 2, 132, 1.0D, 0.0D, ""));
    //((Field)glucoseInfluencerMesg.fields.get(3)).subFields.add(new SubField("calories_amount", 132, 1.0D, 0.0D, "kcal"));
    //((SubField)((Field)glucoseInfluencerMesg.fields.get(3)).subFields.get(0)).addMap(0, 0L);
    //((Field)glucoseInfluencerMesg.fields.get(3)).subFields.add(new SubField("medication_amount", 132, 1.0D, 0.0D, "units"));
    //((SubField)((Field)glucoseInfluencerMesg.fields.get(3)).subFields.get(1)).addMap(0, 0L);
    //glucoseInfluencerMesg.addField(new Field("checksum", 252, 2, 1.0D, 0.0D, ""));
    //glucoseInfluencerMesg.addField(new Field("pad", 251, 13, 1.0D, 0.0D, ""));
    //mesgs[57] = glucoseInfluencerMesg;
    
    //Mesg localMesg59 = new Mesg("glucose_config", 64);
    //glucoseConfigMesg = localMesg59;
    //localMesg59.addField(new Field("measurement_type", 0, 0, 1.0D, 0.0D, ""));
    //glucoseConfigMesg.addField(new Field("strip_code", 1, 132, 1.0D, 0.0D, "TBD"));
    //glucoseConfigMesg.addField(new Field("tester", 2, 0, 1.0D, 0.0D, ""));
    //glucoseConfigMesg.addField(new Field("sample_location", 3, 0, 1.0D, 0.0D, ""));
    //glucoseConfigMesg.addField(new Field("checksum", 252, 2, 1.0D, 0.0D, ""));
    //glucoseConfigMesg.addField(new Field("pad", 251, 13, 1.0D, 0.0D, ""));
    //mesgs[58] = glucoseConfigMesg;
    
    //Mesg localMesg60 = new Mesg("glucose_summary", 65);
    //glucoseSummaryMesg = localMesg60;
    //localMesg60.addField(new Field("timestamp", 253, 134, 1.0D, 0.0D, "s"));
    //glucoseSummaryMesg.addField(new Field("period", 0, 0, 1.0D, 0.0D, ""));
    //glucoseSummaryMesg.addField(new Field("duration", 1, 132, 1.0D, 0.0D, ""));
    //((Field)glucoseSummaryMesg.fields.get(2)).subFields.add(new SubField("hourly_duration", 132, 1.0D, 0.0D, "hours"));
    //((SubField)((Field)glucoseSummaryMesg.fields.get(2)).subFields.get(0)).addMap(0, 0L);
    //((Field)glucoseSummaryMesg.fields.get(2)).subFields.add(new SubField("daily_duration", 132, 1.0D, 0.0D, "days"));
    //((SubField)((Field)glucoseSummaryMesg.fields.get(2)).subFields.get(1)).addMap(0, 1L);
    //((Field)glucoseSummaryMesg.fields.get(2)).subFields.add(new SubField("weekly_duration", 132, 1.0D, 0.0D, "weeks"));
    //((SubField)((Field)glucoseSummaryMesg.fields.get(2)).subFields.get(2)).addMap(0, 2L);
    //((Field)glucoseSummaryMesg.fields.get(2)).subFields.add(new SubField("monthly_duration", 132, 1.0D, 0.0D, "months"));
    //((SubField)((Field)glucoseSummaryMesg.fields.get(2)).subFields.get(3)).addMap(0, 3L);
    //glucoseSummaryMesg.addField(new Field("concentration", 2, 132, 1.0D, 0.0D, "mg/dL"));
    //glucoseSummaryMesg.addField(new Field("carb_intake", 3, 132, 1.0D, 0.0D, "calories"));
    //glucoseSummaryMesg.addField(new Field("calorie_expenditure", 4, 132, 1.0D, 0.0D, "calories"));
    //glucoseSummaryMesg.addField(new Field("medication_rapid", 5, 132, 1.0D, 0.0D, "units"));
    //glucoseSummaryMesg.addField(new Field("medication_short", 6, 132, 1.0D, 0.0D, "units"));
    //glucoseSummaryMesg.addField(new Field("medication_intermed", 7, 132, 1.0D, 0.0D, "units"));
    //glucoseSummaryMesg.addField(new Field("medication_long", 8, 132, 1.0D, 0.0D, "units"));
    //glucoseSummaryMesg.addField(new Field("medication_mix", 9, 132, 1.0D, 0.0D, "units"));
    //glucoseSummaryMesg.addField(new Field("checksum", 252, 2, 1.0D, 0.0D, ""));
    //glucoseSummaryMesg.addField(new Field("pad", 251, 13, 1.0D, 0.0D, ""));
    //mesgs[59] = glucoseSummaryMesg;

    //Mesg localMesg63 = new Mesg("session_config", 59);
    //sessionConfigMesg = localMesg63;
    //localMesg63.addField(new Field("stop_time_reset", 0, 2, 1.0D, 0.0D, "s"));
    //sessionConfigMesg.addField(new Field("start_time_reset", 1, 2, 1.0D, 0.0D, "s"));
    //sessionConfigMesg.addField(new Field("reset_stop_time", 2, 132, 1.0D, 0.0D, "s"));
    //sessionConfigMesg.addField(new Field("reset_factor", 3, 2, 1.0D, 0.0D, ""));
    //sessionConfigMesg.addField(new Field("checksum", 252, 2, 1.0D, 0.0D, ""));
    //sessionConfigMesg.addField(new Field("pad", 251, 13, 1.0D, 0.0D, ""));
    //mesgs[62] = sessionConfigMesg;
    
    //Mesg localMesg64 = new Mesg("session_state", 60);
    //sessionStateMesg = localMesg64;
    //localMesg64.addField(new Field("start_time", 0, 2, 1.0D, 0.0D, "s"));
    //sessionStateMesg.addField(new Field("stop_time", 1, 132, 1.0D, 0.0D, "s"));
    //sessionStateMesg.addField(new Field("checksum", 252, 2, 1.0D, 0.0D, ""));
    //sessionStateMesg.addField(new Field("pad", 251, 13, 1.0D, 0.0D, ""));
    //mesgs[63] = sessionStateMesg;

    //Mesg localMesg65 = new Mesg("sdm_data", 58);
    //sdmDataMesg = localMesg65;
    //localMesg65.addField(new Field("timestamp", 253, 134, 1.0D, 0.0D, ""));
    //sdmDataMesg.addField(new Field("event_timestamp", 0, 134, 256.0D, 0.0D, "s"));
    //sdmDataMesg.addField(new Field("distance", 1, 134, 256.0D, 0.0D, "m"));
    //sdmDataMesg.addField(new Field("speed", 2, 132, 256.0D, 0.0D, "m/s"));
    //sdmDataMesg.addField(new Field("stride_count", 3, 134, 1.0D, 0.0D, "strides"));
    //sdmDataMesg.addField(new Field("cadence", 4, 132, 256.0D, 0.0D, "strides/min"));
    //sdmDataMesg.addField(new Field("calories", 5, 134, 1.0D, 0.0D, "kcal"));
    //sdmDataMesg.addField(new Field("status", 6, 2, 1.0D, 0.0D, ""));
    //sdmDataMesg.addField(new Field("event_latency", 7, 2, 32.0D, 0.0D, "s"));
    //sdmDataMesg.addField(new Field("x_event_timestamp200", 8, 2, 1.0D, 0.0D, ""));
    //((Field)sdmDataMesg.fields.get(9)).components.add(new FieldComponent(18, false, 8, 200.0D, 0.0D));
    //sdmDataMesg.addField(new Field("x_event_timestamp", 9, 2, 1.0D, 0.0D, ""));
    //((Field)sdmDataMesg.fields.get(10)).components.add(new FieldComponent(18, false, 8, 1.0D, 0.0D));
    //sdmDataMesg.addField(new Field("x_distance", 10, 2, 1.0D, 0.0D, ""));
    //((Field)sdmDataMesg.fields.get(11)).components.add(new FieldComponent(17, false, 8, 1.0D, 0.0D));
    //sdmDataMesg.addField(new Field("x_speed_dist16", 11, 2, 1.0D, 0.0D, ""));
    //((Field)sdmDataMesg.fields.get(12)).components.add(new FieldComponent(2, false, 4, 1.0D, 0.0D));
    //((Field)sdmDataMesg.fields.get(12)).components.add(new FieldComponent(17, false, 4, 16.0D, 0.0D));
    //sdmDataMesg.addField(new Field("x_speed256", 12, 2, 1.0D, 0.0D, ""));
    //((Field)sdmDataMesg.fields.get(13)).components.add(new FieldComponent(2, false, 8, 256.0D, 0.0D));
    //sdmDataMesg.addField(new Field("x_stride_count", 13, 2, 1.0D, 0.0D, ""));
    //((Field)sdmDataMesg.fields.get(14)).components.add(new FieldComponent(3, true, 8, 1.0D, 0.0D));
    //sdmDataMesg.addField(new Field("x_cadence", 14, 10, 1.0D, 0.0D, ""));
    //((Field)sdmDataMesg.fields.get(15)).components.add(new FieldComponent(4, false, 8, 1.0D, 0.0D));
    //sdmDataMesg.addField(new Field("x_speed_cad16", 15, 10, 1.0D, 0.0D, ""));
    //((Field)sdmDataMesg.fields.get(16)).components.add(new FieldComponent(2, false, 4, 16.0D, 0.0D));
    //((Field)sdmDataMesg.fields.get(16)).components.add(new FieldComponent(4, false, 4, 1.0D, 0.0D));
    //sdmDataMesg.addField(new Field("x_calories", 16, 2, 1.0D, 0.0D, ""));
    //((Field)sdmDataMesg.fields.get(17)).components.add(new FieldComponent(5, true, 8, 1.0D, 0.0D));
    //sdmDataMesg.addField(new Field("x_distance256", 17, 132, 1.0D, 0.0D, ""));
    //((Field)sdmDataMesg.fields.get(18)).components.add(new FieldComponent(1, true, 16, 256.0D, 0.0D));
    //sdmDataMesg.addField(new Field("x_event_timestamp256", 18, 132, 1.0D, 0.0D, ""));
    //((Field)sdmDataMesg.fields.get(19)).components.add(new FieldComponent(0, true, 16, 256.0D, 0.0D));
    //sdmDataMesg.addField(new Field("checksum", 252, 2, 1.0D, 0.0D, ""));
    //sdmDataMesg.addField(new Field("pad", 251, 13, 1.0D, 0.0D, ""));
    //mesgs[64] = sdmDataMesg;

    //Mesg localMesg66 = new Mesg("hrm_data", 47);
    //hrmDataMesg = localMesg66;
    //localMesg66.addField(new Field("timestamp", 253, 134, 1.0D, 0.0D, ""));
    //hrmDataMesg.addField(new Field("beat_timestamp", 0, 132, 1024.0D, 0.0D, "s"));
    //hrmDataMesg.addField(new Field("beat_count", 1, 2, 1.0D, 0.0D, ""));
    //hrmDataMesg.addField(new Field("filtered_hr", 2, 2, 1.0D, 0.0D, "bpm"));
    //hrmDataMesg.addField(new Field("previous_beat_timestamp", 3, 132, 1024.0D, 0.0D, "s"));
    //hrmDataMesg.addField(new Field("checksum", 252, 2, 1.0D, 0.0D, ""));
    //hrmDataMesg.addField(new Field("pad", 251, 13, 1.0D, 0.0D, ""));
    //mesgs[65] = hrmDataMesg;

    //Mesg localMesg67 = new Mesg("bike_data", 50);
    //bikeDataMesg = localMesg67;
    //localMesg67.addField(new Field("timestamp", 253, 134, 1.0D, 0.0D, ""));
    //bikeDataMesg.addField(new Field("event_timestamp", 0, 132, 1024.0D, 0.0D, "s"));
    //bikeDataMesg.addField(new Field("event_count", 1, 132, 1.0D, 0.0D, ""));
    //bikeDataMesg.addField(new Field("type", 2, 0, 1.0D, 0.0D, ""));
    //bikeDataMesg.addField(new Field("checksum", 252, 2, 1.0D, 0.0D, ""));
    //bikeDataMesg.addField(new Field("pad", 251, 13, 1.0D, 0.0D, ""));
    //mesgs[66] = bikeDataMesg;

    //Mesg localMesg68 = new Mesg("ui_question", 66);
    //uiQuestionMesg = localMesg68;
    //localMesg68.addField(new Field("message_index", 254, 132, 1.0D, 0.0D, ""));
    //uiQuestionMesg.addField(new Field("text", 0, 7, 1.0D, 0.0D, ""));
    //uiQuestionMesg.addField(new Field("type", 1, 0, 1.0D, 0.0D, ""));
    //uiQuestionMesg.addField(new Field("min", 2, 134, 1.0D, 0.0D, ""));
    //uiQuestionMesg.addField(new Field("max", 3, 134, 1.0D, 0.0D, ""));
    //uiQuestionMesg.addField(new Field("units", 4, 7, 1.0D, 0.0D, ""));
    //uiQuestionMesg.addField(new Field("decimals", 5, 2, 1.0D, 0.0D, ""));
    //uiQuestionMesg.addField(new Field("response_option_group", 6, 132, 1.0D, 0.0D, ""));
    //uiQuestionMesg.addField(new Field("response_bar_graph_group", 7, 132, 1.0D, 0.0D, ""));
    //uiQuestionMesg.addField(new Field("checksum", 252, 2, 1.0D, 0.0D, ""));
    //uiQuestionMesg.addField(new Field("pad", 251, 13, 1.0D, 0.0D, ""));
    //mesgs[67] = uiQuestionMesg;

    //Mesg localMesg69 = new Mesg("ui_bar_graph_option", 77);
    //uiBarGraphOptionMesg = localMesg69;
    //localMesg69.addField(new Field("message_index", 254, 132, 1.0D, 0.0D, ""));
    //uiBarGraphOptionMesg.addField(new Field("group", 0, 132, 1.0D, 0.0D, ""));
    //uiBarGraphOptionMesg.addField(new Field("text", 1, 7, 1.0D, 0.0D, ""));
    //uiBarGraphOptionMesg.addField(new Field("value", 2, 134, 1.0D, 0.0D, ""));
    //uiBarGraphOptionMesg.addField(new Field("checksum", 252, 2, 1.0D, 0.0D, ""));
    //uiBarGraphOptionMesg.addField(new Field("pad", 251, 13, 1.0D, 0.0D, ""));
    //mesgs[68] = uiBarGraphOptionMesg;
    
    //Mesg localMesg70 = new Mesg("ui_comment", 75);
    //uiCommentMesg = localMesg70;
    //localMesg70.addField(new Field("message_index", 254, 132, 1.0D, 0.0D, ""));
    //uiCommentMesg.addField(new Field("text", 0, 7, 1.0D, 0.0D, ""));
    //uiCommentMesg.addField(new Field("checksum", 252, 2, 1.0D, 0.0D, ""));
    //uiCommentMesg.addField(new Field("pad", 251, 13, 1.0D, 0.0D, ""));
    //mesgs[69] = uiCommentMesg;
    
    //Mesg localMesg71 = new Mesg("ui_response_option", 67);
    //uiResponseOptionMesg = localMesg71;
    //localMesg71.addField(new Field("message_index", 254, 132, 1.0D, 0.0D, ""));
    //uiResponseOptionMesg.addField(new Field("group", 0, 132, 1.0D, 0.0D, ""));
    //uiResponseOptionMesg.addField(new Field("text", 1, 7, 1.0D, 0.0D, ""));
    //uiResponseOptionMesg.addField(new Field("checksum", 252, 2, 1.0D, 0.0D, ""));
    //uiResponseOptionMesg.addField(new Field("pad", 251, 13, 1.0D, 0.0D, ""));
    //mesgs[70] = uiResponseOptionMesg;
    
    //Mesg localMesg72 = new Mesg("ui_active_question", 68);
    //uiActiveQuestionMesg = localMesg72;
    //localMesg72.addField(new Field("question_index", 0, 132, 1.0D, 0.0D, ""));
    //uiActiveQuestionMesg.addField(new Field("response_value_default", 1, 134, 1.0D, 0.0D, ""));
    //uiActiveQuestionMesg.addField(new Field("response_string_default", 2, 7, 1.0D, 0.0D, ""));
    //uiActiveQuestionMesg.addField(new Field("checksum", 252, 2, 1.0D, 0.0D, ""));
    //uiActiveQuestionMesg.addField(new Field("pad", 251, 13, 1.0D, 0.0D, ""));
    //mesgs[71] = uiActiveQuestionMesg;
    
    //Mesg localMesg73 = new Mesg("ui_active_comment", 76);
    //uiActiveCommentMesg = localMesg73;
    //localMesg73.addField(new Field("comment_index", 0, 132, 1.0D, 0.0D, ""));
    //uiActiveCommentMesg.addField(new Field("comment_value", 1, 134, 1.0D, 0.0D, ""));
    //uiActiveCommentMesg.addField(new Field("comment_decimals", 2, 2, 1.0D, 0.0D, ""));
    //uiActiveCommentMesg.addField(new Field("checksum", 252, 2, 1.0D, 0.0D, ""));
    //uiActiveCommentMesg.addField(new Field("pad", 251, 13, 1.0D, 0.0D, ""));
    //mesgs[72] = uiActiveCommentMesg;
    
    //Mesg localMesg74 = new Mesg("ui_response", 69);
    //uiResponseMesg = localMesg74;
    //localMesg74.addField(new Field("question_index", 0, 132, 1.0D, 0.0D, ""));
    //uiResponseMesg.addField(new Field("response_value", 1, 134, 1.0D, 0.0D, ""));
    //uiResponseMesg.addField(new Field("response_string", 2, 7, 1.0D, 0.0D, ""));
    //uiResponseMesg.addField(new Field("checksum", 252, 2, 1.0D, 0.0D, ""));
    //uiResponseMesg.addField(new Field("pad", 251, 13, 1.0D, 0.0D, ""));
    //mesgs[73] = uiResponseMesg;
    
    //Mesg localMesg75 = new Mesg("personal_record", 114);
    //personalRecordMesg = localMesg75;
    //localMesg75.addField(new Field("message_index", 254, 132, 1.0D, 0.0D, ""));
    //personalRecordMesg.addField(new Field("timestamp", 253, 134, 1.0D, 0.0D, ""));
    //personalRecordMesg.addField(new Field("category", 0, 132, 1.0D, 0.0D, ""));
    //personalRecordMesg.addField(new Field("sport", 1, 0, 1.0D, 0.0D, ""));
    //personalRecordMesg.addField(new Field("duration", 2, 134, 1.0D, 0.0D, ""));
    //((Field)personalRecordMesg.fields.get(4)).subFields.add(new SubField("duration_distance", 134, 100.0D, 0.0D, "m"));
    //((SubField)((Field)personalRecordMesg.fields.get(4)).subFields.get(0)).addMap(0, 0L);
    //((Field)personalRecordMesg.fields.get(4)).subFields.add(new SubField("duration_time", 134, 1000.0D, 0.0D, "s"));
    //((SubField)((Field)personalRecordMesg.fields.get(4)).subFields.get(1)).addMap(0, 1L);
    //((SubField)((Field)personalRecordMesg.fields.get(4)).subFields.get(1)).addMap(0, 2L);
    //((SubField)((Field)personalRecordMesg.fields.get(4)).subFields.get(1)).addMap(0, 3L);
    //personalRecordMesg.addField(new Field("tolerance_min", 3, 134, 1.0D, 0.0D, ""));
    //((Field)personalRecordMesg.fields.get(5)).subFields.add(new SubField("tolerance_min_distance", 134, 100.0D, 0.0D, "m"));
    //((SubField)((Field)personalRecordMesg.fields.get(5)).subFields.get(0)).addMap(0, 0L);
    //personalRecordMesg.addField(new Field("tolerance_max", 4, 134, 1.0D, 0.0D, ""));
    //((Field)personalRecordMesg.fields.get(6)).subFields.add(new SubField("tolerance_max_distance", 134, 100.0D, 0.0D, "m"));
    //((SubField)((Field)personalRecordMesg.fields.get(6)).subFields.get(0)).addMap(0, 0L);
    //personalRecordMesg.addField(new Field("result", 5, 134, 1.0D, 0.0D, ""));
    //((Field)personalRecordMesg.fields.get(7)).subFields.add(new SubField("result_time", 134, 1000.0D, 0.0D, "s"));
    //((SubField)((Field)personalRecordMesg.fields.get(7)).subFields.get(0)).addMap(0, 0L);
    //((Field)personalRecordMesg.fields.get(7)).subFields.add(new SubField("result_distance", 134, 100.0D, 0.0D, "m"));
    //((SubField)((Field)personalRecordMesg.fields.get(7)).subFields.get(1)).addMap(0, 1L);
    //((Field)personalRecordMesg.fields.get(7)).subFields.add(new SubField("result_ascent", 134, 1.0D, 0.0D, "m"));
    //((SubField)((Field)personalRecordMesg.fields.get(7)).subFields.get(2)).addMap(0, 2L);
    //((Field)personalRecordMesg.fields.get(7)).subFields.add(new SubField("result_power", 134, 1.0D, 0.0D, "watts"));
    //((SubField)((Field)personalRecordMesg.fields.get(7)).subFields.get(3)).addMap(0, 3L);
    //personalRecordMesg.addField(new Field("flags", 6, 140, 1.0D, 0.0D, ""));
    //personalRecordMesg.addField(new Field("result_min", 7, 134, 1.0D, 0.0D, ""));
    //((Field)personalRecordMesg.fields.get(9)).subFields.add(new SubField("result_min_time", 134, 1000.0D, 0.0D, "s"));
    //((SubField)((Field)personalRecordMesg.fields.get(9)).subFields.get(0)).addMap(0, 0L);
    //((Field)personalRecordMesg.fields.get(9)).subFields.add(new SubField("result_min_distance", 134, 100.0D, 0.0D, "m"));
    //((SubField)((Field)personalRecordMesg.fields.get(9)).subFields.get(1)).addMap(0, 1L);
    //((Field)personalRecordMesg.fields.get(9)).subFields.add(new SubField("result_min_ascent", 134, 1.0D, 0.0D, "m"));
    //((SubField)((Field)personalRecordMesg.fields.get(9)).subFields.get(2)).addMap(0, 2L);
    //((Field)personalRecordMesg.fields.get(9)).subFields.add(new SubField("result_min_power", 134, 1.0D, 0.0D, "watts"));
    //((SubField)((Field)personalRecordMesg.fields.get(9)).subFields.get(3)).addMap(0, 3L);
    //personalRecordMesg.addField(new Field("checksum", 252, 2, 1.0D, 0.0D, ""));
    //personalRecordMesg.addField(new Field("pad", 251, 13, 1.0D, 0.0D, ""));
    //mesgs[74] = personalRecordMesg;
    
    //Mesg localMesg76 = new Mesg("debug", 24);
    //debugMesg = localMesg76;
    //localMesg76.addField(new Field("timestamp", 253, 134, 1.0D, 0.0D, "s"));
    //debugMesg.addField(new Field("id", 0, 2, 1.0D, 0.0D, ""));
    //debugMesg.addField(new Field("string", 1, 7, 1.0D, 0.0D, ""));
    //debugMesg.addField(new Field("data", 2, 13, 1.0D, 0.0D, ""));
    //debugMesg.addField(new Field("time256", 3, 2, 1.0D, 0.0D, ""));
    //((Field)debugMesg.fields.get(4)).components.add(new FieldComponent(4, false, 8, 256.0D, 0.0D));
    //debugMesg.addField(new Field("fractional_timestamp", 4, 132, 32768.0D, 0.0D, "s"));
    //debugMesg.addField(new Field("checksum", 252, 2, 1.0D, 0.0D, ""));
    //debugMesg.addField(new Field("pad", 251, 13, 1.0D, 0.0D, ""));
    //mesgs[75] = debugMesg;
    
    //Mesg localMesg77 = new Mesg("debug_state", 41);
    //debugStateMesg = localMesg77;
    //localMesg77.addField(new Field("timestamp", 253, 134, 1.0D, 0.0D, "s"));
    //debugStateMesg.addField(new Field("time256", 0, 2, 1.0D, 0.0D, ""));
    //((Field)debugStateMesg.fields.get(1)).components.add(new FieldComponent(3, false, 8, 1.0D, 0.0D));
    //debugStateMesg.addField(new Field("battery_voltage", 1, 132, 1000.0D, 0.0D, "V"));
    //debugStateMesg.addField(new Field("temperature", 2, 131, 100.0D, 0.0D, "C"));
    //debugStateMesg.addField(new Field("fractional_timestamp", 3, 132, 32768.0D, 0.0D, "s"));
    //debugStateMesg.addField(new Field("system_flags", 4, 134, 1.0D, 0.0D, ""));
    //debugStateMesg.addField(new Field("checksum", 252, 2, 1.0D, 0.0D, ""));
    //debugStateMesg.addField(new Field("pad", 251, 13, 1.0D, 0.0D, ""));
    //mesgs[76] = debugStateMesg;
    
    //Mesg localMesg78 = new Mesg("debug_event", 42);
    //debugEventMesg = localMesg78;
    //localMesg78.addField(new Field("timestamp", 253, 134, 1.0D, 0.0D, "s"));
    //debugEventMesg.addField(new Field("time256", 0, 2, 1.0D, 0.0D, ""));
    //((Field)debugEventMesg.fields.get(1)).components.add(new FieldComponent(3, false, 8, 256.0D, 0.0D));
    //debugEventMesg.addField(new Field("type", 1, 0, 1.0D, 0.0D, ""));
    //debugEventMesg.addField(new Field("data", 2, 13, 1.0D, 0.0D, ""));
    //((Field)debugEventMesg.fields.get(3)).subFields.add(new SubField("pedal_position_truth", 2, 1.0D, 0.0D, ""));
    //((SubField)((Field)debugEventMesg.fields.get(3)).subFields.get(0)).addMap(1, 15L);
    //debugEventMesg.addField(new Field("fractional_timestamp", 3, 132, 32768.0D, 0.0D, "s"));
    //debugEventMesg.addField(new Field("checksum", 252, 2, 1.0D, 0.0D, ""));
    //debugEventMesg.addField(new Field("pad", 251, 13, 1.0D, 0.0D, ""));
    //mesgs[77] = debugEventMesg;
    
    //Mesg localMesg79 = new Mesg("dsi_config", 40);
    //dsiConfigMesg = localMesg79;
    //localMesg79.addField(new Field("version", 0, 132, 1.0D, 0.0D, ""));
    //dsiConfigMesg.addField(new Field("data_5", 5, 13, 1.0D, 0.0D, ""));
    //((Field)dsiConfigMesg.fields.get(1)).components.add(new FieldComponent(118, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(1)).components.add(new FieldComponent(103, false, 4, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(1)).components.add(new FieldComponent(102, false, 4, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(1)).components.add(new FieldComponent(105, false, 32, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(1)).components.add(new FieldComponent(106, false, 32, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(1)).components.add(new FieldComponent(107, false, 16, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(1)).components.add(new FieldComponent(108, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(1)).components.add(new FieldComponent(109, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(1)).components.add(new FieldComponent(105, false, 32, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(1)).components.add(new FieldComponent(106, false, 32, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(1)).components.add(new FieldComponent(107, false, 16, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(1)).components.add(new FieldComponent(108, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(1)).components.add(new FieldComponent(109, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(1)).components.add(new FieldComponent(105, false, 32, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(1)).components.add(new FieldComponent(106, false, 32, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(1)).components.add(new FieldComponent(107, false, 16, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(1)).components.add(new FieldComponent(108, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(1)).components.add(new FieldComponent(109, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(1)).components.add(new FieldComponent(111, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(1)).components.add(new FieldComponent(112, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(1)).components.add(new FieldComponent(111, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(1)).components.add(new FieldComponent(112, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(1)).components.add(new FieldComponent(111, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(1)).components.add(new FieldComponent(112, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(1)).components.add(new FieldComponent(111, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(1)).components.add(new FieldComponent(112, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(1)).components.add(new FieldComponent(110, false, 16, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(1)).components.add(new FieldComponent(114, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(1)).components.add(new FieldComponent(113, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(1)).components.add(new FieldComponent(101, false, 16, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(1)).components.add(new FieldComponent(255, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(1)).components.add(new FieldComponent(115, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(1)).components.add(new FieldComponent(116, false, 16, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(1)).components.add(new FieldComponent(117, false, 16, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(1)).components.add(new FieldComponent(104, false, 32, 1.0D, 0.0D));
    //dsiConfigMesg.addField(new Field("data_6", 6, 13, 1.0D, 0.0D, ""));
    //((Field)dsiConfigMesg.fields.get(2)).components.add(new FieldComponent(118, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(2)).components.add(new FieldComponent(103, false, 4, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(2)).components.add(new FieldComponent(102, false, 4, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(2)).components.add(new FieldComponent(105, false, 32, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(2)).components.add(new FieldComponent(106, false, 32, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(2)).components.add(new FieldComponent(107, false, 16, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(2)).components.add(new FieldComponent(108, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(2)).components.add(new FieldComponent(109, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(2)).components.add(new FieldComponent(105, false, 32, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(2)).components.add(new FieldComponent(106, false, 32, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(2)).components.add(new FieldComponent(107, false, 16, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(2)).components.add(new FieldComponent(108, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(2)).components.add(new FieldComponent(109, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(2)).components.add(new FieldComponent(105, false, 32, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(2)).components.add(new FieldComponent(106, false, 32, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(2)).components.add(new FieldComponent(107, false, 16, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(2)).components.add(new FieldComponent(108, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(2)).components.add(new FieldComponent(109, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(2)).components.add(new FieldComponent(111, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(2)).components.add(new FieldComponent(112, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(2)).components.add(new FieldComponent(111, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(2)).components.add(new FieldComponent(112, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(2)).components.add(new FieldComponent(111, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(2)).components.add(new FieldComponent(112, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(2)).components.add(new FieldComponent(111, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(2)).components.add(new FieldComponent(112, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(2)).components.add(new FieldComponent(110, false, 16, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(2)).components.add(new FieldComponent(114, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(2)).components.add(new FieldComponent(113, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(2)).components.add(new FieldComponent(101, false, 16, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(2)).components.add(new FieldComponent(255, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(2)).components.add(new FieldComponent(115, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(2)).components.add(new FieldComponent(116, false, 16, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(2)).components.add(new FieldComponent(117, false, 16, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(2)).components.add(new FieldComponent(104, false, 32, 1.0D, 0.0D));
    //dsiConfigMesg.addField(new Field("data_15", 15, 13, 1.0D, 0.0D, ""));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(118, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(103, false, 4, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(102, false, 4, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(105, false, 32, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(106, false, 32, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(107, false, 16, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(108, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(109, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(105, false, 32, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(106, false, 32, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(107, false, 16, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(108, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(109, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(105, false, 32, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(106, false, 32, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(107, false, 16, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(108, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(109, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(111, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(112, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(111, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(112, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(111, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(112, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(111, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(112, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(119, false, 16, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(120, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(121, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(122, false, 16, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(122, false, 16, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(122, false, 16, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(108, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(108, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(108, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(109, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(109, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(109, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(119, false, 16, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(120, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(121, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(122, false, 16, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(122, false, 16, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(122, false, 16, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(108, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(108, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(108, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(109, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(109, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(109, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(119, false, 16, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(120, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(121, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(122, false, 16, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(122, false, 16, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(122, false, 16, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(108, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(108, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(108, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(109, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(109, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(109, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(119, false, 16, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(120, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(121, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(122, false, 16, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(122, false, 16, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(122, false, 16, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(108, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(108, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(108, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(109, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(109, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(109, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(119, false, 16, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(120, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(121, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(122, false, 16, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(122, false, 16, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(122, false, 16, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(108, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(108, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(108, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(109, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(109, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(109, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(119, false, 16, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(120, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(121, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(122, false, 16, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(122, false, 16, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(122, false, 16, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(108, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(108, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(108, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(109, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(109, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(109, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(119, false, 16, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(120, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(121, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(122, false, 16, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(122, false, 16, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(122, false, 16, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(108, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(108, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(108, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(109, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(109, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(109, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(119, false, 16, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(120, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(121, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(122, false, 16, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(122, false, 16, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(122, false, 16, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(108, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(108, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(108, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(109, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(109, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(109, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(119, false, 16, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(120, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(121, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(122, false, 16, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(122, false, 16, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(122, false, 16, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(108, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(108, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(108, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(109, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(109, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(109, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(119, false, 16, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(120, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(121, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(122, false, 16, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(122, false, 16, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(122, false, 16, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(108, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(108, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(108, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(109, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(109, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(109, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(110, false, 16, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(123, false, 16, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(124, false, 16, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(125, false, 16, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(126, false, 16, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(127, false, 16, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(128, false, 16, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(129, false, 16, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(114, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(113, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(130, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(130, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(130, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(131, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(132, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(133, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(134, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(135, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(136, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(255, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(101, false, 16, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(255, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(115, false, 8, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(116, false, 16, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(117, false, 16, 1.0D, 0.0D));
    //((Field)dsiConfigMesg.fields.get(3)).components.add(new FieldComponent(104, false, 32, 1.0D, 0.0D));
    //dsiConfigMesg.addField(new Field("control_bits", 101, 132, 1.0D, 0.0D, ""));
    //dsiConfigMesg.addField(new Field("hardware_major_version", 102, 2, 1.0D, 0.0D, ""));
    //dsiConfigMesg.addField(new Field("hardware_minor_version", 103, 2, 1.0D, 0.0D, ""));
    //dsiConfigMesg.addField(new Field("serial_number", 104, 140, 1.0D, 0.0D, ""));
    //dsiConfigMesg.addField(new Field("accel_offset", 105, 133, 1.0D, 0.0D, ""));
    //dsiConfigMesg.addField(new Field("accel_sens", 106, 133, 1.0D, 0.0D, ""));
    //dsiConfigMesg.addField(new Field("accel_temp_slope", 107, 131, 1.0D, 0.0D, ""));
    //dsiConfigMesg.addField(new Field("accel_variance", 108, 2, 1.0D, 0.0D, ""));
    //dsiConfigMesg.addField(new Field("accel_delta", 109, 2, 1.0D, 0.0D, ""));
    //dsiConfigMesg.addField(new Field("cal_temperature", 110, 131, 1.0D, 0.0D, ""));
    //dsiConfigMesg.addField(new Field("speed_slope_adjust", 111, 1, 512.0D, 0.0D, "%"));
    //dsiConfigMesg.addField(new Field("speed_offset_adjust", 112, 1, 256.0D, 0.0D, "m/s"));
    //dsiConfigMesg.addField(new Field("dco_cal", 113, 2, 1.0D, 0.0D, ""));
    //dsiConfigMesg.addField(new Field("bc1_cal", 114, 2, 1.0D, 0.0D, ""));
    //dsiConfigMesg.addField(new Field("fuse_key", 115, 2, 1.0D, 0.0D, ""));
    //dsiConfigMesg.addField(new Field("config_crc", 116, 132, 1.0D, 0.0D, ""));
    //dsiConfigMesg.addField(new Field("serial_number_crc", 117, 132, 1.0D, 0.0D, ""));
    //dsiConfigMesg.addField(new Field("mfg_test_bits", 118, 2, 1.0D, 0.0D, ""));
    //dsiConfigMesg.addField(new Field("temp_cal_temperature", 119, 131, 1.0D, 0.0D, ""));
    //dsiConfigMesg.addField(new Field("temperature_variance", 120, 2, 1.0D, 0.0D, ""));
    //dsiConfigMesg.addField(new Field("temperature_delta", 121, 2, 1.0D, 0.0D, ""));
    //dsiConfigMesg.addField(new Field("accel_offset_shift", 122, 131, 1.0D, 0.0D, ""));
    //dsiConfigMesg.addField(new Field("temperature_offset", 123, 131, 1.0D, 0.0D, ""));
    //dsiConfigMesg.addField(new Field("temp_cal_max_temperature", 124, 131, 1.0D, 0.0D, ""));
    //dsiConfigMesg.addField(new Field("temp_cal_min_temperature", 125, 131, 1.0D, 0.0D, ""));
    //dsiConfigMesg.addField(new Field("temp_cal_low_time", 126, 132, 1.0D, 0.0D, "s"));
    //dsiConfigMesg.addField(new Field("temp_cal_rise_time", 127, 132, 1.0D, 0.0D, "s"));
    //dsiConfigMesg.addField(new Field("temp_cal_high_time", 128, 132, 1.0D, 0.0D, "s"));
    //dsiConfigMesg.addField(new Field("temp_cal_total_time", 129, 132, 1.0D, 0.0D, "s"));
    //dsiConfigMesg.addField(new Field("accel_cfg", 130, 2, 1.0D, 0.0D, ""));
    //dsiConfigMesg.addField(new Field("accel_cfg_version", 131, 2, 1.0D, 0.0D, ""));
    //dsiConfigMesg.addField(new Field("accel_sens_shift_bits", 132, 2, 1.0D, 0.0D, ""));
    //dsiConfigMesg.addField(new Field("accel_offset_shift_bits", 133, 2, 1.0D, 0.0D, ""));
    //dsiConfigMesg.addField(new Field("accel_variance_shift_bits", 134, 2, 1.0D, 0.0D, ""));
    //dsiConfigMesg.addField(new Field("temperature_shift_bits", 135, 2, 1.0D, 0.0D, ""));
    //dsiConfigMesg.addField(new Field("temperature_variance_shift_bits", 136, 2, 1.0D, 0.0D, ""));
    //dsiConfigMesg.addField(new Field("checksum", 252, 2, 1.0D, 0.0D, ""));
    //dsiConfigMesg.addField(new Field("pad", 251, 13, 1.0D, 0.0D, ""));
    //mesgs[78] = dsiConfigMesg;
            #endregion


        };
    }
}
