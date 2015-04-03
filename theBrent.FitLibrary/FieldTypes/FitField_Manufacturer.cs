using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theBrent.FitLibrary.FieldTypes
{
    public class FitField_Manufacturer : FitField_UInt16
    {
        public new Manufacturer? Value
        {
            get { return (Manufacturer?)base.Value; }
        }

        public FitField_Manufacturer(byte[] fieldData) : base(fieldData) { }
    }

    public enum Manufacturer
    {
        Garmin = 1,

        /// <summary>
        /// Do not use.  Used by FR405 for ANTFS man id.
        /// </summary>
        GarminFr405Antfs = 2,

        Zephyr = 3,

        Dayton = 4,

        Idt = 5,

        Srm = 6,
        Quarq = 7,
        Ibike = 8,
        Saris = 9,
        SparkHk = 10,
        Tanita = 11,
        Echowell = 12,
        DynastreamOem = 13,
        Nautilus = 14,
        Dynastream = 15,
        Timex = 16,
        Metrigear = 17,
        Xelic = 18,
        Beurer = 19,
        Cardiosport = 20,
        AAndD = 21,
        Hmm = 22,
        Suunto = 23,
        ThitaElektronik = 24,
        Gpulse = 25,
        CleanMobile = 26,
        PedalBrain = 27,
        Peaksware = 28,
        Saxonar = 29,
        LemondFitness = 30,
        Dexcom = 31,
        WahooFitness = 32,
        OctaneFitness = 33,
        Archinoetics = 34,
        TheHurtBox = 35,
        CitizenSystems = 36,
        Magellan = 37,
        Osynce = 38,
        Holux = 39,
        Concept2 = 40,
        OneGiantLeap = 42,
        AceSensor = 43,
        BrimBrothers = 44,
        Xplova = 45,
        PerceptionDigital = 46,
        Bf1Systems = 47,
        Pioneer = 48,
        Spantec = 49,
        Metalogics = 50,
        _4Iiiis = 51,
        SeikoEpson = 52,
        SeikoEpsonOem = 53,
        IforPowell = 54,
        MaxwellGuider = 55,
        StarTrac = 56,
        Breakaway = 57,
        AlatechTechnologyLtd = 58,
        MioTechnologyEurope = 59,
        Rotor = 60,
        Geonaute = 61,
        IDBike = 62,
        Specialized = 63,
        Wtek = 64,
        PhysicalEnterprises = 65,
        NorthPoleEngineering = 66,
        Bkool = 67,
        Cateye = 68,
        StagesCycling = 69,
        Sigmasport = 70,
        Tomtom = 71,
        Peripedal = 72,
        Wattbike = 73,
        Moxy = 76,
        Ciclosport = 77,
        Powerbahn = 78,
        AcornProjectsAps = 79,
        Lifebeam = 80,
        Bontrager = 81,
        Wellgo = 82,
        Scosche = 83,
        Magura = 84,
        Woodway = 85,
        Elite = 86,
        NielsenKellerman = 87,
        DkCity = 88,
        Tacx = 89,
        DirectionTechnology = 90,
        Magtonic = 91,
        _1Partcarbon = 92,

        Development = 255,
        Actigraphcorp = 5759
    }
}
