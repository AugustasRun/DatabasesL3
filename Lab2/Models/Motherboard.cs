using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab2.Models
{
    public class Motherboard
    {
        [DisplayName("Pavadinimas")]
        [Required]
        public string Pavadinimas { get; set; }

        [DisplayName("Dydis")]
        [Required]
        public string Dydis { get; set; }

        [DisplayName("Cpu tipas")]
        [Required]
        public string Cpu_Tipas { get; set; }

        [DisplayName("USB įvestys")]
        [Required]
        public int USB_ivestys { get; set; }

        [DisplayName("Ram Lizdai")]
        [Required]
        public int Ram_Lizdai { get; set; }

        [DisplayName("Pcie Lizdai")]
        [Required]
        public int Pcie_Lizdai { get; set; }

        [DisplayName("M2 NVEM Lizdai")]
        public int? M2_NVEM_Lizdai { get; set; }

        [DisplayName("ID")]
        [Required]
        public int? id_Motinine_Plokste { get; set; }

    }
}