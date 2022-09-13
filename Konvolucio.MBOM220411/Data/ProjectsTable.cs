

namespace Konvolucio.MBOM220411.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Properties;
    using System.Data.SQLite;
    using System.Data;
    using NUnit.Framework;

    public class ProjectsTable : ITableOperations
    {
        readonly DbParameters Parameters;
        SQLiteConnection Conn { get { return Parameters.Connection; } }

        public ProjectsTable(DbParameters parameters)
        {
            Parameters = parameters;
        }

        public void New(string name)
        {

            Conn.Open();
            SQLiteCommand cmd = new SQLiteCommand("SELECT id FROM projects ORDER BY id DESC LIMIT 1", Conn);
            int lastId = Convert.ToInt32(cmd.ExecuteScalar());
            new SQLiteCommand($"INSERT INTO projects (id, name) VALUES ( { lastId + 1 }, '{ name }')", Conn).ExecuteNonQuery();
            Conn.Close();
        }

        public List<string> Get()
        {
            List<string> retval = new List<string>();
            Conn.Open();
            try
            {
                var command = new SQLiteCommand("SELECT name FROM projects", Parameters.Connection);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    retval.Add(reader.GetString(0));
                }
            }
            finally
            {
                Conn.Close();
            }
            return retval;
        }


        public DataTable DataSource()
        {

            DataTable dt = new DataTable();

            return dt;
        }

        public void CreateDefault()
        {
            Conn.Open();

            new SQLiteCommand("CREATE TABLE projects (\"id\" INTEGER NOT NULL, name VARCHAR(20), PRIMARY KEY (\"id\"))", Conn).ExecuteNonQuery();
            new SQLiteCommand("INSERT INTO projects (id, name) VALUES (1, 'MPMT220302')", Conn).ExecuteNonQuery();
            new SQLiteCommand("INSERT INTO projects (id, name) VALUES (2, 'MLGC210815')", Conn).ExecuteNonQuery();
            new SQLiteCommand("INSERT INTO projects (id, name) VALUES (3, 'MMOT211011')", Conn).ExecuteNonQuery();

            Conn.Close();
        }
    }





}

