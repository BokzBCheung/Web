using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class T_DIC_User
    {
        public int ID { get; set; }
        public string LoginName { get; set; }
        public string Pwd { get; set; }
        public string Phone { get; set; }
        public DateTime LastLoginTime { get; set; }
        public int VisitCount { get; set; }
        public int Status { get; set; }
        public int? Role {get;set;}

    }
}
