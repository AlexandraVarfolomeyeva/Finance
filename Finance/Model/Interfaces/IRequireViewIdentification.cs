using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Model.Interfaces
{
    public interface IRequireViewIdentification
    {
        Guid ViewID { get; }
    }
}
