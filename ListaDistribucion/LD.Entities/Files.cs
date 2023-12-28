using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LD.Entities
{
    public class Files
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public XElement XML { get; set; }
    }
}
