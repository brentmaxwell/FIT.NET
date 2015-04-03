using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theBrent.FitLibrary.FieldTypes
{
    public class FitField_AntNetwork : FitField_Enum
    {
        public new AntNetwork? Value
        {
            get { return (AntNetwork?)base.Value; }
        }

        public FitField_AntNetwork(byte[] fieldData) : base(fieldData) { }
    }

    public enum AntNetwork
    {
        Public = 0,
        AntPlus = 1,
        AntFs = 2,
        Private = 3
    }
}
