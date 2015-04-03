using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theBrent.FitLibrary.FieldTypes
{
    public class FitField_Sport : FitField_Enum
    {
        public new Sport? Value
        {
            get { return (Sport?)base.Value; }
        }

        public FitField_Sport(byte[] fieldData) : base(fieldData) { }
    }

    public enum Sport
    {
        Generic = 0,
        Running = 1,
        Cycling = 2,
        /// <summary>
        /// Mulitsport transition
        /// </summary>
        Transition = 3,

        FitnessEquipment = 4,
        
        Swimming = 5,
        
        Basketball = 6,
        
        Soccer = 7,
        
        Tennis = 8,
        
        AmericanFootball = 9,
        
        Training = 10,
        
        Walking = 11,
        
        CrossCountrySkiing = 12,
        
        AlpineSkiing = 13,
        
        Snowboarding = 14,
        
        Rowing = 15,
        
        Mountaineering = 16,
        
        Hiking = 17,
        
        Multisport = 18,
        
        Paddling = 19,

        /// <summary>
        /// All is for goals only to include all sports.
        /// </summary>
        All = 254,

        INVALID = 255
    }
}
