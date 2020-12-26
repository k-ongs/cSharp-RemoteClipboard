using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteClipboard
{
    class ClassJsonConvertObject
    {
        public class PhoneSend
        {
            public string state { get; set; }
            public string code { get; set; }
            public string SessionContext { get; set; }
        }

        public class PhonePass
        {
            public PhonePass(string a, string b, string c)
            {
                user = a;
                pass = b;
                code = c;
            }
            public string user { get; set; }
            public string pass { get; set; }
            public string code { get; set; }
        }
    }
}
