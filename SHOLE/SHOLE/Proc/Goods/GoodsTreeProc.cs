using SHOLE.Meta;
using SHOLE.Execute;

namespace SHOLE.Procs
{
    [Meta.SHProcMeta(Name = "GoodsTree")]
    public partial class GoodsTreeProc : Execute.SHProc
    {
        [SHDataSetMeta(DSIndex = 0, IsInput = true)]
        public GoodsTreeProcInputDS input { get; set; } = new GoodsTreeProcInputDS();

        [SHDataSetMeta(DSIndex = 1)]
        public SHDataSet<GoodsTreeProcOutputDS> result { get; set; } = new SHDataSet<GoodsTreeProcOutputDS>();
    }

    [SHDataSetMeta(DSIndex = 0)]
    public partial class GoodsTreeProcInputDS
    {
        [SHDataSetPropertyMeta(PropertyCode = "209.2.0")]
        public int? goodstree_parent_rid { get; set; }
    }

    [SHDataSetMeta(DSIndex = 1)]
    public partial class GoodsTreeProcOutputDS
    {
        [SHDataSetPropertyMeta(PropertyCode = "209.1.0")]
        public uint goodstree_rid { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "209.2.0")]
        public uint goodstree_parent_rid { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "209.3.0")]
        public string goodstree_name { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "209.4.0")]
        public string goodstree_abbr { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "209.5.0")]
        public uint goodstree_extinfo { get; set; }
    }
}
