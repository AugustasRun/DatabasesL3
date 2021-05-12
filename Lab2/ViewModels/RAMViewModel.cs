using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Lab2.ViewModels
{
    public class RAMViewModel
    {
        [DisplayName("Pavadinimas")]
       
        public string Pavadinimas { get; set; }

        [DisplayName("Talpa")]
        
        public string Talpa { get; set; }

        [DisplayName("Atminties Tipas")]
      
        public string Atmities_Tipas { get; set; }

        [DisplayName("Ram Greitis")]
       
        public string Ram_Greitis { get; set; }

        [DisplayName("Dydis")]
        
        public string Dydis { get; set; }

        [DisplayName("Papildomi Atributai")]
        public string Papildomi_Atributai { get; set; }

        [DisplayName("ID")]
        
        public int id_RAM { get; set; }

        [DisplayName("Motininės plokštės")]
        public string Motherboard_connection { get; set; }
    }
}