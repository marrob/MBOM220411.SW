namespace Konvolucio.MBOM220411.StatusBar
{
    using System;
    using System.Windows.Forms;

    class LogLinesStatusBar : ToolStripStatusLabel
    { 
        public LogLinesStatusBar()
        {
            BorderSides = ToolStripStatusLabelBorderSides.Left;
            BorderStyle = Border3DStyle.Etched;
            Size = new System.Drawing.Size(58, 19);
            Text = AppConstants.ValueNotAvailable2;

        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
        }
    }
}
