using SHOLE.Meta;
using SHOLE.Execute;

namespace SHOLE.Procs
{
    [Meta.SHProcMeta(Name = "Goods")]
    public class GoodsProc : Execute.SHProc
    {
        [SHDataSetMeta(DSIndex = 0, IsInput = true)]
        public GoodsProcInputDS input { get; set; } = new GoodsProcInputDS();

        [SHDataSetMeta(DSIndex = 1)]
        public SHDataSet<GoodsProcOutputDS> result { get; set; } = new SHDataSet<GoodsProcOutputDS>();
    }

    [SHDataSetMeta(DSIndex = 0)]
    public class GoodsProcInputDS
    {
        [SHDataSetPropertyMeta(PropertyCode = "209.1.0")]
        public int goodstree_rid { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "209.2.0")]
        public int goodstree_someparam { get; set; } = 0;
    }

    [SHDataSetMeta(DSIndex = 1)]
    public class GoodsProcOutputDS
    {
        [SHDataSetPropertyMeta(PropertyCode = "210.1.0")]
        public uint goods_rid { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "209.1.0")]
        public uint goodstree_rid { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "210.2.0")]
        public string goods_name { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "210.3.0")]
        public string goods_abbrtext { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "210.4.0")]
        public uint goods_abbrnumber { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "210.5.0")]
        public uint goods_type { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "206.1.0")]
        public uint goods_munit_rid { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "206.2.0")]
        public string goods_munit_name { get; set; }

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
        public double goods_outprice { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "210.6.0")]
        public uint goods_extinfo { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "210.8.0")]
        public uint goods_options { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "210.20.0")]
        public double goods_inprice { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "200.1.1")]
        public uint cmbase_rid { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "200.2.1")]
        public string cmbase_name { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "200.3.1")]
        public string cmbase_abbrtext { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "200.6.1")]
        public uint cmbase_abbrnumber { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "206.1.1")]
        public uint goods_muint_rid { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "206.2.1")]
        public string goods_muint_name { get; set; }

    }
}
