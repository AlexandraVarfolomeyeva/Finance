using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Model.Entities
{
    public class IncomePeriod
    {
        public  DateTime Date { get; set; }
        public double Sum { get; set; }
        public string  Source { get; set; }
        public int User { get; set; }
    }
}
