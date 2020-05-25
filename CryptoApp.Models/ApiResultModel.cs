using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace CryptoApp.Models
{
    public class ApiResultModel<T> where T : class
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }
        [JsonPropertyName("code")]
        public int Code { get; set; } = 0;
        [JsonPropertyName("message")]
        public string Message { get; set; }
        public T Data { get; set; }

    }
}
