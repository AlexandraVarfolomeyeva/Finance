using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Model.Entities
{
    public class ExpensesPeriod
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public float Sum { get; set; }
        public string Category { get; set; }
        public string Necessity { get; set; }
    }
}
