using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2.ViewModels
{
    public class PowerBrickListAddView
    {
        public PowerBrickEditViewModel powerBrick { get; set; }
        public List<PowerBrickEditViewModel> list { get; set; }
    }
}