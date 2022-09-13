
namespace Konvolucio.MBOM220411.View
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using View;
    using Common;
    using Properties;
    using Konvolucio.Controls;
    using Data;

    public interface IMainForm : IWindowLayoutRestoring 
    {

        event EventHandler Shown;
        event FormClosedEventHandler FormClosed;
        event FormClosingEventHandler FormClosing;
        event EventHandler Disposed;

        string Text { get; set; }
        ToolStripItem[] MenuBar { set; }
        ToolStripItem[] StatusBar { set; }
        bool AlwaysOnTop { get; set; }


        DataGridView DataGrid { get; }

        TreeView NavigationTree { get; }

        //event KeyEventHandler KeyUp;
        //event HelpEventHandler HelpRequested; /*????*/

        //void CursorWait();
        //void CursorDefault();

    }



    public partial class MainForm : Form, IMainForm
    {
        public ToolStripItem[] MenuBar
        {
            set { menuStrip1.Items.AddRange(value); }
        }

        public ToolStripItem[] StatusBar
        {
            set { statusStrip1.Items.AddRange(value); }
        }

        public bool AlwaysOnTop
        {
            get { return this.TopMost; }
            set { this.TopMost = value; }
        }     
        
        public TreeView NavigationTree
        {
            get { return treeViewNavigation; }
        }

        public DataGridView DataGrid { get { return knvDataGridView1; } }

        public MainForm()
        {
            InitializeComponent();
        }





        public void LayoutSave()
        {



        }

        public void LayoutRestore()
        {
            //Location = Settings.Default.MainFormLocation;
            //WindowState = Settings.Default.MainFormWindowState;
            //Size = Settings.Default.MainFormSize;
            //splitContainer1.SplitterDistance = Settings.Default.MainTree_SplitterDistance;
        }


        private void MainView1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Db.Instance.CreateDefaultDb();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
