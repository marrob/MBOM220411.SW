
namespace Konvolucio.MBOM220411.Commands
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms; /*ToolStripMenuItem*/
    using Konvolucio.Controls;
    using Properties;


    class ClearReachTextBoxCommand : ToolStripMenuItem
    {
        KnvRichTextBox _KnvRtb;

        public ClearReachTextBoxCommand(KnvRichTextBox knvRtb)
        {
            _KnvRtb = knvRtb;
            ShortcutKeys = Keys.None;
            //Image = Resources.Delete48x48 ;
            Text = "Törlés";

        }

        protected override void OnClick(EventArgs e)
        {
            _KnvRtb.Clear();
        }
    }
}
