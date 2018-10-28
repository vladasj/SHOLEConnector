using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using SHOLE.Meta;

namespace SHOLE.Execute
{

    public class SHDataSet<T> : IEnumerable<T>, IEnumerator<T>
    {
        public int DSIndex { get; set; }
        public int IndQuery { get; set; }
        private ArrayList _cashArrayList = new ArrayList();
        private int _position = -1;
        object IEnumerator.Current => Current;
        public T Item => Current;
        public T Current
        {
            get
            {
                try
                {
                    return (T)_cashArrayList[_position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        private DataSetMeta _currentMeta = new DataSetMeta(typeof(T));

        public IEnumerator<T> GetEnumerator()
        {
            Reset();
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Dispose()
        {
            Reset();
        }

        static byte[] GetStringBytes(string source)
        {
            byte[] result = new byte[source.Length];
            for (int i = 0; i < source.Length; i++)
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

        private T LoadElement()
        {
            var newElement = Activator.CreateInstance(typeof(T));
            foreach (var dataSetProperty in _currentMeta.Propertyes)
            {
                var value = SHOLEConnector.CurrentConnector.ShConnector.pr_ValByName(IndQuery, DSIndex,
                    dataSetProperty.Value);
                if (value is System.DBNull) continue;
                if (value is string)
                    value = ConvertString(value);
                if (dataSetProperty.Key.PropertyType == typeof(uint))
                    value = (uint)value;
                dataSetProperty.Key.SetValue(newElement, value);
            }
            return (T)newElement;
        }

        public bool MoveNext()
        {
            _position++;
            if (_position < this._cashArrayList.Count)
            {
                SHOLEConnector.CurrentConnector.ShConnector.pr_Next(IndQuery, DSIndex);
                return true;
            }
            if (SHOLEConnector.CurrentConnector.ShConnector.pr_EOF(IndQuery, DSIndex) == 1) return false;
            _cashArrayList.Add(LoadElement());
            SHOLEConnector.CurrentConnector.ShConnector.pr_Next(IndQuery, DSIndex);
            return true;
        }

        public void Reset()
        {
            SHOLEConnector.CurrentConnector.ShConnector.pr_First(IndQuery, DSIndex);
            _position = -1;
        }

        public T FindElement(string propertyName, object value)
        {

            var property = this._currentMeta.Propertyes.FirstOrDefault(t => t.Key.Name == propertyName);
            if (property.Equals(default(KeyValuePair<PropertyInfo, string>))) return default(T);

            SHOLEConnector.CurrentConnector.ShConnector.pr_AddIndex(IndQuery, DSIndex, propertyName, property.Value);
            SHOLEConnector.CurrentConnector.ShConnector.pr_SetIndexName(IndQuery, DSIndex, propertyName);

            var result = 0;
            if (value is DateTime)
            {
                var convertedValue = ((DateTime)value).ConvertDate();
                result = SHOLEConnector.CurrentConnector.ShConnector.pr_FindKey(IndQuery, DSIndex, convertedValue, null, null);
            }
            else if (value is string)
            {
                result = SHOLEConnector.CurrentConnector.ShConnector.pr_FindKey(IndQuery, DSIndex, (string)value, null, null);
            }
            else if (value is int)
            {
                result = SHOLEConnector.CurrentConnector.ShConnector.pr_FindKey(IndQuery, DSIndex, (int)value, null, null);
            }

            if (result != 1)
                return default(T);
            var element = LoadElement();
            return element;

        }
    }
}
