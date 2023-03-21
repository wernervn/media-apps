using static WVN.IO.Helpers.IOHelper;

namespace MovieCollection.Common.Winforms;

public static class WinFormHelper
{
    #region Load treeview

    public static int LoadFoldersWithoutInfo(TreeView tvw, string path, List<string> existing)
    {
        tvw.Nodes.Clear();

        TreeNode root = tvw.Nodes.Add(path, path, Constants.FOLDER_KEY, Constants.FOLDER_KEY);
        LoadFoldersWithoutInfo(tvw, root, path, existing);
        root.Expand();
        return root.Nodes.Count;
    }

    public static void LoadFoldersWithoutInfo(TreeView tvw, TreeNode root, string path, List<string> existing)
    {
        try
        {
            tvw.BeginUpdate();

            //check if the current node has child nodes (subfolders)
            //if it has, then check for new folders, else add subfolder (if any)

            var folders = new List<string>(Directory.EnumerateDirectories(path));
            if (root.Nodes.Count == 0)
            {
                foreach (var folder in folders)
                {
                    if (!Helpers.FolderContainsInfo(folder))
                    {
                        string folderName = GetFolderName(folder);
                        string imageKey = existing.Contains(folder) ? Constants.FOLDER_INFO_EXIST : Constants.FOLDER_KEY;
                        TreeNode node = root.Nodes.Add(folder, folderName, imageKey, imageKey);
                        //node.Tag = folder;
                    }
                }
            }
            else
            {

            }
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            tvw.EndUpdate();
        }
    }

    #endregion

}
