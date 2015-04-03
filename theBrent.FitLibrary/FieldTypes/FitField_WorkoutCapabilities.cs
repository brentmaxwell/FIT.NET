using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theBrent.FitLibrary.FieldTypes
{
    public class FitField_WorkoutCapabilities : FitField_UInt32z
    {
        public new WorkoutCapabilities? Value
        {
            get { return (WorkoutCapabilities?)base.Value; }
        }

        public FitField_WorkoutCapabilities(byte[] fieldData) : base(fieldData) { }
    }

    [Flags]
    public enum WorkoutCapabilities
    {
        Interval = 0x00000001,
        Custom = 0x00000002,
        FitnessEquipment = 0x00000004,
        Firstbeat = 0x00000008,
        NewLeaf = 0x00000010,

        /// <summary>
        /// For backwards compatibility.  Watch should add missing id fields then clear flag.
        /// </summary>
        Tcx = 0x00000020,

        /// <summary>
        /// Speed source required for workout step.
        /// </summary>
        Speed = 0x00000080,

        /// <summary>
        /// Heart rate source required for workout step.
        /// </summary>
        HeartRate = 0x00000100,

        /// <summary>
        /// Distance source required for workout step.
        /// </summary>
        Distance = 0x00000200,

        /// <summary>
        /// Cadence source required for workout step.
        /// </summary>
        Cadence = 0x00000400,

        /// <summary>
        /// Power source required for workout step.
        /// </summary>
        Power = 0x00000800,

        /// <summary>
        /// Grade source required for workout step.
        /// </summary>
        Grade = 0x00001000,

        /// <summary>
        /// Resistance source required for workout step.
        /// </summary>
        Resistance = 0x00002000,
        Protected = 0x00004000,
        INVALID = 0x00000000
    }
}
