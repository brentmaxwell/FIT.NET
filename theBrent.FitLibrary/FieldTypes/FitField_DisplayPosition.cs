using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theBrent.FitLibrary.FieldTypes
{
    public class FitField_DisplayPosition : FitField_Enum
    {
        public new DisplayPosition? Value
        {
            get { return (DisplayPosition?)base.Value; }
        }

        public FitField_DisplayPosition(byte[] fieldData) : base(fieldData) { }
    }

    public enum DisplayPosition
    {
        /// <summary>
        /// dd.dddddd
        /// </summary>
        Degree = 0,

        /// <summary>
        /// dddmm.mmm
        /// </summary>
        DegreeMinute = 1,

        /// <summary>
        /// dddmmss
        /// </summary>
        DegreeMinuteSecond = 2,

        /// <summary>
        /// Austrian Grid (BMN)
        /// </summary>
        AustrianGrid = 3,

        /// <summary>
        /// British National Grid
        /// </summary>
        BritishGrid = 4,

        /// <summary>
        /// Dutch grid system
        /// </summary>
        DutchGrid = 5,

        /// <summary>
        /// Hungarian grid system
        /// </summary>
        HungarianGrid = 6,

        /// <summary>
        /// Finnish grid system Zone3 KKJ27
        /// </summary>
        FinnishGrid = 7,

        /// <summary>
        /// Gausss Krueger (German)
        /// </summary>
        GermanGrid = 8,

        /// <summary>
        /// Icelandic Grid
        /// </summary>
        IcelandicGrid = 9,

        /// <summary>
        /// Indonesian Equatorial LCO
        /// </summary>
        IndonesianEquatorial = 10,

        /// <summary>
        /// Indonesian Irian LCO
        /// </summary>
        IndonesianIrian = 11,

        /// <summary>
        /// Indonesian Southern LCO
        /// </summary>
        IndonesianSouthern = 12,

        /// <summary>
        /// India zone 0
        /// </summary>
        IndiaZone0 = 13,

        /// <summary>
        /// India zone IA
        /// </summary>
        IndiaZoneIA = 14,

        /// <summary>
        /// India zone IB
        /// </summary>
        IndiaZoneIB = 15,

        /// <summary>
        /// India zone IIA
        /// </summary>
        IndiaZoneIIA = 16,

        /// <summary>
        /// India zone IIB
        /// </summary>
        IndiaZoneIIB = 17,

        /// <summary>
        /// India zone IIIA
        /// </summary>
        IndiaZoneIIIA = 18,

        /// <summary>
        /// India zone IIIB
        /// </summary>
        IndiaZoneIIIB = 19,

        /// <summary>
        /// India zone IVA
        /// </summary>
        IndiaZoneIVA = 20,

        /// <summary>
        /// India zone IVB
        /// </summary>
        IndiaZoneIVB = 21,

        /// <summary>
        /// Irish Transverse Mercator
        /// </summary>
        IrishTransverse = 22,

        /// <summary>
        /// Irish Grid
        /// </summary>
        IrishGrid = 23,

        /// <summary>
        /// Loran TD
        /// </summary>
        Loran = 24,

        /// <summary>
        /// Maidenhead grid system
        /// </summary>
        MaidenheadGrid = 25,

        /// <summary>
        /// MGRS grid system
        /// </summary>
        MgrsGrid = 26,
        
        /// <summary>
        /// New Zealand grid system
        /// </summary>
        NewZealandGrid = 27,

        /// <summary>
        /// New Zealand Transverse Mercator
        /// </summary>
        NewZealandTransverse = 28,

        /// <summary>
        /// Qatar National Grid
        /// </summary>
        QatarGrid = 29,

        /// <summary>
        /// Modified RT-90 (Sweden)
        /// </summary>
        ModifiedSwedishGrid = 30,

        /// <summary>
        /// RT-90 (Sweden)
        /// </summary>
        SwedishGrid = 31,

        /// <summary>
        /// South African Grid
        /// </summary>
        SouthAfricanGrid = 32,

        /// <summary>
        /// Swiss CH-1903 grid
        /// </summary>
        SwissGrid = 33,

        /// <summary>
        /// Taiwan Grid
        /// </summary>
        TaiwanGrid = 34,

        /// <summary>
        /// United States National Grid
        /// </summary>
        UnitedStatesGrid = 35,

        /// <summary>
        /// UTM/UPS grid system
        /// </summary>
        UtmUpsGrid = 36,

        /// <summary>
        /// West Malayan RSO
        /// </summary>
        WestMalayan = 37,

        /// <summary>
        /// Borneo RSO
        /// </summary>
        BorneoRso = 38,
        
        /// <summary>
        /// Estonian grid system
        /// </summary>
        EstonianGrid = 39,
        
        /// <summary>
        /// Latvian Transverse Mercator
        /// </summary>
        LatvianGrid = 40,

        /// <summary>
        /// Reference Grid 99 TM (Swedish)
        /// </summary>
        SwedishRef99Grid = 41,
    }
}
