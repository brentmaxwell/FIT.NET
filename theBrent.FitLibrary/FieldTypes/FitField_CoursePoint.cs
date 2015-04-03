using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theBrent.FitLibrary.FieldTypes
{
    public class FitField_CoursePoint : FitField_Enum
    {
        public new CoursePoint? Value
        {
            get { return (CoursePoint?)base.Value; }
        }

        public FitField_CoursePoint(byte[] fieldData) : base(fieldData) { }
    }

    public enum CoursePoint
    {
        Generic = 0,
        Summit = 1,
        Valley = 2,
        Water = 3,
        Food = 4,
        Danger = 5,
        Left = 6,
        Right = 7,
        Straight = 8,
        FirstAid = 9,
        FourthCategory = 10,
        ThirdCategory = 11,
        SecondCategory = 12,
        FirstCategory = 13,
        HorsCategory = 14,
        Sprint = 15,
        LeftFork = 16,
        RightFork = 17,
        MiddleFork = 18,
        SlightLeft = 19,
        SharpLeft = 20,
        SlightRight = 21,
        SharpRight = 22,
        UTurn = 23,

        INVALID = 255
    }
}
