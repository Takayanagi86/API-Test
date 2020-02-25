using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace API_Test
{
    public class Result
    {


        [JsonProperty("API")]
        public string Api { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("Auth")]
        public string Auth { get; set; }

        [JsonProperty("HTTPS")]
        public bool Https { get; set; }

        [JsonProperty("Cors")]
        public string Cors { get; set; }

        [JsonProperty("Link")]
        public Uri Link { get; set; }

        [JsonProperty("Category")]
        public string Category { get; set; }
    }
       
       
    
        public class RootObject
        {
            public bool isError { get; set; }
            public int Status { get; set; }
            public string Message { get; set; }

        [JsonProperty("entries")]
        public List<Result> Results { get; set; }
        }
}
