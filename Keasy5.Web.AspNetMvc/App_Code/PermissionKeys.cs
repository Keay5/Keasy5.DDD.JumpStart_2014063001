﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Keasy5.Web.AspNetMvc
{
    [Flags]
    public enum PermissionKeys
    {
        None = 0,
        Customers = 1,
        SalesReps = 2,
        Buyers = 4,
        Administrators = 8
    }
}