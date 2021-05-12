using Lab2.Models;
using Lab2.Repository;
using Lab2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab2.Controllers
{
    public class CPUcountController : Controller
    {
        CPUconnectionRepository CPUconnectionRepository = new CPUconnectionRepository();

        public ActionResult Index(int? from, int? to)
        {
            CPUConnectionsViewModel cPUConnectionsViewModel = new CPUConnectionsViewModel();

            cPUConnectionsViewModel.from = from == null ? null : from;
            cPUConnectionsViewModel.to = to == null ? null : to;

            cPUConnectionsViewModel.list = CPUconnectionRepository.getAllCPUConnections(cPUConnectionsViewModel.from, cPUConnectionsViewModel.to);


            return View(cPUConnectionsViewModel);
        }
    }
}