using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Common
{
    public class AISettings
    {
        public Gemini Gemini { get; set; }
    }
    public class Gemini
    {
        public string Endpoint { get; set; } = String.Empty;
        public string ApiKey { get; set; } = String.Empty;
        public string Model { get; set; } = String.Empty;
    }
}
