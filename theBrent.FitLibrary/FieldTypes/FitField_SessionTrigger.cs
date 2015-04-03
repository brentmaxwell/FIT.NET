using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theBrent.FitLibrary.FieldTypes
{
    public class FitField_SessionTrigger : FitField_Enum
    {
        public new SessionTrigger? Value
        {
            get { return (SessionTrigger?)base.Value; }
        }

        public FitField_SessionTrigger(byte[] fieldData) : base(fieldData) { }
    }

    public enum SessionTrigger
    {
        ActivityEnd = 0,

        /// <summary>
        /// User changed sport.
        /// </summary>
        Manual = 1,

        /// <summary>
        /// Auto multi-sport feature is enabled and user pressed lap button to advance session.
        /// </summary>
        AutoMultiSport = 2,

        /// <summary>
        /// Auto sport change caused by user linking to fitness equipment.
        /// </summary>
        FitnessEquipment = 3,
    }
}
