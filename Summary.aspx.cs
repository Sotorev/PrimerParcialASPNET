using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrimerParcialASPNET2
{
    public partial class Summary : System.Web.UI.Page
    {
        List<DataSummary> dataSummaries = new List<DataSummary>();
        protected void Page_Load(object sender, EventArgs e)
        {
            ReadSummary(Server.MapPath("~/Resumen.txt"));
            LoadDataSource(dataSummaries);
        }
        void LoadDataSource<T>(List<T> dataSource)
        {
            GridView1.DataSource = dataSource;
            GridView1.DataBind();
        }
        void ReadSummary(string file)
        {
            FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            while (sr.Peek() != -1)
            {
                DataSummary ds = new DataSummary()
                {
                    Name = sr.ReadLine(),
                    Grade = Convert.ToInt32(sr.ReadLine())
                };
                dataSummaries.Add(ds);
            }
            sr.Close();
            fs.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            LoadDataSource(dataSummaries.OrderBy(ds => ds.Grade).ToList());
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string message = "Total de alumnos: " + dataSummaries.Count.ToString();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
        }
    }
}