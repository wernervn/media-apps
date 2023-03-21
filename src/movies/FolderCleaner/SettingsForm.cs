using FolderCleaner.Configuration;
using WVN.Extensions;

namespace FolderCleaner;

public partial class SettingsForm : Form
{
    private AppConfiguration _settings;

    public SettingsForm()
    {
        InitializeComponent();
    }

    private void frmSettings_Load(object sender, EventArgs e)
    {
        if (_settings.IgnoreList.Count > 0)
        {
            txtIgnoreFiles.Text = string.Join(Environment.NewLine, _settings.IgnoreList);
        }
    }

    internal void Show(AppConfiguration settings)
    {
        _settings = settings;
        ShowDialog();
    }

    private void btnUpdate_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(txtIgnoreFiles.Text))
        {
            _settings.IgnoreList = txtIgnoreFiles.Text.SplitOnCrLf().ToList();
        }
        else
        {
            _settings.IgnoreList = new();
        }
        DialogResult = DialogResult.OK;
    }
}
