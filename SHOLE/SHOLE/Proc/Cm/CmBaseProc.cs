using SHOLE.Meta;
using SHOLE.Execute;

namespace SHOLE.Procs
{
    [Meta.SHProcMeta(Name = "CmBase")]
    public partial class CmBaseProc : Execute.SHProc
    {
        [SHDataSetMeta(DSIndex = 0, IsInput = true)]
        public CmBaseProcInputDS input { get; set; }

        [SHDataSetMeta(DSIndex = 1)]
        public SHDataSet<CmBaseProcOutputDS> result { get; set; } = new SHDataSet<CmBaseProcOutputDS>();
    }

    [SHDataSetMeta(DSIndex = 0)]
    public partial class CmBaseProcInputDS
    {
        [SHDataSetPropertyMeta(PropertyCode = "201.1.0")]
        public int cm_tree_rid { get; set; }
    }

    [SHDataSetMeta(DSIndex = 1)]
    public partial class CmBaseProcOutputDS
    {
        [SHDataSetPropertyMeta(PropertyCode = "200.1.0")]
        public uint cm_base_rid { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "201.1.0")]
        public uint cm_tree_rid { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "200.2.0")]
        public string cm_base_name { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "200.3.0")]
        public string cm_base_abbr { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "200.4.0")]
        public uint cm_base_options { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "206.1.0")]
        public uint cm_base_munit_rid { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "200.6.0")]
        public uint cm_base_abbrnumber { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "206.2.0")]
        public string cm_base_munit_name { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "0.1.0")]
        public int cm_base_createdate { get; set; }
    }
}
