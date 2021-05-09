﻿using System.Collections.Generic;

namespace MediaApps.Series.Core
{
    public static class Constants
    {
        public static readonly string FOLDER_KEY = "Folder2";
        public static readonly string SERIES_SEASON_THUMB = "folder.jpg";
        public static readonly string IMAGE_EXTENSION = ".jpg";
        public static readonly string CONTENT_EXTENSION = ".xml";
        public static readonly string SEASON_VIEW = "View.xml";
        public static readonly string SERIES_VIEW = "View.xml";
        public static readonly string SERIES_XML = "series.xml";

        public static List<string> IMAGE_VALUES = new List<string> { "*.jpg", "*.jpeg" }; //{ ".jpg", ".jpeg", ".bmp", ".ico", ".png", ".gif" };
        public static List<string> VIDEO_EXTENSIONS = new List<string> { "*.avi", "*.mkv", "*.mp4" };
        public static List<string> SUBTITLES = new List<string> { "*.srt" };

        public static readonly string DATE_FMT = "yyyy-MM-dd";
    }
}
