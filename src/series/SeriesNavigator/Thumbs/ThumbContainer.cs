using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WVN.WinForms.Extensions;

namespace SeriesNavigator.Thumbs
{
    public partial class ThumbContainer : UserControl
    {
        public event EventHandler<ThumbClickEventArgs> ThumbClick;
        public event EventHandler<ThumbEnterEventArgs> ThumbEnter;

        private const int SPACE_WIDTH = 25;
        private const int SPACE_HEIGHT = 25;
        private int _leftPos = SPACE_WIDTH;
        private int _topPos = SPACE_HEIGHT;
        private int _selectedIndex = -1;
        private int _lastIndex = -1;
        private int _column;
        private int _row;

        private ThumbView _selectedItem;

        private readonly List<Keys> Alphabet = Enumerable.Range(65, 26).Select(i => (Keys)i).ToList();
        private readonly List<Keys> Numeric = Enumerable.Range(48, 10).Select(i => (Keys)i).ToList();

        private readonly int _clientWidth;

        public ThumbContainer()
        {
            InitializeComponent();
            _clientWidth = Screen.PrimaryScreen.Bounds.Width - SystemInformation.VerticalScrollBarWidth;
        }

        #region Adding and removing thumbs
        public void AddRange(IEnumerable<ThumbImage> thumbs)
        {
            _column = 0;
            _row = 0;
            this.HideDuringAction(() => thumbs.ToList().ForEach(Add));

            if (_lastIndex != -1)
            {
                SetSelectedIndex(_lastIndex);
                _lastIndex = -1;
            }
        }

        private void Add(ThumbImage thumb)
        {
            var tv = new ThumbView(thumb)
            {
                Left = _leftPos,
                Top = _topPos,
                Row = _row,
                Column = _column
            };
            _column++;

            _leftPos += tv.Width + SPACE_WIDTH;
            if (_leftPos + tv.Width + SPACE_WIDTH > Screen.PrimaryScreen.WorkingArea.Size.Width /*_clientWidth*/ + 360)
            {
                //wrap to next line
                _leftPos = SPACE_WIDTH;
                _topPos += tv.Height + SPACE_HEIGHT;
                _column = 0;
                _row++;
            }

            tv.ThumbClick += Thumb_Click;
            tv.ThumbEnter += Thumb_DoubleClick;
            tv.Visible = true;

            Controls.Add(tv);
        }

        public void Clear()
        {
            _leftPos = SPACE_WIDTH;
            _topPos = SPACE_HEIGHT;
            AllThumbs().ForEach(tv =>
            {
                tv.ThumbClick -= Thumb_Click;
                tv.ThumbEnter -= Thumb_DoubleClick;
            });
            Controls.Clear();
        }
        #endregion

        #region Thumb selection
        private void Thumb_Click(object sender, ThumbClickEventArgs e)
        {
            OnThumbClick(e);
            SetSelectedThumb(e.Index);
        }

        private ThumbImage ThumbImageAtIndex(int index)
            => ThumbViewAtIndex(index)?.ThumbImage;

        private ThumbView ThumbViewAtIndex(int index)
            => AllThumbs().Find(ctrl => ctrl.Index.Equals(index));

        private List<ThumbView> AllThumbs()
            => Controls.All<ThumbView>().ToList();

        public void SetSelectedIndex(int index)
        {
            var selected = ThumbImageAtIndex(index);
            if (selected is not null)
            {
                SelectThumbImage(selected);
            }
        }

        /// <summary>
        /// Event that is raised when a thumb is clicked (selected)
        /// </summary>
        /// <param name="e">ThumbClickEventArgs</param>
        protected virtual void OnThumbClick(ThumbClickEventArgs e)
        {
            _selectedIndex = e.Index;
            ThumbClick?.Invoke(this, e);
        }

        private void Thumb_DoubleClick(object sender, ThumbEnterEventArgs e) => OnThumbEnter(e);

        /// <summary>
        /// Event that is raised when a thumb is double-clicked (entered)
        /// </summary>
        /// <param name="e">ThumbEnterEventArgs</param>
        protected virtual void OnThumbEnter(ThumbEnterEventArgs e)
        {
            _lastIndex = e.Index;
            _selectedIndex = e.Index;
            ThumbEnter?.Invoke(this, e);
        }

        private void SetSelectedThumb(int index)
        {
            AllThumbs().ForEach(thumb => thumb.IsSelected = false);
            var selected = ThumbViewAtIndex(index);
            if (selected is not null)
            {
                selected.IsSelected = true;
                ActiveControl = selected;
                _selectedItem = selected;
            }
        }

        #endregion

        #region Key navigation
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Left:
                    Previous();
                    return true;
                case Keys.PageUp:
                case Keys.Up:
                    PageUp();
                    return true;
                case Keys.Right:
                    Next();
                    return true;
                case Keys.PageDown:
                case Keys.Down:
                    PageDown();
                    return true;
                case Keys.Home:
                    First();
                    return true;
                case Keys.End:
                    Last();
                    return true;
                case var alpha when Alphabet.Contains(alpha):
                    StartsWith(alpha);
                    return true;
                case var numeric when Numeric.Contains(numeric):
                    StartsWith(numeric);
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void StartsWith(Keys keyData)
        {
            var start = Encoding.ASCII.GetString(new byte[]{ (byte)keyData });
            SelectThumbImage(ctrl => ctrl.Title.StartsWith(start, StringComparison.OrdinalIgnoreCase));
        }

        private void SelectThumbImage(ThumbImage selected)
        {
            SetSelectedThumb(selected.Index);
            var ea = new ThumbClickEventArgs(selected.Index, selected.Name, selected.Description);
            OnThumbClick(ea);
        }

        private void SelectThumbImage(Predicate<ThumbView> predicate)
        {
            var selected = AllThumbs().Find(predicate)?.ThumbImage;
            if (selected is not null)
            {
                SelectThumbImage(selected);
            }
        }

        private void Last()
        {
            if (Controls.Count > 0)
            {
                SetSelectedIndex(Controls.Count - 1);
            }
        }

        private void First()
        {
            if (Controls.Count > 0)
            {
                SetSelectedIndex(0);
            }
        }

        private void PageDown()
        {
            if (_selectedItem is null)
            {
                if (Controls.Count == 1)
                {
                    SetSelectedIndex(0);
                }
                return;
            }

            var newRow = _selectedItem.Row + 1;
            SelectThumbImage(ctrl => ctrl.Row == newRow && ctrl.Column == _selectedItem.Column);
        }

        private void PageUp()
        {
            if (_selectedItem is null)
            {
                if (Controls.Count == 1)
                {
                    SetSelectedIndex(0);
                }
                return;
            }

            var newRow = Math.Max(_selectedItem.Row - 1, 0);
            SelectThumbImage(ctrl => ctrl.Row == newRow && ctrl.Column == _selectedItem.Column);
        }

        private void Previous()
        {
            if (_selectedIndex < 1)
            {
                if (Controls.Count == 1)
                {
                    SetSelectedIndex(0);
                }
                return;
            }

            var newIndex = _selectedIndex - 1;
            SetSelectedIndex(newIndex);
        }

        private void Next()
        {
            var newIndex = _selectedIndex + 1;
            if (newIndex <= Controls.Count - 1)
            {
                SetSelectedIndex(newIndex);
            }
            else if (Controls.Count == 1)
            {
                SetSelectedIndex(0);
            }
        }

        #endregion
    }
}
