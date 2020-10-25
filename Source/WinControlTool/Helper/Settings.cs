using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Config.Net;
using WinControlTool.Contracts;

namespace WinControlTool.Helper
{
    public static class Settings
    {
        /// <summary>
        /// A settings manager to read and write the settings in the settings.json of the execution directory.
        /// </summary>
        public static ISettings SettingsManager { get; set; } = new ConfigurationBuilder<ISettings>()
            .UseJsonFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "settings.json"))
            .Build();
    }
}
