using System;
using System.Text.Json.Serialization;

namespace Infrastructure.Models
{
    public class StatementItem
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("requestDate")]
        public DateTime? RequestDate { get; set; }

        [JsonPropertyName("contractNumber")]
        public int? ContractNumber { get; set; } 

        [JsonPropertyName("refundNumber")]
        public int? RefundNumber { get; set; } 

        [JsonPropertyName("beginningPeriod")]
        public DateTime? BeginningPeriod { get; set; } 

        [JsonPropertyName("endPeriod")]
        public DateTime? EndPeriod { get; set; } 

        [JsonPropertyName("generationDate")]
        public DateTime? GenerationDate { get; set; } 

        [JsonPropertyName("createDate")]
        public DateTime? CreateDate { get; set; } 

        [JsonPropertyName("requestUser")]
        public string RequestUser { get; set; }

        [JsonPropertyName("protocolNumber")]
        public string ProtocolNumber { get; set; }

        [JsonPropertyName("requesterName")]
        public string RequesterName { get; set; }

        [JsonPropertyName("requesterEmail")]
        public string RequesterEmail { get; set; }

        [JsonPropertyName("idUserRequester")]
        public int? IdUserRequester { get; set; } 

        [JsonPropertyName("requestStatus")]
        public string RequestStatus { get; set; }

        [JsonPropertyName("numberOfLinesInFile")]
        public int? NumberOfLinesInFile { get; set; } 

        [JsonPropertyName("fullPathStatementFile")]
        public string FullPathStatementFile { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }
    }
}
