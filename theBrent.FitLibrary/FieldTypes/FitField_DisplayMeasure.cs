using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theBrent.FitLibrary.FieldTypes
{
    public class FitField_DisplayMeasure : FitField_Enum
    {
        public new DisplayMeasure? Value
        {
            get { return (DisplayMeasure?)base.Value; }
        }

        public FitField_DisplayMeasure(byte[] fieldData) : base(fieldData) { }
    }

    public enum DisplayMeasure
    {
        Metric = 0,
        Statute = 1
    }
}
