using System;
using SHOLE.Meta;
using SHOLE.Execute;

namespace SHOLE.Procs
{
    [SHProcMeta(Name = "GoodsBase")] 
    public partial class GoodsBaseProc : SHProc
    {
        [SHDataSetMeta(DSIndex = 0, IsInput = true)]
        public GoodsBaseInputDS input { get; set; }

        [SHDataSetMeta(DSIndex = 1)]
        public SHDataSet<GoodsBaseAttrsDS> goods_attr { get; set; } = new SHDataSet<GoodsBaseAttrsDS>();

        [SHDataSetMeta(DSIndex = 2)]
        public SHDataSet<GoodsBaseUnitsDS> units { get; set; } = new SHDataSet<GoodsBaseUnitsDS>();

        [SHDataSetMeta(DSIndex = 3)]
        public SHDataSet<GoodsBaseCorrDS> corr { get; set; } = new SHDataSet<GoodsBaseCorrDS>();

        [SHDataSetMeta(DSIndex = 4)]
        public SHDataSet<GoodsBaseSUnitsCorrDS> sunits_corr { get; set; } = new SHDataSet<GoodsBaseSUnitsCorrDS>();

        [SHDataSetMeta(DSIndex = 5)]
        public SHDataSet<GoodsBaseComplectsDS> complects { get; set; } = new SHDataSet<GoodsBaseComplectsDS>();

        [SHDataSetMeta(DSIndex = 6)]
        public SHDataSet<GoodsBaseComplectsBaseDS> complects_base { get; set; } = new SHDataSet<GoodsBaseComplectsBaseDS>();

        [SHDataSetMeta(DSIndex = 7)]
        public SHDataSet<GoodsBasePricesDS> prices { get; set; } = new SHDataSet<GoodsBasePricesDS>();

        [SHDataSetMeta(DSIndex = 8)]
        public SHDataSet<GoodsBaseClfrDS> clfr { get; set; } = new SHDataSet<GoodsBaseClfrDS>();
    }

    [SHDataSetMeta(DSIndex = 0)]
    public partial class GoodsBaseInputDS
    {
        [SHDataSetPropertyMeta(PropertyCode = "210.1.0")]
        public int goods_rid { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "0.2.0")]
        public int someParam { get; set; } = 0;
    }

    [SHDataSetMeta(DSIndex = 1)]
    public partial class GoodsBaseAttrsDS
    {
        [SHDataSetPropertyMeta(PropertyCode = "210.1.0")]
        public uint goods_rid { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "209.1.0")]
        public uint goods_tree_rid { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "210.2.0")]
        public string goods_name { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "210.3.0")]
        public string goods_abbr_text { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "210.4.0")]
        public uint goods_abbr_number { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "210.5.0")]
        public int goods_type { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "206.1.0")]
        public uint goods_munit_rid { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "208.1.0")]
        public uint goods_ctg_rid { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "219.1.0")]
        public uint goods_ctg2_rid { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "212.2.0")]
        public uint goods_tax_rate { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "213.2.0")]
        public uint goods_tax2_rate { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "212.2.10")]
        public uint goods_tax11_rate { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "213.2.10")]
        public uint goods_tax22_rate { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "210.7.0")]
        public float goods_out_price { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "210.6.0")]
        public uint goods_extinfo { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "210.8.0")]
        public uint goods_options { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "210.20.0")]
        public float goods_inprice { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "209.3.0")]
        public string goods_tree_name { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "208.2.0")]
        public string goods_ctg_name { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "219.2.0")]
        public string goods_ctg2_name { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "206.2.1")]
        public string goods_munit2_name { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "205.1.0")]
        public string goods_mgroup_name { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "206.2.0")]
        public string goods_munit_name { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "206.3.0")]
        public double goods_munit_cf { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "200.1.1")]
        public uint cm_base_rid { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "200.2.1")]
        public string cm_base_name { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "210.1.1")]
        public uint goods_rid1 { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "210.2.1")]
        public string goods_name1 { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "206.1.9")]
        public uint goods_munit1_rid { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "206.2.9")]
        public string goods_munit1_name { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = " 0.1.7")]
        public DateTime goods_createdate { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "0.2.7")]
        public uint goods_createdate_sec { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "0.3.7")]
        public DateTime goods_lastchange { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "0.4.7")]
        public uint goods_lastchange_sec { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "0.5.7")]
        public string goods_minactivedocdate { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "0.6.7")]
        public string goods_user { get; set; }
    }

    [SHDataSetMeta(DSIndex = 2)]
    public partial class GoodsBaseUnitsDS
    {
        [SHDataSetPropertyMeta(PropertyCode = "206.1.0")]
        public uint goods_munit_rid { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "211.1.0")]
        public double goods_gmuint_cf { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "211.2.0")]
        public double goods_gmuint_tareweight { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "206.2.0")]
        public string goods_munit_name { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "206.3.0")]
        public double goods_munit_cf { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "205.1.0")]
        public uint goods_mgroup_rid { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "211.3.0")]
        public string goods_gmuint_barecodes { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "211.4.0")]
        public string goods_gmuint_someparam { get; set; }
    }

    [SHDataSetMeta(DSIndex = 3)]
    public partial class GoodsBaseCorrDS
    {
        [SHDataSetPropertyMeta(PropertyCode = "102.1.0")]
        public uint corr_base_rid { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "102.4.0")]
        public string corr_base_name { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "215.1.0")]
        public double goods_greserve_minr { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "215.2.0")]
        public double goods_greserve_maxr { get; set; }
    }

    [SHDataSetMeta(DSIndex = 4)]
    public partial class GoodsBaseSUnitsCorrDS
    {

        [SHDataSetPropertyMeta(PropertyCode = "214.1.0")]
        public uint goods_sunit_rid { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "214.3.0")]
        public string goods_sunit_name { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "102.1.0")]
        public uint corr_base_rid { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "102.4.0")]
        public string corr_base_name { get; set; }
    }

    [SHDataSetMeta(DSIndex = 5)]
    public partial class GoodsBaseComplectsDS
    {

        [SHDataSetPropertyMeta(PropertyCode = "200.1.0")]
        public uint cm_base_rid { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "200.3.0")]
        public string cm_base_abbrttext { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "200.6.0")]
        public uint cm_base_abbrtnumber { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "200.2.0")]
        public string cm_base_name { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "200.4.0")]
        public int cm_base_options { get; set; }
    }

    [SHDataSetMeta(DSIndex = 6)]
    public partial class GoodsBaseComplectsBaseDS
    {

        [SHDataSetPropertyMeta(PropertyCode = "217.1.0")]
        public uint cm_base_rid { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "0.1.0")]
        public string cm_base_abbrttext { get; set; }
    }

    [SHDataSetMeta(DSIndex = 7)]
    public partial class GoodsBasePricesDS
    {

        [SHDataSetPropertyMeta(PropertyCode = "217.1.0")]
        public uint goods_attr_id { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "0.1.0")]
        public double goods_price { get; set; }
    }

    [SHDataSetMeta(DSIndex = 8)]
    public partial class GoodsBaseClfrDS
    {

        [SHDataSetPropertyMeta(PropertyCode = "245.1.0")]
        public uint clfr_rid { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "245.2.0")]
        public string clfr_name { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "245.3.0")]
        public uint clfr_objid { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "245.4.0")]
        public uint clfr_pos { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "245.5.0")]
        public uint clfr_options { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "246.1.0")]
        public uint clfrval_rid { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "246.2.0")]
        public string clfrval_value { get; set; }
    }
}
