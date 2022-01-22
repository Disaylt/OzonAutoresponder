using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzonAutoresponder.JsonData.JsonFeedbacksData
{
    public class Feedbacks
    {
        [JsonProperty("result")]
        public List<Result>? Result { get; set; }

        [JsonProperty("page_count")]
        public int PageCount { get; set; }

        [JsonProperty("total_items")]
        public int TotalItems { get; set; }
    }
}
