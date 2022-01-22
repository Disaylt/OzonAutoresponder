using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace OzonAutoresponder
{
    public class OzonHttpClient
    { 
        public async Task<Feedbacks> GetFeedbackListAsync()
        {
            try
            {
                var handler = new HttpClientHandler();
                handler.UseCookies = false;

                using (var httpClient = new HttpClient(handler))
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://seller.ozon.ru/api/review/list"))
                    {
                        request.Headers.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:95.0) Gecko/20100101 Firefox/95.0");
                        request.Headers.TryAddWithoutValidation("Accept", "application/json, text/plain, */*");
                        request.Headers.TryAddWithoutValidation("Accept-Language", "ru");
                        request.Headers.TryAddWithoutValidation("Accept-Encoding", "UTF-8");
                        request.Headers.TryAddWithoutValidation("accessToken", SellerProfile.Token);
                        request.Headers.TryAddWithoutValidation("x-o3-company-id", SellerProfile.BrandId);
                        request.Headers.TryAddWithoutValidation("x-o3-language", "ru");
                        request.Headers.TryAddWithoutValidation("Origin", "https://seller.ozon.ru");
                        request.Headers.TryAddWithoutValidation("Connection", "keep-alive");
                        request.Headers.TryAddWithoutValidation("Referer", "https://seller.ozon.ru/app/review?filter=NOT_VIEWED");
                        request.Headers.TryAddWithoutValidation("Sec-Fetch-Dest", "empty");
                        request.Headers.TryAddWithoutValidation("Sec-Fetch-Mode", "cors");
                        request.Headers.TryAddWithoutValidation("Sec-Fetch-Site", "same-origin");
                        request.Headers.TryAddWithoutValidation("TE", "trailers");

                        request.Content = new StringContent(JsonBuilder.GetBodyReviews(SellerProfile.BrandId));
                        request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                        var response = await httpClient.SendAsync(request);
                        var content = response.Content.ReadAsStringAsync().Result;
                        Feedbacks feedbacks = JsonBuilder.ConvertToFeedbacks(content);
                        return feedbacks;
                    }
                }
            }
            catch (Exception ex)
            {
                return new Feedbacks();
            }
        }

        public async Task<string> PostAnswer(string body)
        {
            try
            {
                var handler = new HttpClientHandler();
                handler.UseCookies = false;

                using (var httpClient = new HttpClient(handler))
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://seller.ozon.ru/api/review/comment/create"))
                    {
                        request.Headers.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:95.0) Gecko/20100101 Firefox/95.0");
                        request.Headers.TryAddWithoutValidation("Accept", "application/json, text/plain, */*");
                        request.Headers.TryAddWithoutValidation("Accept-Language", "ru");
                        request.Headers.TryAddWithoutValidation("Accept-Encoding", "UTF-8");
                        request.Headers.TryAddWithoutValidation("accessToken", SellerProfile.Token);
                        request.Headers.TryAddWithoutValidation("x-o3-company-id", SellerProfile.BrandId);
                        request.Headers.TryAddWithoutValidation("x-o3-language", "ru");
                        request.Headers.TryAddWithoutValidation("Origin", "https://seller.ozon.ru");
                        request.Headers.TryAddWithoutValidation("Connection", "keep-alive");
                        request.Headers.TryAddWithoutValidation("Referer", "https://seller.ozon.ru/app/review?filter=NOT_VIEWED");
                        request.Headers.TryAddWithoutValidation("Sec-Fetch-Dest", "empty");
                        request.Headers.TryAddWithoutValidation("Sec-Fetch-Mode", "cors");
                        request.Headers.TryAddWithoutValidation("Sec-Fetch-Site", "same-origin");
                        request.Headers.TryAddWithoutValidation("TE", "trailers");

                        request.Content = new StringContent(body);
                        request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                        var response = await httpClient.SendAsync(request);
                        var content = response.Content.ReadAsStringAsync().Result;
                        return content;
                    }
                }
            }
            catch (Exception ex)
            {
                return String.Empty;
            }
        }
    }
}
