using Domain.Common;
using Microsoft.Extensions.Options;
using Models.Common;
using Models.GeminiModels;
using Models.GeminiModels.Request;
using Models.GeminiModels.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Content = Models.GeminiModels.Request.Content;
using Part = Models.GeminiModels.Request.Part;

namespace Services.Gemini
{
    public class GeminiService(IHttpClientFactory httpClientFactory, IOptions<AISettings> aiSettings) : IAIService
    {
        public async Task<string> TextPrompt(string prompt)
        {
            var httpClient = httpClientFactory.CreateClient();
            var endpoint = GetApiEndPoint();
            // Serialize the request body to JSON
            var body = BuidGeminiTextRequest(prompt);
            var content = new StringContent(body, Encoding.UTF8, "application/json");
            var res = await httpClient.PostAsync(endpoint, content);
            if (!res.IsSuccessStatusCode)
            {
                throw new Exception("Failed to use AI");
            }
            var responseContent = await res.Content.ReadAsStringAsync();
            var responseModel = JsonConvert.DeserializeObject<GeminiMessageResponse>(responseContent);
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
        private string BuidGeminiTextRequest(string prompt)
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
        private static string BuildImageGeminiRequest(
            string message,
            string base64Image,
            string mimeType)
        {
            var requestBody = new GeminiMessageRequest
            {
                Contents =
                    new List<Content>
                    {
                        new Content
                        {
                            Parts = new List<Part>
                            {
                                new Part
                                {
                                    Text = message,
                                },
                                new Part
                                {
                                    InlineData = new InlineData
                                    {
                                        MimeType = mimeType,
                                        Data = base64Image
                                    }
                                }
                            }
                        }
                    },
            };
            var res = JsonConvert.SerializeObject(requestBody);
            return res;
        }
        public async Task<string> TextAndImagePrompt(string prompt, string image, string mimeType)
        {
            var httpClient = httpClientFactory.CreateClient();
            var endpoint = GetApiEndPoint();
            var body = BuildImageGeminiRequest(prompt, image, mimeType);
            var content = new StringContent(body, Encoding.UTF8, "application/json");
            var res = await httpClient.PostAsync(endpoint, content);
            if (!res.IsSuccessStatusCode)
            {
                throw new Exception("Failed to use AI");
            }
            var responseContent = await res.Content.ReadAsStringAsync();
            var responseModel = JsonConvert.DeserializeObject<GeminiMessageResponse>(responseContent);
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
    }
}
