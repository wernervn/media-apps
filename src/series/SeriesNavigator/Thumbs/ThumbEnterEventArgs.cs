using System;

namespace SeriesNavigator.Thumbs
{
    public class ThumbEnterEventArgs : EventArgs
    {
        public ThumbEnterEventArgs(int index, string itemName, string description, SeriesView currentView, string path)
        {
            Index = index;
            ItemName = itemName;
            Description = description;
            CurrentView = currentView;
            Path = path;
        }

        public int Index { get; }
        public string ItemName { get; }
        public string Description { get; }
        public SeriesView CurrentView { get; }
        public string Path { get; }
    }
}
