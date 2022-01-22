using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzonAutoresponder.JsonData.JsonFeedbacksData
{
    public class Result
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("sku")]
        public string? Sku { get; set; }

        [JsonProperty("text")]
        public Text? Text { get; set; }

        [JsonProperty("has_unread_comment")]
        public bool HasUnreadComment { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("rating")]
        public int Rating { get; set; }

        [JsonProperty("interaction_status")]
        public string? InteractionStatus { get; set; }

        [JsonProperty("comments_amount")]
        public int CommentsAmount { get; set; }

        [JsonProperty("likes_amount")]
        public int LikesAmount { get; set; }

        [JsonProperty("dislikes_amount")]
        public int DislikesAmount { get; set; }

        [JsonProperty("author_name")]
        public string? AuthorName { get; set; }

        [JsonProperty("photos_count")]
        public int PhotosCount { get; set; }

        [JsonProperty("videos_count")]
        public int VideosCount { get; set; }

        [JsonProperty("comments_count")]
        public int CommentsCount { get; set; }
    }
}
