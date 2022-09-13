
namespace Konvolucio.MBOM220411.Commands
{
    using System;
    using System.Diagnostics;
    using System.Windows.Forms;
    using Properties;
    using Events;


    class StartStopCommand : ToolStripMenuItem
    {
        public StartStopCommand()
        {
            Text = "A kapcsolódáshoz nyomd meg!";
           // Image = Resources.Play_48x48;
            ShortcutKeys = Keys.F5;
            DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            Enabled = true;
            EventAggregator.Instance.Subscribe((Action<ConnectionChangedAppEvent>)(e =>
            {
                if (e.IsOpen)
                {
                    //Image = Resources.Stop_48x48;
                    Text = "Kapcsolat bontása";
                }
                else
                {
                    //Image = Resources.Play_48x48;
                    Text = "Kapcsolódás";
                }
            }));
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            Debug.WriteLine(this.GetType().Namespace + "." + this.GetType().Name + "." + System.Reflection.MethodBase.GetCurrentMethod().Name + "()");

        }
    }
}
