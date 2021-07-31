using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.Domain
{
    public class DbSetup
    {
        public string Host { get; set; }
        public string Port { get; set; }
        public string Database { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
    }
}
