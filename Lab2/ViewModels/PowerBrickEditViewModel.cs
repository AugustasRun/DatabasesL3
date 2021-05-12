using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab2.ViewModels
{
    public class PowerBrickEditViewModel
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
        public int id_Power { get; set; }

        [DisplayName("Motine plokste")]
        public int Motherboard { get; set; }

        public IList<SelectListItem> MotherBoardList { get; set; }

    }
}