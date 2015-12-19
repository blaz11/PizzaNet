using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.Net.RestAPIAccess
{
    static class UserSingleton
    {
        public static bool TokenValid { get; set; } = false;
        public static string Token { get; set; }
        public static string Email { get; set; }
    }
}