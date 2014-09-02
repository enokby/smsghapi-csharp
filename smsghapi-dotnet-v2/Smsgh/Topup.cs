using System;

namespace smsghapi_dotnet_v2.Smsgh
{
    public class Topup
    {
        public Topup() {}

        public Topup(ApiDictionary dix)
        {
            foreach (string key in dix.Keys) {
                switch (key.ToLower()) {
                    case "purchasedcredit":
                        PurchasedCredit = Convert.ToInt64(dix[key]);
                        break;
                    case "actualcredit":
                        ActualCredit = Convert.ToDouble(dix[key]);
                        break;
                }
            }
        }

        public long PurchasedCredit { set; get; }
        public double ActualCredit { set; get; }
    }
}