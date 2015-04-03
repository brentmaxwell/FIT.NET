using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theBrent.FitLibrary.FieldTypes
{
    public class FitField_MesgNum : FitField_UInt16
    {
        public new MessageNumber? Value
        {
            get { return (MessageNumber?)base.Value; }
        }

        public FitField_MesgNum(byte[] fieldData) : base(fieldData) { }
    }

    public enum MessageNumber
    {
        FileId = 0,
        Capabilities = 1,
        DeviceSettings = 2,
        UserProfile = 3,
        HrmProfile = 4,
        SdmProfile = 5,
        BikeProfile = 6,
        ZonesTarget = 7,
        HrZone = 8,
        PowerZone = 9,
        MetZone = 10,
        Sport = 12,
        Goal = 15,
        Session = 18,
        Lap = 19,
        Record = 20,
        Event = 21,
        DeviceInfo = 23,
        Workout = 26,
        WorkoutStep = 27,
        Schedule = 28,
        WeightScale = 30,
        Course = 31,
        CoursePoint = 32,
        Totals = 33,
        Activity = 34,
        Software = 35,
        FileCapabilities = 37,
        MesgCapabilities = 38,
        FieldCapabilities = 39,
        FileCreator = 49,
        BloodPressure = 51,    
        Monitoring = 55,
        TrainingFile = 72,
        Hrv = 78,
        Length = 101,
        MonitoringInfo = 103,
        Pad = 105,
        SlaveDevice = 106,
        CadenceZone = 131,
        MemoGlob = 145,

        /// <summary>
        /// 0xFF00 - 0xFFFE reserved for manufacturer specific messages
        /// </summary>
        MfgRangeMin = 0xFF00,

        /// <summary>
        /// 0xFF00 - 0xFFFE reserved for manufacturer specific messages
        /// </summary>
        MfgRangeMax = 0xFFFE,

        TrainingPages = 14, //UNDOCUMENTED
        Location = 29,//UNDOCUMENTED
        SpeedZone = 53,  //UNDOCUMENTED
        ActivityMonitorProfile = 83, //UNDOCUMENTED
        Connectivity = 127, //UNDOCUMENTED
    }
}
