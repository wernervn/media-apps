using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesNavigator.Configuration
{
    public class AppConfiguration
    {
        public string SeriesFolder { get; set; } = string.Empty;
        public System.Drawing.Color SelectedForeColour { get; set; } = System.Drawing.Color.White;
        public System.Drawing.Color SelectedBackColour { get; set; } = System.Drawing.Color.Blue;
    }
}
