using SeriesNavigator.Configuration;

namespace SeriesNavigator;

public partial class frmSettings : Form
{
    public AppSettings AppSettings { get; }

    public frmSettings(AppSettings settings)
    {
        InitializeComponent();
        AppSettings = settings;
    }

    private void btnAccept_Click(object sender, EventArgs e)
    {
        AppSettings.AppConfiguration.SeriesFolder = txtSeriesFolder.Text;

        AppSettings.AppConfiguration.SelectedForeColour = lblSelected.ForeColor;
        AppSettings.AppConfiguration.SelectedBackColour = lblSelected.BackColor;

        DialogResult = DialogResult.OK;
    }

    private void frmSettings_Load(object sender, EventArgs e)
    {
        txtSeriesFolder.Text = AppSettings.AppConfiguration.SeriesFolder;
        lblSelected.ForeColor = AppSettings.AppConfiguration.SelectedForeColour;
        lblSelected.BackColor = AppSettings.AppConfiguration.SelectedBackColour;
    }

    private void btnForeColour_Click(object sender, EventArgs e)
        => lblSelected.ForeColor = SelectColour(lblSelected.ForeColor);

    private Color SelectColour(Color current)
    {
        using (var dlg = new ColorDialog())
        {
            dlg.Color = current;
            return dlg.ShowDialog() == DialogResult.OK
                ? dlg.Color
                : current;
        }
    }

    private void btnBackColour_Click(object sender, EventArgs e)
        => lblSelected.BackColor = SelectColour(lblSelected.BackColor);
}
