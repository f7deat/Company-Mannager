﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyManager.Common
{
    [Serializable]
    public class UserInfo
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public int Roles { get; set; }
    }
}