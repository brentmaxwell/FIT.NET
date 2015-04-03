using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theBrent.FitLibrary.FieldTypes
{
    public class FitField_Event : FitField_Enum
    {
        public new Event? Value
        {
            get { return (Event?)base.Value; }
        }

        public FitField_Event(byte[] fieldData) : base(fieldData) { }
    }

    public enum Event
    {

        ///<summary>
        /// Group 0.  Start / stop_all
        /// </summary>
        Timer=0,

        ///<summary>
        /// start / stop
        /// </summary>
        Workout=3,
        
        ///<summary>
        /// Start at beginning of workout.  Stop at end of each step.
        /// </summary>
        WorkoutStep=4,

        ///<summary>
        /// stop_all group 0
        /// </summary>
        PowerDown=5,

        ///<summary>
        /// stop_all group 0
        /// </summary>
        PowerUp=6,

        ///<summary>
        /// start / stop group 0
        /// </summary>
        OffCourse=7,

        ///<summary>
        /// Stop at end of each session.
        /// </summary>
        Session=8,

        ///<summary>
        /// Stop at end of each lap.
        /// </summary>
        Lap=9,

        ///<summary>
        /// marker
        /// </summary>
        CoursePoint=10,

        ///<summary>
        /// marker
        /// </summary>
        Battery=11,

        ///<summary>
        /// Group 1. Start at beginning of activity if VP enabled, when VP pace is changed during activity or VP enabled mid activity.  stop_disable when VP disabled.
        /// </summary>
        VirtualPartnerPace=12,

        ///<summary>
        /// Group 0.  Start / stop when in alert condition.
        /// </summary>
        HrHighAlert=13,

        ///<summary>
        /// Group 0.  Start / stop when in alert condition.
        /// </summary>
        HrLowAlert=14,

        ///<summary>
        /// Group 0.  Start / stop when in alert condition.
        /// </summary>
        SpeedHighAlert=15,

        ///<summary>
        /// Group 0.  Start / stop when in alert condition.
        /// </summary>
        SpeedLowAlert=16,

        ///<summary>
        /// Group 0.  Start / stop when in alert condition.
        /// </summary>
        CadHighAlert=17,

        ///<summary>
        /// Group 0.  Start / stop when in alert condition.
        /// </summary>
        CadLowAlert=18,

        ///<summary>
        /// Group 0.  Start / stop when in alert condition.
        /// </summary>
        PowerHighAlert=19,

        ///<summary>
        /// Group 0.  Start / stop when in alert condition.
        /// </summary>
        PowerLowAlert=20,

        ///<summary>
        /// marker
        /// </summary>
        RecoveryHr=21,

        ///<summary>
        /// marker
        /// </summary>
        BatteryLow=22,

        ///<summary>
        /// Group 1.  Start if enabled mid activity (not required at start of activity). Stop when duration is reached.  stop_disable if disabled.
        /// </summary>
        TimeDurationAlert=23,

        ///<summary>
        /// Group 1.  Start if enabled mid activity (not required at start of activity). Stop when duration is reached.  stop_disable if disabled.
        /// </summary>
        DistanceDurationAlert=24,

        ///<summary>
        /// Group 1.  Start if enabled mid activity (not required at start of activity). Stop when duration is reached.  stop_disable if disabled.
        /// </summary>
        CalorieDurationAlert=25,

        ///<summary>
        /// Group 1..  Stop at end of activity.
        /// </summary>
        Activity=26,

        ///<summary>
        /// marker
        /// </summary>
        FitnessEquipment=27,

        ///<summary>
        /// Stop at end of each length.
        /// </summary>
        Length=28,

        ///<summary>
        /// marker
        /// </summary>
        UserMarker=32,

        ///<summary>
        /// marker
        /// </summary>
        SportPoint=33,

        ///<summary>
        /// start/stop/marker
        /// </summary>
        Calibration=36,

        ///<summary>
        /// marker
        /// </summary>
        FrontGearChange=42,

        ///<summary>
        /// marker
        /// </summary>
        RearGearChange=43,

        INVALID = 255
    }
}
