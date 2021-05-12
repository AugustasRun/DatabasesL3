using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab2.ViewModels
{
    public class CoolerEditViewModel
    {
        [DisplayName("Pavadinimas")]
        [Required]
        public string Pavadinimas { get; set; }

        [DisplayName("Paskirtis")]
        [Required]
        public string Paskirtis { get; set; }

        [DisplayName("Gamintojas")]
        [Required]
        public string Gamintojas { get; set; }

        [DisplayName("Ventiliatoriaus Dydis")]
        [Required]
        public string Fan_size { get; set; }

        [DisplayName("Max Apsukos")]
        [Required]
        public string Max_RPM { get; set; }

        [DisplayName("ID")]
        [Required]
        public int id_Cooler { get; set; }

        [DisplayName("CPU")]
        public int idCPU { get; set; }
    }
}