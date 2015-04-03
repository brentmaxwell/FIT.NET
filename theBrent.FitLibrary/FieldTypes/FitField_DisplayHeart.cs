using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theBrent.FitLibrary.FieldTypes
{
    public class FitField_DisplayHeart : FitField_Enum
    {
        public new DisplayHeart? Value
        {
            get { return (DisplayHeart?)base.Value; }
        }

        public FitField_DisplayHeart(byte[] fieldData) : base(fieldData) { }
    }

    public enum DisplayHeart
    {
        BPM = 0,
        Max = 1,
        Reserve = 2
    }
}
