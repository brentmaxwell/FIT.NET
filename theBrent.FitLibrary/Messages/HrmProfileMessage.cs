using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using theBrent.FitLibrary.FieldTypes;

namespace theBrent.FitLibrary.Messages
{
    public class HrmProfileMessage : DataMessage
    {
        public FitField_MessageIndex MessageIndex
        {
            get { return (FitField_MessageIndex)this["message_index"]; }
        }

        public FitField_Bool Enabled
        {
            get { return (FitField_Bool) this["enabled"]; }
        }

        public FitField_UInt16z HrmAntID
        {
            get { return (FitField_UInt16z) this["hrm_ant_id"]; }
        }

        public FitField_Bool LogHrv
        {
            get { return (FitField_Bool) this["log_hrv"]; }
        }

        public FitField_UInt8z HrmAntIDTransType
        {
            get { return (FitField_UInt8z) this["hrm_ant_id_trans_type"]; }
        }

        public HrmProfileMessage(DataMessage message) : base(message) { }
    }
}
