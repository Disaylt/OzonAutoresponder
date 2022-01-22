using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzonAutoresponder.JsonData.JsonBodeRequstAnswer
{
    public class BodyAnswer
    {
        [JsonProperty("company_id")]
        public string CompanyId { get; set; }

        [JsonProperty("parent_comment_id")]
        public string ParentCommentId { get; set; }

        [JsonProperty("review_id")]
        public string ReviewId { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
