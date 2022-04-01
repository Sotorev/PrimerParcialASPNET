using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrimerParcialASPNET2
{
    public partial class Default : System.Web.UI.Page
    {
        List<Student> students = new List<Student>();
        List<Inscription> inscriptions = new List<Inscription>();
        List<DataSummary> dataSummaries = new List<DataSummary>();
        protected void Page_Load(object sender, EventArgs e)
        {
            ReadStudents(Server.MapPath("~/Alumnos.txt"));
            ReadInscriptions(Server.MapPath("~/Inscripciones.txt"));
            if (!IsPostBack)
            {
                DropDownList1.DataValueField = "Name";
                DropDownList1.DataSource = students;
                DropDownList1.DataBind();

            }
            
            //AddStudentNames();
        }
        void AddStudentNames()
        {
            if(DropDownList1.Items.Count == 0)
                foreach(var s in students)
                {
                    DropDownList1.Items.Add(s.name);
                }
            
        }
        void ReadStudents(string file)
        {
            FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            while (sr.Peek() != -1)
            {
                Student student = new Student()
                {
                    id = Convert.ToInt32(sr.ReadLine()),
                    name = sr.ReadLine()
                };
                students.Add(student);
            }
            sr.Close();
            fs.Close();
        }
        void ReadInscriptions(string file)
        {
            FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            while (sr.Peek() != -1)
            {
                Inscription ins = new Inscription()
                {
                    Id = Convert.ToInt32(sr.ReadLine()),
                    Grade = Convert.ToInt32(sr.ReadLine()),
                    Date = Convert.ToDateTime(sr.ReadLine())
                };
                inscriptions.Add(ins);
            }
            sr.Close();
            fs.Close();
        }
        void WriteInscriptions(string file)
        {
            FileStream fs = new FileStream(file, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            foreach(var i in inscriptions)
            {
                sw.WriteLine(i.Id);
                sw.WriteLine(i.Grade);
                sw.WriteLine(i.Date);
            }
            sw.Close();
            fs.Close();
        }
        void WriteSummary(string file)
        {
            foreach (var i in inscriptions)
            {
                DataSummary ds = new DataSummary()
                {
                    Grade = i.Grade,
                    Name = students.Find(s => s.id == i.Id).name
                };
                dataSummaries.Add(ds);
            }

            FileStream fs = new FileStream(file, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            foreach (var i in dataSummaries)
            {
                sw.WriteLine(i.Name);
                sw.WriteLine(i.Grade);
            }
            sw.Close();
            fs.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int id = students.Find(s => s.name.Equals(DropDownList1.Text)).id;
            Inscription ins = new Inscription()
            {
                Id = id,
                Grade = Convert.ToInt32(DropDownList2.Text),
                Date = DateTime.Now
            };
            inscriptions.Add(ins);
            WriteInscriptions(Server.MapPath("~/Inscripciones.txt"));
            WriteSummary(Server.MapPath("~/Resumen.txt"));
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Summary.aspx");
        }
    }
}