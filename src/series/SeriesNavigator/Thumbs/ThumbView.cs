namespace SeriesNavigator.Thumbs;

public partial class ThumbView : UserControl
{
    public event EventHandler<ThumbClickEventArgs> ThumbClick;
    public event EventHandler<ThumbEnterEventArgs> ThumbEnter;

    private ThumbImage _thumb;
    private bool _isSelected;

    public ThumbView()
        => InitializeComponent();

    public ThumbView(ThumbImage thumb)
        : this()
        => ThumbImage = thumb;

    public ThumbImage ThumbImage
    {
        get => _thumb;
        set
        {
            _thumb = value;
            PIC.Tag = value;
            PIC.Image = value.Image;
            TIPS.SetToolTip(PIC, Path.GetFileName(((ThumbImage)PIC.Tag).ItemPath));
            LBL.Text = value.Name;
            SizeThumb();
            if (IsWatched())
            {
                picViewed.Image = ThumbsHelper.WatchedImage;
            }
            else
            {
                picViewed.Visible = false;
            }
            ctxSetWatched.Visible = _thumb.CurrentView == SeriesView.Episodes;
        }
    }

    protected virtual void OnThumbClick(ThumbClickEventArgs e)
    {
        ThumbClick?.Invoke(this, e);
    }

    private void PIC_Click(object sender, EventArgs e)
    {
        OnThumbClick(new ThumbClickEventArgs(_thumb.Index, _thumb.Name, _thumb.Description));
    }

    private void ThumbView_Load(object sender, EventArgs e)
    {
        SizeThumb();
    }

    private void SizeThumb()
    {
        if (_thumb.CurrentView != SeriesView.Episodes)
        {
            Width = Constants.THUMB_WIDTH;
            Height = Constants.THUMB_HEIGHT;
        }
        else
        {
            Width = Constants.THUMB_HEIGHT;
            Height = Constants.THUMB_WIDTH;
        }
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        //if (keyData == (Keys.Control | Keys.F))
        //{
        //    DoSomething();   // Implement the Ctrl+F short-cut keystroke
        //    return true;     // This keystroke was handled, don't pass to the control with the focus
        //}
        switch (keyData)
        {
            case Keys.Enter:
                OnThumbEnter(new ThumbEnterEventArgs(_thumb.Index, _thumb.Name, _thumb.Description, _thumb.CurrentView, _thumb.ItemPath));
                return true;
        }
        return base.ProcessCmdKey(ref msg, keyData);
    }

    private void PIC_DoubleClick(object sender, EventArgs e)
    {
        OnThumbEnter(new ThumbEnterEventArgs(_thumb.Index, _thumb.Name, _thumb.Description, _thumb.CurrentView, _thumb.ItemPath));
    }

    protected virtual void OnThumbEnter(ThumbEnterEventArgs e)
    {
        ThumbEnter?.Invoke(this, e);
    }

    private bool IsWatched()
    {
        if (_thumb.CurrentView == SeriesView.Episodes)
        {
            return File.Exists(_thumb.WatchedPath());
        }
        return false;
    }

    private void ctxSetWatched_Click(object sender, EventArgs e)
    {
        if (_thumb.CurrentView == SeriesView.Episodes && File.Exists(_thumb.ItemPath))
        {
            var watched = _thumb.WatchedPath();
            if (!File.Exists(watched))
            {
                using (var w = File.Create(watched)) { }
                picViewed.Image = ThumbsHelper.WatchedImage;
                picViewed.Visible = true;
            }
        }
    }

    public bool IsSelected
    {
        get => _isSelected;
        set
        {
            _isSelected = value;
            StyleSelected();
        }
    }

    public int Index => _thumb.Index;
    public string Description => _thumb.Description;
    public string Title => _thumb.Name;
    public int Row { get; set; }
    public int Column { get; set; }

    private void StyleSelected()
    {
        if (_isSelected)
        {
            BackColor = Styles.SelectedBackColour;
            LBL.ForeColor = Styles.SelectedForeColour;
        }
        else
        {
            BackColor = Color.Black;
            LBL.ForeColor = Color.White;
        }
    }
}
