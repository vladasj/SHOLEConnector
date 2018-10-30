using System;
using System.Linq;
using System.Text;
using Sh4Ole;
using SHOLE.Execute;

using SHOLE.Procs;

namespace StoreOLE
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // args[0] - server address
            // args[1] - login
            // args[2] - password
            // args[3] - port

            SHOLEConnector.CurrentConnector.Init(args[0], (uint)Convert.ToInt16(args[3]), args[1], args[2]);
            SHOLEConnector.CurrentConnector.Connect();

            var treeProcDS = new CmTreeProc();
            var error = treeProcDS.Execute();
            foreach (var element in treeProcDS.result.Take(3))
            {
                Console.WriteLine($"TREE - name:{element.cm_tree_name} rid:{element.cm_tree_rid}");
                var cmBaseProcDS = new CmBaseProc()
                {
                    Input = new CmBaseProcInputDS()
                    {
                        cm_tree_rid = (int)element.cm_tree_rid
                    }
                };
                cmBaseProcDS.Execute();
                foreach (var cmBaseElenent in cmBaseProcDS.result)
                {
                    Console.WriteLine($"    BASE - name:{cmBaseElenent.cm_base_name} createdate:{cmBaseElenent.cm_tree_rid} user:{cmBaseElenent.cm_base_createdate}");
                    Console.WriteLine($"    BASE - abbr:{cmBaseElenent.cm_base_abbr} abbrnum:{cmBaseElenent.cm_base_abbrnumber}");

                    var hdrProcDS = new CmHdrProc()
                    {
                        input = new CmHdrProcInputDS()
                        {
                            cm_base_rid = (int)cmBaseElenent.cm_base_rid,
                            date = DateTime.Now,
                            someParam = 1
                        }
                    };
                    hdrProcDS.Execute();
                    Console.WriteLine("         HDR attr:");
                    foreach (var cmElenent in hdrProcDS.cm_hdr_attr)
                    {
                        Console.WriteLine($"                CMHDR - name:{cmElenent.cm_hdr_name} createdate:{cmElenent.cm_hdr_createdate} user:{cmElenent.cm_hdr_user}");
                        Console.WriteLine($"                CMHDR - abbr_text:{cmElenent.cm_hdr_abbr_text} abbr_num:{cmElenent.cm_hdr_abbr_number}");
                    }
                    Console.WriteLine("         HDR versions:");
                    foreach (var cmElenent in hdrProcDS.versions)
                    {
                        Console.WriteLine($"                CMVERSION - rid:{cmElenent.cm_version_rid} datefrom:{cmElenent.cm_version_dateFrom} dateto:{cmElenent.cm_version_dateTo}");
                    }
                    Console.WriteLine("         HDR complects:");
                    foreach (var cmElenent in hdrProcDS.complects)
                    {
                        Console.WriteLine($"                CMCOMP - rid:{cmElenent.cm_comp_rid} name:{cmElenent.cm_comp_name} out:{cmElenent.cm_item_out}");
                    }
                }
            }

            var goodsTree = new GoodsTreeProc();
            goodsTree.Execute();
            foreach (var element in goodsTree.result.Take(3))
            {
                Console.WriteLine($"GOODSTREE - name:{element.goodstree_name} rid:{element.goodstree_rid}");
                var goods = new GoodsProc()
                {
                    input = new GoodsProcInputDS()
                    {
                        goodstree_rid = (int)element.goodstree_rid
                    }
                };
                goods.Execute();
                foreach (var goodsElement in goods.result)
                {
                    Console.WriteLine($"    GOODS - name:{goodsElement.goods_name} rid:{goodsElement.goods_rid}");
                    Console.WriteLine($"    GOODS - abbr:{goodsElement.goods_abbrtext} abbrnum:{goodsElement.goods_abbrnumber}");
                    var goodsBase = new GoodsBaseProc()
                    {
                        input = new GoodsBaseInputDS()
                        {
                            goods_rid = (int)goodsElement.goods_rid
                        }
                    };
                    goodsBase.Execute();
                    foreach (var goodsBaseElement in goodsBase.complects)
                    {
                        Console.WriteLine($"        COMPLECTS - name:{goodsBaseElement.cm_base_name} rid:{goodsBaseElement.cm_base_rid}");
                    }
                    foreach (var goodsBaseElement in goodsBase.corr)
                    {
                        Console.WriteLine($"        CORR - name:{goodsBaseElement.corr_base_name} rid:{goodsBaseElement.corr_base_rid}");
                    }
                    foreach (var goodsBaseElement in goodsBase.clfr)
                    {
                        Console.WriteLine($"        CLFR - name:{goodsBaseElement.clfr_name} rid:{goodsBaseElement.clfrval_rid}");
                    }
                    foreach (var goodsBaseElement in goodsBase.complects_base)
                    {
                        Console.WriteLine($"        COMPLECTSBASE - abbr:{goodsBaseElement.cm_base_abbrttext} rid:{goodsBaseElement.cm_base_rid}");
                    }
                    foreach (var goodsBaseElement in goodsBase.units)
                    {
                        Console.WriteLine($"        UNITS - name:{goodsBaseElement.goods_munit_name} rid:{goodsBaseElement.goods_munit_rid}");
                    }
                    foreach (var goodsBaseElement in goodsBase.prices)
                    {
                        Console.WriteLine($"        PRICES - attr_id:{goodsBaseElement.goods_attr_id} price:{goodsBaseElement.goods_price}");
                    }
                    foreach (var goodsBaseElement in goodsBase.sunits_corr)
                    {
                        Console.WriteLine($"        SUINTSCORR - name:{goodsBaseElement.corr_base_rid} rid:{goodsBaseElement.corr_base_name}");
                    }
                }
            }
            Console.ReadKey();

            SHOLEConnector.CurrentConnector.Disconnect();
        }
    }
}
