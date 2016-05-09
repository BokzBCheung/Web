using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class T_DIC_Book
    {
        public int ID { get; set; }
        public string ISBN { get; set; }
        public string Name { get; set; }
        public string Publisher { get; set; }
        public decimal Pricing { get; set; }
        public DateTime PublishYear { get; set; }
        public string Author { get; set; }
        public string Notes { get; set; }
    }
}
