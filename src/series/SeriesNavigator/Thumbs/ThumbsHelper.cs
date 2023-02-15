namespace SeriesNavigator.Thumbs;

public static class ThumbsHelper
{
    private static Image _watchedImage;

    public static Image WatchedImage
        => _watchedImage ??= GetResourceImage("Eyes.png");

    private static Image _emptyImage;

    public static Image EmptyImage
        => _emptyImage ??= GetResourceImage("Empty.png");

    private static Image GetResourceImage(string resourceName)
        => MediaApps.Series.Core.ResourceHelper.GetImageResource($"SeriesNavigator.Resources.{resourceName}");
}
