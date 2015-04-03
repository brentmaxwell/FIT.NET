using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theBrent.FitLibrary.FieldTypes
{
    public class FitField_SubSport : FitField_Enum
    {
        public new SubSport? Value
        {
            get { return (SubSport?)base.Value; }
        }

        public FitField_SubSport(byte[] fieldData) : base(fieldData) { }
    }

    public enum SubSport
    {

        Generic = 0,

        /// <summary>
        /// Run/Fitness Equipment
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
        /// Cycling/Fitness Equipment
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

        /// <summary>
        /// Training
        /// </summary>
        FlexibilityTraining = 19,

        /// <summary>
        /// Training
        /// </summary>
        StrengthTraining = 20,

        /// <summary>
        /// Tennis
        /// </summary>
        WarmUp = 21,

        /// <summary>
        /// Tennis
        /// </summary>
        Match = 22,

        /// <summary>
        /// Tennis
        /// </summary>
        Exercise = 23,

        /// <summary>
        /// Tennis
        /// </summary>
        Challenge = 24,

        /// <summary>
        /// Fitness Equipment
        /// </summary>
        IndoorSkiing = 25,

        /// <summary>
        /// Training
        /// </summary>
        CardioTraining = 26,

        All = 254,

        INVALID = 255
    }
}
