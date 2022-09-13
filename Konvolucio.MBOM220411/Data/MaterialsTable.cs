

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

    public class MaterialsTable
    {
        readonly DbParameters Parameters;
        SQLiteConnection Conn { get { return Parameters.Connection; } }

        public MaterialsTable(DbParameters parameters)
        {
            Parameters = parameters;
        }

                
        public void CreateDefault()
        {
            Conn.Open();
            new SQLiteCommand("CREATE TABLE materials (id INTEGER NOT NULL, project VARCHAR(256), comment VARCHAR(256), manufacturer VARCHAR(256), manufacturerpartno VARCHAR(256), supplier VARCHAR(256), PRIMARY KEY (\"id\"))", Conn).ExecuteNonQuery();
            new SQLiteCommand("INSERT INTO materials (id, project, comment, manufacturer, manufacturerpartno, supplier) VALUES (1, 'MPMT220302', '1nF', 'WALSIN', '0805N102J500CT', 'LOM-82-11-37;'  )", Conn).ExecuteNonQuery();
            new SQLiteCommand("INSERT INTO materials (id, project, comment, manufacturer, manufacturerpartno, supplier) VALUES (2, 'MPMT220302', '22pF', 'SAMSUNG', 'CL21C220JBANNNC', 'LOM-82-09-18;'  )", Conn).ExecuteNonQuery();
            new SQLiteCommand("INSERT INTO materials (id, project, comment, manufacturer, manufacturerpartno, supplier) VALUES (3, 'MPMT220302', '100nF', 'YAGEO', 'CC0805KRX7R9BB104', 'FAR-3019949;LOM-82-01-25'  )", Conn).ExecuteNonQuery();
            Conn.Close();
        }


        public DataTable DataSource()
        {

            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn("Project"));
            dt.Columns.Add(new DataColumn("Comment"));
            dt.Columns.Add(new DataColumn("Manufacturer"));

            List<string> retval = new List<string>();
            Conn.Open();
            try
            {
                var command = new SQLiteCommand("SELECT project, comment, manufacturer FROM materials", Parameters.Connection);
                var reader = command.ExecuteReader();
                int row = 0;
                while (reader.Read())
                {
                    dt.Rows.Add();
                    DataRow dr = dt.Rows[row++];
                    for (int coulmn = 0; coulmn < dt.Columns.Count; coulmn++)
                    {
                        var temp =  reader.GetString(coulmn);
                        dr[coulmn] = temp;
                    }
                    /*
                    for (int coulmn = 0; coulmn < dt.Columns.Count; coulmn++)
                        dt.Columns[coulmn].ReadOnly = true;
                    */
                }
            }
            finally
            {
                Conn.Close();
            }


            return dt;
        }

        public DataTable Get() 
        {

            return new DataTable();
        }
    }



}
