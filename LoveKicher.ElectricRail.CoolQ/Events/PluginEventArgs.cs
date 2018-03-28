using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoveKicher.ElectricRail.CoolQ.Events
{
    public class PluginEventArgs:EventArgs 
    {
        public virtual int ReturnValue { get; set; }
    }
}
