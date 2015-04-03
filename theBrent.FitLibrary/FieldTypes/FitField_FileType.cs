using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theBrent.FitLibrary.FieldTypes
{
    public class FitField_FileType : FitField_Enum
    {
        public new FileType? Value
        {
            get { return (FileType?)base.Value; }
        }

        public FitField_FileType(byte[] fieldData) : base(fieldData) { }
    }

    public enum FileType
    {
        /// <summary>
        /// Read only, single file. Must be in root directory.
        /// </summary>
        Device = 1,

        /// <summary>
        /// Read/write, single file. Directory=Settings
        /// </summary>
        Settings = 2,

        /// <summary>
        /// Read/write, multiple files, file number = sport type. Directory=Sports
        /// </summary>
        Sport = 3,

        /// <summary>
        /// Read/erase, multiple files. Directory=Activities
        /// </summary>
        Activity = 4,

        /// <summary>
        /// Read/write/erase, multiple files. Directory=Workouts
        /// </summary>
        Workout = 5,

        /// <summary>
        /// Read/write/erase, multiple files. Directory=Courses
        /// </summary>
        Course = 6,

        /// <summary>
        /// Read/write, single file. Directory=Schedules
        /// </summary>
        Schedules = 7,

        /// <summary>
        /// Garmin custom
        /// </summary>
        Elevations = 8,

        /// <summary>
        /// Read only, single file. Circular buffer. All message definitions at start of file. Directory=Weight
        /// </summary>
        Weight = 9,

        /// <summary>
        /// Read only, single file. Directory=Totals
        /// </summary>
        Totals = 10,

        /// <summary>
        /// Read/write, single file. Directory=Goals
        /// </summary>
        Goals = 11,

        /// <summary>
        /// Read only. Directory=Blood Pressure
        /// </summary>
        BloodPressure = 14,

        /// <summary>
        /// Read only. Directory=Monitoring. File number=sub type.
        /// </summary>
        MonitoringA = 15,

        /// <summary>
        /// Read/erase, multiple files. Directory=Activities
        /// </summary>
        ActivitySummary = 20,

        /// <summary>
        ///
        /// </summary>
        MonitoringDaily = 28,

        /// <summary>
        /// Garmin custom
        /// </summary>
        Records = 29,

        /// <summary>
        /// Read only. Directory=Monitoring. File number=identifier
        /// </summary>
        MonitoringB = 32,
    }
}
