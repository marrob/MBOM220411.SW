
namespace Konvolucio.MBOM220411.Commands
{
    using System;
    using System.Diagnostics;
    using System.Windows.Forms;
    using Properties;
    using Events;

    class SelectDeviceCommand : ToolStripComboBox
    {
        public SelectDeviceCommand()
        {
            Text = "Válaszd ki a megfelelő eszköz típust a listából...";
            Enabled = true;
            DropDownStyle = ComboBoxStyle.DropDownList;

            DropDownClosed += (o, e) =>
            {

            };

            EventAggregator.Instance.Subscribe((Action<ShowAppEvent>)(e =>
            {

            }));

            EventAggregator.Instance.Subscribe((Action<ConnectionChangedAppEvent>)(e =>
            {
                Enabled = !e.IsOpen;       
            }));
        }
    }
}
