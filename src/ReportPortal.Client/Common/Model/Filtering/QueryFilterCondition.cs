using System.Collections.Generic;

namespace ReportPortal.Client.Common.Model.Filtering
{
    public class QueryFilterCondition
    {
        public QueryFilterCondition(QueryFilterOperation operation, string field, object value, params object[] values)
        {
            Operation = operation;
            Field = field;
            Values = new List<object> {value};
            Values.AddRange(values);
        }

        public QueryFilterOperation Operation { get; }

        public string Field { get; }

        public List<object> Values { get; } 
    }
}
