using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theBrent.FitLibrary.FieldTypes
{
    public class FitField_Icon : FitField_UInt16
    {
        public new Icon? Value
        {
            get { return (Icon?)base.Value; }
        }

        public FitField_Icon(byte[] fieldData) : base(fieldData) { }
    }

    public enum Icon
    {
        //MARKERS
        sym_flag_blue = 38,
        //sym_flag_green
        //sym_flag_red
        //sym_civil
        //sym_pin_blue
        //sym_pin_green
        //sym_pin_red
        //sym_golf
        //sym_block_blue
        //sym_block_green
        //sym_block_red
        //sym_stadium
        //sym_buoy_blue
        //sym_buoy_grn
        //sym_buoy_red
        //sym_buoy_wht
        //sym_buoy_ambr
        //sym_buoy_blck
        //sym_buoy_orng
        //sym_buoy_violet
        sym_sml_cty = 112,
        //sym_med_cty
        //sym_lrg_cty
        //sym_crossing
        sym_house = 57,
        sym_fhs_facility = 94,
        sym_building = 62,
    }
}
