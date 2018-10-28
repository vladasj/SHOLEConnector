using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SHOLE.Meta;

namespace SHOLE.Execute
{
    public class SHProc
    {
        private ProcMeta _procMeta;
        private int _indQuery = -1;
        public bool Executed
        {
            get { return _indQuery != -1; }
        }
        public SHProc()
        {
            _procMeta = new ProcMeta(this.GetType());
        }

        public bool Execute()
        {
            _indQuery = SHOLEConnector.CurrentConnector.ShConnector.pr_CreateProc(_procMeta.Name);
            foreach (var inputDataSet in _procMeta.InputDataSetMetas)
            {
                foreach (var inputDataSetProperty in inputDataSet.Value.Propertyes)
                {
                    var value = inputDataSetProperty.Key.GetValue(inputDataSet.Key.GetValue(this));

                    if (value is DateTime || (value is DateTime? && value != null))
                    {
                        var convertedValue = ((DateTime)value).ConvertDate();
                        SHOLEConnector.CurrentConnector.ShConnector.pr_SetValByName(_indQuery, inputDataSet.Value.DSIndex,
                            inputDataSetProperty.Value, (int)convertedValue);
                    }
                    else if (value is string)
                    {
                        SHOLEConnector.CurrentConnector.ShConnector.pr_SetValByName(_indQuery, inputDataSet.Value.DSIndex,
                            inputDataSetProperty.Value, (string)value);
                    }
                    else if (value is int || (value is int? && value != null))
                    {
                        SHOLEConnector.CurrentConnector.ShConnector.pr_SetValByName(_indQuery, inputDataSet.Value.DSIndex,
                            inputDataSetProperty.Value, (int)value);
                    }
                    else if (value is uint || (value is uint? && value != null))
                    {
                        SHOLEConnector.CurrentConnector.ShConnector.pr_SetValByName(_indQuery, inputDataSet.Value.DSIndex,
                            inputDataSetProperty.Value, (uint)value);
                    }
                }
                SHOLEConnector.CurrentConnector.ShConnector.pr_Post(_indQuery, inputDataSet.Value.DSIndex);
            }
            SHOLEConnector.CurrentConnector.ShConnector.pr_ExecuteProc(_indQuery);
            foreach (var outputDataSet in _procMeta.OutputDataSetMetas)
            {
                var dataSet = outputDataSet.Key.GetValue(this);
                var typeInfo = dataSet.GetType().GetTypeInfo();
                typeInfo.GetProperty("IndQuery").SetValue(dataSet, _indQuery);
                typeInfo.GetProperty("DSIndex").SetValue(dataSet, outputDataSet.Value.DSIndex);
            }

            return true;
        }

        ~SHProc()
        {
            if (Executed) SHOLEConnector.CurrentConnector.ShConnector.pr_CloseProc(_indQuery);
        }
    }
}
