
namespace Konvolucio.MBOM220411.Commands
{
    using System;
    using System.Diagnostics;
    using System.Windows.Forms;
    using Properties;
    using Events;
    using Data;
    using View;

    class NewCommand : ToolStripMenuItem
    {
        ITableOperations table;
        public NewCommand(ITableOperations table)
        {

            this.table = table;

            Text = "New";
           // Image = Resources.Play_48x48;
            ShortcutKeys = Keys.F5;
            DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            Enabled = true;
            EventAggregator.Instance.Subscribe((Action<ConnectionChangedAppEvent>)(e =>
            {

            }));
        }

        protected override void OnClick(EventArgs e)
        {

            if (table is ProjectsTable)
            {
              var form = new NewProjectForm();
                 form.ShowDialog();
                Db.Instance.Projects.New(form.NewName);
            }
       

            base.OnClick(e);
            


                
        }
    }
}
