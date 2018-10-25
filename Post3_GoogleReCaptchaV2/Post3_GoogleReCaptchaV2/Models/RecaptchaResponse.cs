﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace Post3_GoogleReCaptchaV2.Models
{
    public class RecaptchaResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("error-codes")]
        public List<string> ErrorCodes { get; set; }
    }
}