using System;
using SHOLE.Meta;
using SHOLE.Execute;

namespace SHOLE.Procs
{
    [Meta.SHProcMeta(Name = "CmHdr")]
    public partial class CmHdrProc: Execute.SHProc
    {
        [SHDataSetMeta(DSIndex = 0, IsInput = true)]
        public CmHdrProcInputDS input { get; set; }

        [SHDataSetMeta(DSIndex = 1)]
        public SHDataSet<CmHdrProcOutputDS1> cm_hdr_attr { get; set; } = new SHDataSet<CmHdrProcOutputDS1>();

        [SHDataSetMeta(DSIndex = 2)]
        public SHDataSet<CmHdrProcOutputDS2> versions { get; set; } = new SHDataSet<CmHdrProcOutputDS2>();

        [SHDataSetMeta(DSIndex = 3)]
        public SHDataSet<CmHdrProcOutputDS3> inplace_since { get; set; } = new SHDataSet<CmHdrProcOutputDS3>();

        [SHDataSetMeta(DSIndex = 4)]
        public SHDataSet<CmHdrProcOutputDS4> complects { get; set; } = new SHDataSet<CmHdrProcOutputDS4>();
    }

    [SHDataSetMeta(DSIndex = 0)]
    public partial class CmHdrProcInputDS
    {
        [SHDataSetPropertyMeta(PropertyCode = "200.1.0")]
        public int cm_base_rid { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "0.1.0")]
        public DateTime date { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "0.2.0")]
        public int someParam { get; set; } = 0;
    }

    [SHDataSetMeta(DSIndex = 1)]
    public partial class CmHdrProcOutputDS1
    {
        [SHDataSetPropertyMeta(PropertyCode = "200.1.0")]
        public uint cm_hdr_rid { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "201.1.0")]
        public uint cm_tree_parent_rid { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "200.2.0")]
        public string cm_hdr_name { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "200.3.0")]
        public string cm_hdr_abbr_text { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "200.4.0")]
        public int cm_hdr_options { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "206.1.0")]
        public uint cm_hdr_munit_rid { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "200.6.0")]
        public uint cm_hdr_abbr_number { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "206.2.0")]
        public string cm_hdr_munit_name { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "201.3.0")]
        public string cm_tree_parent_name { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "102.1.0")]
        public int cm_hdr_corrbase_rec { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "102.4.0")]
        public string cm_hdr_corrbase_name { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "0.1.7")]
        public DateTime cm_hdr_createdate { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "0.2.7")]
        public int cm_hdr_createdate_sec { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "0.3.7")]
        public DateTime cm_hdr_modifydate { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "0.4.7")]
        public int cm_hdr_modifydate_sec { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "0.5.7")]
        public string cm_hdr_mindateactivedoc { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "0.6.7")]
        public string cm_hdr_user { get; set; }
    }

    [SHDataSetMeta(DSIndex = 2)]
    public partial class CmHdrProcOutputDS2
    {
        [SHDataSetPropertyMeta(PropertyCode = "202.1.10")]
        public uint cm_version_rid { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "202.2.10")]
        public DateTime cm_version_dateFrom { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "202.3.10")]
        public DateTime cm_version_dateTo { get; set; }

    }

    [SHDataSetMeta(DSIndex = 3)]
    public partial class CmHdrProcOutputDS3
    {
        [SHDataSetPropertyMeta(PropertyCode = "202.1.0")]
        public int cm_hdr_rid { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "202.2.0")]
        public DateTime cm_hdr_dateFrom { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "200.1.0")]
        public int cm_base_rid { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "202.4.0")]
        public float cm_hdr_norm { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "202.100.0")]
        public int cm_hdr_someparam { get; set; }
    }

    [SHDataSetMeta(DSIndex = 4)]
    public partial class CmHdrProcOutputDS4
    {

        [SHDataSetPropertyMeta(PropertyCode = "203.1.0")]
        public uint cm_item_rid { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "203.11.0")]
        public int cm_item_order { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "203.2.0")]
        public int cm_item_options { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "204.8.0")]
        public uint cm_comp_rid { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "204.9.0")]
        public string cm_comp_name { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "206.1.0")]
        public uint cm_item_muint_rid { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "206.2.0")]
        public string cm_item_muint_name { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "211.1.0")]
        public double cm_item_gmunit_cf { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "206.1.1")]
        public uint cm_item_muint_rid2 { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "206.2.1")]
        public string cm_item_muint_name2 { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "212.2.0")]
        public int cm_item_tgtax_rate { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "213.2.0")]
        public int cm_item_tgtax_rate2 { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "203.4.1")]
        public double cm_item_brutto { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "203.5.1")]
        public double cm_item_proc1 { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "203.15.1")]
        public double cm_item_netto { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "203.6.1")]
        public double cm_item_proc2 { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "203.16.1")]
        public double cm_item_out { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "203.7.1")]
        public double cm_item_share { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "220.1.0")]
        public int cm_item_replace_rid { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "220.2.0")]
        public string cm_item_replace_name { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "203.20.2")]
        public double cm_item_pcost { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "203.21.2")]
        public double cm_item_tax1 { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "203.22.2")]
        public double cm_item_tax2 { get; set; }

        [SHDataSetPropertyMeta(PropertyCode = "202.1.0")]
        public uint cm_hdr_rid { get; set; }
    }
}
