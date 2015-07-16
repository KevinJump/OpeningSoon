using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core;
using Umbraco.Core.Logging;
using Umbraco.Core.PropertyEditors;

namespace Jumoo.OpeningSoon
{
    public class OpeningTime
    {
        [JsonProperty("name")]
        public string Weekday { get; private set; }

        [JsonProperty("scheduled")]
        public bool IsScheduled { get; private set; }
        
        [JsonProperty("open")]
        public string Open { get; private set; }

        [JsonProperty("close")]
        public string Close { get; private set; }

        [JsonProperty("open2")]
        public string Open2 { get; private set; }

        [JsonProperty("close2")]
        public string Close2 { get; private set; }

        [JsonIgnore]
        public bool IsFirstSet
        {
            get
            {
                return (!string.IsNullOrWhiteSpace(this.Open) || !string.IsNullOrWhiteSpace(this.Close));
            }
        }

        [JsonIgnore]
        public bool IsSecondSet
        {
            get
            {
                return (!string.IsNullOrWhiteSpace(this.Open2) || !string.IsNullOrWhiteSpace(this.Close2));
            }
        }

        public static IEnumerable<OpeningTime> Deserialize(string json)
        {
            if (json == null)
                return null;

            return JsonConvert.DeserializeObject<IEnumerable<OpeningTime>>(json);
        }
    }

    [JsonObject]
    public class OpeningSoonModel : IEnumerable<OpeningTime>
    {
        // [JsonProperty("days")]
        public IEnumerable<OpeningTime> openingTimes { get; set; }

        public IEnumerator<OpeningTime> GetEnumerator()
        {
            return this.openingTimes.GetEnumerator(); 
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public static OpeningSoonModel Deserialize(string json)
        {
            if (json == null)
                return null;

            var items = JsonConvert.DeserializeObject<IEnumerable<OpeningTime>>(json);
            var m = new OpeningSoonModel();
            m.openingTimes = items;

            return m;
        }
    }

    public class OpeningSoonPropertyValueConverter : IPropertyValueConverter
    {
        public object ConvertDataToSource(Umbraco.Core.Models.PublishedContent.PublishedPropertyType propertyType, object source, bool preview)
        {
            return source;
        }

        public object ConvertSourceToObject(Umbraco.Core.Models.PublishedContent.PublishedPropertyType propertyType, object source, bool preview)
        {
            return OpeningSoonModel.Deserialize((string)source);
        }

        public object ConvertSourceToXPath(Umbraco.Core.Models.PublishedContent.PublishedPropertyType propertyType, object source, bool preview)
        {
            return null;
        }

        public bool IsConverter(Umbraco.Core.Models.PublishedContent.PublishedPropertyType propertyType)
        {
            return propertyType.PropertyEditorAlias == "Jumoo.OpeningSoon";
        }
    }
}
