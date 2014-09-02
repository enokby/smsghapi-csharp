using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace smsghapi_dotnet_v2.Smsgh
{
    public class Ticket
    {
        private readonly string _accountId;
        private readonly string _assignedTo;
        private readonly string _attachment;
        private readonly int _id;
        private readonly DateTime? _lastUpdated;
        private readonly int? _rating;
        private readonly string _recipients;
        private readonly List<TicketResponse> _responses;
        private readonly int? _supporStatusId;
        private readonly DateTime? _timeAdded;
        private readonly DateTime? _timeAssigned;
        private readonly DateTime? _timeClosed;

        public Ticket() {}

        public Ticket(ApiDictionary jso)
        {
            _responses = new List<TicketResponse>();
            foreach (string key in jso.Keys) {
                switch (key.ToLower()) {
                    case "id":
                        _id = Convert.ToInt32(jso[key]);
                        break;
                    case "accountid":
                        _accountId = Convert.ToString(jso[key]);
                        break;
                    case "assignedto":
                        _assignedTo = Convert.ToString(jso[key]);
                        break;
                    case "supportdepartmentid":
                        SupportDepartmentId = Convert.ToInt32(jso[key]);
                        break;
                    case "supportcategoryid":
                        SupportCategoryId = Convert.ToInt32(jso[key]);
                        break;
                    case "supportstatusid":
                        _supporStatusId = Convert.ToInt32(jso[key]);
                        break;
                    case "priority":
                        Priority = Convert.ToInt32(jso[key]);
                        break;
                    case "source":
                        Source = Convert.ToString(jso[key]);
                        break;
                    case "recipients":
                        _recipients = Convert.ToString(jso[key]);
                        break;
                    case "timeadded":

                        if (jso[key].ToString() != "") {
                            DateTime timeParsed;
                            _timeAdded = DateTime.TryParseExact(jso[key].ToString(), "yyyy-dd-MM hh:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out timeParsed)
                                ? timeParsed
                                : (DateTime?) null;
                        }
                        break;
                    case "timeclosed":

                        if (jso[key].ToString() != "") {
                            DateTime timeParsed;
                            _timeClosed = DateTime.TryParseExact(jso[key].ToString(), "yyyy-dd-MM hh:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out timeParsed)
                                ? timeParsed
                                : (DateTime?) null;
                        }
                        break;
                    case "timeassigned":

                        if (jso[key].ToString() != "") {
                            DateTime timeParsed;
                            _timeAssigned = DateTime.TryParseExact(jso[key].ToString(), "yyyy-dd-MM hh:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out timeParsed)
                                ? timeParsed
                                : (DateTime?) null;
                        }
                        break;
                    case "lastupdated":

                        if (jso[key].ToString() != "") {
                            DateTime timeParsed;
                            _lastUpdated = DateTime.TryParseExact(jso[key].ToString(), "yyyy-dd-MM hh:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out timeParsed)
                                ? timeParsed
                                : (DateTime?) null;
                        }
                        break;
                    case "subject":
                        Subject = Convert.ToString(jso[key]);
                        break;
                    case "content":
                        Content = Convert.ToString(jso[key]);
                        break;
                    case "attachment":
                        _attachment = Convert.ToString(jso[key]);
                        break;
                    case "rating":
                        _rating = Convert.ToInt32(jso[key]);
                        break;
                    case "responses":
                        var os = jso[key] as IEnumerable;
                        if (os != null)
                            foreach (JObject o in os)
                                _responses.Add(new TicketResponse(o.ToObject<ApiDictionary>()));
                        break;
                }
            }
        }

        [JsonIgnore]
        public int Id
        {
            get { return _id; }
        }

        [JsonIgnore]
        public string AccountId
        {
            get { return _accountId; }
        }

        public int? SupportDepartmentId { get; set; }
        public int? SupportCategoryId { get; set; }

        [JsonIgnore]
        public int? SupportStatusId
        {
            get { return _supporStatusId; }
        }

        public int? Priority { get; set; }
        public string Source { get; set; }

        [JsonIgnore]
        public string Recipients
        {
            get { return _recipients; }
        }

        [JsonIgnore]
        public DateTime? TimeAdded
        {
            get { return _timeAdded; }
        }

        [JsonIgnore]
        public DateTime? TimeClosed
        {
            get { return _timeClosed; }
        }

        [JsonIgnore]
        public DateTime? TimeAssigned
        {
            get { return _timeAssigned; }
        }

        [JsonIgnore]
        public DateTime? LastUpdated
        {
            get { return _lastUpdated; }
        }

        public string Subject { get; set; }
        public string Content { get; set; }

        [JsonIgnore]
        public string Attachment
        {
            get { return _attachment; }
        }

        [JsonIgnore]
        public string AssignedTo
        {
            get { return _assignedTo; }
        }

        [JsonIgnore]
        public int? Rating
        {
            get { return _rating; }
        }

        [JsonIgnore]
        public List<TicketResponse> Responses
        {
            get { return _responses; }
        }
    }
}