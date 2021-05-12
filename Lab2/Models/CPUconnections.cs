using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Lab2.Models
{
    public class CPUconnections
    {
        [DisplayName("Motinines plokštės pavadinimas")]
        public string Name { get; set; }


        [DisplayName("Motinės plokštės serijinis numeris")]
        public string ID { get; set; }

        [DisplayName("Cpu kiekis")]
        public int Cpu_Count { get; set; }

        [DisplayName("Aušintuvų kiekis")]
        public int Cooler_Count { get; set; }


    }
}