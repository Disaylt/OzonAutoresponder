using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzonAutoresponder
{
    public static class SellerProfile
    {
        private static OzonProfileData? ozonProfileData { get; } = JsonBuilder.GetOzonProfileData($"{GlobalVaribles.ProjectDirectory}{GlobalVaribles.ProfileJsonFile}");
        public static string BrandId
        {
            get
            {
                return ozonProfileData.BrandId;
            }
        }

        public static string Token
        {
            get
            {
                return ozonProfileData.Token;
            }
        }
    }
}
