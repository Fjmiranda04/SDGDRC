﻿using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;

namespace Common
{
    public class SessionHelper
    {
        public static string GetValue(IPrincipal User, string Property)
        {
            var r = ((ClaimsIdentity)User.Identity).FindFirst(Property);
            return r == null ? "" : r.Value;
        }

        public static IEnumerable<Claim> GetValues(IPrincipal User, string Property)
        {
            var r = ((ClaimsIdentity)User.Identity).FindAll(Property);
            return r;
        }

        public static string GetNameIdentifier(IPrincipal User)
        {
            var r = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.NameIdentifier);
            return r == null ? "" : r.Value;
        }

        public static string GetName(IPrincipal User)
        {
            var r = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.Name);
            return r == null ? "" : r.Value;
        }
    }
}