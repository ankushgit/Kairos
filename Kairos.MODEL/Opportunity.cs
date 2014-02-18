using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kairos.MODEL
{
    public class Opportunity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Sector { get; set; }
        public string Client { get; set; }
        public string PrimaryContact { get; set; }
        public string Telno { get; set; }
    }
}
