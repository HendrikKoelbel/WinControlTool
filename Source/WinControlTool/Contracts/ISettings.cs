using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Config.Net;

namespace WinControlTool.Contracts
{
    public interface ISettings
    {
        [Option(Alias = "Alias.SubAlias", DefaultValue = "n/a")]
        string AuthClientId { get; set; }
    }
}
