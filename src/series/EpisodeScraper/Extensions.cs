using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EpisodeScraper
{
    public static class Extensions
    {
        public static bool IsSeriesFolder(this TreeNode node)
        {
            var nodePath = node.Tag?.ToString() ?? string.Empty;
            return Directory.Exists(nodePath) && node.Parent == node.TreeView.Nodes[0];
        }

        public static bool IsSeasonFolder(this TreeNode node)
        {
            var nodePath = node.Tag?.ToString() ?? string.Empty;
            if (Directory.Exists(nodePath))
            {
                var folderName = new DirectoryInfo(nodePath).Name;
                return folderName.StartsWith("Season", StringComparison.InvariantCultureIgnoreCase);
            }
            return false;
        }

        public static void CheckInvoke(this Control control, Action action)
        {
            if (control.Handle == IntPtr.Zero || control.IsDisposed)
            {
                return;
            }
            _ = Task.Factory.StartNew(() =>
            {
                if (control.InvokeRequired)
                {
                    _ = control.Invoke(new Action(() =>
                        // e.g. control.Text = $"{_fanartIndex + 1} of {_fanart.Count}"
                        action.Invoke()));
                }
            });
        }
    }
}
