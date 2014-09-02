using System;

namespace smsghapi_dotnet_v2.Smsgh
{
    public class TopupLocation
    {
        public TopupLocation() {}

        public TopupLocation(ApiDictionary dix)
        {
            foreach (string key in dix.Keys) {
                switch (key.ToLower()) {
                    case "id":
                        Id = Convert.ToInt64(dix[key]);
                        break;
                    case "city":
                        City = Convert.ToString(dix[key]);
                        break;
                    case "area":
                        Area = Convert.ToString(dix[key]);
                        break;
                    case "region":
                        Region = Convert.ToString(dix[key]);
                        break;
                    case "details":
                        Details = Convert.ToString(dix[key]);
                        break;
                    case "description":
                        Description = Convert.ToString(dix[key]);
                        break;
                    case "latitude":
                        Latitude = Convert.ToDouble(dix[key]);
                        break;
                    case "longitude":
                        Longitute = Convert.ToDouble(dix[key]);
                        break;
                }
            }
        }

        public long Id { private set; get; }
        public string City { set; get; }
        public string Area { set; get; }
        public string Region { set; get; }
        public string Details { set; get; }
        public string Description { set; get; }
        public double Latitude { set; get; }
        public double Longitute { set; get; }
    }
}