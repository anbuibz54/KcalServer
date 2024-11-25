using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.GeminiModels.Response
{
    public class GeminiMessageResponse
    {
        [JsonProperty("candidates")] public List<Candidate> Candidates { get; set; }
    }

    public class Candidate
    {
        [JsonProperty("content")] public Content Content { get; set; }
    }

    public class Content
    {
        [JsonProperty("parts")] public List<Part> Parts { get; set; }
    }

    public class Part
    {
        [JsonProperty("text")] public string Text { get; set; }
    }
}
