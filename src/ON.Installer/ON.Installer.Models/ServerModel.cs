﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ON.Installer.Models
{
    public class ServerModel
    {
        public string IP { get; set; } = "";
        public string User { get; set; } = "";
        public string SSHPrivateKey { get; set; } = "";
    }
}
