using System;
using System.Text.Json.Serialization;

namespace Infrastructure.Models
{
    public class StatementRequest
    {
        [JsonPropertyName("dtBegin")]
        public string DtBegin { get; set; }

        [JsonPropertyName("dtEnd")]
        public string DtEnd { get; set; }

        [JsonPropertyName("contractNumber")]
        public int ContractNumber { get; set; }

        [JsonPropertyName("refundNumber")]
        public int RefundNumber { get; set; }

        [JsonPropertyName("user")]
        public string User { get; set; }

        [JsonPropertyName("protocolNumber")]
        public string ProtocolNumber { get; set; }

        [JsonPropertyName("requesterName")]
        public string RequesterName { get; set; }

        [JsonPropertyName("requesterEmail")]
        public string RequesterEmail { get; set; }

        [JsonPropertyName("idUserRequester")]
        public int IdUserRequester { get; set; }
    }
}
