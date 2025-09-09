using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiLink.Models
{
    internal class Links
    {
        public string? Name { get; set; }
        public string? Url { get; set; }
        public Tags? Tags { get; set; } = new Tags();
    }
}
