using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theBrent.FitLibrary.FieldTypes.CustomFieldTypes
{
    public class FitField_Point : FitField_SInt32
    {
        private const int SCALE = 100;

        public FitField_Point(byte[] fieldData)
            : base(fieldData)
        {
        }

        public decimal? Value
        {
            get { return base.Value.HasValue ? (decimal) base.Value*(180.0M/(decimal) Math.Pow(2, 31)) : (decimal?)null; }
        }
    }
}
