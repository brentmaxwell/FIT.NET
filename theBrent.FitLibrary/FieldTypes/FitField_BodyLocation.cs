using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theBrent.FitLibrary.FieldTypes
{
    public class FitField_BodyLocation : FitField_Enum
    {
        public new BodyLocation? Value
        {
            get { return (BodyLocation?)base.Value; }
        }

        public FitField_BodyLocation(byte[] fieldData) : base(fieldData) { }
    }

    public enum BodyLocation
    {
        LeftLeg = 0,
        LeftCalf = 1,
        LeftShin = 2,
        LeftHamstring = 3,
        LeftQuad = 4,
        LeftGlute = 5,
        RightLeg = 6,
        RightCalf = 7,
        RightShin = 8,
        RightHamstring = 9,
        RightQuad = 10,
        RightGlute = 11,
        TorsoBack = 12,
        LeftLowerBack = 13,
        LeftUpperBack = 14,
        RightLowerBack = 15,
        RightUpperBack = 16,
        TorsoFront = 17,
        LeftAbdomen = 18,
        LeftChest = 19,
        RightAbdomen = 20,
        RightChest = 21,
        LeftArm = 22,
        LeftShoulder = 23,
        LeftBicep = 24,
        LeftTricep = 25,

        /// <summary>
        /// Left anterior forearm
        /// </summary>
        LeftBrachioradialis = 26,

        /// <summary>
        /// Left posterior forearm
        /// </summary>
        LeftForearmExtensors = 27,
        RightArm = 28,
        RightShoulder = 29,
        RightBicep = 30,
        RightTricep = 31,

        /// <summary>
        /// Right anterior forearm
        /// </summary>
        RightBrachioradialis = 32,

        /// <summary>
        /// Right posterior forearm
        /// </summary>
        RightForearmExtensors = 33,
        Neck = 34,
        Throat = 35,

    }
}
