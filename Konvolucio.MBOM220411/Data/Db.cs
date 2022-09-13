
namespace Konvolucio.MBOM220411.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Properties;
    using System.Data.SQLite;


    public class DbParameters 
    {
        public SQLiteConnection Connection { get; set; }

        public DbParameters()
        {
            Connection = new SQLiteConnection("Data Source=" + Settings.Default.DatabasePath + ";Version=3;");
        }
    }

    internal class Db
    {
        public static Db Instance { get; } = new Db();

        readonly DbParameters Parameters;
        public ProjectsTable Projects;
        public MaterialsTable Materials;

        public Db()
        {
            Parameters = new DbParameters();
            Projects = new ProjectsTable(Parameters);
            Materials = new MaterialsTable(Parameters);
        }

        public void CreateDefaultDb()
        {
            SQLiteConnection.CreateFile(Settings.Default.DatabasePath);
            Projects.CreateDefault();
            Materials.CreateDefault();
        }
    }
}
