using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeF.Config
{
    public interface IConfigTopic
    {
        IConfigTopic this[int index] { get; set; }
    }
}
