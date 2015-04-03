using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theBrent.FitLibrary.FieldTypes
{
    public class FitField_Language : FitField_Enum
    {
        public new Language? Value
        {
            get { return (Language?)base.Value; }
        }

        public FitField_Language(byte[] fieldData) : base(fieldData) { }
    }

    public enum Language
    {
        english = 0,
        french = 1,
        italian = 2,
        german = 3,
        spanish = 4,
        croatian = 5,
        czech = 6,
        danish = 7,
        dutch = 8,
        finnish = 9,
        greek = 10,
        hungarian = 11,
        norwegian = 12,
        polish = 13,
        portuguese = 14,
        slovakian = 15,
        slovenian = 16,
        swedish = 17,
        russian = 18,
        turkish = 19,
        latvian = 20,
        ukrainian = 21,
        arabic = 22,
        farsi = 23,
        bulgarian = 24,
        romanian = 25,
        custom = 254,
        INVALID = 255
    }
}
