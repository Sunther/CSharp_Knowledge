using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Newtonsoft.Dtos
{
    public class DemoEntity
    {
        [JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public int Id { get; set; }
        [JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
        [JsonProperty("description", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<string> Description { get; set; }
        [JsonProperty("tags", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, string> Tags { get; set; }

        public bool ShouldSerializeDescription()
        {
            return Description.Count() > 0;
        }
        public bool ShouldSerializeTags()
        {
            return Tags.Count > 0;
        }
    }
}
