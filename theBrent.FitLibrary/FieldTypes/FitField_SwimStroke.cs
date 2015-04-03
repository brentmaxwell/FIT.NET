using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theBrent.FitLibrary.FieldTypes
{
    public class FitField_SwimStroke : FitField_Enum
    {
        public new SwimStroke? Value
        {
            get { return (SwimStroke?)base.Value; }
        }

        public FitField_SwimStroke(byte[] fieldData) : base(fieldData) { }
    }

    public enum SwimStroke
    {
        Freestyle = 0,
        Backstroke = 1,
        Breaststroke = 2,
        Butterfly = 3,
        Drill = 4,
        Mixed = 5,
        /// <summary>
        /// IM is a mixed interval containing the same number of lengths for each of: Butterfly, Backstroke, Breaststroke, Freestyle, swam in that order.
        /// </summary>
        Im = 6
    }
}
