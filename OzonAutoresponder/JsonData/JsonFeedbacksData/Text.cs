using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzonAutoresponder.JsonData.JsonFeedbacksData
{
    public class Text
    {
        [JsonProperty("positive")]
        public string? Positive { get; set; }

        [JsonProperty("negative")]
        public string? Negative { get; set; }

        [JsonProperty("comment")]
        public string? Comment { get; set; }
    }
}
