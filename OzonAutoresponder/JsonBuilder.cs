using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzonAutoresponder
{
    public static class JsonBuilder
    {
        private static BodyReviews? _bodyReviews;

        public static string GetBodyReviews(string brand)
        {
            if (_bodyReviews == null)
            {
                Sort sort = new Sort
                {
                    sort_by = "CREATED_AT",
                    sort_direction = "DESC"
                };
                Filter filter = new Filter
                {
                    interaction_status = new List<string> { "NOT_VIEWED" },
                    rating = new List<int> { 5 }
                };
                _bodyReviews = new BodyReviews
                {
                    company_id = brand,
                    filter = filter,
                    page = 1,
                    sort = sort,
                    page_size = GlobalVaribles.Settings.NumReviews
                };
            }
            string bodyReviews = JsonConvert.SerializeObject(_bodyReviews);
            return bodyReviews;
        }

        public static Feedbacks ConvertToFeedbacks(string content)
        {
            Feedbacks? feedbacks = JToken.Parse(content)
                .ToObject<Feedbacks>();
            if(feedbacks == null)
            {
                return new Feedbacks();
            }
            else
            {
                return feedbacks;
            }
        }

        public static OzonProfileData? GetOzonProfileData(string path)
        {
            OzonProfileData? ozonProfileData;
            if(File.Exists(path))
            {
                string jsonContent = File.ReadAllText(path);
                ozonProfileData = JToken
                    .Parse(jsonContent)
                    .ToObject<OzonProfileData>();
            }
            else
            {
                ozonProfileData = null;
            }
            return ozonProfileData;
        }

        public static string GetBodyAnswer(string text, string reviewId)
        {
            BodyAnswer bodyAnswer = new BodyAnswer 
            {
                CompanyId = SellerProfile.BrandId, 
                ParentCommentId = "0", 
                ReviewId = reviewId, 
                Text = text 
            };
            string content = JsonConvert.SerializeObject(bodyAnswer);
            return content;
        }
    }
}
