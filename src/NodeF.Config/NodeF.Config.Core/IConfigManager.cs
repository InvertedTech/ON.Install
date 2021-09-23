using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeF.Config
{
    public interface IConfigManager
    {
        void AddTopic();
        Task LoadAll();
        Task LoadOne();
        Task SaveAll();
        Task SaveOne();
    }
}
