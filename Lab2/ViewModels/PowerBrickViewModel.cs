using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab2.ViewModels
{
    public class PowerBrickViewModel
    {
        [DisplayName("Pavadinimas")]
        [Required]
        public string Pavadinimas { get; set; }

        [DisplayName("Maksimali galia ")]
        [Required]
        public string Power { get; set; }

        [DisplayName("Energijos effektyvumo reitingas ")]
        [Required]
        public string Efficiency { get; set; }

        [DisplayName("Ausintuvo dydis ")]
        [Required]
        public string Fan_size { get; set; }

        [DisplayName("Jungikliai")]
        [Required]
        public string Swithces { get; set; }

        [DisplayName("id Maitinimo bloko")]
        [Required]
        public int id_Brick { get; set; }

        [DisplayName("Motine plokste")]
        public string Motherboard { get; set; }
    }
}