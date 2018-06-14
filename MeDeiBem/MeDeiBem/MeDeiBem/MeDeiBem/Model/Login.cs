using System;
using System.Collections.Generic;
using System.Text;

namespace MeDeiBem.Model
{
    public class Login
    {
        public string email { get; set; }
        public string senha { get; set; }
        public int sinc_stat { get; set; }
        public string sinc_msg { get; set; }
    }
}
