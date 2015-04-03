namespace theBrent.FitLibrary.FieldTypes
{
    public class FitField_SourceType : FitField_Enum
    {
        public new SourceType? Value
        {
            get { return (SourceType?)base.Value; }
        }

        public FitField_SourceType(byte[] fieldData) : base(fieldData) { }
    }

    public enum SourceType
    {
        /// <summary>
        /// External device connected with ANT
        /// </summary>
        Ant = 0,

        /// <summary>
        /// External device connected with ANT+
        /// </summary>
        Antplus = 1,

        /// <summary>
        /// External device connected with BT
        /// </summary>
        Bluetooth = 2,

        /// <summary>
        /// External device connected with BLE
        /// </summary>
        BluetoothLowEnergy = 3,

        /// <summary>
        /// External device connected with Wifi
        /// </summary>
        Wifi = 4,

        /// <summary>
        /// Onboard device
        /// </summary>
        Local = 5,

    }
}
