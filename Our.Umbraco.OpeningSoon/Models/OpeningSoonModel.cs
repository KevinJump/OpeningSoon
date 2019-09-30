using Newtonsoft.Json;

using System.Collections;
using System.Collections.Generic;

using Umbraco.Core;

namespace Our.Umbraco.OpeningSoon
{
    public class OpeningSoonModel : IEnumerable<OpeningTime>
    {
        public IEnumerable<OpeningTime> OpeningTimes { get; set; }

        public IEnumerator<OpeningTime> GetEnumerator()
            => this.OpeningTimes.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        public static OpeningSoonModel Deserialize(string json)
        {
            if (string.IsNullOrEmpty(json) || !json.DetectIsJson()) 
                return null;

            var items = JsonConvert.DeserializeObject<IEnumerable<OpeningTime>>(json);
            var model = new OpeningSoonModel()
            {
                OpeningTimes = items
            };

            return model;
        }
    }
}
