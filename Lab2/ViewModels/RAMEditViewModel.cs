using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab2.ViewModels
{
    public class RAMEditViewModel
    {
        [DisplayName("Pavadinimas")]
        [Required]
        public string Pavadinimas { get; set; }

        [DisplayName("Talpa")]
        [Required]

        public string Talpa { get; set; }

        [DisplayName("Atminties Tipas")]
        [Required]

        public string Atmities_Tipas { get; set; }

        [DisplayName("Ram Greitis")]
        [Required]

        public string Ram_Greitis { get; set; }

        [DisplayName("Dydis")]
        [Required]

        public string Dydis { get; set; }

        [DisplayName("Papildomi Atributai")]
        public string Papildomi_Atributai { get; set; }

        [DisplayName("ID")]
        [Required]
        public int id_RAM { get; set; }

        [DisplayName("Motininės plokštės ID")]
        [Required]
        public int Motherboard_connection { get; set; }

        public IList<SelectListItem> MotherBoardList { get; set; }

    }
}