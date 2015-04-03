using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theBrent.FitLibrary.FieldTypes
{
    public class FitField_Intensity : FitField_Enum
    {
        public new Intensity? Value
        {
            get { return (Intensity?)base.Value; }
        }

        public FitField_Intensity(byte[] fieldData) : base(fieldData) { }
    }

    public enum Intensity
    {
        Active = 0,
        Rest = 1,
        Warmup = 2,
        Cooldown = 3
    }
}
