using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Common.Model
{
    public class Variable
    {
        [JsonPropertyName("email")]
        public string email { get; set; }

        [JsonPropertyName("substitutions")]
        public List<Substitution> substitutions { get; set; }
    }
}