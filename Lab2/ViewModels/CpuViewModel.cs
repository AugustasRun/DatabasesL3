using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab2.ViewModels
{
    public class CpuViewModel
    {
        [DisplayName("Pavadinimas")]
        [Required]
        public string Pavadinimas { get; set; }

        [DisplayName("Daznis")]
        [Required]
        public string Daznis { get; set; }

        [DisplayName("Vatų suvartojimas")]
        [Required]
        public string Vatai { get; set; }

        [DisplayName("Pagreitintas Daznis")]
        [Required]
        public string Boost { get; set; }

        [DisplayName("Gamintojas")]
        [Required]
        public string Manufacturer { get; set; }

        [DisplayName("ID")]
        [Required]
        public int id_CPU { get; set; }

        [DisplayName("Motine plokste")]
        public string idMotherboard { get; set; }

    }
}