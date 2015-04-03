using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theBrent.FitLibrary.FieldTypes
{
    public class FitField_ActivitySubType : FitField_Enum
    {
        public new ActivitySubType? Value
        {
            get { return (ActivitySubType?)base.Value; }
        }

        public FitField_ActivitySubType(byte[] fieldData) : base(fieldData) { }
    }

    public enum ActivitySubType
    {
        Generic = 0,

        /// <summary>
        /// Run
        /// </summary>
        Treadmill = 1,

        /// <summary>
        /// Run
        /// </summary>
        Street = 2,

        /// <summary>
        /// Run
        /// </summary>
        Trail = 3,

        /// <summary>
        /// Run
        /// </summary>
        Track = 4,

        /// <summary>
        /// Cycling
        /// </summary>
        Spin = 5,

        /// <summary>
        /// Cycling
        /// </summary>
        IndoorCycling = 6, 

        /// <summary>
        /// Cycling
        /// </summary>
        Road = 7, 

        /// <summary>
        /// Cycling
        /// </summary>
        Mountain = 8, 

        /// <summary>
        /// Cycling
        /// </summary>
        Downhill = 9, 

        /// <summary>
        /// Cycling
        /// </summary>
        Recumbent = 10, 

        /// <summary>
        /// Cycling
        /// </summary>
        Cyclocross = 11, 
        
        /// <summary>
        /// Cycling
        /// </summary>
        HandCycling = 12, 

        /// <summary>
        /// Cycling
        /// </summary>
        TrackCycling = 13,

        /// <summary>
        /// Fitness Equipment
        /// </summary>
        IndoorRowing = 14,

        /// <summary>
        /// Fitness Equipment
        /// </summary>
        Elliptical = 15,

        /// <summary>
        /// Fitness Equipment
        /// </summary>
        StairClimbing = 16,

        /// <summary>
        /// Swimming
        /// </summary>
        LapSwimming = 17,

        /// <summary>
        /// Swimming
        /// </summary>
        OpenWater = 18,
        ALL = 254,
        INVALID = 255
    }
}
