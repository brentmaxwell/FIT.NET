using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using theBrent.FitLibrary.FieldTypes;

namespace theBrent.FitLibrary.Messages
{
    public class RecordMessage : DataMessage
    {
        public FitField_DateTime TimeStamp
        {
            get { return (FitField_DateTime)this["timestamp"]; }
        }

        public FitField_SInt32 PositionLat
        {
            get { return (FitField_SInt32)this["position_lat"]; }
        }

        public FitField_SInt32 PositionLong
        {
            get { return (FitField_SInt32)this["position_long"]; }
        }

        public FitField_UInt16 Altitude
        {
            get { return (FitField_UInt16)this["altitude"]; }
        }

        public FitField_UInt8 HeartRate
        {
            get { return (FitField_UInt8)this["heart_rate"]; }
        }

        public FitField_UInt8 Cadence
        {
            get { return (FitField_UInt8)this["cadence"]; }
        }

        public FitField_UInt32 Distance
        {
            get { return (FitField_UInt32)this["distance"]; }
        }

        public FitField_UInt16 Speed
        {
            get { return (FitField_UInt16)this["speed"]; }
        }

        public FitField_UInt16 Power
        {
            get { return (FitField_UInt16)this["power"]; }
        }

        public FitField_SInt16 Grade
        {
            get { return (FitField_SInt16)this["grade"]; }
        }

        public FitField_UInt8 Resistance
        {
            get { return (FitField_UInt8)this["resistance"]; }
        }

        public FitField_SInt32 TimeFromCourse
        {
            get { return (FitField_SInt32)this["time_from_course"]; }
        }

        public FitField_UInt8 CycleLength
        {
            get { return (FitField_UInt8)this["cycle_length"]; }
        }

        public FitField_SInt8 Temperature
        {
            get { return (FitField_SInt8)this["temperature"]; }
        }

        public FitField_UInt8 Speed1s
        {
            get { return (FitField_UInt8)this["speed_1s"]; }
        }

        public FitField_UInt8 Cycles
        {
            get { return (FitField_UInt8)this["cycles"]; }
        }

        public FitField_UInt32 TotalCycles
        {
            get { return (FitField_UInt32)this["total_cycles"]; }
        }

        public FitField_UInt32 AccumulatedPower
        {
            get { return (FitField_UInt32)this["accumulated_power"]; }
        }

        public FitField_LeftRightBalance LeftRightBalance
        {
            get { return (FitField_LeftRightBalance)this["left_right_balance"]; }
        }

        public FitField_UInt8 GpsAccuracy
        {
            get { return (FitField_UInt8)this["gps_accuracy"]; }
        }

        public FitField_SInt16 VerticalSpeed
        {
            get { return (FitField_SInt16)this["vertical_speed"]; }
        }

        public FitField_UInt16 Calories
        {
            get { return (FitField_UInt16)this["calories"]; }
        }

        public RecordMessage(DataMessage message) : base(message) { }
    }
}
