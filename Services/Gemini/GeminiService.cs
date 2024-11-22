using Domain.Common;
using Microsoft.Extensions.Options;
using Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Gemini
{
    public class GeminiService(IHttpClientFactory httpClientFactory, IOptions<AISettings> aiSettings) : IAIService
    {
        public async Task<string> GetResponse(string prompt)
        {
            var httpClient = httpClientFactory.CreateClient();
            var endpoint = GetApiEndPoint();
            // Serialize the request body to JSON
            var answer = CreateRequestBody(prompt);
            var content = new StringContent(answer, Encoding.UTF8, "application/json");
            var res = await httpClient.PostAsync(endpoint, content);
            if (!res.IsSuccessStatusCode)
            {
                throw new Exception("Failed to use AI");
            }
            var responseContent = await res.Content.ReadAsStringAsync();
            var responseModel = JsonConvert.DeserializeObject<Response>(responseContent);
            var responseText = "";
            if (responseModel?.Candidates != null && responseModel.Candidates.Count > 0)
            {
                foreach (var candidate in responseModel.Candidates)
                {
                    if (candidate.Content?.Parts != null)
                    {
                        foreach (var part in candidate.Content.Parts)
                        {
                            responseText += part.Text;
                        }
                    }
                }
            }
            return responseText;
        }
        private string GetApiEndPoint()
        {
            var settingsValue = aiSettings.Value.Gemini;
            var endpoint = $@"{settingsValue.Endpoint}/models/{settingsValue.Model}:generateContent?key={settingsValue.ApiKey}";
            return endpoint;
        }
        private string CreateRequestBody(string prompt)
        {
            var requestBody = new
            {
                contents = new[]
                {
            new
            {
                parts = new[]
                {
                    new
                    {
                        text = prompt
                    }
                }
            }
        }
            };
            return System.Text.Json.JsonSerializer.Serialize(requestBody);
        }
    }

    public class Response
    {
        public List<Candidate> Candidates { get; set; }
    }

    public class Candidate
    {
        public Content Content { get; set; }
    }

    public class Content
    {
        public List<Part> Parts { get; set; }
    }

    public class Part
    {
        public string Text { get; set; }
    }
}
