using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace Infrastructure.Models
{
    public class StatementRequest
    {
        [DataType(DataType.DateTime, ErrorMessage = "O campo 'DtBegin' deve ser uma data válida.")]
        [JsonPropertyName("dtBegin")]
        public string DtBegin { get; set; }

        [DataType(DataType.DateTime, ErrorMessage = "O campo 'DtEnd' deve ser uma data válida.")]
        [JsonPropertyName("dtEnd")]
        public string DtEnd { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "O campo 'contractNumber' deve ser maior que zero.")]
        [JsonPropertyName("contractNumber")]
        public int ContractNumber { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "O campo 'refundNumber' deve ser maior que zero.")]
        [JsonPropertyName("refundNumber")]
        public int RefundNumber { get; set; }

        [Required]
        [JsonPropertyName("user")]
        public string User { get; set; }

        [Required]
        [JsonPropertyName("protocolNumber")]
        public string ProtocolNumber { get; set; }

        [Required]
        [JsonPropertyName("requesterName")]
        public string RequesterName { get; set; }

        [EmailAddress(ErrorMessage = "Insira um email válido")]
        [JsonPropertyName("requesterEmail")]
        public string RequesterEmail { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "O campo 'idUserRequester' deve ser maior que zero.")]
        [JsonPropertyName("idUserRequester")]
        public int IdUserRequester { get; set; }
    }
}
