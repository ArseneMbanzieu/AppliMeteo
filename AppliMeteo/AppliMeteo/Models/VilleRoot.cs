using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppliMeteo.Models
{
    public class VilleRoot
    {
        [PrimaryKey, AutoIncrement]
        public int VilleRootId { get; set; }
        public string name { get; set; }
        public string npa { get; set; }
        public string region { get; set; }
        public string country { get; set; }
        public string url { get; set; }
    }
}