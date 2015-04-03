using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using theBrent.FitLibrary.FieldTypes;

namespace theBrent.FitLibrary.Messages
{
    public class SessionMessage : DataMessage
    {
        public FitField_MessageIndex MessageIndex
        {
            get { return (FitField_MessageIndex)this["message_index"]; }
        }

        public FitField_DateTime TimeStamp
        {
            get { return (FitField_DateTime)this["timestamp"]; }
        }

        public FitField_Event Event
        {
            get { return (FitField_Event)this["event"]; }
        }

        public FitField_EventType EventType
        {
            get { return (FitField_EventType)this["event_type"]; }
        }

        public FitField_DateTime StartTime
        {
            get { return (FitField_DateTime)this["start_time"]; }
        }

        public FitField_SInt32 StartPositionLat
        {
            get { return (FitField_SInt32)this["start_position_lat"]; }
        }

        public FitField_SInt32 StartPositionLong
        {
            get { return (FitField_SInt32)this["start_position_long"]; }
        }

        public FitField_Sport Sport
        {
            get { return (FitField_Sport)this["sport"]; }
        }

        public FitField_SubSport SubSport
        {
            get { return (FitField_SubSport)this["sub_sport"]; }
        }

        public FitField_UInt32 TotalElapsedTime
        {
            get { return (FitField_UInt32)this["total_elapsed_time"]; }
        }

        public FitField_UInt32 TotalTimerTime
        {
            get { return (FitField_UInt32)this["total_timer_time"]; }
        }

        public FitField_UInt32 TotalDistance
        {
            get { return (FitField_UInt32)this["total_distance"]; }
        }

        public FitField_UInt32 TotalCycles
        {
            get { return (FitField_UInt32)this["total_cycles"]; }
        }

        public FitField_UInt16 TotalCalories
        {
            get { return (FitField_UInt16)this["total_calories"]; }
        }

        public FitField_UInt16 TotalFatCalories
        {
            get { return (FitField_UInt16)this["total_fat_calories"]; }
        }

        public FitField_UInt16 AverageSpeed
        {
            get { return (FitField_UInt16)this["avg_speed"]; }
        }

        public FitField_UInt16 MaxSpeed
        {
            get { return (FitField_UInt16)this["max_speed"]; }
        }

        public FitField_UInt8 AverageHeartRate
        {
            get { return (FitField_UInt8)this["avg_heart_reate"]; }
        }

        public FitField_UInt8 MaxHeartRate
        {
            get { return (FitField_UInt8)this["max_heart_reate"]; }
        }

        public FitField_UInt8 AverageCadence
        {
            get { return (FitField_UInt8)this["avg_cadence"]; }
        }

        public FitField_UInt8 MaxCadence
        {
            get { return (FitField_UInt8)this["max_cadence"]; }
        }

        public FitField_UInt16 AveragePower
        {
            get { return (FitField_UInt16)this["avg_power"]; }
        }

        public FitField_UInt16 MaxPower
        {
            get { return (FitField_UInt16)this["max_power"]; }
        }

        public FitField_UInt16 TotalAscent
        {
            get { return (FitField_UInt16)this["total_ascent"]; }
        }

        public FitField_UInt16 TotalDescent
        {
            get { return (FitField_UInt16)this["total_descent"]; }
        }

        public FitField_UInt8 TotalTrainingEffect
        {
            get { return (FitField_UInt8)this["total_training_effect"]; }
        }

        public FitField_UInt16 FirstLapIndex
        {
            get { return (FitField_UInt16)this["first_lap_index"]; }
        }

        public FitField_UInt16 NumberOfLaps
        {
            get { return (FitField_UInt16)this["num_laps"]; }
        }

        public FitField_UInt8 EventGroup
        {
            get { return (FitField_UInt8)this["event_group"]; }
        }

        public FitField_SessionTrigger Trigger
        {
            get { return (FitField_SessionTrigger)this["trigger"]; }
        }

        public FitField_SInt32 NECLat
        {
            get { return (FitField_SInt32)this["nec_lat"]; }
        }

        public FitField_SInt32 NECLong
        {
            get { return (FitField_SInt32)this["nec_long"]; }
        }

        public FitField_SInt32 SWCLat
        {
            get { return (FitField_SInt32)this["swc_lat"]; }
        }

        public FitField_SInt32 SWCLong
        {
            get { return (FitField_SInt32)this["swc_long"]; }
        }

        public FitField_UInt16 NormalizedPower
        {
            get { return (FitField_UInt16)this["normalized_power"]; }
        }

        public FitField_UInt16 TrainingStressScore
        {
            get { return (FitField_UInt16)this["training_stress_score"]; }
        }

        public FitField_UInt16 IntensityFactor
        {
            get { return (FitField_UInt16)this["intensity_factor"]; }
        }

        public FitField_LeftRightBalance100 LeftRightBalance
        {
            get { return (FitField_LeftRightBalance100)this["left_right_balance"]; }
        }

        public FitField_UInt32 AverageStrokeCount
        {
            get { return (FitField_UInt32)this["avg_stroke_count"]; }
        }

        public FitField_UInt16 AverageStrokeDistance
        {
            get { return (FitField_UInt16)this["avg_stroke_distance"]; }
        }

        public FitField_SwimStroke SwimStroke
        {
            get { return (FitField_SwimStroke)this["swim_stroke"]; }
        }

        public FitField_UInt16 PoolLength
        {
            get { return (FitField_UInt16)this["pool_length"]; }
        }

        public FitField_DisplayMeasure PoolLengthUnit
        {
            get { return (FitField_DisplayMeasure)this["pool_length_unit"]; }
        }

        public FitField_UInt16 NumberOfActiveLengths
        {
            get { return (FitField_UInt16)this["num_active_lengths"]; }
        }

        public FitField_UInt32 TotalWork
        {
            get { return (FitField_UInt32)this["total_work"]; }
        }

        public FitField_UInt16 AverageAltitude
        {
            get { return (FitField_UInt16)this["avg_altitude"]; }
        }

        public FitField_UInt16 MaxAltitude
        {
            get { return (FitField_UInt16)this["max_altitude"]; }
        }

        public FitField_UInt8 GpsAccuracy
        {
            get { return (FitField_UInt8)this["gps_accuracy"]; }
        }

        public FitField_SInt16 AverageGrade
        {
            get { return (FitField_SInt16)this["avg_grade"]; }
        }

        public FitField_SInt16 AveragePositiveGrade
        {
            get { return (FitField_SInt16)this["avg_pos_grade"]; }
        }

        public FitField_SInt16 AverageNegativeGrade
        {
            get { return (FitField_SInt16)this["avg_neg_grade"]; }
        }

        public FitField_SInt16 MaxPositiveGrade
        {
            get { return (FitField_SInt16)this["max_pos_grade"]; }
        }

        public FitField_SInt16 MaxNegativeGrade
        {
            get { return (FitField_SInt16)this["max_neg_grade"]; }
        }

        public FitField_SInt8 AverageTemperature
        {
            get { return (FitField_SInt8)this["avg_temperature"]; }
        }

        public FitField_SInt8 MaxTemperature
        {
            get { return (FitField_SInt8)this["max_temperature"]; }
        }

        public FitField_UInt32 TotalMovingTime
        {
            get { return (FitField_UInt32)this["total_moving_time"]; }
        }

        public FitField_SInt16 AveragePositiveVerticalSpeed
        {
            get { return (FitField_SInt16)this["avg_pos_vertical_speed"]; }
        }

        public FitField_SInt16 AverageNegativeVerticalSpeed
        {
            get { return (FitField_SInt16)this["avg_neg_vertical_speed"]; }
        }

        public FitField_SInt16 MaxPositiveVerticalSpeed
        {
            get { return (FitField_SInt16)this["max_pos_vertical_speed"]; }
        }

        public FitField_SInt16 MaxNegativeVerticalSpeed
        {
            get { return (FitField_SInt16)this["max_neg_vertical_speed"]; }
        }

        public FitField_UInt8 MinHeartRate
        {
            get { return (FitField_UInt8)this["min_heart_rate"]; }
        }

        public FitField_UInt32 TimeInHrZone
        {
            get { return (FitField_UInt32)this["time_in_hr_zone"]; }
        }

        public FitField_UInt32 TimeInSpeedZone
        {
            get { return (FitField_UInt32)this["time_in_speed_zone"]; }
        }

        public FitField_UInt32 TimeInCadenceZone
        {
            get { return (FitField_UInt32)this["time_in_cadence_zone"]; }
        }

        public FitField_UInt32 TimeInPowerZone
        {
            get { return (FitField_UInt32)this["time_in_power_zone"]; }
        }

        public FitField_UInt32 AverageLapTime
        {
            get { return (FitField_UInt32)this["avg_lap_time"]; }
        }

        public FitField_UInt16 BestLapIndex
        {
            get { return (FitField_UInt16)this["best_lap_index"]; }
        }

        public FitField_UInt16 MinAltitude
        {
            get { return (FitField_UInt16)this["min_altitude"]; }
        }

        public SessionMessage(DataMessage message) : base(message) { }
    }
}
