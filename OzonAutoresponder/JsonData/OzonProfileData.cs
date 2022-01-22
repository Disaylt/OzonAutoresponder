using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzonAutoresponder.JsonData
{
    public class OzonProfileData
    {
        [JsonProperty("brand_id")]
        public string? BrandId { get; set; }

        [JsonProperty("token")]
        public string? Token { get; set; }
    }
}
