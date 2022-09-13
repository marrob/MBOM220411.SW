namespace Konvolucio.MBOM220411
{
    using View;
    using Properties;
    using Events;
    using System.Diagnostics;
    using System.Reflection;
    using System.ComponentModel;
    using Data;
    using System.Threading;
    using System.Windows.Forms;
    using System;

    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            new App();
        }

        public interface IApp
        {

        }

        public class App : IApp
        {
            public static SynchronizationContext SyncContext = null;
            readonly IMainForm _mainForm;

            public App()
            {
                /*** Application Settings Upgrade ***/
                if (Settings.Default.ApplictionSettingsSaveCounter == 0)
                {
                    Settings.Default.Upgrade();
                    Settings.Default.ApplictionSettingsUpgradeCounter++;
                }
                Settings.Default.ApplictionSettingsSaveCounter++;
                Settings.Default.PropertyChanged += new PropertyChangedEventHandler(Settings_PropertyChanged);

                /*** Main Form ***/
                _mainForm = new MainForm();
                _mainForm.Text = AppConstants.SoftwareTitle + " - " + Application.ProductVersion;
                _mainForm.Shown += MainForm_Shown;
                _mainForm.FormClosing += MainForm_FormClosing;
                _mainForm.FormClosed += new FormClosedEventHandler(MainForm_FormClosed);



                /*** Navigation Tree  ***/
                _mainForm.NavigationTree.ContextMenuStrip = new ContextMenuStrip();
                _mainForm.NavigationTree.ContextMenuStrip.Items.Add(new Commands.NewCommand(Db.Instance.Projects));
                _mainForm.NavigationTree.Nodes.Add(new ProjectsTreeNode());

                _mainForm.NavigationTree.Nodes.Add("Warehouse");

                _mainForm.NavigationTree.Nodes.Add("Bill of Materials");



                #region StatusBar
                _mainForm.StatusBar = new ToolStripItem[]
                {
                    new StatusBar.WhoIsStatusBar(),
                    new StatusBar.EmptyStatusBar(),
                    new StatusBar.VersionStatus(),
                    new StatusBar.LogoStatusBar(),
                };
                #endregion


                _mainForm.MenuBar = new ToolStripItem[]
                {
                    /*
                    new Commands.DevicesConnectCommand(this),
                    toolsMenu,
                    diagMenu,
                    new Commands.HelpCommand(),
                    */
                };


                EventAggregator.Instance.Subscribe((Action<TracingChanged>)(e =>
                {

                }));

                /*** Run ***/
                Application.Run((MainForm)_mainForm);

            }

            void MainForm_Shown(object sender, EventArgs e)
            {

                SyncContext = SynchronizationContext.Current;
                _mainForm.LayoutRestore();


                if(!System.IO.File.Exists(Settings.Default.DatabasePath))
                {
                    Db.Instance.CreateDefaultDb();
                }



                _mainForm.DataGrid.DataSource = Db.Instance.Materials.DataSource();

//                var i = Db.Instance.Materials.DataSource().Rows[0];




                /*Kezdő Node Legyen az Adapter node*/
                //EventAggregator.Instance.Publish<TreeViewSelectionChangedAppEvent>(new TreeViewSelectionChangedAppEvent(_startTreeNode));


                EventAggregator.Instance.Publish(new ShowAppEvent());


               

            }

            void MainForm_FormClosing(object sender, FormClosingEventArgs e)
            {
#if TRACE
                Debug.WriteLine(GetType().Namespace + "." + GetType().Name + "." + MethodBase.GetCurrentMethod().Name + "()");
#endif
            }

            void MainForm_FormClosed(object sender, FormClosedEventArgs e)
            {
#if TRACE
                Debug.WriteLine(GetType().Namespace + "." + GetType().Name + "." + MethodBase.GetCurrentMethod().Name + "()");
#endif
                _mainForm.LayoutSave();
                Settings.Default.Save();
                EventAggregator.Instance.Dispose();
            }

            void Settings_PropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                Debug.WriteLine(GetType().Namespace + "." + GetType().Name + "." + MethodBase.GetCurrentMethod().Name + "(): " + e.PropertyName + ", NewValue: " + Settings.Default[e.PropertyName]);


            }

        }

    }

}