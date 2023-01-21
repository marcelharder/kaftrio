using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.FileIO;

namespace api.DAL.code
{
    public class CSVProducer
    {
        private DataTable _dt;
        private readonly IWebHostEnvironment _env;
        public CSVProducer(IWebHostEnvironment env)
        {
            _env = env;
            _dt = new DataTable();

        }

        public void rehydrateByte(byte[] b)
        {
            var values = new List<string>();
            Stream stream = new MemoryStream(b);

            using (TextFieldParser parser = new TextFieldParser(stream))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                int rowCount = 1;
                while (!parser.EndOfData)
                {
                    string[] row = parser.ReadFields();
                    if (rowCount == 1)
                    {
                        //foreach (string h in row) { this._dt.Columns.Add(h, typeof(string)); }
                        _dt.Columns.Add("Pint", typeof(double));
                        _dt.Columns.Add("Part", typeof(double));
                        _dt.Columns.Add("SvO2", typeof(double));
                        _dt.Columns.Add("Temp", typeof(double));
                    }
                    if (rowCount > 1)
                    {
                        if (row[2] != "") { }// filter out all the codes
                        else                 // there is no errorcode en dus 54 fields
                        {
                            var dr = _dt.NewRow();
                            dr["Pint"] = row[8];
                            dr["Part"] = row[13];
                            dr["SvO2"] = row[32];
                            dr["Temp"] = row[41];
                            _dt.Rows.Add(dr);
                        }
                    }
                    rowCount++;
                }
            }
        }

        public List<double> getPint()
        {
            var t = 0.0;
            var help = new List<double>();
            foreach (DataRow row in _dt.Rows)
            {
                t = (double)row.ItemArray[0];
                help.Add(t);
            }
            return help;
        }
        public List<double> getPart()
        {
            var t = 0.0;
            var help = new List<double>();
            foreach (DataRow row in _dt.Rows)
            {
                t = (double)row.ItemArray[1];
                help.Add(t);
            }
            return help;
        }
        public List<double> getSvO2()
        {
            var t = 0.0;
            var help = new List<double>();
            foreach (DataRow row in _dt.Rows)
            {
                t = (double)row.ItemArray[2];
                help.Add(t);
            }
            return help;
        }
        public List<double> getTemp()
        {
            var t = 0.0;
            var help = new List<double>();
            foreach (DataRow row in _dt.Rows)
            {
                t = (double)row.ItemArray[3];
                help.Add(t);
            }
            return help;
        }



    }

}