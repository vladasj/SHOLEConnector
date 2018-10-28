using System;
using SHOLE.Meta;
using SHOLE.Execute;

namespace SHOLE.Procs
{
    [Meta.SHProcMeta(Name = "CmList")]
    public partial class CmListProc : Execute.SHProc
    {
        [SHDataSetMeta(DSIndex = 0, IsInput = true)]
        public CmListProcInputDS input { get; set; }

        [SHDataSetMeta(DSIndex = 2)]
        public SHDataSet<CmListProcOutputDS1> output1 { get; set; } = new SHDataSet<CmListProcOutputDS1>();
    }

    [SHDataSetMeta(DSIndex = 0)]
    public partial class CmListProcInputDS
    {
        [SHDataSetPropertyMeta(PropertyCode = "0.9.0")]
        public DateTime startDate { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "0.1.0")]
        public int someParam1 { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "201.1.0")]
        public int cm_tree_rid { get; set; }
    }

    [SHDataSetMeta(DSIndex = 1)]
    public partial class CmListProcOutputDS1
    {
        [SHDataSetPropertyMeta(PropertyCode = "0.1.0")]
        public DateTime cm_date { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "202.1.0")]
        public uint cm_rid { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "203.2.0")]
        public int options { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "204.8.0")]
        public string cm_comp_rid { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "200.9.0")]
        public string cm_comp_name { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "204.3.0")]
        public string cm_some_param_str { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "204.4.0")]
        public int cm_some_param_int { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "203.4.0")]
        public long cm_brutto { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "206.1.0")]
        public uint cm_munit_rid { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "206.2.0")]
        public string cm_munit_name { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "203.5.0")]
        public long cm_proc1 { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "203.6.0")]
        public long cm_proc2 { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "203.15.0")]
        public long cm_netto { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "203.16.0")]
        public long cm_out { get; set; }

        //[SHDataSetProperty(PropertyCode = "202.7.0")]
        //public int cm_bobrecipe { get; set; }

    }
}
