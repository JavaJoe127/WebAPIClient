﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;
using System.Text;

namespace WebAPIClient
{
    [DataContract(Name = "repo")]
    public class Repository
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "html_url")]
        public Uri GitHubHomeUrl { get; set; }

        [DataMember(Name = "homepage")]
        public Uri Homepage { get; set; }

        [DataMember(Name = "watchers")]
        public int Watchers { get; set; }

        [DataMember(Name = "pushed_at")]
        private string JsonDate { get; set; }

        // notice only a get accessor, read-only propertie
        // IgnoreDataMember, it's not part of the JSON object
        [IgnoreDataMember]
        public DateTime LastPush
        {
            get
            {
                return DateTime.ParseExact(JsonDate, "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture);
            }
        }
    }
}
