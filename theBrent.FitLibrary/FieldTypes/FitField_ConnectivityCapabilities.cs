using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theBrent.FitLibrary.FieldTypes
{
    public class FitField_ConnectivityCapabilities : FitField_UInt32z
    {
        public new ConnectivityCapabilities? Value
        {
            get { return (ConnectivityCapabilities?)base.Value; }
        }

        public FitField_ConnectivityCapabilities(byte[] fieldData) : base(fieldData) { }
    }

    [Flags]
    public enum ConnectivityCapabilities
    {
        Bluetooth = 0x00000001,
        BluetoothLe = 0x00000002,
        Ant = 0x00000004,
        ActivityUpload = 0x00000008,
        CourseDownload = 0x00000010,
        WorkoutDownload = 0x00000020,
        LiveTrack = 0x00000040,
        WeatherConditions = 0x00000080,
        WeatherAlerts = 0x00000100,
        GpsEphemerisDownload = 0x00000200,
        ExplicitArchive = 0x00000400,
        SetupIncomplete = 0x00000800,
        ContinueSyncAfterSoftwareUpdate = 0x00001000
    }
}
