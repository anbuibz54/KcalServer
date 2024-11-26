using Models.GeminiModels.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public interface IAIService
    {
        public Task<string> TextPrompt(string prompt);
        public Task<string> TextAndImagePrompt(string prompt, string image, string mimeType);
    }
}
