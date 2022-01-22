using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzonAutoresponder.JsonData.JsonBodyReviews
{
    public class BodyReviews
    {
        public Filter? filter { get; set; }
        public int page { get; set; }
        public int page_size { get; set; }
        public Sort? sort { get; set; }
        public string? company_id { get; set; }
    }
}
