using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzonAutoresponder.JsonData
{
    public class SettingsData
    {
        [JsonProperty("timeout_min")]
        public int TimeOut { get; set; }

        [JsonProperty("num_reviews")]
        public int NumReviews { get; set; }

        [JsonProperty("is_answer")]
        public bool IsAnswer { get; set; }
        [JsonProperty("timeout_sec_answer")]
        public int TimeoutAnswer { get; set; }
    }
}
