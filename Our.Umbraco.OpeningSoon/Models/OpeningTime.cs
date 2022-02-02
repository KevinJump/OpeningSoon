using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Our.Umbraco.OpeningSoon
{
    public class OpeningTime
    {
        [JsonProperty("name")]
        public string? Weekday { get; private set; }

        [JsonProperty("scheduled")]
        public bool IsScheduled { get; private set; }

        [JsonProperty("open")]
        public string? Open { get; private set; }

        [JsonProperty("close")]
        public string? Close { get; private set; }

        [JsonProperty("open2")]
        public string? Open2 { get; private set; }

        [JsonProperty("close2")]
        public string? Close2 { get; private set; }

        [JsonIgnore]
        public bool IsFirstSet
        {
            get => !string.IsNullOrWhiteSpace(this.Open);
        }

        public bool IsSecondSet
        {
            get => !string.IsNullOrWhiteSpace(this.Open2);
        }

        public static IEnumerable<OpeningTime>? Deserialize(string json)
        {
            if (json == null) return Enumerable.Empty<OpeningTime>();
            return JsonConvert.DeserializeObject<IEnumerable<OpeningTime>>(json);
        }


    }
}
