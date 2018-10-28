using SHOLE.Meta;
using SHOLE.Execute;

namespace SHOLE.Procs
{
    [Meta.SHProcMeta(Name = "CmTree")]
    public class CmTreeProc : Execute.SHProc
    {
        [SHDataSetMeta(DSIndex = 1)]
        public SHDataSet<CmTreeProcOutputDS> result { get; set; } = new SHDataSet<CmTreeProcOutputDS>();
    }

    [SHDataSetMeta(DSIndex = 1)]
    public class CmTreeProcOutputDS
    {
        [SHDataSetPropertyMeta(PropertyCode = "201.1.0")]
        public uint cm_tree_rid { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "201.2.0")]
        public uint cm_tree_parent_rid { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "201.3.0")]
        public string cm_tree_name { get; set; }
    }
}
