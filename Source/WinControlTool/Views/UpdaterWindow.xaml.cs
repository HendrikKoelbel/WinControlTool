using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Squirrel;

namespace WinControlTool.Views
{
    /// <summary>
    /// Interaktionslogik für UpdaterWindow.xaml
    /// </summary>
    public partial class UpdaterWindow : Window
    {
        public UpdaterWindow()
        {
            InitializeComponent();
        }
        public bool CanClose { get; set; } = false;
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = !CanClose;
        }
        public void SetText(string text)
        {
            TextBlockUpdateInfo.Text = text;
        }

        public void UpdateProgress(int i)
        {
            Application.Current.Dispatcher.Invoke(() => this.ProgressBarUpdate.Value = i);
        }

        private async void UpdaterWindow_OnContentRendered(object sender, EventArgs e)
        {
            using var updateManager = UpdateManager.GitHubUpdateManager("https://github.com/HendrikKoelbel/WinControlTool");
            await updateManager.Result.UpdateApp(this.UpdateProgress);
        }
    }
}
