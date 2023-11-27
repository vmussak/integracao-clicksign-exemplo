using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Clicksign.Exemplo.Dtos
{
    public class CreateDocumentRequest
    {
        [JsonPropertyName("document")]
        public CreateDocumentDataRequest Document { get; set; }
    }

    public class CreateDocumentDataRequest
    {
        [JsonPropertyName("path")]
        public string Path { get; set; }

        [JsonPropertyName("content_base64")]
        public string ContentBase64 { get; set; }

        [JsonPropertyName("deadline_at")]
        public DateTime? DeadlineAt { get; set; }

        [JsonPropertyName("auto_close")]
        public bool AutoClose { get; set; }

        [JsonPropertyName("locale")]
        public string Locale { get; set; }

        [JsonPropertyName("sequence_enabled")]
        public bool SequenceEnabled { get; set; }

        [JsonPropertyName("remind_interval")]
        public byte? RemindInteral { get; set; }

        [JsonPropertyName("block_after_refusal")]
        public bool BlockAfterRefusal { get; set; }
    }
}
