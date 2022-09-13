

namespace Konvolucio.MBOM220411.StatusBar
{
    using System;
    using System.Windows.Forms;
    using Properties;

    class UpTimeCounterStatusBar : ToolStripStatusLabel
    { 
        public UpTimeCounterStatusBar()
        {
            BorderSides = ToolStripStatusLabelBorderSides.Left;
            BorderStyle = Border3DStyle.Etched;
            Size = new System.Drawing.Size(58, 19);
            Text = "UpTime Counter: " + AppConstants.ValueNotAvailable2;
 
        }
    }
}
