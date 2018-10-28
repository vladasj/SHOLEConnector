# StoreHouse4 OLE interface

Interface helps you to grab data from SH4 via OLE interface.

How it works:

1. Init connection
```c#
SHOLEConnector.CurrentConnector.Init(SHServerAddress, SHServerPort, UserName, Password);
SHOLEConnector.CurrentConnector.Connect();
```
1. Create object instance of remote proc
```c#
var cmBaseProcDS = new CmBaseProc()
                {
                    input = new CmBaseProcInputDS()
                    {
                        cm_tree_rid = SomeComplectTreeRid
                    }
                };
```

1. Execute remote proc and get data
```c#
cmBaseProcDS.Execute();
foreach (var cmBaseElenent in cmBaseProcDS.result)
{
  Console.WriteLine($"CMBASE - name:{cmBaseElenent.cm_base_name} createdate:{cmBaseElenent.cm_tree_rid}");
  Console.WriteLine($"CMBASE - abbr:{cmBaseElenent.cm_base_abbr} abbrnum:{cmBaseElenent.cm_base_abbrnumber}");
}
```

That's it!

You can implement any of SH remote proc all you need is to create description class.
```c#
[Meta.SHProcMeta(Name = "Goods")]
public class GoodsProc : Execute.SHProc
```
`SHProcMets` attribute defines SH remote proc name

Then describe input data set
```c#
[SHDataSetMeta(DSIndex = 0, IsInput = true)]
public GoodsProcInputDS input { get; set; } = new GoodsProcInputDS();

[SHDataSetMeta(DSIndex = 0)]
public class GoodsProcInputDS
{
  [SHDataSetPropertyMeta(PropertyCode = "209.1.0")]
  public int goodstree_rid { get; set; }

  [SHDataSetPropertyMeta(PropertyCode = "209.2.0")]
  public int goodstree_someparam { get; set; } = 0;
}
```
`SHDataSetMeta(DSIndex)` attribute describe index of dataset in query, `SHDataSetPropertyMeta` attributes define SH value codes

And describe result dataset
```c#
[SHDataSetMeta(DSIndex = 1)]
public SHDataSet<GoodsProcOutputDS> result { get; set; } = new SHDataSet<GoodsProcOutputDS>();

[SHDataSetMeta(DSIndex = 1)]
public class GoodsProcOutputDS
{
  [SHDataSetPropertyMeta(PropertyCode = "210.1.0")]
  public uint goods_rid { get; set; }
}
```
As in input dataset `SHDataSetPropertyMeta` defines SH value codes.
