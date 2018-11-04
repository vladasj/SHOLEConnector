using SHOLE.Meta;
using SHOLE.Execute;

namespace SHOLE.Procs
{
    [SHProcMeta(Name = "CmBase")]
    public partial class CmBaseProc : SHProc
    {
        [SHDataSetMeta(DSIndex = 0, IsInput = true)]
        public CmBaseProcInputDS Input { get; set; }

        [SHDataSetMeta(DSIndex = 1)]
        public SHDataSet<CmBaseDS> result { get; set; } = new SHDataSet<CmBaseDS>();
    }

    [SHDataSetMeta(DSIndex = 0)]
    public partial class CmBaseProcInputDS
    {
        [SHDataSetPropertyMeta(PropertyCode = "201.1.0")]
        public int cm_tree_rid { get; set; }
    }

    [SHDataSetMeta(DSIndex = 1)]
    public partial class CmBaseDS
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
