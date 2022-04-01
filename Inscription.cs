using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrimerParcialASPNET2
{
    public class Inscription
    {
        public int Id { get; set; }
        public int Grade { get; set; }
        public DateTime date { get; set; }
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
    }
}