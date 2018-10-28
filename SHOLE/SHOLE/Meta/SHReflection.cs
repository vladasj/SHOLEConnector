using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SHOLE.Meta
{

    public class DataSetMeta
    {
        public int DSIndex { get; } = 0;
        public bool IsList { get; } = false;

        public Type ItemType { get; } = null;

        public Dictionary<PropertyInfo, string> Propertyes { get; } = new Dictionary<PropertyInfo, string>();

        public DataSetMeta(Type source, int? dsIndex = null)
        {
            var typeInfo = source.GetTypeInfo();
            IsList = typeof(IEnumerable).IsAssignableFrom(typeInfo);
            if (IsList)
            {
                ItemType = typeInfo.GetProperty("Item").PropertyType;
                typeInfo = ItemType.GetTypeInfo();
            }

            var shDataSetAttrbute = typeInfo.GetCustomAttribute<SHDataSetMeta>();
            if (dsIndex == null && shDataSetAttrbute != null)
                DSIndex = shDataSetAttrbute.DSIndex;
            else
                DSIndex = dsIndex ?? -1;

            foreach (var propertyInfo in typeInfo.GetProperties().Where(p => p.GetCustomAttribute<SHDataSetPropertyMeta>() != null))
            {
                Propertyes.Add(propertyInfo, propertyInfo.GetCustomAttribute<SHDataSetPropertyMeta>().PropertyCode);
            }
        }
    }

    public class ProcMeta
    {
        public string Name { get; }

        public Dictionary<PropertyInfo, DataSetMeta> InputDataSetMetas { get; } = new Dictionary<PropertyInfo, DataSetMeta>();

        public Dictionary<PropertyInfo, DataSetMeta> OutputDataSetMetas { get; } = new Dictionary<PropertyInfo, DataSetMeta>();

        public ProcMeta(Type source)
        {
            var typeInfo = source.GetTypeInfo();
            var shProcAttrbute = typeInfo.GetCustomAttribute<SHProcMeta>();
            if (shProcAttrbute != null)
                Name = shProcAttrbute.Name;

            foreach (var propertyInfo in typeInfo.GetProperties().Where(p => p.GetCustomAttribute<SHDataSetMeta>() != null && p.GetCustomAttribute<SHDataSetMeta>().IsInput))
                InputDataSetMetas.Add(propertyInfo, new DataSetMeta(propertyInfo.PropertyType, propertyInfo.GetCustomAttribute<SHDataSetMeta>().DSIndex));

            foreach (var propertyInfo in typeInfo.GetProperties().Where(p => p.GetCustomAttribute<SHDataSetMeta>() != null && !p.GetCustomAttribute<SHDataSetMeta>().IsInput))
                OutputDataSetMetas.Add(propertyInfo, new DataSetMeta(propertyInfo.PropertyType, propertyInfo.GetCustomAttribute<SHDataSetMeta>().DSIndex));
        }
    }
}