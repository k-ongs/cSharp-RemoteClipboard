using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteClipboardServer
{
    class ClassJsonConvertObject
    {
        public class PhoneSend
        {
            public string ret { get; set; }
            public string msg { get; set; }
            public string data { get; set; }
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
