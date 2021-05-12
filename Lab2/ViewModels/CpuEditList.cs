using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2.ViewModels
{
    public class CpuEditList
    {

        public CpuEditViewModel cpu { get; set; }

        public List<CoolerEditViewModel> coolers { get; set; }
    }
}