// Code generated by Microsoft (R) AutoRest Code Generator 0.16.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Minor.Dag21.CASServiceClient.Agents.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;

    public partial class Foutmelding
    {
        /// <summary>
        /// Initializes a new instance of the Foutmelding class.
        /// </summary>
        public Foutmelding() { }

        /// <summary>
        /// Initializes a new instance of the Foutmelding class.
        /// </summary>
        public Foutmelding(int? errorType = default(int?), string errorMessage = default(string), string remedy = default(string))
        {
            ErrorType = errorType;
            ErrorMessage = errorMessage;
            Remedy = remedy;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "errorType")]
        public int? ErrorType { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "errorMessage")]
        public string ErrorMessage { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "remedy")]
        public string Remedy { get; set; }

    }
}
