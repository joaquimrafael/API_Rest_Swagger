using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Infrastructure.Models
{
    public class StatementRequestPaginationParameters
    {
        // Parâmetros obrigatórios para paginação
        [Required(ErrorMessage = "O campo 'skip' é obrigatório.")]
        [Range(0, int.MaxValue, ErrorMessage = "O campo 'skip' deve ser um número inteiro não negativo.")]
        [JsonPropertyName("skip")]
        public int Skip { get; set; }

        [Required(ErrorMessage = "O campo 'take' é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "O campo 'take' deve ser um número inteiro positivo.")]
        [JsonPropertyName("take")]
        public int Take { get; set; }

        // Período de geração (opcional)
        [DataType(DataType.DateTime, ErrorMessage = "O campo 'InitGenerationPeriod' deve ser uma data válida.")]
        [JsonPropertyName("InitGenerationPeriod")]
        public DateTime? InitGenerationPeriod { get; set; }

        [DataType(DataType.DateTime, ErrorMessage = "O campo 'EndGenerationPeriod' deve ser uma data válida.")]
        [JsonPropertyName("EndGenerationPeriod")]
        public DateTime? EndGenerationPeriod { get; set; }

        // Período de registro (opcional)
        [DataType(DataType.DateTime, ErrorMessage = "O campo 'InitRegisterPeriod' deve ser uma data válida.")]
        [JsonPropertyName("InitRegisterPeriod")]
        public DateTime? InitRegisterPeriod { get; set; }

        [DataType(DataType.DateTime, ErrorMessage = "O campo 'EndRegisterPeriod' deve ser uma data válida.")]
        [JsonPropertyName("EndRegisterPeriod")]
        public DateTime? EndRegisterPeriod { get; set; }

        // Número de contrato (opcional)
        [Range(1, long.MaxValue, ErrorMessage = "O campo 'ContractNumber' deve ser maior que zero.")]
        [JsonPropertyName("ContractNumber")]
        public long? ContractNumber { get; set; }

        // Número de reembolso (opcional)
        [Range(1, long.MaxValue, ErrorMessage = "O campo 'RefundNumber' deve ser maior que zero.")]
        [JsonPropertyName("RefundNumber")]
        public long? RefundNumber { get; set; }
    }
}
