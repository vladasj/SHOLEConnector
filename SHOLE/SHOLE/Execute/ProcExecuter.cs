using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using SHOLE.Meta;

namespace SHOLE.Execute
{
    public static class ProcExecuter
    {
        static byte[] GetStringBytes(string source)
        {
            var result = new byte[source.Length];
            for (var i = 0; i < source.Length; i++)
            {
                result[i] = (byte)source[i];
            }
            return result;
        }

        static string ConvertString(string source)
        {
            var bytes = GetStringBytes(source);
            var win1251Encoding = Encoding.GetEncoding(1251);
            var results = Encoding.Convert(win1251Encoding, Encoding.Unicode, bytes);
            return Encoding.Unicode.GetString(results);
        }

        public static SHOLEConnector Connector = new SHOLEConnector();

        public static bool ExecuteProc(object proc)
        {
            var procMeta = new ProcMeta(proc.GetType());
            var indQuery = Connector.ShConnector.pr_CreateProc(procMeta.Name);
            foreach (var inputDataSet in procMeta.InputDataSetMetas)
            {
                foreach (var inputDataSetProperty in inputDataSet.Value.Propertyes)
                {
                    var value = inputDataSetProperty.Key.GetValue(inputDataSet.Key.GetValue(proc));

                    if (value is DateTime)
                    {
                        var convertedValue = (int) (DateTime.Now.ToUniversalTime().AddYears(-1) - new DateTime(1899, 12, 30)).TotalDays;
                        Connector.ShConnector.pr_SetValByName(indQuery, inputDataSet.Value.DSIndex,
                            inputDataSetProperty.Value, (int)convertedValue);
                    }else if (value is string)
                    {
                        Connector.ShConnector.pr_SetValByName(indQuery, inputDataSet.Value.DSIndex,
                            inputDataSetProperty.Value, (string)value);
                    }
                    else if (value is int)
                    {
                        Connector.ShConnector.pr_SetValByName(indQuery, inputDataSet.Value.DSIndex,
                            inputDataSetProperty.Value, (int)value);
                    }
                    else if (value is uint)
                    {
                        Connector.ShConnector.pr_SetValByName(indQuery, inputDataSet.Value.DSIndex,
                            inputDataSetProperty.Value, (uint)value);
                    }
                    else if ((value is int?) && (!(value != null)))
                    {
                        Connector.ShConnector.pr_SetValByName(indQuery, inputDataSet.Value.DSIndex,
                            inputDataSetProperty.Value, (int)value);
                    }
                    else if ((value is uint?)&&(!(value != null)))
                    {
                        Connector.ShConnector.pr_SetValByName(indQuery, inputDataSet.Value.DSIndex,
                            inputDataSetProperty.Value, (uint)value);
                    }
                
                }
                Connector.ShConnector.pr_Post(indQuery, inputDataSet.Value.DSIndex);
            }
            Connector.ShConnector.pr_ExecuteProc(indQuery);
            foreach (var outputDataSet in procMeta.OutputDataSetMetas)
            {
                if (outputDataSet.Value.IsList)
                {
                    var index = 0;
                    var listType = typeof(List<>).MakeGenericType(outputDataSet.Value.ItemType);
                    var list = Activator.CreateInstance(listType);
                    while (Connector.ShConnector.pr_EOF(indQuery, outputDataSet.Value.DSIndex) != 1 && ++index < 30)
                    {
                        var dataSetPropertyes = Activator.CreateInstance(outputDataSet.Value.ItemType);
                        foreach (var dataSetProperty in outputDataSet.Value.Propertyes)
                        {
                            var value = Connector.ShConnector.pr_ValByName(indQuery, outputDataSet.Value.DSIndex,
                                dataSetProperty.Value);
                            if (!(value is System.DBNull))
                            {
                                if (value is string)
                                    value = ConvertString(value);
                                dataSetProperty.Key.SetValue(dataSetPropertyes, value);
                            }
                        }
                        listType.GetTypeInfo().GetMethod("Add").Invoke(list, new object[] { dataSetPropertyes });
                        Connector.ShConnector.pr_Next(indQuery, outputDataSet.Value.DSIndex);
                    }
                    outputDataSet.Key.SetValue(proc, list);
                }
            }
            Connector.ShConnector.pr_CloseProc(indQuery);
            return true;
        }
    }
}