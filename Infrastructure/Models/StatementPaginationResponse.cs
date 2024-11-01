using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Infrastructure.Models
{
    public class StatementPaginationResponse
    {
        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("pageCount")]
        public int PageCount { get; set; }

        [JsonPropertyName("pageSize")]
        public int PageSize { get; set; }

        [JsonPropertyName("totalRows")]
        public int TotalRows { get; set; }

        [JsonPropertyName("items")]
        public List<StatementItem> Items { get; set; }
    }
}

