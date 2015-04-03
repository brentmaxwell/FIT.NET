using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using theBrent.FitLibrary.FieldTypes;

namespace theBrent.FitLibrary.Messages
{
    public class SdmProfileMessage : DataMessage
    {
        public FitField_MessageIndex MessageIndex
        {
            get { return (FitField_MessageIndex)this["message_index"]; }
        }

        public FitField_Bool Enabled
        {
            get { return (FitField_Bool) this["enabled"]; }
        }

        public FitField_UInt16z SdmAntID
        {
            get { return (FitField_UInt16z) this["sdm_ant_id"]; }
        }

        public FitField_UInt16 SdmCalFactor
        {
            get { return (FitField_UInt16)this["sdm_cal_factor"]; }
        }

        public FitField_UInt32 Odometer
        {
            get { return (FitField_UInt32)this["odometer"]; }
        }

        /// <summary>
        /// Use footpod for speed source instead of GPS
        /// </summary>
        public FitField_Bool SpeedSource
        {
            get { return (FitField_Bool) this["speed_source"]; }
        }

        public FitField_UInt8z SdmAntIDTransType
        {
            get { return (FitField_UInt8z) this["sdm_ant_id_trans_type"]; }
        }

        /// <summary>
        /// Rollover counter that can be used to extend the odometer
        /// </summary>
        public FitField_UInt8 OdometerRollover
        {
            get { return (FitField_UInt8)this["odometer_rollover"]; }
        }

        public SdmProfileMessage(DataMessage message) : base(message) { }
    }
}
