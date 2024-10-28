using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Infrastructure.Models
{
    public class StatementResponse
    {
        [JsonPropertyName("id_Requisicao")]
        public int IdRequisicao { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("periodo")]
        public string Periodo { get; set; }

        [JsonPropertyName("consulta")]
        public string Consulta { get; set; }

        [JsonPropertyName("solicitante")]
        public string Solicitante { get; set; }

        [JsonPropertyName("dataCadastro")]
        public string DataCadastro { get; set; }

        [JsonPropertyName("dataGeracao")]
        public string DataGeracao { get; set; }
    }

}
