using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theBrent.FitLibrary.FieldTypes
{
    public class FitField_EventType : FitField_Enum
    {
        public new EventType? Value
        {
            get { return (EventType?)base.Value; }
        }

        public FitField_EventType(byte[] fieldData) : base(fieldData) { }
    }

    public enum EventType
    {
        Start = 0,
        Stop = 1, 
        ConsecutiveDepreciated = 2, 
        Marker = 3, 
        StopAll = 4, 
        BeginDepreciated = 5, 
        EndDepreciated = 6, 
        EndAllDepreciated = 7, 
        StopDisable = 8, 
        StopDisableAll = 9, 
        INVALID = 255
    }
}
