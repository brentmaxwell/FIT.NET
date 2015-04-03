using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theBrent.FitLibrary.FieldTypes
{
    public class FitField_FitnessEquipmentState : FitField_Enum
    {
        public new FitnessEquipmentState? Value
        {
            get { return (FitnessEquipmentState?)base.Value; }
        }

        public FitField_FitnessEquipmentState(byte[] fieldData) : base(fieldData) { }
    }

    /// <summary>
    /// fitness equipment event data
    /// </summary>
    public enum FitnessEquipmentState
    {
        Ready = 0,
        InUse = 1,
        Paused = 2,

        /// <summary>
        /// lost connection to fitness equipment
        /// </summary>
        Unknown = 3,

        INVALID = 255
    }
}
