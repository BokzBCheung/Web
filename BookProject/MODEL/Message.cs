using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class Message
    {
        public string statusCode { get; set; }
        public string message { get; set; }
        public string navTabId { get; set; }
        public string dialogId { get; set; }
        public string rel { get; set; }
        public string callbackType { get; set; }
        public string forwardUrl { get; set; }
    }
}
