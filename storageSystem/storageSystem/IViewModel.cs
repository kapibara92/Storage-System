using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace storageSystem
{
    public interface IViewModel
    {
        IEnumerable<string> Names { get; }
    }
}
