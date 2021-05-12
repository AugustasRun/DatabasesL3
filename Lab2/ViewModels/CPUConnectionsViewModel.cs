using Lab2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2.ViewModels
{
    public class CPUConnectionsViewModel
    {
        public List<CPUconnections> list { get; set; }

        public int? from { get; set; }
        public int? to { get; set; }

    }
}