﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ON.Settings.SimpleSettings.Service.Models
{
    public class AppSettings
    {
        public string DataStore { get; set; } = "/data";
        public string EventDBConnStr { get; set; } = "esdb://eventdb:2113?tls=false&keepAliveTimeout=10000&keepAliveInterval=10000";
    }
}
