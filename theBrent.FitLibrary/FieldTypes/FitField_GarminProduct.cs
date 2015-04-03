using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theBrent.FitLibrary.FieldTypes
{
    public class FitField_GarminProduct : FitField_UInt16
    {
        public new GarminProduct? Value
        {
            get { return (GarminProduct?)base.Value; }
        }

        public FitField_GarminProduct(byte[] fieldData) : base(fieldData) { }
    }

    public enum GarminProduct
    {
        hrm1 = 1,

        /// <summary>
        /// AXH01 HRM Chipset
        /// </summary>
        axh01 = 2,
        axb01 = 3,
        axb02 = 4,
        hrm2ss = 5,
        dsi_alf02 = 6,
        hrm3ss = 7,

        /// <summary>
        /// hrm_run model for HRM ANT+ messaging
        /// </summary>
        hrm_run_single_byte_product_id = 8,

        /// <summary>
        /// BSM model for ANT+ messaging
        /// </summary>
        bsm = 9,

        /// <summary>
        /// BCM model for ANT+ messaging
        /// </summary>
        bcm = 10,
        fr301_china = 473,
        fr301_japan = 474,
        fr301_korea = 475,
        fr301_taiwan = 494,

        /// <summary>
        /// Forerunner 405
        /// </summary>
        fr405 = 717,

        /// <summary>
        /// Forerunner 50
        /// </summary>
        fr50 = 782,
        fr405_japan = 987,

        /// <summary>
        /// Forerunner 60
        /// </summary>
        fr60 = 988,
        dsi_alf01 = 1011,

        /// <summary>
        /// Forerunner 310
        /// </summary>
        fr310xt = 1018,
        edge500 = 1036,

        /// <summary>
        /// Forerunner 110
        /// </summary>
        fr110 = 1124,
        edge800 = 1169,
        edge500_taiwan = 1199,
        edge500_japan = 1213,
        chirp = 1253,
        fr110_japan = 1274,
        edge200 = 1325,
        fr910xt = 1328,
        edge800_taiwan = 1333,
        edge800_japan = 1334,
        alf04 = 1341,
        fr610 = 1345,
        fr210_japan = 1360,
        vector_ss = 1380,
        vector_cp = 1381,
        edge800_china = 1386,
        edge500_china = 1387,
        fr610_japan = 1410,
        edge500_korea = 1422,
        fr70 = 1436,
        fr310xt_4t = 1446,
        amx = 1461,
        fr10 = 1482,
        edge800_korea = 1497,
        swim = 1499,
        fr910xt_china = 1537,
        fenix = 1551,
        edge200_taiwan = 1555,
        edge510 = 1561,
        edge810 = 1567,
        tempe = 1570,
        fr910xt_japan = 1600,
        fr620 = 1623,
        fr220 = 1632,
        fr910xt_korea = 1664,
        fr10_japan = 1688,
        edge810_japan = 1721,
        virb_elite = 1735,

        /// <summary>
        /// Also Edge Touring Plus
        /// </summary>
        edge_touring = 1736,
        edge510_japan = 1742,
        hrm_run = 1752,
        edge510_asia = 1821,
        edge810_china = 1822,
        edge810_taiwan = 1823,
        edge1000 = 1836,
        vivo_fit = 1837,
        virb_remote = 1853,
        vivo_ki = 1885,
        fr15 = 1903,
        edge510_korea = 1918,
        fr620_japan = 1928,
        fr620_china = 1929,
        fr220_japan = 1930,
        fr220_china = 1931,
        fenix2 = 1967,

        /// <summary>
        /// SDM4 footpod
        /// </summary>
        sdm4 = 10007,
        edge_remote = 10014,
        training_center = 20119,
        android_antplus_plugin = 65532,

        /// <summary>
        /// Garmin Connect website
        /// </summary>
        connect = 65534,
    }
}
