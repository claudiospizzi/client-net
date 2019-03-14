﻿using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using ReportPortal.Client.Common.Model.Paging;
using ReportPortal.Client.Extension;

namespace ReportPortal.Client.Common.Model.Filtering
{
    public class QueryFilter
    {
        public Page Paging { get; set; }

        public Sorting Sorting { get; set; }

        public IReadOnlyList<QueryFilterCondition> FilterConditions { get; set; }

        public string ToQueryString()
        {
            var builder = new StringBuilder();

            if (Paging != null)
            {
                builder.Append($"page.page={Paging.Number.ToString(CultureInfo.InvariantCulture)}");
                builder.Append($"&page.size={Paging.Size.ToString(CultureInfo.InvariantCulture)}");
            }

            if (Sorting != null)
            {
                builder.Append($"&page.sort={string.Join(",", Sorting.Fields.ToArray()) + "," + Sorting.Direction.GetDescriptionAttribute()}");
            }

            if (FilterConditions != null)
            {
                foreach (var filter in FilterConditions)
                {
                    var value = string.Join(",", filter.Values.Select(s => s.ToString()).ToArray());
                    builder.Append($"&filter.{filter.Operation.GetDescriptionAttribute()}.{filter.Field}={value}");
                }
            }

            return builder.ToString();
        }
    }
}